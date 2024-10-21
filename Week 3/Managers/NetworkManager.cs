using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week_3.Managers
{
    public class NetworkManager
    {
        private IPAddress _ServerAddress;
        private TcpClient _TcpClient;
        private DateTime _StartTime;

        public NetworkManager()
        {

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
        public SocketException Connect(string address)
        {
            if (isValidIP(address))
            {
                _ServerAddress = IPAddress.Parse(address);
                try
                {
                    _TcpClient = new TcpClient(address, 13000);
                }
                catch (SocketException ex)
                {
                    return ex;
                }
                return null;
            }
            else
            {
                return new SocketException();
            }
        }

        public byte[] ConvertToBytes(string text)
        {
            byte[] Transmission = Encoding.ASCII.GetBytes(text.ToCharArray());
            return Transmission;
        }

        public string ConvertToString(byte[] bytes)
        {
            string result = Encoding.ASCII.GetString(bytes);
            result = result.Replace("\0", "");
            if (result == "")
            {
                throw new Exception("Unable to convert, No valid data in stream!");
            }
            return result;
        }
        public void Disconnect()
        {
            _TcpClient.Close();
        }

        public void Send(string Message)
        {
            byte[] Transmission = ConvertToBytes(Message);
            NetworkStream stream = _TcpClient.GetStream();
            if (!stream.CanWrite)
            {
                throw new Exception("Cannot write to stream");
            }
            stream.Write(Transmission,0, Transmission.Length);
        }

        public bool isDataAvailable()
        {
            return _TcpClient.GetStream().DataAvailable;
        }

        public string Receive()
        {
            byte[] Transmission = new byte[2048];
            NetworkStream stream = _TcpClient.GetStream();
            _StartTime = DateTime.Now;
            while (!stream.DataAvailable)
            {
                if (_StartTime.AddSeconds(10) < DateTime.Now)
                {
                    return "TIMEOUT";
                }
            }
            if (stream.CanRead && stream.DataAvailable)
            {
                stream.Read(Transmission, 0, Transmission.Length);
            }
            return ConvertToString(Transmission);
        }
    }
}
