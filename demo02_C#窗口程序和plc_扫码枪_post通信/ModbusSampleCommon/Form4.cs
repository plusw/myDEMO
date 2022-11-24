using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ModbusTester
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.Text = "你好深圳 V1.0  参数设置界面";
            readConfig();
        }
        String plc_address = "";

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

            txtIP.Text = plc_address;
            //左
            textBox15.Text = left_port;
            textBox1.Text = recieve_plc_qr_sign_address_left;
            textBox2.Text = recieve_plc_qr_sign_value_left;
            textBox3.Text = qr_completed_sign_address_left;
            textBox4.Text = qr_completed_sign_value_left;
            textBox5.Text = qr_timeOut_sign_address_left;
            textBox6.Text = qr_timeOut_sign_value_left;
            //右
            textBox16.Text = right_port;
            textBox14.Text = recieve_plc_qr_sign_address_right;
            textBox13.Text = recieve_plc_qr_sign_value_right;
            textBox12.Text = qr_completed_sign_address_right;
            textBox11.Text = qr_completed_sign_value_right;
            textBox10.Text = qr_timeOut_sign_address_right;
            textBox9.Text = qr_timeOut_sign_value_right;


            textBox8.Text = qr_timeOut_time;
            textBox7.Text = post_url;



        }
        private void label3_Click(object sender, EventArgs e)
        {
            
        }
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string node, string key, string value, string filepath);

        static string iniPath = Environment.CurrentDirectory + "\\config.ini";
        private void button3_Click(object sender, EventArgs e)
        {
            //调用Winapi函数将Name=李增光写入C#上位机群大佬节点下
            long len = WritePrivateProfileString("plc地址", "PLC IP地址", txtIP.Text, iniPath);

            len = WritePrivateProfileString("左扫码枪串口号", "串口号", textBox15.Text, iniPath);
            
            len = WritePrivateProfileString("左触发扫码信号", "将D几作为扫码触发标志", textBox1.Text, iniPath);
            len = WritePrivateProfileString("左触发扫码信号", "接收扫码信号D值", textBox2.Text, iniPath);
            
            len = WritePrivateProfileString("左扫码完成信号", "将D几作为扫码完成标志", textBox3.Text, iniPath);
            len = WritePrivateProfileString("左扫码完成信号", "扫码完成标志D值", textBox4.Text, iniPath);

            len = WritePrivateProfileString("左扫码超时信号", "将D几作为扫码超时标志", textBox5.Text, iniPath);
            len = WritePrivateProfileString("左扫码超时信号", "扫码超时标志D值", textBox6.Text, iniPath);

            len = WritePrivateProfileString("右扫码枪串口号", "串口号", textBox16.Text, iniPath);
            len = WritePrivateProfileString("右触发扫码信号", "将D几作为扫码触发标志", textBox14.Text, iniPath);
            len = WritePrivateProfileString("右触发扫码信号", "接收扫码信号D值", textBox13.Text, iniPath);

            len = WritePrivateProfileString("右扫码完成信号", "将D几作为扫码完成标志", textBox12.Text, iniPath);
            len = WritePrivateProfileString("右扫码完成信号", "扫码完成标志D值", textBox11.Text, iniPath);

            len = WritePrivateProfileString("右扫码超时信号", "将D几作为扫码超时标志", textBox10.Text, iniPath);
            len = WritePrivateProfileString("右扫码超时信号", "扫码超时标志D值", textBox9.Text, iniPath);

            len = WritePrivateProfileString("扫码超时时长", "扫码超过多少秒为超时", textBox8.Text, iniPath);
            
            len = WritePrivateProfileString("POST地址", "POST到接口地址", textBox7.Text, iniPath);

            label100.Text = "参数已保存，重启软件后生效";
        }
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string node, string key, string value, StringBuilder result, int size, string filePath);


       
    }
}
