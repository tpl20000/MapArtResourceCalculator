namespace MapArtResourceCalculator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.serverPortLabel = new System.Windows.Forms.Label();
            this.serverAddressLabel = new System.Windows.Forms.Label();
            this.serverPortTextBox = new System.Windows.Forms.TextBox();
            this.serverAddressTextBox = new System.Windows.Forms.TextBox();
            this.serverLogBox = new System.Windows.Forms.RichTextBox();
            this.startServerButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clientPortLabel = new System.Windows.Forms.Label();
            this.resourceList = new System.Windows.Forms.ListBox();
            this.itemsTotalLabel = new System.Windows.Forms.Label();
            this.clientPortTextBox = new System.Windows.Forms.TextBox();
            this.itemsMissingLabel = new System.Windows.Forms.Label();
            this.itemsAvailableLabel = new System.Windows.Forms.Label();
            this.addItemsButton = new System.Windows.Forms.Button();
            this.adderTextBox = new System.Windows.Forms.TextBox();
            this.clientConnectButton = new System.Windows.Forms.Button();
            this.clientAddressLabel = new System.Windows.Forms.Label();
            this.clientAddressTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.serverPortLabel);
            this.groupBox1.Controls.Add(this.serverAddressLabel);
            this.groupBox1.Controls.Add(this.serverPortTextBox);
            this.groupBox1.Controls.Add(this.serverAddressTextBox);
            this.groupBox1.Controls.Add(this.serverLogBox);
            this.groupBox1.Controls.Add(this.startServerButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 425);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server";
            // 
            // serverPortLabel
            // 
            this.serverPortLabel.AutoSize = true;
            this.serverPortLabel.Location = new System.Drawing.Point(167, 39);
            this.serverPortLabel.Name = "serverPortLabel";
            this.serverPortLabel.Size = new System.Drawing.Size(26, 13);
            this.serverPortLabel.TabIndex = 3;
            this.serverPortLabel.Text = "Port";
            // 
            // serverAddressLabel
            // 
            this.serverAddressLabel.AutoSize = true;
            this.serverAddressLabel.Location = new System.Drawing.Point(167, 19);
            this.serverAddressLabel.Name = "serverAddressLabel";
            this.serverAddressLabel.Size = new System.Drawing.Size(45, 13);
            this.serverAddressLabel.TabIndex = 3;
            this.serverAddressLabel.Text = "Address";
            // 
            // serverPortTextBox
            // 
            this.serverPortTextBox.Location = new System.Drawing.Point(218, 36);
            this.serverPortTextBox.Name = "serverPortTextBox";
            this.serverPortTextBox.Size = new System.Drawing.Size(100, 20);
            this.serverPortTextBox.TabIndex = 2;
            this.serverPortTextBox.Text = "8888";
            // 
            // serverAddressTextBox
            // 
            this.serverAddressTextBox.Location = new System.Drawing.Point(218, 16);
            this.serverAddressTextBox.Name = "serverAddressTextBox";
            this.serverAddressTextBox.Size = new System.Drawing.Size(100, 20);
            this.serverAddressTextBox.TabIndex = 2;
            this.serverAddressTextBox.Text = "127.0.0.1";
            // 
            // serverLogBox
            // 
            this.serverLogBox.HideSelection = false;
            this.serverLogBox.Location = new System.Drawing.Point(7, 62);
            this.serverLogBox.Name = "serverLogBox";
            this.serverLogBox.ReadOnly = true;
            this.serverLogBox.Size = new System.Drawing.Size(320, 357);
            this.serverLogBox.TabIndex = 1;
            this.serverLogBox.Text = "";
            // 
            // startServerButton
            // 
            this.startServerButton.BackColor = System.Drawing.Color.Green;
            this.startServerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startServerButton.ForeColor = System.Drawing.Color.White;
            this.startServerButton.Location = new System.Drawing.Point(7, 20);
            this.startServerButton.Name = "startServerButton";
            this.startServerButton.Size = new System.Drawing.Size(151, 36);
            this.startServerButton.TabIndex = 0;
            this.startServerButton.Text = "Start";
            this.startServerButton.UseVisualStyleBackColor = false;
            this.startServerButton.Click += new System.EventHandler(this.serverStartButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clientPortLabel);
            this.groupBox2.Controls.Add(this.resourceList);
            this.groupBox2.Controls.Add(this.itemsTotalLabel);
            this.groupBox2.Controls.Add(this.clientPortTextBox);
            this.groupBox2.Controls.Add(this.itemsMissingLabel);
            this.groupBox2.Controls.Add(this.itemsAvailableLabel);
            this.groupBox2.Controls.Add(this.addItemsButton);
            this.groupBox2.Controls.Add(this.adderTextBox);
            this.groupBox2.Controls.Add(this.clientConnectButton);
            this.groupBox2.Controls.Add(this.clientAddressLabel);
            this.groupBox2.Controls.Add(this.clientAddressTextBox);
            this.groupBox2.Location = new System.Drawing.Point(386, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 425);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client";
            // 
            // clientPortLabel
            // 
            this.clientPortLabel.AutoSize = true;
            this.clientPortLabel.Location = new System.Drawing.Point(160, 39);
            this.clientPortLabel.Name = "clientPortLabel";
            this.clientPortLabel.Size = new System.Drawing.Size(26, 13);
            this.clientPortLabel.TabIndex = 3;
            this.clientPortLabel.Text = "Port";
            // 
            // resourceList
            // 
            this.resourceList.FormattingEnabled = true;
            this.resourceList.Location = new System.Drawing.Point(7, 59);
            this.resourceList.Name = "resourceList";
            this.resourceList.Size = new System.Drawing.Size(147, 355);
            this.resourceList.TabIndex = 10;
            this.resourceList.SelectedIndexChanged += new System.EventHandler(this.itemsPicker_SelectedIndexChanged);
            // 
            // itemsTotalLabel
            // 
            this.itemsTotalLabel.AutoSize = true;
            this.itemsTotalLabel.Location = new System.Drawing.Point(170, 92);
            this.itemsTotalLabel.Name = "itemsTotalLabel";
            this.itemsTotalLabel.Size = new System.Drawing.Size(31, 13);
            this.itemsTotalLabel.TabIndex = 9;
            this.itemsTotalLabel.Text = "Total";
            // 
            // clientPortTextBox
            // 
            this.clientPortTextBox.Location = new System.Drawing.Point(211, 36);
            this.clientPortTextBox.Name = "clientPortTextBox";
            this.clientPortTextBox.Size = new System.Drawing.Size(100, 20);
            this.clientPortTextBox.TabIndex = 2;
            this.clientPortTextBox.Text = "8888";
            // 
            // itemsMissingLabel
            // 
            this.itemsMissingLabel.AutoSize = true;
            this.itemsMissingLabel.Location = new System.Drawing.Point(170, 62);
            this.itemsMissingLabel.Name = "itemsMissingLabel";
            this.itemsMissingLabel.Size = new System.Drawing.Size(42, 13);
            this.itemsMissingLabel.TabIndex = 8;
            this.itemsMissingLabel.Text = "Missing";
            // 
            // itemsAvailableLabel
            // 
            this.itemsAvailableLabel.AutoSize = true;
            this.itemsAvailableLabel.Location = new System.Drawing.Point(170, 118);
            this.itemsAvailableLabel.Name = "itemsAvailableLabel";
            this.itemsAvailableLabel.Size = new System.Drawing.Size(50, 13);
            this.itemsAvailableLabel.TabIndex = 6;
            this.itemsAvailableLabel.Text = "Available";
            // 
            // addItemsButton
            // 
            this.addItemsButton.Location = new System.Drawing.Point(160, 357);
            this.addItemsButton.Name = "addItemsButton";
            this.addItemsButton.Size = new System.Drawing.Size(236, 57);
            this.addItemsButton.TabIndex = 2;
            this.addItemsButton.Text = "Add";
            this.addItemsButton.UseVisualStyleBackColor = true;
            this.addItemsButton.Click += new System.EventHandler(this.addItemsButton_Click);
            // 
            // adderTextBox
            // 
            this.adderTextBox.Location = new System.Drawing.Point(262, 115);
            this.adderTextBox.Name = "adderTextBox";
            this.adderTextBox.Size = new System.Drawing.Size(97, 20);
            this.adderTextBox.TabIndex = 3;
            // 
            // clientConnectButton
            // 
            this.clientConnectButton.BackColor = System.Drawing.Color.Green;
            this.clientConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientConnectButton.ForeColor = System.Drawing.Color.White;
            this.clientConnectButton.Location = new System.Drawing.Point(6, 19);
            this.clientConnectButton.Name = "clientConnectButton";
            this.clientConnectButton.Size = new System.Drawing.Size(148, 36);
            this.clientConnectButton.TabIndex = 4;
            this.clientConnectButton.Text = "Connect";
            this.clientConnectButton.UseVisualStyleBackColor = false;
            this.clientConnectButton.Click += new System.EventHandler(this.clientConnectButton_Click);
            // 
            // clientAddressLabel
            // 
            this.clientAddressLabel.AutoSize = true;
            this.clientAddressLabel.Location = new System.Drawing.Point(160, 19);
            this.clientAddressLabel.Name = "clientAddressLabel";
            this.clientAddressLabel.Size = new System.Drawing.Size(45, 13);
            this.clientAddressLabel.TabIndex = 3;
            this.clientAddressLabel.Text = "Address";
            // 
            // clientAddressTextBox
            // 
            this.clientAddressTextBox.Location = new System.Drawing.Point(211, 16);
            this.clientAddressTextBox.Name = "clientAddressTextBox";
            this.clientAddressTextBox.Size = new System.Drawing.Size(100, 20);
            this.clientAddressTextBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Map Art Resource Monitor and Calculator V0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button startServerButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox serverLogBox;
        private System.Windows.Forms.Label serverAddressLabel;
        private System.Windows.Forms.TextBox serverAddressTextBox;
        private System.Windows.Forms.Label clientAddressLabel;
        private System.Windows.Forms.TextBox clientAddressTextBox;
        private System.Windows.Forms.Button clientConnectButton;
        private System.Windows.Forms.Button addItemsButton;
        private System.Windows.Forms.TextBox adderTextBox;
        private System.Windows.Forms.Label itemsAvailableLabel;
        private System.Windows.Forms.Label itemsMissingLabel;
        private System.Windows.Forms.Label itemsTotalLabel;
        private System.Windows.Forms.ListBox resourceList;
        private System.Windows.Forms.Label serverPortLabel;
        private System.Windows.Forms.TextBox serverPortTextBox;
        private System.Windows.Forms.Label clientPortLabel;
        private System.Windows.Forms.TextBox clientPortTextBox;
    }
}

