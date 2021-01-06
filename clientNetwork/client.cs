using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace clientNetwork
{
    class client
    {
        const string IpServer = "127.0.0.1";
        const int PORT = 8080;

        static void Main(string[] args)
        {
            try
            {
                TcpClient clientSocket = new TcpClient();
                clientSocket.Connect(IpServer, PORT);

                NetworkStream netStream = clientSocket.GetStream();

                StreamWriter writer = new StreamWriter(netStream);

                Console.Write("Write any string: ");
                writer.WriteLine(Console.ReadLine());
                writer.Flush();

                StreamReader reader = new StreamReader(netStream);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Response from server: {0}", reader.ReadLine());

                writer.Close();
                reader.Close();
                netStream.Close();
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR!\n" + ex.Message);
                Console.ReadLine();
            }

            
        }
    }
}
