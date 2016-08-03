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
    
   public class Program
    {
        static int port = 8005;
        public static string message = null;
        public static string data = null;

        internal static void IsSuccess(bool action)
        {
            if (!action)
            {
                Program.message = "Не должно быть дубликатов в пределах одной папки!";
            }
        }


       public static void StartListening()
        {
           
            var driver = new FileSystem();

            byte[] bytes = new Byte[1024];

            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            using (Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {

                try
                {
                    listenSocket.Bind(ipPoint);
                    listenSocket.Listen(10);

                    while (true)
                    {
                        Console.WriteLine("Ожидание соединения...");

                        using (Socket handler = listenSocket.Accept())
                        {

                            data = null;

                            #region Получение команд
                            do
                            {
                                bytes = new byte[1024];
                                int bytesRec = handler.Receive(bytes);
                                data = Encoding.Unicode.GetString(bytes, 0, bytesRec);
                                Console.WriteLine("Текст получен: {0}", data);

                                try
                                {

                                    var s = data.ToLower();
                                    var param = s.Split(' ');
                                    message = "все ок";

                                    #region switch

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

                                        case "exit":
                                            break;

                                        default:
                                            message = "Некорректная команда!";
                                            break;
                                    }

                                    #endregion


                                }
                                catch (NullReferenceException)
                                {

                                    message = "Неверно задан путь";


                                }

                                catch (IndexOutOfRangeException)
                                {
                                    message = "Неверно заданы параметры";

                                }


                                // отправляем ответ
                                byte[] msg = Encoding.Unicode.GetBytes(message);
                                handler.Send(msg);

                            }
                            while (true);

                            #endregion Получение комманд
                        }


                      



                        //handler.Shutdown(SocketShutdown.Both);

                        //handler.Close();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static int Main(String[] args)
        {
            StartListening();
            return 0;
        }
    }
}
