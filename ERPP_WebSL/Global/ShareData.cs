using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace ERPP_WebSL
{
    public static class ShareData
    {
        //public static string DeviceIP
        //{
        //    get
        //    {
        //        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(DeviceName);
        //        string ipaddress = ipEntry.AddressList[0].ToString();
        //        return ipaddress.ToString();
        //    }
        //}

        //public static string DeviceVersion
        //{
        //    get
        //    {
        //        return Environment.OSVersion.ToString();
        //    }
        //}
        //public static string DeviceName
        //{
        //    get
        //    {
        //        return System.Net.Dns.GetHostName();
        //    }
        //}

        //public static int DeviceResolutionHeight
        //{
        //    get
        //    {
        //        return System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        //    }
        //}

        //public static int DeviceResolutionWidth
        //{
        //    get
        //    {
        //        return System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        //    }
        //}

        //public static String CurrentDirectory
        //{
        //    get
        //    {
        //        return System.IO.Directory.GetCurrentDirectory();
        //    }
        //}
        public static string Server = "erppartner.dyndns.org:8000";
        public static string UserLogin;
        public static string Password { get { return Password; } set { } }
        public static string SecID;
        public static string Site;
        public static string CurWhse;
        public static DateTime LoginDate { get { return LoginDate; } set { } }
        public static int IsLoaded;
    }
}
