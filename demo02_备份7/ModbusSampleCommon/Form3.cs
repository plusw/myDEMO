using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModbusTCP;
using ModbusTester;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.WebRequestMethods;
using Modbus;
using System.Net.NetworkInformation;
using System.IO.Ports;

namespace ModbusTester
{
    public partial class Form3 : Form
    {
        public ModbusTCP.Master MBmaster;
        public String value_D = "noValue";
        private byte[] data;
        public Form3()
        {
            InitializeComponent();
            openSerialPort();//打开串口
            //扫码枪串口事件
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            serialPort1.Encoding = Encoding.GetEncoding("gb2312");//串口接收编码GB2312码
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//忽略程序跨越线程运行导致的错误.没有此句将会产生错误

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        public void MBmaster_OnResponseData(ushort ID, byte function, byte[] values)
        {
            // Seperate calling threads
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData), new object[] { ID, function, values });
                return;
            }
            // Ignore watchdog response data
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


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnWriteSingleReg_Click(object sender, EventArgs e)
        {
            ushort ID = 7;
            byte[] data = new byte[4];
            data[1] = 72;
            byte[] writedDate = new byte[] { 3, 75, 3, 4, 5, 6, 7, 8, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            ushort address = ushort.Parse(textBox1.Text);
            byte inputData = (byte)int.Parse(textBox2.Text);
            writedDate[1] = inputData;
            //  label10.Text = Convert.ToString(index);
            // label11.Text = Convert.ToString(inputData);
            //MBmaster.WriteSingleRegister(4, 0, data);
           // MBmaster.WriteSingleRegister(ID, address, writedDate);//写单个线圈保持寄存器
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "";
            url= "http://localhost:8080/web-demo/searchSong";
           // url = textBox3.Text;
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
                label12.Text = result;
            }
        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        public void btnConnect_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Create new modbus master and add event functions
                MBmaster = new Master(txtIP.Text, 502);
                MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData);
                MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);
                // Show additional fields, enable watchdog
                label14.Text = "已连通";

            }
            catch (SystemException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void btnReadInpReg_Click_1(object sender, EventArgs e)
        {
            ushort ID = 4;
            ushort StartAddress = ReadStartAdr();//开始地址，从输入框里读到
            ushort slaveAddress = 0;
            MBmaster.ReadInputRegister(ID, StartAddress, 1, slaveAddress);//读AI的值
        }

        public void txtIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MBmaster != null)
            {
                ushort num=0;
                byte[] data = new byte[4];
                double numData = 2;
                data = new byte[4];
                ushort ID = 7;
                ushort StartAddress = num;
                if (Convert.ToInt32(numData) >= 65536)
                {
                    data[0] = Convert.ToByte((Convert.ToInt32(numData) % 65536) / 256);
                    data[1] = Convert.ToByte((Convert.ToInt32(numData) % 65536) % 256);
                }
                else
                {
                    data[0] = Convert.ToByte(Convert.ToInt32(numData) / 256);
                    //data[1] = Convert.ToByte(Convert.ToInt32(numData) % 256);
                    data[1] = (byte)int.Parse(textBox2.Text);
                }

                //data[2] = Convert.ToByte(Convert.ToInt32(textBox2.Text) / 256);
                //data[3] = Convert.ToByte(Convert.ToInt32(textBox2.Text) % 256);
                // MBmaster.WriteMultipleRegister(ID, StartAddress, data);
                MBmaster.WriteSingleRegister(4, 0, data);
                /*
                data[0] = Convert.ToByte(Convert.ToInt32(numData) / 65536 / 256);
                if (Convert.ToInt32(numData) >= 65536)
                    data[1] = Convert.ToByte(Convert.ToInt32(numData) / 65536 % 256);
                else
                    data[1] = 0;
                */
                //MBmaster.WriteSingleRegister(4, Convert.ToUInt16(StartAddress + 1), data);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ip = "192.168.1.88";
            bool result = IPTools.PingIpOrDomainName(ip);
            if (result == true)
            {
                label17.Text = "已ping通";
            }
            if (result == false)
            {
                label17.Text = "未ping通";
            }
        }
        SerialPort serialPort1 = new SerialPort();
        private void openSerialPort()//打开串口
        {
            if (!serialPort1.IsOpen)//没有打开
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
                    MessageBox.Show("串口打开失败", "提示");
                }
            }

        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)//串口数据接收事件
        {


            string revData = serialPort1.ReadExisting();//字符方式读取
           
            String result = revData;
            label21.Text = revData;
            
        }
            
            private void button4_Click(object sender, EventArgs e)//串口发送数据
            {
                //string mystr = sendBox.Text;
                string mystr = textBox4.Text;
                mystr = mystr.Replace("0X", string.Empty);//去掉所有“OX”
                mystr = mystr.Replace(" ", string.Empty);//去掉所有“ ”
                byte[] myBytes = new byte[mystr.Length / 2];//去掉最后的奇数 如0A 06 8。将去掉末尾的8
                for (int i = 0; i < mystr.Length / 2; i++)
                {
                    myBytes[i] = Convert.ToByte(mystr.Substring(i * 2, 2), 16);
                }
                serialPort1.Write(myBytes, 0, mystr.Length / 2);
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
