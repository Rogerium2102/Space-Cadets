using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2.Managers;

namespace Week_4_Server
{
    internal class Program
    {
        static NetworkManager NetworkManager = new NetworkManager("127.0.0.1", 13000);
        static void Main(string[] args)
        {
            NetworkManager.Start();
        }
    }
}
