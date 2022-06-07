using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WirelessNodeSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///
        public static int UserCount = 0;
        public static string Servername = "localhost", ServerIP = "192.168.1.2";
        public static string userName = "Unknown";
        public static string x = "";
        public static string y = "";
        public static string desx = "";
        public static string desy = "";
        public static string desx1 = "";
        public static string desy1 = "";
        public static string desx2 = "";
        public static string desy2 = "";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
        }
    }
}
