using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PortScanner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string host = "127.0.0.1";
            int startPort;
            int endPort;

            Console.WriteLine("Введите начальный порт:");
            if (!int.TryParse(Console.ReadLine(), out startPort))
            {
                Console.WriteLine("Неверный ввод начального порта. Порт выбран автоматически(35078) :)");
                startPort = 35078;
            }

            Console.WriteLine("Введите конечный порт:");
            if (!int.TryParse(Console.ReadLine(), out endPort))
            {
                Console.WriteLine("Неверный ввод конечного порта. Порт выбран автоматически(35128) :)");
                endPort = 35128;
            }

            for (int port = startPort; port <= endPort; port++)
            {
                CheckPort(host, port);
            }

            Console.WriteLine("Скан завершен");
        }

        private static void CheckPort(string host, int port)
        {
            using (var tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect(host, port);
                    Console.WriteLine($"Порт {port} открыт.");
                }
                catch (SocketException)
                {
                    Console.WriteLine($"Порт {port} закрыт.");
                }
            }
        }
    }
}
