using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Ratnovskaia_Angelina_Task07
{
   public class Proxy
    {
        
        
        public Proxy(Socket socket)
        {
            Socket = socket;
        }
        
           public void Communication()
        {
            string message = "";
            do
            {
                Console.Write("Введите сообщение:");
                message = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(message);
                Socket.Send(data);
                // получаем ответ
                data = new byte[256]; // буфер для ответа
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байт

                do
                {
                    bytes = Socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }

                while (Socket.Available > 0);
                Console.WriteLine("ответ сервера: " + builder.ToString());
              //  Socket.Close();
            }
            while (message != "exit");
        }
        Socket Socket { get; set; }
    }
            


        
    }

