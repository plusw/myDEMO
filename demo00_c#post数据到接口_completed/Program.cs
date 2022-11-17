using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;

namespace BarcodeScanner
{
    class TestClass
    {
        static void Main(string[] args)
        {
            // Display the number of command line arguments.
            Console.WriteLine("hello");
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
                Console.WriteLine(result);
            }


            Console.ReadKey();
        }
    }

}