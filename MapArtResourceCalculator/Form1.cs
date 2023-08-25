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

namespace MapArtResourceCalculator
{
    public partial class Form1 : Form
    {

        public bool isServerStarted = false;
        public bool isClientConnected = false;
        private string fileName = ""; // file path
        public int concurentUserAmount = 100;
        public int serverPort = 8888;
        public int clientPort = 8888;

        private Excel.Application xlsxApp;
        private Excel.Workbook xlsxFile;
        private Excel.Worksheet xlsxSheet;

        private IPEndPoint ipPoint;
        private Socket serverSocket;
        private Socket clientSocket;

        public Form1()
        {
            InitializeComponent();

            // tmp function calling to open xlsx file
            loadItemList();
        }

        private void loadItemList() {
            xlsxApp = new Excel.Application();
            xlsxFile = xlsxApp.Workbooks.Open(fileName);
            xlsxSheet = xlsxFile.Sheets[1];

            itemsPicker.Items.Clear();

            int i = 3;
            while (xlsxSheet.Cells[i, 1].Value != null) {
                itemsPicker.Items.Add(xlsxSheet.Cells[i, 1].Value);
                i++;
            }
        }

        // utility functions for better resource representation
        // MOVE TO THE CLIENT SIDE
        private string convertToSB(string s) {
            int num = int.Parse(s);
            string str = (Math.Round((num / (64.0 * 27.0)), 2)).ToString() + " SB";
            return str;
        }
        private string convertToStack(string s) {
            int num = int.Parse(s);
            string str = (num / 64).ToString() + " * 64 + " + (num % 64).ToString();
            return str;
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

        private void addItemsButton_Click(object sender, EventArgs e)
        {
            
            int addedVal = 0;
            int.TryParse(adderTextBox.Text, out addedVal);

            xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 4] = xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 4].Value + addedVal;
            xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 3] = xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 2].Value - xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 4].Value;
            itemsAvailableLabel.Text = xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 4].Value.ToString() + " + ";
            itemsMissingLabel.Text = xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 3].Value.ToString();
            if (xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 2].Value >= 64 * 27) itemsTotalLabel.Text = convertToSB(xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 2].Value.ToString());
            else if (xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 2].Value <= 64) itemsTotalLabel.Text = xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 2].Value.ToString();
            else itemsTotalLabel.Text = convertToStack(xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 2].Value.ToString());
            xlsxApp.Visible = false;
            xlsxApp.UserControl = false;
            xlsxFile.Save();
            adderTextBox.Clear();
        }

        private void itemsPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemsAvailableLabel.Text = xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 4].Value.ToString() + " + ";
            itemsMissingLabel.Text = xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 3].Value.ToString();
            if (xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 2].Value >= 64 * 27) itemsTotalLabel.Text = convertToSB(xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 2].Value.ToString());
            else if (xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 2].Value <= 64) itemsTotalLabel.Text = xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 2].Value.ToString();
            else itemsTotalLabel.Text = convertToStack(xlsxSheet.Cells[itemsPicker.SelectedIndex + 3, 2].Value.ToString());
        }
        
        // tmp cleaning and closing file function
        // MOVE TO SERVER SHUTDOWN FUNCTION
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
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
