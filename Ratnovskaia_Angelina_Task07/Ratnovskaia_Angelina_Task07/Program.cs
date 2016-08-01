using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;

namespace Ratnovskaia_Angelina_Task07
{
    
    class Program
    {
        static int port = 8005;
        
        

        internal static void IsSuccess(bool action)
        {
            if (!action)
            {
                Console.WriteLine("Не должно быть дубликатов имен в пределах одной папки!");
            }
        }


        static void Main()
        {
           
            var driver = new FileSystem();

            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(ipPoint);
            listenSocket.Listen(10);
            while (true)
            {
                Socket handler = listenSocket.Accept();
                // получаем сообщение
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байтов
                byte[] data = new byte[256]; // буфер для получаемых данных

                do
                {
                    bytes = handler.Receive(data);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (handler.Available > 0);
             

                    try
                    {
                        var s = builder.ToString();
                        s = s.ToLower();
                        var param = s.Split(' ');


                        switch (param[0])
                        {
                            case "md":
                                IsSuccess(driver.CreateCatalog(param[1], (param[2])));
                                break;

                            case "mf":
                                IsSuccess(driver.CreateFile(param[1], param[2]));
                                break;

                            case "remove":
                                IsSuccess(driver.Remove(param[1]));
                                break;

                            case "copy":
                                IsSuccess(driver.Copy(param[1], param[2]));
                                break;

                            case "move":
                                IsSuccess(driver.Move(param[1], param[2]));
                                break;

                            case "rename":
                                IsSuccess(driver.Rename(param[1], param[2]));
                                break;

                            case "show":

                                var itemList = driver.GetAllItemsByPath(param[1]);
                                var list = itemList.Select(element => element.Name).ToList();

                                foreach (var element in list)
                                {
                                    Console.WriteLine(element);
                                }
                                break;

                            default:
                                Console.WriteLine(("Некорректная команда!"));
                                break;
                        }
                    }
                    catch (NullReferenceException)
                    {

                        Console.WriteLine("Неверно задан путь");
                    }

                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Неверно заданы параметры");
                    }
                


                Console.ReadLine();

                // отправляем ответ
                string message = "ваше сообщение доставлено";
                data = Encoding.Unicode.GetBytes(message);
                handler.Send(data);
                // закрываем сокет
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }


        }
    }
}
