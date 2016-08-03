using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Ratnovskaia_Angelina_Task07
{
   public class ConnectionFactory
    {

        public Proxy Connect(int port, string address)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket = socket;
            // подключаемся к удаленному хосту
            Socket.Connect(ipPoint);
            

            return new Proxy(socket);
        }

        public void CloseConnection(Socket socket)
        {
            // закрываем сокет
            Socket.Shutdown(SocketShutdown.Both);
            Socket.Close();
        }

        public Socket Socket { get; private set; }
       
    }
}
