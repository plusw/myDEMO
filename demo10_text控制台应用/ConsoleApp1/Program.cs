using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace 读写INI
{
    class Program
    {
        /// <summary>
        /// 写入ini文件,调用WinApi函数操作ini
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="filepath">ini路径</param>
        /// <returns>0失败/其他成功</returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string node, string key, string value, string filepath);


        /// <summary>
        /// 读取ini
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="value">值(未读取到数据时设置的默认返回值)</param>
        /// <param name="result">读取的结果值</param>
        /// <param name="size">读取缓冲区大小</param>
        /// <param name="filePath">ini路径</param>
        /// <returns>读取到的字节数量</returns>
        33333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333



        static void Main(string[] args)
        {
            //WriteIni();
            GetIni();
        }
        static string iniPath = Environment.CurrentDirectory + "\\config.ini";
        /// <summary>
        /// 读取ini
        /// </summary>
        private static void GetIni()
        {
            //声明接收的数据
            StringBuilder builder = new StringBuilder(1024);
            //调用Winapi函数读取C#上位机群大佬节点下Name的值
            int len = GetPrivateProfileString("C#上位机群大佬", "Name", "", builder, 1024, iniPath);
            //输出应该是C#上位机群大佬节点下的键值"Name"的值:李增光
            Console.WriteLine(builder.ToString());
            Console.ReadKey();
        }
        /// <summary>
        /// 写入ini
        /// </summary>
        private static void WriteIni()
        {
            //调用Winapi函数将Name=李增光写入C#上位机群大佬节点下
            long len = WritePrivateProfileString("参数配置", "PLC ip地址", "李增光", iniPath);
            len = WritePrivateProfileString("C#上位机群大佬", "Sex", "男", iniPath);


            
        }
    }
}
