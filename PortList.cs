using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace WirelessNodeSimulation
{

    public struct Portinfo
    {
        public string protocol, port, status, PID, process;
    }
    class PortList
    {
        List<Portinfo> plist = new List<Portinfo>();
        List<int> portlist = new List<int>();
        List<Portinfo> suspectlist = new List<Portinfo>();
        public event EventHandler<PortEvent> Port_List_event;
        public event EventHandler<PortEvent> NewPort_event;


        static bool detect = false;

        //Timer tm1 = new Timer();
        public Thread tm1;

        #region functions
        public PortList()
        {
            
            tm1 = new Thread(new ThreadStart(thrfun));
            
            //tm1.Interval = 10000;
            //tm1.Tick += new EventHandler(tm1_Tick);
            
        }
        public void thrfun()
        {
            while (true)
            {
                plist.Clear();
                getport();
                Thread.Sleep(10000);
            }
        }
        
        public void start()
        {
            if (tm1.ThreadState == System.Threading.ThreadState.Unstarted)
                tm1.Start();
            else if (tm1.ThreadState == System.Threading.ThreadState.Suspended)
                tm1.Resume();
        }

        public void stop()
        {
            tm1.Suspend();
        }
         void getport()
        {
            try
            {

                suspectlist.Clear();
                
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c netstat -nao");
                
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
               
                procStartInfo.CreateNoWindow = true;
               
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                
               
               
                while (!proc.StandardOutput.EndOfStream)
                {
                   
                    string rst = proc.StandardOutput.ReadLine();
                   
                    //converting to comma separated list
                    if (rst != null && rst != "")
                    {
                        string temp1 = null;
                        bool fl = false;
                        foreach (char c in rst)
                        {
                            if (c != ' ')
                            {
                            temp1 += c.ToString();
                            fl = true;
                            }
                            else
                            {
                                if (fl)
                                {
                                temp1 += ",";
                                fl = false;
                                }
                            }


                        }
                        Portinfo temp = new Portinfo();
                        string[] arr = temp1.Split(',');
                       
                        if (arr[0] == "TCP" || arr[0] == "UDP")
                        {
                        temp.protocol = arr[0].ToString();
                        temp.port = arr[1].Substring(arr[1].LastIndexOf(':')+1);

                            //new port creation detection
                        bool attck = false;
                        if (detect)
                        {
                            if (portlist.IndexOf(Convert.ToInt32(temp.port)) < 0)
                            {
                                attck = true;
                            }
                        }
                        else
                        {
                            portlist.Add(Convert.ToInt32(temp.port));
                        }
                        if (arr[0] == "TCP")
                        {
                            temp.status = arr[3].ToString();
                            temp.PID = arr[4];
                            temp.process = getProcess(arr[4]).Replace("\"", " "); 
                        }
                        else if (arr[0] == "UDP")
                        {
                            temp.status = "WAITING";
                            temp.PID = arr[3];
                            temp.process = getProcess(arr[3]).Replace("\"", " ");
                        }

                        
                        plist.Add(temp);

                        if (attck)
                            suspectlist.Add(temp);
                        }
                       

                        
                    }

                }

                detect = true;

//event fire
                EventHandler<PortEvent> Port_list_event1 = Port_List_event;
                if(Port_List_event!=null)
                    this.Port_List_event(this,new PortEvent(plist));
//suspected list
                if (suspectlist.Count > 0)
                {
                    EventHandler<PortEvent> NewPort_event1 = NewPort_event;
                    if (NewPort_event != null)
                        this.NewPort_event(this, new PortEvent(suspectlist));
                }

                 
            }
            catch (Exception objException)
            {
                MessageBox.Show(objException.Message);
            }
        }

        string getProcess(string PID)
        {
            string pname = "unknown";
            try
            {

                
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c Tasklist /FI \"PID EQ " + PID + "\" /FO CSV /NH");

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;

                procStartInfo.CreateNoWindow = true;

                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
               


                while (!proc.StandardOutput.EndOfStream)
                {

                    string rst = proc.StandardOutput.ReadLine();
                    string[] dd = rst.Split(',');
                    pname = dd[0];
                }
                return pname;
            }
            catch (Exception ert)
            {
                MessageBox.Show(ert.Message);
                return pname;
            }

        }

        #endregion

    }

    public class PortEvent : EventArgs
    {
         List<Portinfo> List = new List<Portinfo>();
        public PortEvent(List<Portinfo> pro)
        {
            List = pro;
        }
        public List<Portinfo> Portargs
        {
            get
            {
                return List;
            }
        }
    }
}
