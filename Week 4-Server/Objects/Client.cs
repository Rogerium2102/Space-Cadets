using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Week_2.Managers;
using Week_4_Server.Managers;

namespace Week_4_Server.Objects
{
    public class Client
    {
        private TcpClient _TcpClient;
        private Thread _Run;
        private bool _Online;
        private TaskManager _TaskManager;
        private NetworkManager _NetMan;
        private string CurrentPage;
        private string LatestMessage;

        public Client(TcpClient Client, NetworkManager NetworkMan)
        {
            _TcpClient = Client;
            _Online = true;
            _TaskManager = new TaskManager();
            _NetMan = NetworkMan;
            _Run = new Thread(new ThreadStart(HandleClientAsync));
            _Run.Start();
        }

        public bool isClientAlive() { return _Online; }
        public bool isDataAvaliable()
        {
            return _TcpClient.GetStream().DataAvailable;
        }
        private async void HandleClientAsync()
        {
            string Response;
            string[] Command;
            bool Error;
            while (_Online)
            {
                Error = false;
                await _TaskManager.WaitUntil(isDataAvaliable);
                Response=_NetMan.Receive(_TcpClient);
                Command = Response.Split('#');
                if (isValidCode(Command))
                {
                    switch (Command[0]) {
                        case "SEND":
                            if (LatestMessage == "")
                            {
                                LatestMessage = Command[1];
                            }
                            else
                            {
                                _NetMan.Send(_TcpClient, "FAIL");
                                Error = true;
                            }
                            break;
                        case "CHNG":
                            CurrentPage = Command[1];
                            break;
                        case "DISC":
                            _NetMan.Send(_TcpClient,"COMP");
                            _TcpClient.Close();
                            _Online = false;
                            break;

                    }
                    if (!Error)
                    {
                        _NetMan.Send(_TcpClient, "COMP");
                    }
                }
            }
        }

        public bool CheckMessage()
        {
            if (LatestMessage == "")
            {
                return false;
            }
            return true;
        }
        public string GetMessage()
        {
            string TempStore = LatestMessage;
            LatestMessage = "";
            return TempStore;
        }
        private void SetCurrentPage(string NewPage)
        {
            CurrentPage = NewPage;
            _NetMan.Send(_TcpClient, "Navi#" + CurrentPage);
        }

        private bool isValidCode(string[] Command)
        {
            if (Command.Length < 2)
            {
                return false;
            }
            else if (Command[0] == "DISC")
            {
                return true;
            }
            switch (Command[0].ToUpper())
            {
                case "SEND":
                    return true;
                case "CHNG":
                    if (Command[1][0] != '/')
                    {
                        return false;
                    }
                    if (!Command[1].Contains("wiki"))
                    {
                        return false;
                    }
                    return true;
                default:
                    return false;
            }
        }
    }
}
