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
using System.Resources;
using System.Net.NetworkInformation;

namespace Modbus
{
    public class frmStart : System.Windows.Forms.Form
    {

        String plc_address="";

        String left_port = "";

        String recieve_plc_qr_sign_address_left = "";
        String recieve_plc_qr_sign_value_left = "";

        String qr_completed_sign_address_left = "";
        String qr_completed_sign_value_left = "";

        String qr_timeOut_sign_address_left = "";
        String qr_timeOut_sign_value_left = "";

        String right_port = "";

        String recieve_plc_qr_sign_address_right = "";
        String recieve_plc_qr_sign_value_right = "";

        String qr_completed_sign_address_right = "";
        String qr_completed_sign_value_right = "";

        String qr_timeOut_sign_address_right = "";
        String qr_timeOut_sign_value_right = "";


        String qr_timeOut_time = "";
        
        String post_url = "";

        //String qr_timeOut_sign_address = "";
        //String qr_timeOut_sign_value = "";


        long workStartTime_left= new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();//置为当前时间
        long workStartTime_right = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();//置为当前时间
        //long workStartTime = 0;
        long workedTime_left = 0;
        long nowTime_left = 0;
        long workedTime_right = 0;
        long nowTime_right = 0;
        System.DateTime currentTime = new System.DateTime();
        
        private ModbusTCP.Master MBmaster;
        private TextBox txtData;
        private Label labData;
        private byte[] data;
        private Label label5;
        private Label label4;
        private Label label6;
        private Button button2;
        private TextBox receiveBox;
        private Button button4;
        private Label label12;
        private System.Windows.Forms.GroupBox grpStart;
        private Button button1;
        private Label label2;
        private Label label3;
        private Button button3;
        private Label label8;
        private Label label7;
        private Label label10;
        private Label label9;
        private System.ComponentModel.IContainer components;
        private Label label11;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label1;
        private Label label17;
        private Label label18;
        private Label label22;
        private Label label21;
        private Label label20;
        private Label label19;
        static string iniPath = Environment.CurrentDirectory + "\\config.ini";
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string node, string key, string value, StringBuilder result, int size, string filePath);
  
        private void readConfig()
        {
            //声明接收的数据
            StringBuilder builder = new StringBuilder(1024);
            int len = GetPrivateProfileString("plc地址", "PLC IP地址", "", builder, 1024, iniPath);
            plc_address = builder.ToString();

            //左扫码信号
            len = GetPrivateProfileString("左扫码枪串口号", "串口号", "", builder, 1024, iniPath);
            left_port = builder.ToString();

            len = GetPrivateProfileString("左触发扫码信号", "将D几作为扫码触发标志", "", builder, 1024, iniPath);
            recieve_plc_qr_sign_address_left = builder.ToString();
            len = GetPrivateProfileString("左触发扫码信号", "接收扫码信号D值", "", builder, 1024, iniPath);
            recieve_plc_qr_sign_value_left = builder.ToString();

            len = GetPrivateProfileString("左扫码完成信号", "将D几作为扫码完成标志", "", builder, 1024, iniPath);
            qr_completed_sign_address_left = builder.ToString();
            len = GetPrivateProfileString("左扫码完成信号", "扫码完成标志D值", "", builder, 1024, iniPath);
            qr_completed_sign_value_left = builder.ToString();

            len = GetPrivateProfileString("左扫码超时信号", "将D几作为扫码超时标志", "", builder, 1024, iniPath);
            qr_timeOut_sign_address_left = builder.ToString();
            len = GetPrivateProfileString("左扫码超时信号", "扫码超时标志D值", "", builder, 1024, iniPath);
            qr_timeOut_sign_value_left = builder.ToString();
            //右扫码信号
            len = GetPrivateProfileString("右扫码枪串口号", "串口号", "", builder, 1024, iniPath);
            right_port = builder.ToString();

            len = GetPrivateProfileString("右触发扫码信号", "将D几作为扫码触发标志", "", builder, 1024, iniPath);
            recieve_plc_qr_sign_address_right = builder.ToString();
            len = GetPrivateProfileString("右触发扫码信号", "接收扫码信号D值", "", builder, 1024, iniPath);
            recieve_plc_qr_sign_value_right = builder.ToString();

            len = GetPrivateProfileString("右扫码完成信号", "将D几作为扫码完成标志", "", builder, 1024, iniPath);
            qr_completed_sign_address_right = builder.ToString();
            len = GetPrivateProfileString("右扫码完成信号", "扫码完成标志D值", "", builder, 1024, iniPath);
            qr_completed_sign_value_right = builder.ToString();

            len = GetPrivateProfileString("右扫码超时信号", "将D几作为扫码超时标志", "", builder, 1024, iniPath);
            qr_timeOut_sign_address_right = builder.ToString();
            len = GetPrivateProfileString("右扫码超时信号", "扫码超时标志D值", "", builder, 1024, iniPath);
            qr_timeOut_sign_value_right = builder.ToString();


            len = GetPrivateProfileString("扫码超时时长", "扫码超过多少秒为超时", "", builder, 1024, iniPath);
            qr_timeOut_time = builder.ToString();

            len = GetPrivateProfileString("POST地址", "POST到接口地址", "", builder, 1024, iniPath);
            post_url = builder.ToString();

            label2.Text = "PING " + plc_address;

            label21.Text = left_port;

            label22.Text = right_port;
            //Console.WriteLine(recieve_plc_qr_sign_address_left);

        }

