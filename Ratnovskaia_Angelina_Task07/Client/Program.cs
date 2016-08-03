using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Ratnovskaia_Angelina_Task07
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var connection = new ConnectionFactory();
                var proxy = connection.Connect(8005, "127.0.0.1");
                proxy.Communication();


             //   connection.CloseConnection(connection.Socket);

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}