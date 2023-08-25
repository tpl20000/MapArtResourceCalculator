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
            this.serverAddressLabel = new System.Windows.Forms.Label();
            this.serverAddressTextBox = new System.Windows.Forms.TextBox();
            this.serverLogBox = new System.Windows.Forms.RichTextBox();
            this.startServerButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clientConnectButton = new System.Windows.Forms.Button();
            this.clientAddressLabel = new System.Windows.Forms.Label();
            this.clientAddressTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.serverAddressLabel);
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
            // serverAddressLabel
            // 
            this.serverAddressLabel.AutoSize = true;
            this.serverAddressLabel.Location = new System.Drawing.Point(165, 30);
            this.serverAddressLabel.Name = "serverAddressLabel";
            this.serverAddressLabel.Size = new System.Drawing.Size(45, 13);
            this.serverAddressLabel.TabIndex = 3;
            this.serverAddressLabel.Text = "Address";
            // 
            // serverAddressTextBox
            // 
            this.serverAddressTextBox.Location = new System.Drawing.Point(216, 27);
            this.serverAddressTextBox.Name = "serverAddressTextBox";
            this.serverAddressTextBox.Size = new System.Drawing.Size(100, 20);
            this.serverAddressTextBox.TabIndex = 2;
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
            this.startServerButton.Font = new System.Drawing.Font("Anonymous Pro", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // clientConnectButton
            // 
            this.clientConnectButton.BackColor = System.Drawing.Color.Green;
            this.clientConnectButton.Font = new System.Drawing.Font("Anonymous Pro", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.clientAddressLabel.Location = new System.Drawing.Point(160, 30);
            this.clientAddressLabel.Name = "clientAddressLabel";
            this.clientAddressLabel.Size = new System.Drawing.Size(45, 13);
            this.clientAddressLabel.TabIndex = 3;
            this.clientAddressLabel.Text = "Address";
            // 
            // clientAddressTextBox
            // 
            this.clientAddressTextBox.Location = new System.Drawing.Point(211, 27);
            this.clientAddressTextBox.Name = "clientAddressTextBox";
            this.clientAddressTextBox.Size = new System.Drawing.Size(100, 20);
            this.clientAddressTextBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Map Art Resource Monitor and Calculator V0.1";
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
    }
}

