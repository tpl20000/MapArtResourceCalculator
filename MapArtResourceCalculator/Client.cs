using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace MapArtResourceCalculator
{
    public class Client
    {

        private Socket clientSocket;
        private IProgress<string> printToLog;
        CancellationTokenSource tkSource = new CancellationTokenSource();
        CancellationToken ct;

        public Client(IProgress<string> _printToLogBox)
        {
            printToLog = _printToLogBox;
        }

        public void connectClient(IPAddress address, int port)
        {

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Task.Run(async () =>
            {

                ct.ThrowIfCancellationRequested();

                await clientSocket.ConnectAsync(address, port);
                printToLog.Report("[Client] Connected!");

                while (true)
                {
                    if (ct.IsCancellationRequested) 
                        ct.ThrowIfCancellationRequested();
                }

            }, tkSource.Token);

        }

        public void disconnectClient()
        {
            //FIGURE OUT WTF IS WRONG WITH THESE SOCKETS
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Disconnect(false);
            clientSocket.Close();
            if(clientSocket != null)
            {
                clientSocket.Close();
                clientSocket = null;
            }

            try { printToLog.Report("[Client] Disconnected!"); }
            catch { } //not critical, skipping...

        }

    }
}
