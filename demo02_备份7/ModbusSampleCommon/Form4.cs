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

namespace ModbusTester
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
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

            len = WritePrivateProfileString("触发扫码信号", "扫码触发信号D值", textBox1.Text, iniPath);
            len = WritePrivateProfileString("触发扫码信号", "接收扫码信号D值", textBox2.Text, iniPath);
            
            len = WritePrivateProfileString("扫码完成信号", "将D几作为扫码完成标志", textBox3.Text, iniPath);
            len = WritePrivateProfileString("扫码完成信号", "扫码完成标志D值", textBox4.Text, iniPath);

            len = WritePrivateProfileString("扫码超时信号", "将D几作为扫码超时标志", textBox5.Text, iniPath);
            len = WritePrivateProfileString("扫码超时信号", "扫码超时标志D值", textBox6.Text, iniPath);

            len = WritePrivateProfileString("扫码超时时长", "扫码超过多少秒为超时", textBox8.Text, iniPath);
            len = WritePrivateProfileString("POST地址", "POST到接口地址", textBox7.Text, iniPath);
        }
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string node, string key, string value, StringBuilder result, int size, string filePath);


        private void button1_Click(object sender, EventArgs e)
        {
            //声明接收的数据
            StringBuilder builder = new StringBuilder(1024);
            //调用Winapi函数读取C#上位机群大佬节点下Name的值
            int len = GetPrivateProfileString("plc地址", "PLC IP地址", "", builder, 1024, iniPath);
            //输出应该是C#上位机群大佬节点下的键值"Name"的值:李增光
            Console.WriteLine(builder.ToString());
           
        }
    }
}
