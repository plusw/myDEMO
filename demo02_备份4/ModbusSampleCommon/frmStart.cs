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
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
        private TextBox receiveBox;
        private Button button4;
        private Button button3;
        private Label label12;
        private TextBox sendBox;
        private Button sendButton;
        private Button button5;
        private Label label13;
        private System.ComponentModel.IContainer components;

        public frmStart()
        {
            InitializeComponent();
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            serialPort1.Encoding = Encoding.GetEncoding("gb2312");//串口接收编码GB2312码
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//忽略程序跨越线程运行导致的错误.没有此句将会产生错误
        }


        #region Vom Windows Form-Designer generierter Code
        private void InitializeComponent()
        {
            this.grpStart = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.sendBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.receiveBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
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
            this.label13 = new System.Windows.Forms.Label();
            this.grpStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpStart
            // 
            this.grpStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStart.Controls.Add(this.label13);
            this.grpStart.Controls.Add(this.button5);
            this.grpStart.Controls.Add(this.sendButton);
            this.grpStart.Controls.Add(this.sendBox);
            this.grpStart.Controls.Add(this.label12);
            this.grpStart.Controls.Add(this.button3);
            this.grpStart.Controls.Add(this.button4);
            this.grpStart.Controls.Add(this.receiveBox);
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
            this.grpStart.Location = new System.Drawing.Point(12, 12);
            this.grpStart.Name = "grpStart";
            this.grpStart.Size = new System.Drawing.Size(2290, 605);
            this.grpStart.TabIndex = 11;
            this.grpStart.TabStop = false;
            this.grpStart.Text = "开始交互数据";
            this.grpStart.Enter += new System.EventHandler(this.grpStart_Enter);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(57, 519);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(139, 49);
            this.button5.TabIndex = 40;
            this.button5.Text = "打开串口";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.BackColor = System.Drawing.SystemColors.Window;
            this.sendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sendButton.Location = new System.Drawing.Point(774, 517);
            this.sendButton.Margin = new System.Windows.Forms.Padding(4);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(87, 58);
            this.sendButton.TabIndex = 39;
            this.sendButton.Text = "发送数据";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // sendBox
            // 
            this.sendBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendBox.Location = new System.Drawing.Point(283, 519);
            this.sendBox.Margin = new System.Windows.Forms.Padding(4);
            this.sendBox.Multiline = true;
            this.sendBox.Name = "sendBox";
            this.sendBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sendBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sendBox.Size = new System.Drawing.Size(440, 56);
            this.sendBox.TabIndex = 38;
            this.sendBox.Text = "16 54 0D";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(663, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 41);
            this.label12.TabIndex = 36;
            this.label12.Text = "none";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(1094, 398);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 49);
            this.button3.TabIndex = 35;
            this.button3.Text = "停止运行";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(925, 398);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 49);
            this.button4.TabIndex = 34;
            this.button4.Text = "开始运行";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // receiveBox
            // 
            this.receiveBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receiveBox.Location = new System.Drawing.Point(899, 57);
            this.receiveBox.Margin = new System.Windows.Forms.Padding(4);
            this.receiveBox.Multiline = true;
            this.receiveBox.Name = "receiveBox";
            this.receiveBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receiveBox.Size = new System.Drawing.Size(323, 236);
            this.receiveBox.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(722, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 49);
            this.button2.TabIndex = 32;
            this.button2.Text = "打开调试界面";
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1026, 539);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 15);
            this.label13.TabIndex = 41;
            this.label13.Text = "二维码";
            // 
            // frmStart
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(1400, 600);
            this.Controls.Add(this.grpStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStart";
            this.Text = "你好深圳 V1.0 深圳海德智能科技";
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
        private void btnWriteSingleReg_Click(object sender, System.EventArgs e)//写D值到plc
        {
            ushort ID = 7;
            byte[] writedDate = new byte[4] ;
            ushort address = ushort.Parse(textBox1.Text);
            byte inputData = (byte)int.Parse(textBox2.Text);
            writedDate[1] = inputData;

            MBmaster.WriteSingleRegister(ID, address, writedDate);//写单个线圈保持寄存器
        }
        private void writeToPlc()//写D值到plc
        {
            ushort ID = 7;
            byte[] writedDate = new byte[4];
            ushort address = ushort.Parse(textBox1.Text);
            //byte inputData = (byte)int.Parse(textBox2.Text);
            byte inputData = (byte)int.Parse("99");
            writedDate[1] = inputData;

            MBmaster.WriteSingleRegister(ID, address, writedDate);//写单个线圈保持寄存器
        }
        String QR_ScanerStatus = "waiting";
        int QR_ScanerTime =0;
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
                    label5.Text = "读取PLC中 D" + txtStartAdress.Text + " 的值为：";
                    label12.Text = varString;
                    if (label12.Text == "13"&&QR_ScanerStatus=="waiting"&&mainStart==true)
                    {
                        QR_ScanerStatus = "working";
                        receiveBox.AppendText("接收到plc扫码信号，正在打开扫码枪去扫码..."+ System.Environment.NewLine);
                        writeToPlc();//给plc发送信号，说明已收到plc扫码信号，让plc关闭扫码信号
                        sendToScaner();

                        // if (result == "") {
                        //}
                    
                    }
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

        private void label2_Click(object sender, EventArgs e){}
        private void label4_Click(object sender, EventArgs e){}
        private void textBox1_TextChanged(object sender, EventArgs e){}
        private void button1_Click(object sender, EventArgs e)//post按钮
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
        private String post(String QR)//post
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
                return result;
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


        private void grpStart_Enter(object sender, EventArgs e)
        {

        }


        ThreadStart childref;//监听plc的线程变量
        Thread childThread;//监听plc的线程变量
        bool mainStart = false;//主程序是否开始
        String text = "";
        private void button4_Click(object sender, EventArgs e)//开始运行按钮
        {
            mainStart = true;
            if (mainStart == true)
            {
                button4.Enabled = false;//按钮是否可以点击
                button3.Enabled = true;
            }
            else {
                button4.Enabled = true;
                button3.Enabled = false;
            }
            
            receiveBox.AppendText("程序开始运行"+ System.Environment.NewLine);

            receiveBox.AppendText("正在连接PLC..." + System.Environment.NewLine);
            btnConnect_Click(sender,e);//调用连接设备按钮,连接设备
            receiveBox.AppendText("plc已联通" + System.Environment.NewLine);
            button5_Click(sender,e);//调用打开串口按钮
            receiveBox.AppendText("扫码枪串口打开成功"+ System.Environment.NewLine);
            childref = new ThreadStart(readPlc);
            childThread = new Thread(childref);
            childThread.Start();
            receiveBox.AppendText("开始监听plc中的D0值..." );
            receiveBox.AppendText("等待plc扫码信号..." + System.Environment.NewLine);
            
        }

        private void button3_Click(object sender, EventArgs e)//停止运行按钮
        {
            mainStart = false;
            if (mainStart == true)
            {
                button4.Enabled = false;
                button3.Enabled = true;
            }
            else {
                button4.Enabled = true;
                button3.Enabled = false;
            }
            receiveBox.AppendText("程序正在结束..." + System.Environment.NewLine);
            button4.Enabled = true;
            childThread.Abort();
            receiveBox.AppendText("已停止监听plc" + System.Environment.NewLine);
        }
        SerialPort serialPort1 = new SerialPort();
       
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)//串口数据接收事件
        {
            
            if (QR_ScanerStatus == "working")
            {
                string revData = serialPort1.ReadExisting();//字符方式读取
                receiveBox.AppendText(revData + System.Environment.NewLine);
                String result = post(revData);
                receiveBox.AppendText("将二维码POST提交后，得到的返回数据是" + result + System.Environment.NewLine);
                
                label13.Text = revData;
               
                QR_ScanerTime++;
                receiveBox.AppendText("已完成第" + QR_ScanerTime + "次扫码" + System.Environment.NewLine);
                receiveBox.AppendText("等待plc扫码信号..." + System.Environment.NewLine);
                QR_ScanerStatus = "waiting";
            }

            
        }
        private void sendButton_Click(object sender, EventArgs e)//串口通过按钮发送数据
        {
            string mystr = sendBox.Text;
            mystr = mystr.Replace("0X", string.Empty);//去掉所有“OX”
            mystr = mystr.Replace(" ", string.Empty);//去掉所有“ ”
            byte[] myBytes = new byte[mystr.Length / 2];//去掉最后的奇数 如0A 06 8。将去掉末尾的8
            for (int i = 0; i < mystr.Length / 2; i++)
            {
                myBytes[i] = Convert.ToByte(mystr.Substring(i * 2, 2), 16);
            }
            /*if (checkNewLine.Checked)
            {
                serialPort1.Write(myBytes, 0, mystr.Length / 2);
                serialPort1.Write(data, 0, 2);
            }
            else*/
            serialPort1.Write(myBytes, 0, mystr.Length / 2);
        }
        private void sendToScaner()//串口发送数据
        {
            string mystr = sendBox.Text;
            mystr = mystr.Replace("0X", string.Empty);//去掉所有“OX”
            mystr = mystr.Replace(" ", string.Empty);//去掉所有“ ”
            byte[] myBytes = new byte[mystr.Length / 2];//去掉最后的奇数 如0A 06 8。将去掉末尾的8
            for (int i = 0; i < mystr.Length / 2; i++)
            {
                myBytes[i] = Convert.ToByte(mystr.Substring(i * 2, 2), 16);
            }
            /*if (checkNewLine.Checked)
            {
                serialPort1.Write(myBytes, 0, mystr.Length / 2);
                serialPort1.Write(data, 0, 2);
            }
            else*/
            serialPort1.Write(myBytes, 0, mystr.Length / 2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)//没有打开
            {
                serialPort1.PortName = "COM3";
                serialPort1.BaudRate = Convert.ToInt32("115200");
                try
                {
                    serialPort1.Open();
                    serialPort1.DataBits = Convert.ToInt32("8");
                    //serialPort1.StopBits = Convert.ToInt32(stopBitSelect.Text);
                    button5.Text = "关闭串口";
                    //return "扫码枪串口打开成功";
                }
                catch
                {
                    serialPort1.Close();
                    MessageBox.Show("串口打开失败", "提示");
                   // return "扫码枪串口打开失败";
                }
            }
            else//关闭
            {
                try
                {
                    serialPort1.Close();
                    button5.Text = "打开串口";
                   // return "扫码枪串口关闭成功";
                }
                catch
                {
                    MessageBox.Show("串口关闭失败", "提示");
//return "扫码枪串口关闭失败";
                }
            }
        }
    }
}
