using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ERPP_WebSL
{
    class Config
    {
        // SizeScreen
        public int size_x = 240;
        public int size_y = 300;

        //private string _server_name = "192.168.1.210";
        //private string _server_name = "192.168.1.9"; // npsksl
        //private string _server_name = "SL900";
        private string _server_name;
        private string ipaddress;

        public string server_name
        {
            get 
            {
                string line;
                StreamReader sr = new StreamReader(getCurrentPathWriteServerIP);
                if ((line = sr.ReadLine()) != null)
                {
                    _server_name = line;
                }
                sr.Close();
                return _server_name; 
            }
        }

        public string IP_ServerNameSL
        {
            get
            {
                IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(server_name);
                ipaddress = ipEntry.AddressList[1].ToString();
                return ipaddress;
            }
        }

        public string getCurrentPathWriteServerIP
        {
            get
            {
                string path1;
                path1 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                path1 = string.Format(@"{0}\server_ip.txt",path1.ToString());
                if (path1.Contains("file:\\") == true)
                {
                    path1 = path1.Substring(6, path1.Length - 6).ToString();
                }
                return path1;
            }
        }

        public void checkFileServerIP()
        {
            if (!File.Exists(getCurrentPathWriteServerIP.ToString()))
            {
                File.Create(getCurrentPathWriteServerIP.ToString()).Close();
                StreamWriter sw = new StreamWriter(getCurrentPathWriteServerIP.ToString(), true);
                sw.Write("172.16.10.22");            // default ip
                sw.Close();
            }
        }
    }
}
