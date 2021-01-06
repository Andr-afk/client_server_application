using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace serverNetwork
{
    class server
    {
        const int PORT = 8080;
        const string IpServer = "127.0.0.1";


        static void Main(string[] args)
        {
            try
            {
                TcpListener serverSocket = new TcpListener(IPAddress.Parse(IpServer), PORT);

                serverSocket.Start();

                while (true)
                {
                    Console.WriteLine("Wait connection...");

                    TcpClient clientSocket = serverSocket.AcceptTcpClient();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Connection occured!");
                    Console.ResetColor();

                    NetworkStream payLoadFromClient = clientSocket.GetStream();
                    StreamReader reader = new StreamReader(payLoadFromClient);
                    string message = reader.ReadLine();

                    StreamWriter writer = new StreamWriter(payLoadFromClient);

                    writer.WriteLine(message.ToUpper());

                    
                    writer.Close();
                    reader.Close();
                    payLoadFromClient.Close();
                    clientSocket.Close();

                }
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("ERROR!\n" + ex.Message);

                Console.ResetColor();
                Console.ReadLine();
            }
            
        }
    }
}
