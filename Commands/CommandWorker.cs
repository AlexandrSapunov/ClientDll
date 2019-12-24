using Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Commands
{
    public class CommandWorker
    {
        public static Chat client;
        
        public static void Send(string message)
        {
            Console.WriteLine($"Sending message: {message}");
            client.SendMessage(message);
        }

        public static void SetIp(string IP)
        {
            Console.WriteLine($"Set IP: {IP}");
            UserInfo.Ip = IP;
        }

        public static void Connect()
        {
            client = new Chat();
            client.Connect();
        }

        public static void SetName(string Name)
        {
            Console.WriteLine($"New name: {Name}");
            UserInfo.Name = Name;
        }

        public static void Disconnect()
        {
            client.Disconnect();
        }

        public static void Status()
        {
            string ip = UserInfo.Ip;
            string name = UserInfo.Name;
            DateTime dateTime = UserInfo.ConnectFirstTime;
            var connection = client.Status;
            
            Console.WriteLine($"Status:\n");
            Console.WriteLine($"IP Adress:{ip} \n");
            Console.WriteLine($"Your name: {name} \n");
            Console.WriteLine($"Connected date and time: {dateTime} \n");
            Console.WriteLine($"Connection: {connection}");
        }

        public static void Help()
        {
            Console.WriteLine("Help: Show list command\n");
            Console.WriteLine("Send: Send message\n");
            Console.WriteLine("SetIP: Change IP_Adress\n");
            Console.WriteLine("SetName: Change name\n");
            Console.WriteLine("Connect: Connect Server\n");
            Console.WriteLine("Disconnect: Disconnect Server\n");
            Console.WriteLine("Status:  Show status connect to server (IPAddress, name, datetime connect, connect status)\n");
            Console.WriteLine("Exit: Close client");
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
