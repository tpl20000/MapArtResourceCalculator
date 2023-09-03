using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapArtResourceCalculator
{

    public class Server
    {

        private int concurentUserAmount = 100;
        private string filePath = "";
        private IPEndPoint ipPoint;
        private Socket serverSocket;
        private Socket connectedClient;
        private IProgress<string> printToServerLog;
        CancellationTokenSource tkSource = new CancellationTokenSource();
        CancellationToken ct;

        public Server(IProgress<string> _printToServerLog)
        {
            printToServerLog = _printToServerLog;
        }

        public void startServer(IPAddress ip, int port)
        {

            ipPoint = new IPEndPoint(ip, port);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            MessageBox.Show($"Current port is {port}");
            serverSocket.Bind(ipPoint);
            serverSocket.Listen(concurentUserAmount);

            printToServerLog.Report("[Server] Server started!");

            ct = tkSource.Token;

            Task.Run(async () =>
            {

                ct.ThrowIfCancellationRequested();
                try
                {
                    connectedClient = await serverSocket.AcceptAsync();
                    printToServerLog.Report($"[Server] Client connected! ({connectedClient.RemoteEndPoint})");
                }
                catch (SocketException err)
                {

                    printToServerLog.Report($"[Server] Client connection error! ({err.Message})");

                }

                while(true)
                {

                    if (ct.IsCancellationRequested)
                        ct.ThrowIfCancellationRequested();

                }
                

            }, tkSource.Token);


        }

        public void stopServer()
        {

            tkSource.Cancel();
            if (serverSocket != null)
            {
                //FIGURE OUT WTF IS WRONG WITH THESE SOCKETS
                serverSocket.Shutdown(SocketShutdown.Both);
                serverSocket.Disconnect(false);
                serverSocket.Close();
                serverSocket = null;
            }
            ipPoint = null;

            try { printToServerLog.Report("[Server] Server stopped!"); }
            catch { } //not critical, skipping...

        }

    }
}
