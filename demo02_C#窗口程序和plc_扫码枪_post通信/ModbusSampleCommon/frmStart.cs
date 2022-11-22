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
        long workStartTime= new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();//��Ϊ��ǰʱ��
        //long workStartTime = 0;
        long workedTime = 0;
        long nowTime = 0;
        System.DateTime currentTime = new System.DateTime();
        Form3 window2 = new Form3();
        Form4 window3 = new Form4() ;
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
        private Label label13;
        private System.Windows.Forms.GroupBox grpStart;
        private Label label1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Button button3;
        private Label label8;
        private Label label7;
        private Label label10;
        private Label label9;
        private System.ComponentModel.IContainer components;

        public frmStart()
        {
            InitializeComponent();

            receiveBox.AppendText("����ʼ����" + System.Environment.NewLine);
            receiveBox.AppendText("��������PLC..." + System.Environment.NewLine);
            connectToPLC();//����PLC
            //receiveBox.AppendText("plc����ͨ" + System.Environment.NewLine);
            openSerialPort();//��ɨ��ǹ����
            receiveBox.AppendText("ɨ��ǹ�����Ѵ�" + System.Environment.NewLine);
            //��������plc�߳�
            childref = new ThreadStart(readPlc);
            childThread = new Thread(childref);
            childThread.Start();
            receiveBox.AppendText("��ʼ����plc�е�D0ֵ...");
            receiveBox.AppendText("�ȴ�plcɨ���ź�..." + System.Environment.NewLine);

            //����ping plc ip����߳�
            childref2 = new ThreadStart(ping_IP);
            childThread2 = new Thread(childref2);
            childThread2.Start();
            
            //ɨ��ǹ�����¼�
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            serialPort1.Encoding = Encoding.GetEncoding("gb2312");//���ڽ��ձ���GB2312��
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//���Գ����Խ�߳����е��µĴ���.û�д˾佫���������
       
        }
        public void ping_IP() {
            while (true)
            {
                //Console.WriteLine(MBmaster);
                Thread.Sleep(500);
                string ip = "192.168.1.88";
                bool result = IPTools.PingIpOrDomainName(ip);
               // Console.WriteLine("ping {0} result is {1}!", ip, result);
                if (result == true)
                {
                    label3.Text = "��pingͨ";
                }
                if (result == false)
                {
                    label3.Text = "δpingͨ";
                    label6.Text = "plcδ��ͨ";
                }
                //return result;
            }
        }


        #region Vom Windows Form-Designer generierter Code
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.receiveBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.grpStart = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.grpStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("����", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(23, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(279, 41);
            this.label5.TabIndex = 8;
            this.label5.Text = "��ȡPLC�� D ��ֵΪ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("����", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(23, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 19);
            this.label4.TabIndex = 20;
            this.label4.Text = "�豸����״̬: ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("����", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(162, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 19);
            this.label6.TabIndex = 21;
            this.label6.Text = "δ��ͨ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(70, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 49);
            this.button2.TabIndex = 32;
            this.button2.Text = "�򿪵��Խ���";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // receiveBox
            // 
            this.receiveBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receiveBox.Location = new System.Drawing.Point(381, 25);
            this.receiveBox.Margin = new System.Windows.Forms.Padding(4);
            this.receiveBox.Multiline = true;
            this.receiveBox.Name = "receiveBox";
            this.receiveBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receiveBox.Size = new System.Drawing.Size(460, 496);
            this.receiveBox.TabIndex = 12;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(430, 539);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 49);
            this.button4.TabIndex = 34;
            this.button4.Text = "��ʼ����";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("����", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(204, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 41);
            this.label12.TabIndex = 36;
            this.label12.Text = "none";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("����", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(91, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 18);
            this.label13.TabIndex = 41;
            this.label13.Text = "QRCODE";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // grpStart
            // 
            this.grpStart.AccessibleRole = System.Windows.Forms.AccessibleRole.Animation;
            this.grpStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStart.Controls.Add(this.label10);
            this.grpStart.Controls.Add(this.label9);
            this.grpStart.Controls.Add(this.label8);
            this.grpStart.Controls.Add(this.label7);
            this.grpStart.Controls.Add(this.label3);
            this.grpStart.Controls.Add(this.label2);
            this.grpStart.Controls.Add(this.button1);
            this.grpStart.Controls.Add(this.label1);
            this.grpStart.Controls.Add(this.label13);
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
            this.grpStart.Size = new System.Drawing.Size(883, 613);
            this.grpStart.TabIndex = 11;
            this.grpStart.TabStop = false;
            this.grpStart.Text = "��ʼ��������";
            this.grpStart.Enter += new System.EventHandler(this.grpStart_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("����", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(113, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 18);
            this.label10.TabIndex = 49;
            this.label10.Text = "0��";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("����", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(23, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 18);
            this.label9.TabIndex = 48;
            this.label9.Text = "ɨ��ʱ��:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("����", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(136, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 23);
            this.label8.TabIndex = 47;
            this.label8.Text = "waiting";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("����", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(23, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 18);
            this.label7.TabIndex = 46;
            this.label7.Text = "ɨ��ǹ״̬:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("����", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(205, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 45;
            this.label3.Text = "δpingͨ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("����", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(23, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 18);
            this.label2.TabIndex = 44;
            this.label2.Text = "PING 192.168.1.88";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 512);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 49);
            this.button1.TabIndex = 43;
            this.button1.Text = "�򿪲������ý���";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("����", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 42;
            this.label1.Text = "��ά��";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(626, 539);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 49);
            this.button3.TabIndex = 35;
            this.button3.Text = "ֹͣ����";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmStart
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(927, 627);
            this.Controls.Add(this.grpStart);
            this.Name = "frmStart";
            this.Text = "������� V1.0  ���ں������ܿƼ�  �Ƽ��ı�δ��";
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
       
        private void connectToPLC()//����plc
        {
            try
            {
                MBmaster = new Master("192.168.1.88", 502);
                MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData);
                MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);
                label6.Text = "plc����ͨ";
            }
            catch (SystemException error)
            {
                MessageBox.Show(error.Message);
                //MessageBox.Show("����plcʧ��");
            }
        }
        private void writeToPlc(String address,String value)//дDֵ��plc
        {
            ushort ID = 7;
            byte[] writedDate = new byte[4];
            //ushort address = ushort.Parse(textBox1.Text);
            ushort address_D = ushort.Parse(address);
            //byte inputData = (byte)int.Parse(textBox2.Text);
            byte inputData = (byte)int.Parse(value);
            writedDate[1] = inputData;

            MBmaster.WriteSingleRegister(ID, address_D, writedDate);//д������Ȧ���ּĴ���
        }
        //String QR_ScanerStatus = "waiting";
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
                case 4:
                    data = values;
                    //string str = System.Text.Encoding.UTF8.GetString(data);
                    string varString = Convert.ToString(data[1]);
                    label5.Text = "��ȡPLC�� D0"  + " ��ֵΪ��";
                    label12.Text = varString;
                    if (label12.Text == "13" && label8.Text == "waiting" && mainStart == true&& label6.Text == "plc����ͨ")
                    {
                        label8.Text = "working";
                        label8.Text = label8.Text;
                        receiveBox.AppendText("���յ�plcɨ���źţ����ڴ�ɨ��ǹȥɨ��..." + System.Environment.NewLine);
                        sendToScaner("16 54 0D"); //����ɨ��ǹɨ��
                        workStartTime =new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

                        
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
                label6.Text = "plcδ��ͨ";
                label8.Text = "waiting";
                receiveBox.AppendText("��⵽plc�����ж�" + System.Environment.NewLine);
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
            string url = "http://localhost:8080/web-demo/searchSong";
            using (HttpClient httpClient = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.None,
                ClientCertificateOptions = ClientCertificateOption.Automatic
            }))
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("singer", "�ֿ���");
                httpClient.BaseAddress = new Uri(url);
                FormUrlEncodedContent content = new FormUrlEncodedContent(data);
                String result = httpClient.PostAsync(url, content).Result.Content.ReadAsStringAsync().Result;
                return result;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            window2.Show();
        }
        private void readPlc()//read plc�����ö�ʱ��
        {
            ushort ID = 4;
            ushort StartAddress = 0;
            ushort slaveAddress = 0;
            while (true)
            {

                Thread.Sleep(1000);
                if (label8.Text == "working")
                {
                    nowTime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();//��ȡ��ǰ����
                    workedTime = nowTime - workStartTime;
                    if (workedTime > 5)
                    {
                        writeToPlc("0", "17");
                        sendToScaner("16 55 0D"); //�ر�ɨ��ǹɨ��
                        receiveBox.AppendText("ɨ�볬ʱ" + System.Environment.NewLine);
                        label8.Text = "waiting";
                    }
                }
                label10.Text = workedTime.ToString() + "��";
                if (label6.Text == "plc����ͨ")
                {
                    MBmaster.ReadInputRegister(ID, StartAddress, 1, slaveAddress);//��DI��ֵ
                }
                else if (label6.Text == "plcδ��ͨ"&&label3.Text=="��pingͨ") {
                    receiveBox.AppendText("�����Զ�����plc..." + System.Environment.NewLine);
                    connectToPLC();
                    receiveBox.AppendText(label6.Text + System.Environment.NewLine);
                   
                }
            }
        }


        private void grpStart_Enter(object sender, EventArgs e)
        {

        }


        ThreadStart childref;//����plc���̱߳���
        Thread childThread;//����plc���̱߳���
        ThreadStart childref2;//����plc���̱߳���
        Thread childThread2;//����plc���̱߳���
        bool mainStart = false;//�������Ƿ�ʼ
        String text = "";
        private void button4_Click(object sender, EventArgs e)//��ʼ���а�ť
        {
            mainStart = true;
            if (mainStart == true)
            {
                button4.Enabled = false;//��ť�Ƿ���Ե��
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
            receiveBox.AppendText("�������ڽ���..." + System.Environment.NewLine);
            button4.Enabled = true;
            childThread.Abort();
            childThread2.Abort();
            receiveBox.AppendText("��ֹͣ����plc" + System.Environment.NewLine);

            try
            {
                serialPort1.Close();
                receiveBox.AppendText("�ѹر�ɨ��ǹ����" + System.Environment.NewLine);
            }
            catch
            {
                MessageBox.Show("���ڹر�ʧ��", "��ʾ");
            }
            
        }


        private void button3_Click(object sender, EventArgs e)//ֹͣ���а�ť
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
        }
        SerialPort serialPort1 = new SerialPort();

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)//�������ݽ����¼�
        {
            if (label8.Text == "working" && label6.Text == "plc����ͨ")
            {

                string revData = serialPort1.ReadExisting();//�ַ���ʽ��ȡ
                receiveBox.AppendText(revData + System.Environment.NewLine);
                String result = post(revData);
                receiveBox.AppendText("����ά��POST�ύ�󣬵õ��ķ���������" + result + System.Environment.NewLine);
                label13.Text = revData;
                writeToPlc("1","99");//��plc�����źţ�˵�����յ�plcɨ���źţ���plc�ر�ɨ���ź�
                QR_ScanerTime++;
                receiveBox.AppendText("����ɵ�" + QR_ScanerTime + "��ɨ��" + System.Environment.NewLine);
                receiveBox.AppendText("�ȴ�plcɨ���ź�..." + System.Environment.NewLine);
                label8.Text = "waiting";
            }
            else if (label6.Text == "plcδ��ͨ") {
                label8.Text = label8.Text;
            }
        }
        
        private void sendToScaner(String data)//���ڷ�������
        {
            //string mystr = sendBox.Text;
            string mystr = data;
            mystr = mystr.Replace("0X", string.Empty);//ȥ�����С�OX��
            mystr = mystr.Replace(" ", string.Empty);//ȥ�����С� ��
            byte[] myBytes = new byte[mystr.Length / 2];//ȥ���������� ��0A 06 8����ȥ��ĩβ��8
            for(int i = 0; i < mystr.Length / 2; i++)
            {
                myBytes[i] = Convert.ToByte(mystr.Substring(i * 2, 2), 16);
            }
            serialPort1.Write(myBytes, 0, mystr.Length / 2);
        }


       
        private void openSerialPort()
        {
            if (!serialPort1.IsOpen)//û�д�
            {
                serialPort1.PortName = "COM3";
                serialPort1.BaudRate = Convert.ToInt32("115200");
                try
                {
                    serialPort1.Open();
                    serialPort1.DataBits = Convert.ToInt32("8");
                }
                catch
                {
                    serialPort1.Close();
                    MessageBox.Show("���ڴ�ʧ��", "��ʾ");
                }
            }
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
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
    }
    public class IPTools
    {
        #region ���ĳ��IP�������Ƿ����Pingͨ
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