        public frmStart()
        {
            InitializeComponent();

            readConfig();//读取配置

            receiveBox.AppendText("正在连接PLC..." + System.Environment.NewLine);
            connectToPLC();//连接PLC
            //receiveBox.AppendText("plc已联通" + System.Environment.NewLine);
           
            //开启监听plc线程
            childref = new ThreadStart(readPlc);
            childThread = new Thread(childref);
            childThread.Start();
            

            //开启ping plc ip检测线程
            childref2 = new ThreadStart(ping_IP);
            childThread2 = new Thread(childref2);
            childThread2.Start();
            
            //扫码枪串口事件
            //左扫码枪
            serialPortLeft.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            serialPortLeft.Encoding = Encoding.GetEncoding("gb2312");//串口接收编码GB2312码
            //右扫码枪
            serialPortRight.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived_right);
            serialPortRight.Encoding = Encoding.GetEncoding("gb2312");//串口接收编码GB2312码

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//忽略程序跨越线程运行导致的错误.没有此句将会产生错误
       
        }
        public void ping_IP() {
            while (true)
            {
                //Console.WriteLine(MBmaster);
                Thread.Sleep(500);
                string ip = plc_address;
                bool result = IPTools.PingIpOrDomainName(ip);
               // Console.WriteLine("ping {0} result is {1}!", ip, result);
                if (result == true)
                {
                    label3.Text = "已ping通";
                }
                if (result == false)
                {
                    label3.Text = "未ping通";
                    label6.Text = "plc未连通";
                }
                //return result;
            }
        }


        #region Vom Windows Form-Designer generierter Code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.receiveBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.grpStart = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.grpStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(23, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(279, 41);
            this.label5.TabIndex = 8;
            this.label5.Text = "读取PLC中 D 的值为";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(23, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 19);
            this.label4.TabIndex = 20;
            this.label4.Text = "设备连接状态: ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(162, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 19);
            this.label6.TabIndex = 21;
            this.label6.Text = "未连通";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(70, 546);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 49);
            this.button2.TabIndex = 32;
            this.button2.Text = "打开调试界面";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // receiveBox
            // 
            this.receiveBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receiveBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.receiveBox.Location = new System.Drawing.Point(381, 25);
            this.receiveBox.Margin = new System.Windows.Forms.Padding(4);
            this.receiveBox.Multiline = true;
            this.receiveBox.Name = "receiveBox";
            this.receiveBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receiveBox.Size = new System.Drawing.Size(537, 580);
            this.receiveBox.TabIndex = 12;
            this.receiveBox.TextChanged += new System.EventHandler(this.receiveBox_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(447, 625);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 49);
            this.button4.TabIndex = 34;
            this.button4.Text = "开始运行";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(204, 209);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 41);
            this.label12.TabIndex = 36;
            this.label12.Text = "none";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // grpStart
            // 
            this.grpStart.AccessibleRole = System.Windows.Forms.AccessibleRole.Animation;
            this.grpStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStart.Controls.Add(this.label22);
            this.grpStart.Controls.Add(this.label21);
            this.grpStart.Controls.Add(this.label20);
            this.grpStart.Controls.Add(this.label19);
            this.grpStart.Controls.Add(this.label17);
            this.grpStart.Controls.Add(this.label18);
            this.grpStart.Controls.Add(this.label16);
            this.grpStart.Controls.Add(this.label15);
            this.grpStart.Controls.Add(this.label14);
            this.grpStart.Controls.Add(this.label13);
            this.grpStart.Controls.Add(this.label1);
            this.grpStart.Controls.Add(this.label11);
            this.grpStart.Controls.Add(this.label10);
            this.grpStart.Controls.Add(this.label9);
            this.grpStart.Controls.Add(this.label8);
            this.grpStart.Controls.Add(this.label7);
            this.grpStart.Controls.Add(this.label3);
            this.grpStart.Controls.Add(this.label2);
            this.grpStart.Controls.Add(this.button1);
            this.grpStart.Controls.Add(this.label12);
            this.grpStart.Controls.Add(this.button3);
            this.grpStart.Controls.Add(this.button4);
            this.grpStart.Controls.Add(this.receiveBox);
            this.grpStart.Controls.Add(this.button2);
            this.grpStart.Controls.Add(this.label6);
            this.grpStart.Controls.Add(this.label4);
            this.grpStart.Controls.Add(this.label5);
            this.grpStart.Location = new System.Drawing.Point(12, 12);
            this.grpStart.Name = "grpStart";
            this.grpStart.Size = new System.Drawing.Size(960, 697);
            this.grpStart.TabIndex = 11;
            this.grpStart.TabStop = false;
            this.grpStart.Text = "开始交互数据";
            this.grpStart.Enter += new System.EventHandler(this.grpStart_Enter);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(100, 379);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 18);
            this.label22.TabIndex = 61;
            this.label22.Text = "COM";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(100, 184);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 18);
            this.label21.TabIndex = 60;
            this.label21.Text = "COM";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(23, 184);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 18);
            this.label20.TabIndex = 59;
            this.label20.Text = "串口号:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(23, 379);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 18);
            this.label19.TabIndex = 58;
            this.label19.Text = "串口号:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(121, 475);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 18);
            this.label17.TabIndex = 57;
            this.label17.Text = "0秒";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(23, 475);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 18);
            this.label18.TabIndex = 56;
            this.label18.Text = "扫码时长:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(136, 438);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(190, 23);
            this.label16.TabIndex = 55;
            this.label16.Text = "connection lost";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(23, 443);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 18);
            this.label15.TabIndex = 54;
            this.label15.Text = "扫码枪状态:";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(204, 406);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 41);
            this.label14.TabIndex = 53;
            this.label14.Text = "none";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(23, 411);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(279, 41);
            this.label13.TabIndex = 52;
            this.label13.Text = "读取PLC中 D 的值为";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 51;
            this.label1.Text = "右扫码枪";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(23, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 50;
            this.label11.Text = "左扫码枪";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(121, 285);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 18);
            this.label10.TabIndex = 49;
            this.label10.Text = "0秒";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(23, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 18);
            this.label9.TabIndex = 48;
            this.label9.Text = "扫码时长:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(136, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(190, 23);
            this.label8.TabIndex = 47;
            this.label8.Text = "connection lost";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(23, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 18);
            this.label7.TabIndex = 46;
            this.label7.Text = "扫码枪状态:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(205, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 45;
            this.label3.Text = "未ping通";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(23, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 44;
            this.label2.Text = "PING";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 625);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 49);
            this.button1.TabIndex = 43;
            this.button1.Text = "打开参数设置界面";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(641, 625);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 49);
            this.button3.TabIndex = 35;
            this.button3.Text = "停止运行";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmStart
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(1000, 721);
            this.Controls.Add(this.grpStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStart";
            this.Text = "你好深圳 V1.0  深圳海德智能科技  科技改变未来";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmStart_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.frmStart_Load);
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
        private void frmStart_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MBmaster != null)
            {
                MBmaster.Dispose();
                MBmaster = null;
            }
            Application.Exit();
        }
       
        private void connectToPLC()//连接plc
        {
            try
            {
                MBmaster = new Master(plc_address, 502);
                MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData);
                MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);
                label6.Text = "plc已连通";

            }
            catch (SystemException error)
            {
                MessageBox.Show(error.Message);
                //MessageBox.Show("连接plc失败");
            }
        }
        private void writeToPlc(String address,String value)//写D值到plc
        {
            ushort ID = 7;
            byte[] writedDate = new byte[4];
            ushort address_D = ushort.Parse(address);
            byte inputData = (byte)int.Parse(value);
            writedDate[1] = inputData;

            MBmaster.WriteSingleRegister(ID, address_D, writedDate);//写单个线圈保持寄存器
        }
        int QR_ScanerTime = 0;
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
                //左扫码枪
                case 4:
                    data = values;
                    //string str = System.Text.Encoding.UTF8.GetString(data);
                    string varString = Convert.ToString(data[1]);
                    label5.Text = "读取PLC中 D"+ recieve_plc_qr_sign_address_left + " 的值为：";
                    
                    label12.Text = varString;
                    if (label12.Text == recieve_plc_qr_sign_value_left && label8.Text == "waiting" && mainStart == true&& label6.Text == "plc已连通")
                    {
                        label8.Text = "working";
                        receiveBox.AppendText("接收到plc扫码信号，正在打开 左 扫码枪去扫码..." + System.Environment.NewLine);
                        sendToScanerLeft("16 54 0D"); //触发扫码枪扫码
                        workStartTime_left =new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

                        
                    }
                    break;
                //右扫码枪
                case 5:
                    data = values;
                    //string str = System.Text.Encoding.UTF8.GetString(data);
                    string varString2 = Convert.ToString(data[1]);
                    label13.Text = "读取PLC中 D"+ recieve_plc_qr_sign_address_right + " 的值为：";
                    label14.Text = varString2;
                    if (label14.Text == recieve_plc_qr_sign_value_right && label16.Text == "waiting" && mainStart == true && label6.Text == "plc已连通")
                    {
                        label16.Text = "working";
                        receiveBox.AppendText("接收到plc扫码信号，正在打开 右 扫码枪去扫码..." + System.Environment.NewLine);
                        sendToScanerRight("16 54 0D"); //触发扫码枪扫码
                        workStartTime_right = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();


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
                case Master.excIllegalFunction: exc = "Illegal function!"; break;
                case Master.excIllegalDataAdr: exc = "Illegal data adress!"; break;
                case Master.excIllegalDataVal: exc = "Illegal data value!"; break;
                case Master.excSlaveDeviceFailure: exc = "Slave device failure!"; break;
                case Master.excAck: exc = "Acknoledge!"; break;
                case Master.excSlaveIsBusy: exc = "Slave is busy!"; break;
                case Master.excGatePathUnavailable: exc = "Gateway path unavailbale!"; break;
                case Master.excExceptionTimeout: exc = "Slave timed out!"; break;
                case Master.excExceptionConnectionLost: exc = "Connection is lost!"; break;
                case Master.excExceptionNotConnected: exc += "Not connected!"; break;
            }

            //MessageBox.Show(exc);
            if (exc == "Connection is lost!")
            {
                label6.Text = "plc未连通";
                label8.Text = "waiting";
                label16.Text = "waiting";
                receiveBox.AppendText("检测到plc连接中断" + System.Environment.NewLine);
            }
            else {
                MessageBox.Show(exc);
            }
           
           
           
        }
        
        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private String post(String QR)//post
        {
            string url = post_url;
            using (HttpClient httpClient = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.None,
                ClientCertificateOptions = ClientCertificateOption.Automatic
            }))
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("qrcode", QR);

                httpClient.BaseAddress = new Uri(url);
                FormUrlEncodedContent content = new FormUrlEncodedContent(data);
                String result = httpClient.PostAsync(url, content).Result.Content.ReadAsStringAsync().Result;
                return result;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button4.Enabled == true)
            {
                Form3 window2 = new Form3();
                window2.Show();
            }
            else
            {
                MessageBox.Show("如果要进入调试界面，请先将主程序停止运行");
            }
        }
        private void readPlc()//read plc并设置定时器
        {
            //ushort ID = 4;
            ushort StartAddress_left = ushort.Parse(recieve_plc_qr_sign_address_left);
            ushort slaveAddress_left = ushort.Parse(recieve_plc_qr_sign_value_left);
            ushort StartAddress_right = ushort.Parse(recieve_plc_qr_sign_address_right);
            ushort slaveAddress_right = ushort.Parse(recieve_plc_qr_sign_value_right);
            while (true)
            {
                Thread.Sleep(1000);
                if (label8.Text == "working")//左扫码枪
                {
                    nowTime_left = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();//获取当前秒数
                    workedTime_left = nowTime_left - workStartTime_left;
                    if (workedTime_left > int.Parse(qr_timeOut_time))
                    {
                        writeToPlc(qr_timeOut_sign_address_left, qr_timeOut_sign_value_left);
                        sendToScanerLeft("16 55 0D"); //关闭扫码枪扫码
                        receiveBox.AppendText("左边扫码枪扫码超时" + System.Environment.NewLine);
                        label8.Text = "waiting";
                    }
                }
                if (label16.Text == "working")//右扫码枪
                {
                    nowTime_right = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();//获取当前秒数
                    workedTime_right = nowTime_right - workStartTime_right;
                    if (workedTime_right > int.Parse(qr_timeOut_time))
                    {
                        writeToPlc(qr_timeOut_sign_address_right, qr_timeOut_sign_value_right);
                        sendToScanerRight("16 55 0D"); //关闭扫码枪扫码
                        receiveBox.AppendText("右边扫码枪扫码超时" + System.Environment.NewLine);
                        label16.Text = "waiting";
                    }
                }

                label10.Text = workedTime_left.ToString() + "秒";
                label17.Text = workedTime_right.ToString() + "秒";
                if (label6.Text == "plc已连通")
                {
                    
                    MBmaster.ReadInputRegister(4, StartAddress_left, 1, slaveAddress_left);//读DI的值  左扫码枪
                    MBmaster.ReadInputRegister(5, StartAddress_right, 1, slaveAddress_right);//读DI的值  右扫码枪
                    
                }
                else if (label6.Text == "plc未连通"&&label3.Text=="已ping通") {
                    receiveBox.AppendText("正在自动重连plc..." + System.Environment.NewLine);
                    connectToPLC();
                    receiveBox.AppendText(label6.Text + System.Environment.NewLine);
                }
            }
        }


        private void grpStart_Enter(object sender, EventArgs e)
        {

        }


        ThreadStart childref;//监听plc的线程变量
        Thread childThread;//监听plc的线程变量
        ThreadStart childref2;//监听plc的线程变量
        Thread childThread2;//监听plc的线程变量
        bool mainStart = false;//主程序是否开始
        String text = "";
        private void button4_Click(object sender, EventArgs e)//开始运行按钮
        {
            
            openSerialPortLeft();//打开扫码枪串口
            openSerialPortRight();//打开扫码枪串口
           
            mainStart = true;
            if (mainStart == true)
            {
                button4.Enabled = false;//按钮是否可以点击
                button3.Enabled = true;
            }
            else
            {
                button4.Enabled = true;
                button3.Enabled = false;
            }
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            receiveBox.AppendText("程序正在结束..." + System.Environment.NewLine);
            button4.Enabled = true;
            childThread.Abort();//读d值
            childThread2.Abort();//ping
            receiveBox.AppendText("已停止监听plc" + System.Environment.NewLine);
            try
            {
                serialPortLeft.Close();
                receiveBox.AppendText("已关闭扫码枪串口" + System.Environment.NewLine);
            }
            catch
            {
                MessageBox.Show("串口关闭失败", "提示");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)//停止运行按钮
        {
            
            mainStart = false;
            if (mainStart == true)
            {
                button4.Enabled = false;
                button3.Enabled = true;
            }
            else
            {
                button4.Enabled = true;
                button3.Enabled = false;
            }
            try
            {
                serialPortLeft.Close();
                serialPortRight.Close();
                receiveBox.AppendText("已关闭扫码枪串口" + System.Environment.NewLine);
                label8.Text = "connection lost";
                label16.Text="connection lost";
            }
            catch
            {
                MessageBox.Show("串口关闭失败", "提示");
            }
        }
        SerialPort serialPortLeft = new SerialPort();
        SerialPort serialPortRight = new SerialPort();

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)//串口数据接收事件
        {
            if (label8.Text == "working" && label6.Text == "plc已连通")
            {
                string revData = serialPortLeft.ReadExisting();//字符方式读取
                receiveBox.AppendText("左扫码枪:" + revData + System.Environment.NewLine);
                String result;
                try
                {
                    result = post(revData);
                }
                catch(Exception) {
                    Console.WriteLine("post提交失败");
                    result = "post_error";
                    QR_ScanerTime--;
                }
                receiveBox.AppendText("将左边二维码POST提交后，得到的返回数据是" + System.Environment.NewLine);
                receiveBox.AppendText(result + System.Environment.NewLine);
                //label13.Text = revData;
                writeToPlc(qr_completed_sign_address_left, qr_completed_sign_value_left);//给plc发送信号，说明已收到plc扫码信号，让plc关闭扫码信号
                QR_ScanerTime++;
                receiveBox.AppendText("已完成第" + QR_ScanerTime + "次扫码" + System.Environment.NewLine);
                receiveBox.AppendText("左扫码枪等待plc扫码信号..." + System.Environment.NewLine);
                label8.Text = "waiting";
            }
        }

        private void port_DataReceived_right(object sender, SerialDataReceivedEventArgs e)//串口数据接收事件
        {
            if (label16.Text == "working" && label6.Text == "plc已连通")
            {
                string revData = serialPortRight.ReadExisting();//字符方式读取
                receiveBox.AppendText("右扫码枪:"+revData + System.Environment.NewLine);
                String result;
                try
                {
                    result = post(revData);
                }
                catch (Exception)
                {
                    Console.WriteLine("post提交失败");
                    result = "post_error";
                    QR_ScanerTime--;
                }
                receiveBox.AppendText("将右边二维码POST提交后，得到的返回数据是"  + System.Environment.NewLine);
                receiveBox.AppendText(result + System.Environment.NewLine);
                writeToPlc(qr_completed_sign_address_right, qr_completed_sign_value_right);//给plc发送信号，说明已收到plc扫码信号，让plc关闭扫码信号
                QR_ScanerTime++;
                receiveBox.AppendText("已完成第" + QR_ScanerTime + "次扫码" + System.Environment.NewLine);
                receiveBox.AppendText("右扫码枪等待plc扫码信号..." + System.Environment.NewLine);
                label16.Text = "waiting";
            }
        }

        private void sendToScanerLeft(String data)//串口发送数据
        {
            //string mystr = sendBox.Text;
            string mystr = data;
            mystr = mystr.Replace("0X", string.Empty);//去掉所有“OX”
            mystr = mystr.Replace(" ", string.Empty);//去掉所有“ ”
            byte[] myBytes = new byte[mystr.Length / 2];//去掉最后的奇数 如0A 06 8。将去掉末尾的8
            for(int i = 0; i < mystr.Length / 2; i++)
            {
                myBytes[i] = Convert.ToByte(mystr.Substring(i * 2, 2), 16);
            }
            serialPortLeft.Write(myBytes, 0, mystr.Length / 2);
        }
        private void sendToScanerRight(String data)//串口发送数据
        {
            //string mystr = sendBox.Text;
            string mystr = data;
            mystr = mystr.Replace("0X", string.Empty);//去掉所有“OX”
            mystr = mystr.Replace(" ", string.Empty);//去掉所有“ ”
            byte[] myBytes = new byte[mystr.Length / 2];//去掉最后的奇数 如0A 06 8。将去掉末尾的8
            for (int i = 0; i < mystr.Length / 2; i++)
            {
                myBytes[i] = Convert.ToByte(mystr.Substring(i * 2, 2), 16);
            }
            serialPortRight.Write(myBytes, 0, mystr.Length / 2);
        }

        bool rightSort_open = false;
        bool leftSort_open = false;
        private void openSerialPortLeft()
        {
            if (!serialPortLeft.IsOpen)//没有打开
            {
                serialPortLeft.PortName = left_port;
                serialPortLeft.BaudRate = Convert.ToInt32("115200");
                try
                {
                    serialPortLeft.Open();
                    serialPortLeft.DataBits = Convert.ToInt32("8");
                    receiveBox.AppendText("扫码枪 左 串口已打开" + System.Environment.NewLine);
                    label8.Text = "waiting";
                }
                catch
                {
                    serialPortLeft.Close();
                    MessageBox.Show("扫码枪 左 串口打开失败", "提示");
                    receiveBox.AppendText("扫码枪 左 串口打开失败" + System.Environment.NewLine);
                    label8.Text = "connection lost";
                }
            }
            
        }
        private void openSerialPortRight()
        {
            if (!serialPortRight.IsOpen)//没有打开
            {
                serialPortRight.PortName = right_port;
                serialPortRight.BaudRate = Convert.ToInt32("115200");
                try
                {
                    serialPortRight.Open();
                    serialPortRight.DataBits = Convert.ToInt32("8");
                    receiveBox.AppendText("扫码枪 右 串口已打开" + System.Environment.NewLine);
                    label16.Text = "waiting";
                }
                catch
                {
                    serialPortRight.Close();
                    MessageBox.Show("扫码枪 右 串口打开失败", "提示");
                    receiveBox.AppendText("扫码枪 右 串口打开失败" + System.Environment.NewLine);
                    label16.Text = "connection lost";
                }
            }

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                Form4 window3 = new Form4();
                window3.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void frmStart_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void receiveBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
    public class IPTools
    {
        #region 检测某个IP或域名是否可以Ping通
        public static bool PingIpOrDomainName(string strIpOrDName)
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions();
                objPinOptions.DontFragment = true;
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 120;
                PingReply objPinReply = objPingSender.Send(strIpOrDName, intTimeout, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
