using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace sp3
{
    public partial class Form1 : Form
    {
        SerialPort serialPort1=new SerialPort();
        Thread spThread;
        ASCIIEncoding TempAscii;
        public Form1()
        {
            InitializeComponent();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.PortName = cbSerial.SelectedItem.ToString();
                    serialPort1.BaudRate = Convert.ToInt32(TP_BaudRate.SelectedItem.ToString());
                    serialPort1.DataBits = Convert.ToInt32(TP_DataBits.SelectedItem.ToString());
                    switch (TP_Stop.SelectedItem.ToString())
                    {
                        case "1": serialPort1.StopBits = StopBits.One; break;
                        case "1.5": serialPort1.StopBits = StopBits.OnePointFive; break;
                        case "2": serialPort1.StopBits = StopBits.Two; break;
                        case "无": serialPort1.StopBits = StopBits.None; break;
                        default: MessageBox.Show("停止位参数错误"); break;

                    }
                    switch (TP_Parity.SelectedItem.ToString())
                    {
                        case "无": serialPort1.Parity = Parity.None; break;
                        case "奇校验": serialPort1.Parity = Parity.Odd; break;
                        case "偶校验": serialPort1.Parity = Parity.Even; break;
                        default: ; break;

                    }
                    if (serialPort1.IsOpen)
                        serialPort1.Close();
                    serialPort1.Open();
                    TP_BaudRate.Enabled = false;
                    TP_DataBits.Enabled = false;
                    TP_Parity.Enabled = false;
                    TP_Stop.Enabled = false;
                    cbSerial.Enabled = false;
                    button1.Text = "关闭串口";

                }
                catch (Exception)
                {
                    MessageBox.Show("串口打开失败！" + e.ToString());
                }
            }
            else
            {
                serialPort1.Close();
                TP_Stop.Enabled = true;
                TP_Parity.Enabled = true;
                TP_DataBits.Enabled = true;
                TP_BaudRate.Enabled = true;
                cbSerial.Enabled = true;
                button1.Text = "打开串口";
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //检查是否含有串口
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }

            //添加串口项目
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {//获取有多少个COM口
                cbSerial.Items.Add(s);
            }
            timer1.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.WriteLine(TP_Send.Text);
                serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);

                TP_Received.Text += serialPort1.ReadExisting();
            }
            catch (Exception)
            {
                MessageBox.Show("发送失败" + e.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    int w;
            //    TP_Received.Text += serialPort1.ReadLine();
            //}
            //catch (Exception)
            //{

            //}

        }
        private void GetSp()
        {
            bool i = true;
            while (true)
            {
                serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);

                TP_Received.Text += serialPort1.ReadExisting();
                
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //TP_Received.Text += serialPort1.ReadLine();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            spThread = new Thread(new ThreadStart(GetSp));
            spThread.Start();
            TP_Received.Text += "串口接收已打开";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
            spThread.Abort();
        }
    }
}
