namespace sp3
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSerial = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TP_Stop = new System.Windows.Forms.ComboBox();
            this.TP_Parity = new System.Windows.Forms.ComboBox();
            this.TP_DataBits = new System.Windows.Forms.ComboBox();
            this.TP_BaudRate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TP_Send = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.TP_Received = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口：";
            // 
            // cbSerial
            // 
            this.cbSerial.FormattingEnabled = true;
            this.cbSerial.Location = new System.Drawing.Point(96, 40);
            this.cbSerial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSerial.Name = "cbSerial";
            this.cbSerial.Size = new System.Drawing.Size(121, 23);
            this.cbSerial.TabIndex = 1;
            this.cbSerial.Text = "COM3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(291, 40);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "打开串口";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TP_Stop);
            this.groupBox1.Controls.Add(this.TP_Parity);
            this.groupBox1.Controls.Add(this.TP_DataBits);
            this.groupBox1.Controls.Add(this.TP_BaudRate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(41, 136);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(419, 191);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // TP_Stop
            // 
            this.TP_Stop.FormattingEnabled = true;
            this.TP_Stop.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2",
            "无"});
            this.TP_Stop.Location = new System.Drawing.Point(293, 116);
            this.TP_Stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TP_Stop.Name = "TP_Stop";
            this.TP_Stop.Size = new System.Drawing.Size(85, 23);
            this.TP_Stop.TabIndex = 7;
            this.TP_Stop.Text = "1";
            // 
            // TP_Parity
            // 
            this.TP_Parity.FormattingEnabled = true;
            this.TP_Parity.Items.AddRange(new object[] {
            "偶校验",
            "奇校验",
            "无"});
            this.TP_Parity.Location = new System.Drawing.Point(293, 51);
            this.TP_Parity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TP_Parity.Name = "TP_Parity";
            this.TP_Parity.Size = new System.Drawing.Size(85, 23);
            this.TP_Parity.TabIndex = 6;
            this.TP_Parity.Text = "None";
            // 
            // TP_DataBits
            // 
            this.TP_DataBits.FormattingEnabled = true;
            this.TP_DataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5",
            "4"});
            this.TP_DataBits.Location = new System.Drawing.Point(105, 116);
            this.TP_DataBits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TP_DataBits.Name = "TP_DataBits";
            this.TP_DataBits.Size = new System.Drawing.Size(87, 23);
            this.TP_DataBits.TabIndex = 5;
            this.TP_DataBits.Text = "8";
            // 
            // TP_BaudRate
            // 
            this.TP_BaudRate.FormattingEnabled = true;
            this.TP_BaudRate.Items.AddRange(new object[] {
            "256000",
            "128000",
            "115200",
            "57600",
            "38400",
            "28800",
            "19200",
            "14400",
            "9600",
            "4800",
            "1200",
            "600"});
            this.TP_BaudRate.Location = new System.Drawing.Point(105, 52);
            this.TP_BaudRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TP_BaudRate.Name = "TP_BaudRate";
            this.TP_BaudRate.Size = new System.Drawing.Size(87, 23);
            this.TP_BaudRate.TabIndex = 4;
            this.TP_BaudRate.Text = "115200";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "停止位：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "校验位：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "数据位：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "波特率：";
            // 
            // TP_Send
            // 
            this.TP_Send.Location = new System.Drawing.Point(41, 359);
            this.TP_Send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TP_Send.Multiline = true;
            this.TP_Send.Name = "TP_Send";
            this.TP_Send.Size = new System.Drawing.Size(419, 112);
            this.TP_Send.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(63, 494);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 46);
            this.button2.TabIndex = 5;
            this.button2.Text = "发送";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TP_Received
            // 
            this.TP_Received.Location = new System.Drawing.Point(517, 85);
            this.TP_Received.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TP_Received.Multiline = true;
            this.TP_Received.Name = "TP_Received";
            this.TP_Received.Size = new System.Drawing.Size(247, 358);
            this.TP_Received.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(169, 494);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 46);
            this.button3.TabIndex = 7;
            this.button3.Text = "开始接收";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 668);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.TP_Received);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TP_Send);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbSerial);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSerial;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TP_Stop;
        private System.Windows.Forms.ComboBox TP_Parity;
        private System.Windows.Forms.ComboBox TP_DataBits;
        private System.Windows.Forms.ComboBox TP_BaudRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TP_Send;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TP_Received;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button3;





    }
}

