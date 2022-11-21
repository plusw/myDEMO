namespace ModbusTester
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStartAdress = new System.Windows.Forms.TextBox();
            this.btnReadInpReg = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP地址";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(95, 14);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(116, 25);
            this.txtIP.TabIndex = 9;
            this.txtIP.Text = "192.168.1.88";
            this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIP.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(23, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 22);
            this.label2.TabIndex = 14;
            this.label2.Text = "读取的D几的值:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "测试读取D值";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(145, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 22);
            this.label4.TabIndex = 20;
            this.label4.Text = "D";
            // 
            // txtStartAdress
            // 
            this.txtStartAdress.Location = new System.Drawing.Point(166, 130);
            this.txtStartAdress.Name = "txtStartAdress";
            this.txtStartAdress.Size = new System.Drawing.Size(33, 25);
            this.txtStartAdress.TabIndex = 21;
            this.txtStartAdress.Text = "0";
            this.txtStartAdress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnReadInpReg
            // 
            this.btnReadInpReg.Location = new System.Drawing.Point(26, 177);
            this.btnReadInpReg.Name = "btnReadInpReg";
            this.btnReadInpReg.Size = new System.Drawing.Size(139, 49);
            this.btnReadInpReg.TabIndex = 22;
            this.btnReadInpReg.Text = "读取PLC中的D值";
            this.btnReadInpReg.Click += new System.EventHandler(this.btnReadInpReg_Click_1);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(22, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(279, 41);
            this.label5.TabIndex = 23;
            this.label5.Text = "读取PLC中 D 的值为";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(404, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 19);
            this.label6.TabIndex = 24;
            this.label6.Text = "测试写入D值";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(404, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 22);
            this.label7.TabIndex = 25;
            this.label7.Text = "写入的D几的值:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(526, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 22);
            this.label8.TabIndex = 26;
            this.label8.Text = "D";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(547, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 25);
            this.textBox1.TabIndex = 27;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(787, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(182, 19);
            this.label9.TabIndex = 29;
            this.label9.Text = "测试Post请求到接口";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(787, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 22);
            this.label10.TabIndex = 30;
            this.label10.Text = "POST到接口地址:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(914, 130);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(350, 25);
            this.textBox3.TabIndex = 31;
            this.textBox3.Text = "http://localhost:8080/web-demo/searchSong";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(785, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 49);
            this.button1.TabIndex = 32;
            this.button1.Text = "提交POST请求";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(787, 247);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(182, 19);
            this.label11.TabIndex = 33;
            this.label11.Text = "得到接口返回的结果:";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(787, 285);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(323, 288);
            this.label12.TabIndex = 34;
            this.label12.Text = "result data";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(250, 8);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(138, 38);
            this.btnConnect.TabIndex = 35;
            this.btnConnect.Text = "连接设备";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click_1);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(423, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 19);
            this.label13.TabIndex = 36;
            this.label13.Text = "设备连接状态: ";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(526, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 19);
            this.label14.TabIndex = 37;
            this.label14.Text = "未连通";
            this.label14.Click += new System.EventHandler(this.label14_Click_1);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(406, 177);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 22);
            this.label15.TabIndex = 38;
            this.label15.Text = "写入的数值为:";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(526, 177);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 22);
            this.label16.TabIndex = 39;
            this.label16.Text = "D";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(547, 174);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(33, 25);
            this.textBox2.TabIndex = 40;
            this.textBox2.Text = "9";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(426, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 49);
            this.button2.TabIndex = 41;
            this.button2.Text = "将D值写入PLC";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 600);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnReadInpReg);
            this.Controls.Add(this.txtStartAdress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStartAdress;
        private System.Windows.Forms.Button btnReadInpReg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox txtIP;
        public System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button2;
    }
}