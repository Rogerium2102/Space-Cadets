using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Week_2.Managers;
using System.IO;

namespace Week_2
{
    internal class Program
    {
        static string TargetProgram = "Program2.txt";
        static string[] _instructionSet;
        static List<Objects.Program> _programList;
        static NetworkManager NetMan;
        static List<string> CodeLines = new List<string>();
        static Random RNG = new Random();
        static string[] URLs = new string[] {"" };
        static void Main(string[] args)
        {
            _programList = new List<Objects.Program>();
            NetMan = new NetworkManager("127.0.0.1",13000);
            Run();
        }

        static void Run()
        {
            while (NetMan.isOnline())
            {
                string Response = NetMan.CheckIncomingTransmissionAndConnectClient();
                string ToSend = "DONE ";
                if (Response != null)
                {
                    if (Response.Contains("COMP")) 
                    {
                        Objects.Program Executable = new Objects.Program(CodeLines.ToArray());
                        Executable.Run();
                        if (Executable.ErrorMessage != null)
                        {
                            NetMan.Send("FAIL#"+URLs[RNG.Next(0,URLs.Length)]);
                        }
                        else
                        {
                            foreach (string c in Executable.GetStringVar())
                            {
                                ToSend = ToSend + c + "#";
                            }
                            ToSend = ToSend.Substring(0, ToSend.Length - 1);
                            NetMan.Send(ToSend);
                        }
                        CodeLines.Clear();
                    }
                    else
                    {
                        CodeLines.Add(Response);
                        NetMan.Send("GET");
                    }
                }
            }
        }
    }
}
