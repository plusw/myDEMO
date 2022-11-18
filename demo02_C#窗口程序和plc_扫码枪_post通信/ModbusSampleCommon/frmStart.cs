using System;
using System.Windows.Forms;
using ModbusTCP;
using System.Net;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using ModbusTester;
using System.Threading;

namespace Modbus
{
    public class frmStart : System.Windows.Forms.Form
    {
        Form3 window2 = new Form3();
        private ModbusTCP.Master MBmaster;
        private TextBox txtData;
        private Label labData;
        private byte[] data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartAdress;
        private System.Windows.Forms.GroupBox grpStart;
        private System.Windows.Forms.Button btnReadInpReg;
        private Label label5;
        private Label label4;
        private Label label6;
        private Button btnWriteSingleReg;
        private TextBox textBox1;
        private Label label8;
        private Label label7;
        private Label label3;
        private Label label9;
        private TextBox textBox2;
        private Button button1;
        private TextBox textBox3;
        private Label label10;
        private Label label11;
        private Button button2;
        private Button button3;
        private System.ComponentModel.IContainer components;

        public frmStart()
        {
            InitializeComponent();
        }



        #region Vom Windows Form-Designer generierter Code
        private void InitializeComponent()
        {
            this.grpStart = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnWriteSingleReg = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReadInpReg = new System.Windows.Forms.Button();
            this.txtStartAdress = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.grpStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpStart
            // 
            this.grpStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStart.Controls.Add(this.button3);
            this.grpStart.Controls.Add(this.button2);
            this.grpStart.Controls.Add(this.label11);
            this.grpStart.Controls.Add(this.button1);
            this.grpStart.Controls.Add(this.textBox3);
            this.grpStart.Controls.Add(this.label10);
            this.grpStart.Controls.Add(this.label9);
            this.grpStart.Controls.Add(this.textBox2);
            this.grpStart.Controls.Add(this.textBox1);
            this.grpStart.Controls.Add(this.label8);
            this.grpStart.Controls.Add(this.label7);
            this.grpStart.Controls.Add(this.btnWriteSingleReg);
            this.grpStart.Controls.Add(this.label6);
            this.grpStart.Controls.Add(this.label4);
            this.grpStart.Controls.Add(this.label3);
            this.grpStart.Controls.Add(this.label5);
            this.grpStart.Controls.Add(this.label1);
            this.grpStart.Controls.Add(this.btnConnect);
            this.grpStart.Controls.Add(this.txtIP);
            this.grpStart.Controls.Add(this.label2);
            this.grpStart.Controls.Add(this.btnReadInpReg);
            this.grpStart.Controls.Add(this.txtStartAdress);
            this.grpStart.Location = new System.Drawing.Point(11, -17);
            this.grpStart.Name = "grpStart";
            this.grpStart.Size = new System.Drawing.Size(1264, 632);
            this.grpStart.TabIndex = 11;
            this.grpStart.TabStop = false;
            this.grpStart.Text = "开始交互数据";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(59, 482);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 22);
            this.label11.TabIndex = 31;
            this.label11.Text = "数据";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(712, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 49);
            this.button1.TabIndex = 30;
            this.button1.Text = "POST";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(202, 422);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(452, 25);
            this.textBox3.TabIndex = 29;
            this.textBox3.Text = "http://localhost:8080/web-demo/searchSong";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(59, 425);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 22);
            this.label10.TabIndex = 28;
            this.label10.Text = "POST到接口地址:";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(59, 349);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 22);
            this.label9.TabIndex = 27;
            this.label9.Text = "写入的数值为:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(202, 346);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(33, 25);
            this.textBox2.TabIndex = 26;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(202, 283);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 25);
            this.textBox1.TabIndex = 25;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(181, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 22);
            this.label8.TabIndex = 24;
            this.label8.Text = "D";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(59, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 22);
            this.label7.TabIndex = 23;
            this.label7.Text = "写入的D几的值:";
            // 
            // btnWriteSingleReg
            // 
            this.btnWriteSingleReg.Location = new System.Drawing.Point(283, 297);
            this.btnWriteSingleReg.Name = "btnWriteSingleReg";
            this.btnWriteSingleReg.Size = new System.Drawing.Size(139, 49);
            this.btnWriteSingleReg.TabIndex = 22;
            this.btnWriteSingleReg.Text = "将D值写入PLC";
            this.btnWriteSingleReg.Click += new System.EventHandler(this.btnWriteSingleReg_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(587, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 19);
            this.label6.TabIndex = 21;
            this.label6.Text = "未连通";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(476, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 19);
            this.label4.TabIndex = 20;
            this.label4.Text = "设备连接状态: ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(181, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 22);
            this.label3.TabIndex = 19;
            this.label3.Text = "D";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(443, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(279, 41);
            this.label5.TabIndex = 8;
            this.label5.Text = "读取PLC中 D 的值为";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "IP地址";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(299, 30);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(138, 38);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "连接设备";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(149, 35);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(139, 25);
            this.txtIP.TabIndex = 5;
            this.txtIP.Text = "192.168.1.88";
            this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIP.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(59, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "读取的D几的值:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnReadInpReg
            // 
            this.btnReadInpReg.Location = new System.Drawing.Point(283, 173);
            this.btnReadInpReg.Name = "btnReadInpReg";
            this.btnReadInpReg.Size = new System.Drawing.Size(139, 49);
            this.btnReadInpReg.TabIndex = 18;
            this.btnReadInpReg.Text = "读取PLC中的D值";
            this.btnReadInpReg.Click += new System.EventHandler(this.btnReadInpReg_Click);
            // 
            // txtStartAdress
            // 
            this.txtStartAdress.Location = new System.Drawing.Point(202, 187);
            this.txtStartAdress.Name = "txtStartAdress";
            this.txtStartAdress.Size = new System.Drawing.Size(33, 25);
            this.txtStartAdress.TabIndex = 12;
            this.txtStartAdress.Text = "0";
            this.txtStartAdress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStartAdress.TextChanged += new System.EventHandler(this.txtStartAdress_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(922, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 49);
            this.button2.TabIndex = 32;
            this.button2.Text = "打开调试界面";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(934, 163);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 49);
            this.button3.TabIndex = 33;
            this.button3.Text = "开始运行";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmStart
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(1284, 544);
            this.Controls.Add(this.grpStart);
            this.Name = "frmStart";
            this.Text = "ModbusTCP  V1.0   锋利科技 QQ：2189690376";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmStart_Closing);
            this.grpStart.ResumeLayout(false);
            this.grpStart.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        [STAThread]
        static void Main()
        {
            Application.Run(new frmStart());
        }


        // ------------------------------------------------------------------------
        // Programm start程序启动
        // ------------------------------------------------------------------------


        // ------------------------------------------------------------------------
        // Programm stop程序停止
        // ------------------------------------------------------------------------
        private void frmStart_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MBmaster != null)
            {
                MBmaster.Dispose();
                MBmaster = null;
            }
            Application.Exit();
        }

        // Button connect按下链接设备按钮
        private void btnConnect_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Create new modbus master and add event functions
                MBmaster = new Master(txtIP.Text, 502);
                MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData);
                MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);
                // Show additional fields, enable watchdog
                label6.Text = "已连通";

            }
            catch (SystemException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnReadInpReg_Click(object sender, System.EventArgs e)//可以读
        {
            ushort ID = 4;
            ushort StartAddress = ReadStartAdr();//开始地址，从输入框里读到
            ushort slaveAddress = 0;
            MBmaster.ReadInputRegister(ID, StartAddress, 1, slaveAddress);//读AI的值
        }
        private void btnWriteSingleReg_Click(object sender, System.EventArgs e)
        {
            ushort ID = 7;


            byte[] writedDate = new byte[] { 3, 75, 3, 4, 5, 6, 7, 8, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            ushort address = ushort.Parse(textBox1.Text);
            byte inputData = (byte)int.Parse(textBox2.Text);
            writedDate[1] = inputData;
            //  label10.Text = Convert.ToString(index);
            // label11.Text = Convert.ToString(inputData);
            MBmaster.WriteSingleRegister(ID, address, writedDate);//写单个线圈保持寄存器
        }


        private void MBmaster_OnResponseData(ushort ID, byte function, byte[] values)
        {
            // ------------------------------------------------------------------
            // Seperate calling threads
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData), new object[] { ID, function, values });
                return;
            }

            // Ignore watchdog response data
            if (ID == 0xFF) return;

            // ------------------------------------------------------------------------
            // Identify requested data
            switch (ID)
            {
                case 4:

                    data = values;

                    //string str = System.Text.Encoding.UTF8.GetString(data);
                    string varString = Convert.ToString(data[1]);
                    label5.Text = "读取PLC中 D" + txtStartAdress.Text + " 的值为：" + varString;
                    break;
            }
        }
        private void MBmaster_OnException(ushort id, byte function, byte exception)
        {
            // ------------------------------------------------------------------
            // Seperate calling threads
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ModbusTCP.Master.ExceptionData(MBmaster_OnException), new object[] { id, function, exception });
                return;
            }

            string exc = "Modbus says error: ";
            switch (exception)
            {
                case Master.excIllegalFunction: exc += "Illegal function!"; break;
                case Master.excIllegalDataAdr: exc += "Illegal data adress!"; break;
                case Master.excIllegalDataVal: exc += "Illegal data value!"; break;
                case Master.excSlaveDeviceFailure: exc += "Slave device failure!"; break;
                case Master.excAck: exc += "Acknoledge!"; break;
                case Master.excSlaveIsBusy: exc += "Slave is busy!"; break;
                case Master.excGatePathUnavailable: exc += "Gateway path unavailbale!"; break;
                case Master.excExceptionTimeout: exc += "Slave timed out!"; break;
                case Master.excExceptionConnectionLost: exc += "Connection is lost!"; break;
                case Master.excExceptionNotConnected: exc += "Not connected!"; break;
            }

            MessageBox.Show(exc, "Modbus slave exception");
        }

        // ------------------------------------------------------------------------
        // Generate new number of text boxes创建标签及文本显示控件
        // ------------------------------------------------------------------------


        // ------------------------------------------------------------------------
        // Resize form elements 如果数据显示控件状态为显示，就调用生成数据区功能
        // ------------------------------------------------------------------------

        // ------------------------------------------------------------------------
        // Read start address 读取起始地址
        // ------------------------------------------------------------------------
        private ushort ReadStartAdr()
        {
            // Convert hex numbers into decimal
            if (txtStartAdress.Text.IndexOf("0x", 0, txtStartAdress.Text.Length) == 0)
            {
                string str = txtStartAdress.Text.Replace("0x", "");
                ushort hex = Convert.ToUInt16(str, 16);
                return hex;
            }
            else
            {
                return Convert.ToUInt16(txtStartAdress.Text);
            }
        }


        // Show values in selected way显示读取的数值
        // ------------------------------------------------------------------------

        // ------------------------------------------------------------------------
        // Put new data into text boxes
        //放新数据到text文本框中


        // ------------------------------------------------------------------------
        // Call watchdog reset every 500 ms
        // ------------------------------------------------------------------------


        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReadDisInp_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtStartAdress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:8080/web-demo/searchSong";

            using (HttpClient httpClient = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.None,
                ClientCertificateOptions = ClientCertificateOption.Automatic
            }))
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("singer", "林俊杰");
                httpClient.BaseAddress = new Uri(url);
                FormUrlEncodedContent content = new FormUrlEncodedContent(data);
                String result = httpClient.PostAsync(url, content).Result.Content.ReadAsStringAsync().Result;
                label2.Text = result;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            window2.Show();
        }
        private void readPlc()
        {
            while (true)
            {
                Thread.Sleep(1000);
                ushort ID = 4;
                ushort StartAddress = 0;//开始地址，从输入框里读到
                ushort slaveAddress = 0;
                MBmaster.ReadInputRegister(ID, StartAddress, 1, slaveAddress);//读AI的值
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始运行");
            ThreadStart childref = new ThreadStart(readPlc);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread = new Thread(childref);
            childThread.Start();
            //监听plc
        }
    }
}
