using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Client
{
    public class Chat
    {
        private System.Timers.Timer timer;
        private TcpClient socket;
        private NetworkStream stream;
        private Thread thread;

        public Chat()
        {
            this.socket = new TcpClient();
            thread = new Thread(GetMessageClient);
        }

        public ConnectionStatuses Status { get; private set; } = ConnectionStatuses.Idle;

        private void GetMessageClient()
        {
            try
            {
                while (Status == ConnectionStatuses.Connect)
                {
                    byte[] buffer = new byte[1024];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    if (bytes == 0)
                        continue;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytes);
                    Console.WriteLine(message);
                }
            }
            catch
            {
                if (Status != ConnectionStatuses.Disconnect)
                    Disconnect();
            }
        }

        private void StartLoopPing()
        {
            timer = new System.Timers.Timer(500);
            timer.Elapsed += OnTimerLoopPing;
            timer.AutoReset = true;
            timer.Start();
        }

        private void OnTimerLoopPing(object sender, ElapsedEventArgs e)
        {
            try
            {
                byte[] ping = new byte[] { 0 };
                stream.Write(ping, 0, ping.Length);
                stream.Flush();
            }
            catch
            {
                Disconnect();
            }
        }

        public bool Connect()
        {
            if (socket.Connected)
            {
                Console.WriteLine("Error: connection is now exist");
                return false;
            }

            try
            {
                Status = ConnectionStatuses.TryConnect;
                Console.WriteLine($"Connected to {UserInfo.Ip}:{UserInfo.Port}...");
                // Подключаемся к серверу
                socket.Connect(UserInfo.Ip, UserInfo.Port);
                Status = ConnectionStatuses.Connect;

                // Connect is success
                stream = socket.GetStream();
                thread.Start();
                UserInfo.ConnectFirstTime = DateTime.Now;
                // После подключения отправляем свое имя на сервер
                Console.WriteLine("Подключен к серверу ");
                SendMessage(UserInfo.Name);
                StartLoopPing();
                return true;
            }
            catch (Exception ex)
            {
                Status = ConnectionStatuses.FailConnect;
                Console.WriteLine($"Server Not Found {ex.Message}");
                return false;
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
            catch
            {
                timer.Stop();
            }
        }

        public void Disconnect()
        {
            Status = ConnectionStatuses.Disconnect;

            socket.Close();
            socket.Dispose();
            Console.WriteLine("Disconnected from server");
            timer.Stop();

            //Create new socket
            //socket = new TcpClient();
            //thread = new Thread(GetMessageClient);
        }
    }
}