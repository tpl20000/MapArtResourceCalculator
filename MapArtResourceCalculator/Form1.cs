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
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace MapArtResourceCalculator
{
    public partial class Form1 : Form
    {

        public bool isServerStarted = false;
        public bool isClientConnected = false;
        private string fileName = "C:\\Users\\Sentinel\\source\\repos\\MapArtResourceCalculator\\MapArtResourceCalculator\\bin\\Debug\\MapArtItemList.xlsx";
        public int concurentUserAmount = 100;

        private IPAddress parsedAddress;
        private int parsedPort;

        private Server srv = new Server();

        //remove once moved to server
        private Excel.Application xlsxApp;
        private Excel.Workbook xlsxFile;
        private Excel.Worksheet xlsxSheet;

        //remove once moved to server/client
        private IPEndPoint ipPoint;
        private Socket serverSocket;
        private Socket clientSocket;

        public Form1()
        {
            InitializeComponent();

            // tmp function calling to open xlsx file
            loadItemList();
        }

        private void loadItemList()
        {
            xlsxApp = new Excel.Application();
            xlsxFile = xlsxApp.Workbooks.Open(fileName);
            xlsxSheet = xlsxFile.Sheets[1];

            resourceList.Items.Clear();

            int i = 3;
            while (xlsxSheet.Cells[i, 1].Value != null)
            {
                resourceList.Items.Add(xlsxSheet.Cells[i, 1].Value);
                i++;
            }
        }

        // utility functions for better resource representation
        // MOVE TO THE CLIENT SIDE
        private string convertToSB(string s)
        {
            int num = int.Parse(s);
            string str = $"{Math.Round(num / (64.0 * 27.0), 2)} SB";
            return str;
        }

        private string convertToStack(string s)
        {
            int num = int.Parse(s);
            string str = $"{num / 64} * 64 + {num % 64}";
            return str;
        }

        private void serverStartButton_Click(object sender, EventArgs e)
        {
            if (!isServerStarted) //start server if disabled
            {

                //check if text in server address box is a valid ip address
                if (!IPAddress.TryParse(serverAddressTextBox.Text, out parsedAddress))
                {
                    serverLogBox.AppendText($"Server did not start - Bad IP Address! ({serverAddressTextBox.Text})\n");
                    return;
                }

                //check if text in server port box is a valid port
                if (!serverPortTextBox.Text.All(char.IsDigit) || (int.Parse(serverPortTextBox.Text) > 65536))
                {
                    serverLogBox.AppendText($"Server did not start - Bad Port! ({serverPortTextBox.Text})\n");
                    return;
                }
                parsedPort = int.Parse(serverPortTextBox.Text);

                //run server in a separate thread
                try
                {
                    serverBackgroundWorker.RunWorkerAsync();
                }
                catch (Exception err)
                {
                    serverLogBox.AppendText(err.Message);
                    serverBackgroundWorker.Dispose();
                }


                isServerStarted = true;
                startServerButton.BackColor = Color.Red;
                startServerButton.Text = "Stop";
                serverLogBox.AppendText("Server started!\n");

            }
            else //stop server if running
            {

                srv.StopServer();

                isServerStarted = false;
                startServerButton.BackColor = Color.Green;
                startServerButton.Text = "Start";

                serverLogBox.AppendText("Server stopped!\n");

            }

        }

        private void ServerBackgroundWorkerStart(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker worker = sender as BackgroundWorker;
            srv.StartServer(parsedAddress, parsedPort);

        }

        private async void clientConnectButton_Click(object sender, EventArgs e)
        {

            if (!isClientConnected)
            {

                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.ConnectAsync(IPAddress.Parse(clientAddressTextBox.Text), int.Parse(clientPortTextBox.Text));

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

        private void addItemsButton_Click(object sender, EventArgs e)
        {

            int addedVal;
            int.TryParse(adderTextBox.Text, out addedVal);

            xlsxSheet.Cells[resourceList.SelectedIndex + 3, 4] = xlsxSheet.Cells[resourceList.SelectedIndex + 3, 4].Value + addedVal;
            xlsxSheet.Cells[resourceList.SelectedIndex + 3, 3] = xlsxSheet.Cells[resourceList.SelectedIndex + 3, 2].Value - xlsxSheet.Cells[resourceList.SelectedIndex + 3, 4].Value;
            itemsAvailableLabel.Text = xlsxSheet.Cells[resourceList.SelectedIndex + 3, 4].Value.ToString() + " + ";
            itemsMissingLabel.Text = xlsxSheet.Cells[resourceList.SelectedIndex + 3, 3].Value.ToString();
            if (xlsxSheet.Cells[resourceList.SelectedIndex + 3, 2].Value >= 64 * 27) itemsTotalLabel.Text = convertToSB(xlsxSheet.Cells[resourceList.SelectedIndex + 3, 2].Value.ToString());
            else if (xlsxSheet.Cells[resourceList.SelectedIndex + 3, 2].Value <= 64) itemsTotalLabel.Text = xlsxSheet.Cells[resourceList.SelectedIndex + 3, 2].Value.ToString();
            else itemsTotalLabel.Text = convertToStack(xlsxSheet.Cells[resourceList.SelectedIndex + 3, 2].Value.ToString());

            xlsxApp.Visible = false;
            xlsxApp.UserControl = false;
            xlsxFile.Save();
            adderTextBox.Clear();
        }

        private void itemsPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

            itemsAvailableLabel.Text = xlsxSheet.Cells[resourceList.SelectedIndex + 3, 4].Value.ToString() + " + ";
            itemsMissingLabel.Text = xlsxSheet.Cells[resourceList.SelectedIndex + 3, 3].Value.ToString();
            if (xlsxSheet.Cells[resourceList.SelectedIndex + 3, 2].Value >= 64 * 27) itemsTotalLabel.Text = convertToSB(xlsxSheet.Cells[resourceList.SelectedIndex + 3, 2].Value.ToString());
            else if (xlsxSheet.Cells[resourceList.SelectedIndex + 3, 2].Value <= 64) itemsTotalLabel.Text = xlsxSheet.Cells[resourceList.SelectedIndex + 3, 2].Value.ToString();
            else itemsTotalLabel.Text = convertToStack(xlsxSheet.Cells[resourceList.SelectedIndex + 3, 2].Value.ToString());
        }



        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (isServerStarted) srv.StopServer();

            // tmp cleaning and closing file function
            // MOVE TO SERVER SHUTDOWN FUNCTION
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(xlsxSheet);
            xlsxFile.Close();
            Marshal.ReleaseComObject(xlsxFile);
            xlsxApp.Quit();
            Marshal.ReleaseComObject(xlsxApp);
        }
    }
}
