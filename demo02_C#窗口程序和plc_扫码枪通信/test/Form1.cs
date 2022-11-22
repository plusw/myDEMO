using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ip1 = "127.0.0.1";
            bool result = IPTools.PingIpOrDomainName(ip1);
            Console.WriteLine("ping {0} result is {1}!", ip1, result);

            string ip2 = "www.baidu.com";
            result = IPTools.PingIpOrDomainName(ip2);
            Console.WriteLine("ping {0} result is {1}!", ip2, result);

            string ip3 = "192.168.1.88";
            result = IPTools.PingIpOrDomainName(ip3);
            Console.WriteLine("ping {0} result is {1}!", ip3, result);
        }
    }
    public class IPTools
    {
        #region 检测某个IP或域名是否可以Ping通

        /// <summary>
        /// 检测某个IP或域名是否可以Ping通
        /// </summary>
        /// <param name="strIpOrDName">IP或域名</param>
        /// <returns>true为通，false为不通</returns>
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
