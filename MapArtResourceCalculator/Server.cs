using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MapArtResourceCalculator
{

    internal class Server
    {

        private int concurentUserAmount = 100;
        private string filePath = "";
        private IPEndPoint ipPoint;
        private Socket serverSocket;
        private Socket connectedClient;
        CancellationTokenSource tkSource = new CancellationTokenSource();
        CancellationToken ct;

        public void StartServer(IPAddress ip, int port)
        {

            ipPoint = new IPEndPoint(ip, port);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            serverSocket.Bind(ipPoint);
            serverSocket.Listen(concurentUserAmount);

            ct = tkSource.Token;
            Task.Run(async () =>
            {

                ct.ThrowIfCancellationRequested();

                connectedClient = await serverSocket.AcceptAsync();

                while(true)
                {

                    if (ct.IsCancellationRequested)
                    {
                        ct.ThrowIfCancellationRequested();
                    }

                }
                

            }, tkSource.Token);

        }

        public void StopServer()
        {

            tkSource.Cancel();
            serverSocket.Close();
            ipPoint = null;
            serverSocket = null;

        }

    }
}
