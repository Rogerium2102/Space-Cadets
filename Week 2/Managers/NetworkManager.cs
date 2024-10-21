using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week_2.Managers
{
    public class NetworkManager
    {
        private TcpListener _listener;
        private IPAddress _HostingIP;
        private int _HostingPort;
        private List<TcpClient> _Clients = new List<TcpClient>();
        private bool _Online = false;
        private TcpClient LastClient;

        public NetworkManager(string IP, int Port)
        {
            if (!isValidIP(IP))
            {
                throw new ArgumentException("IP address is not valid!");
            }
            _HostingIP = IPAddress.Parse(IP);
            _HostingPort = Port;
            _listener = new TcpListener(_HostingIP, _HostingPort);
            _listener.Start();
            _Online = true;
        }

        public void ConnectClient()
        {
            if (_listener.Pending())
            {
                TcpClient client = _listener.AcceptTcpClient();
                _Clients.Add(client);
                Console.WriteLine("New client connected!");
            }
        }

        private void RemoveInactiveClients()
        {
            foreach (TcpClient client in _Clients)
            {
                if (!client.Connected)
                {
                    _Clients.Remove(client);
                }
            }
        }
        public string CheckIncomingTransmissionAndConnectClient()
        {
            ConnectClient();
            TcpClient client = isDataAvailable();
            RemoveInactiveClients();
            if (client != null)
            {
                LastClient = client;
                return Receive(client);
            }
            else
            {
                return null;
            }
        }

        public void Close()
        {
            _listener.Stop();
            _Online = false;
        }
        public bool isValidIP(string address)
        {
            Regex reg = new Regex(@"(\d{1,3}.){2}\d{1,3}");
            if (reg.IsMatch(address))
            {
                return true;
            }
            return false;
        }

        public void Send(string Message)
        {
            Send(LastClient, Message);
        }

        public void Send(TcpClient Client, string Message)
        {
            byte[] Transmission = ConvertToBytes(Message);
            NetworkStream stream = Client.GetStream();
            if (!stream.CanWrite)
            {
                throw new Exception("Cannot write to stream");
            }
            stream.Write(Transmission, 0, Transmission.Length);
        }

        public TcpClient isDataAvailable()
        {
            foreach (TcpClient Client in _Clients)
            {
                if (Client.GetStream().DataAvailable)
                {
                    return Client;
                }
            }
            return null;
        }

        public int GetClientCount()
        {
            return _Clients.Count;
        }
        public string Receive(TcpClient Client)
        {
            byte[] Transmission = new byte[2048];
            NetworkStream stream = Client.GetStream();
            if (stream.CanRead && stream.DataAvailable)
            {
                stream.Read(Transmission, 0, Transmission.Length);
            }
            return ConvertToString(Transmission);
        }
        public byte[] ConvertToBytes(string text)
        {
            byte[] Transmission = Encoding.ASCII.GetBytes(text.ToCharArray());
            return Transmission;
        }
        public string ConvertToString(byte[] bytes)
        {
            string result = Encoding.ASCII.GetString(bytes);
            if (result.IndexOf('\0') == 0)
            {
                throw new Exception("Unable to convert, No valid data in stream!");
            }
            result = result.Substring(0, result.IndexOf('\0'));
            return result;
        }

        public bool isOnline()
        {
            return _Online;
        }
    }
}
