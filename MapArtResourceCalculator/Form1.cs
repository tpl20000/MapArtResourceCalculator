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
        public IProgress<string> printToServerLog;

        private IPAddress parsedAddress;
        private int parsedPort;

        private Server srv;
        private Client clt;

        private Task serverTask;
        private Task clientTask;

        //remove once moved to server
        private Excel.Application xlsxApp;
        private Excel.Workbook xlsxFile;
        private Excel.Worksheet xlsxSheet;

        public Form1()
        {
            InitializeComponent();

            
            printToServerLog = new Progress<string>(msg => printToLog(msg));
            srv = new Server(printToServerLog);
            clt = new Client(printToServerLog);

            // tmp function calling to open xlsx file
            loadItemList();
        }

        public void printToLog(string msg) { serverLogBox.AppendText($"{msg}\n"); }

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

        //Method for validating addresses, bool parameter true if server
        private bool isAddressValid(string address, string port, bool isServer)
        {

            //check if text in server address box is a valid ip address
            if (!IPAddress.TryParse(address, out parsedAddress))
            {
                if (isServer) printToLog($"Server did not start - Bad IP Address! ({address})");
                else printToLog($"Client did not connect - Bad IP Address! ({address})");
                return false;
            }

            //check if text in server port box is a valid port
            if (!port.All(char.IsDigit) || (int.Parse(port) > 65536))
            {
                if (isServer) printToLog($"Server did not start - Bad Port! ({port})");
                else printToLog($"Client did not connect - Bad port! ({port})");
                return false;
            }

            parsedPort = int.Parse(port);
            return true;
        }

        // utility functions for better resource representation
        // MOVE TO THE CLIENT SIDE (is it really needed there though?)
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

                if (!isAddressValid(serverAddressTextBox.Text, serverPortTextBox.Text, true)) return;

                //run server in a separate thread
                try
                {
                    serverTask = Task.Factory.StartNew(() => srv.startServer(parsedAddress, parsedPort));
                }
                catch (Exception err)
                {
                    printToLog($"Server did not start - Error ({err.Message})");
                    serverTask = null;
                    return;
                }

                isServerStarted = true;
                startServerButton.BackColor = Color.Red;
                startServerButton.Text = "Stop";

            }
            else //stop server if running
            {
                srv.stopServer();
                isServerStarted = false;
                startServerButton.BackColor = Color.Green;
                startServerButton.Text = "Start";
            }

        }

        private void clientConnectButton_Click(object sender, EventArgs e)
        {

            if (!isClientConnected) //connect client if not connected
            {

                if (!isAddressValid(clientAddressTextBox.Text, clientPortTextBox.Text, false)) return;

                try
                {
                    clientTask = Task.Factory.StartNew(() => clt.connectClient(parsedAddress, parsedPort));
                }
                catch (Exception err)
                {
                    printToLog($"Client did not connect - Error! ({err.Message})");
                    clientTask = null;
                    return;
                }

                isClientConnected = true;
                clientConnectButton.Text = "Disconnect";
                clientConnectButton.BackColor = Color.Red;

            }
            else //disconnect client if connected
            {

                clt.disconnectClient();
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

            if (isServerStarted) srv.stopServer();
            if (isClientConnected) clt.disconnectClient();

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
