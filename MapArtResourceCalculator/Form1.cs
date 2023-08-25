using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace MapArtResourceCalculator
{
    public partial class Form1 : Form
    {

        public bool isServerStarted = false;
        public bool isClientConnected = false;
        public string fileName = "MapArtResourceBase.xlsx";
        public int concurentUserAmount = 100;
        public int serverPort = 8888;
        public int clientPort = 8888;

        private IPEndPoint ipPoint;
        private Socket serverSocket;
        private Socket clientSocket;

        public Form1()
        {
            InitializeComponent();
        }

        private async void serverStartButton_Click(object sender, EventArgs e)
        {

            

            if (!isServerStarted) //if disabled
            {

                ipPoint = new IPEndPoint(IPAddress.Parse(serverAddressTextBox.Text), serverPort);
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                serverSocket.Bind(ipPoint);
                serverSocket.Listen(100);


                isServerStarted = true;
                startServerButton.BackColor = Color.Red;
                //startServerButton.Text = "Stop";
                startServerButton.Text = "Stop";
                //server start logic

                serverLogBox.AppendText("Server started!\n");

                while (true)
                {

                    serverLogBox.AppendText("Listening...");
                    Socket connectedClient = await serverSocket.AcceptAsync();
                    serverLogBox.AppendText($"Connection established ({connectedClient.RemoteEndPoint})!");

                }

            }
            else
            {

                serverSocket.Close();

                isServerStarted = false;
                startServerButton.BackColor = Color.Green;
                startServerButton.Text = "Start";
                //server shutdown logic

                serverLogBox.AppendText("Server stopped!\n");

            }

        }

        private async void clientConnectButton_Click(object sender, EventArgs e)
        {

            if (!isClientConnected) 
            {

                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.ConnectAsync(IPAddress.Parse(clientAddressTextBox.Text), clientPort);

                isClientConnected = true;
                clientConnectButton.Text = "Disconnect";
                clientConnectButton.BackColor = Color.Red;

            }
            else
            {

                clientSocket.Close();

                isClientConnected = false;
                clientConnectButton.Text = "Connect";
                clientConnectButton.BackColor = Color.Green;

            }

        }
    }
}
