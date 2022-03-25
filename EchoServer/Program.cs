using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Echo Echo");

            TcpListener listener = new TcpListener(IPAddress.Any, 7);
            listener.Start();

            TcpClient socket = listener.AcceptTcpClient();

            NetworkStream ns = socket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);

            string message = reader.ReadLine();
            Console.WriteLine("Message has been send:"+ message);

            writer.WriteLine(message);
            writer.Flush();

            socket.Close();

            listener.Stop();

            Console.ReadKey();




        }
    }
}
