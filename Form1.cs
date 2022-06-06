using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.PieChart;
using System.Collections;
using DBRemoting;
using System.Net;
using System.Threading;
using System.Data.SqlClient;
using System.IO;
using System.Net.NetworkInformation;
using Channel;
using EnCryptDecrypt;

namespace WirelessNodeSimulation
{
    public partial class Form1 : Form
    {
        static string CurrntSourceUser;
        public static int pcount;
        public static int Preceiver;
        public static int Preceiver1;
        public static int Preceiver2;
        public static int pcount1;
        public static int pcount2;
        ServerAdvertise svr_adv = new ServerAdvertise();
      //  User userobj = new User();
        //RemoteDBcon RmtDb = new RemoteDBcon("WNS");
        TSReceiver TCPreceiver = new TSReceiver(9000);
      //  FTServerCode FTserver = new FTServerCode(5656);
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            My_meter.SystemMeter_Event += new EventHandler<Event_Meter>(My_meter_SystemMeter_Event);

          //  FTserver.File_Redirecting += new EventHandler<FileEventargs>(FTserver_File_Redirecting);
           // FTserver.File_RedirectComplete += new EventHandler(FTserver_File_RedirectComplete);
            
        }

        void FTserver_File_RedirectComplete(object sender, EventArgs e)
        {
            richTextBox1.AppendText("Redirecting Complete.....");

            //listView_channel.Items[listView_channel.Items.Count - 1].SubItems[3].Text = "Closed";
            //listView_channel.Items[listView_channel.Items.Count - 1].ForeColor = Color.Red;

        }

        void FTserver_File_Redirecting(object sender, FileEventargs e)
        {
            richTextBox1.AppendText("\nRedirecting : "+e.ReceivedBytes.ToString());
        }

       

       

        
        #region UserFunctions
        void setPieChart(PieChartControl pieChart,decimal used,decimal free)
        {
           pieChart.ShadowStyle = ShadowStyle.GradualShadow;

            decimal[] dd = new decimal[] { free, used };
            string[] ss = new string[] { "free", "used" };
           pieChart.Values = dd;
           pieChart.Texts = ss;
           pieChart.SliceRelativeHeight = 0.25F;
           pieChart.InitialAngle = -30f;

           pieChart.LeftMargin = 10f;
           pieChart.RightMargin = 10f;
           pieChart.TopMargin = 10f;
           pieChart.BottomMargin = 10f;

            ArrayList colors = new ArrayList();
            colors.Add(Color.FromArgb((int)200, Color.Blue));
            colors.Add(Color.FromArgb((int)200, Color.Red));
           pieChart.Colors = (Color[])colors.ToArray(typeof(Color));

           pieChart.EdgeLineWidth = 1.0f;

           pieChart.EdgeColorType = EdgeColorType.DarkerThanSurface;
        }
#endregion

        void My_meter_SystemMeter_Event(object sender, Event_Meter e)
        {
            //setPieChart(pieChartControl1, Convert.ToDecimal(e.ProcessorUsage), Convert.ToDecimal(100-e.ProcessorUsage));
            //setPieChart(pieChartControl2, Convert.ToDecimal(e.RamUsage), Convert.ToDecimal(100 - e.RamUsage));
            //setPieChart(pieChartControl3, Convert.ToDecimal(e.DiskUsage), Convert.ToDecimal(100 - e.DiskUsage));
            //label4.Text = Program.UserCount.ToString();
        }

        SystemMeter My_meter = new SystemMeter();
        private void Form1_Load(object sender, EventArgs e)
        {

            svr_adv.startAdvertise();
           // Program.UserCount=Convert.ToInt32( userobj.getUserCount());
            label4.Text = listView1.Items.Count.ToString();
            backgroundWorker1.RunWorkerAsync();
            backPeerdetails.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            My_meter.startMeter();
            label5.Text = Preceiver2.ToString();
           // label6.Text= (pcount - Preceiver).ToString() ;
            label7.Text = pcount2.ToString();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            TCPreceiver.MessageReceived += new EventHandler<TcpMessageReceivedEventArgs>(TCPreceiver_MessageReceived);
            TCPreceiver.Listen();
        }

        void TCPreceiver_MessageReceived(object sender, TcpMessageReceivedEventArgs e)
        {

            
            if (e.Message.StartsWith("flag001"))
            {
                
                ListViewItem lst = new ListViewItem(e.Message.Split('^')[1]);
                   lst.ForeColor = Color.Green;
                 //  lst.SubItems.Add(e.SourceIP.Split(':')[0]);
                   lst.SubItems.Add(e.Message.Split('^')[2]);
                   lst.SubItems.Add(e.Message.Split('^')[3]);
                    listView1.Items.Add(lst);
                //   // userobj.userIPupdate(usr[0].ToString(),e.SourceIP);
                    richTextBox1.AppendText("UserLogin...... \nupdating ipaddress location...\n");
                    richTextBox1.AppendText("User IP " + e.Message.Split('^')[1].ToString() + "Login.... \n");
                //}

            }
            else if (e.Message.StartsWith("flag002"))
            {
                richTextBox1.AppendText("Service Request From " + e.SourceIP + "...\n");
            }

            else if (e.Message.StartsWith("flag003"))
            {
                richTextBox1.AppendText("Service:  "+e.Message.Split('^')[1]+" Request From " + e.SourceIP + "...\n");

                richTextBox1.AppendText("Updating service information............\n");
            }
            else if (e.Message.StartsWith("flag005"))
            {
                richTextBox1.ForeColor = Color.Red;
                richTextBox1.AppendText("Data Source Node IP:  " + e.Message.Split('^')[1] + "...\n");
                richTextBox1.AppendText("Data Destination Node IP:  " + e.Message.Split('^')[2] + "...\n");
                richTextBox1.AppendText("Data Sended Data:  " + e.Message.Split('^')[3] + "...\n");
                richTextBox1.AppendText("Date Sended Time:  " + e.Message.Split('^')[4] + "...\n");
                richTextBox1.AppendText("Packet Count:  " + e.Message.Split('^')[5] + "...\n");
                richTextBox1.AppendText("Hash Code:  " + e.Message.Split('^')[6] + "...\n");
                int ss=Convert.ToInt32(e.Message.Split('^')[5]);
                if (ss > 30)
                {
                    Preceiver1 = Convert.ToInt32(e.Message.Split('^')[5]) / 20;
                    Preceiver2 = Preceiver2 + Preceiver1;
                }
                else
                {
                    Preceiver1 = Convert.ToInt32(e.Message.Split('^')[5])-5;
                    Preceiver2 = Preceiver2 + Preceiver1;
                }

              
            }
            else if (e.Message.StartsWith("flag006"))
            {
                richTextBox1.ForeColor = Color.Green;
                richTextBox1.AppendText("Data Received by Node Ip:  " + e.Message.Split('^')[1] + "...\n");
                richTextBox1.AppendText("Status:  " + e.Message.Split('^')[2] + "...\n");
                richTextBox1.AppendText("Reached Destination Date:  " + e.Message.Split('^')[3] + "...\n");
                richTextBox1.AppendText("Date Time:  " + e.Message.Split('^')[4] + "...\n");
                richTextBox1.AppendText("Packet Loss:  " + e.Message.Split('^')[5] + "...\n");
                int pcount1=Convert.ToInt32(e.Message.Split('^')[5]);
                pcount2 = pcount2 + pcount1;
                //label7.Text = pcount2.ToString();
              
            }

            else if (e.Message.StartsWith("logout001"))
            {
                foreach (ListViewItem itm in listView1.Items)
                {
                    if (itm.Text == e.Message.Split('^')[1].ToString())
                    {
                        itm.ForeColor = Color.Red;
                    }
                }
            }

            else if (e.Message.StartsWith("filebuff"))
            {
                //ListViewItem lst = new ListViewItem(e.Message.Split('^')[1]);
                //lst.ForeColor = Color.Green;
                //lst.SubItems.Add("5657");
                //lst.SubItems.Add("Encrypted");
                //lst.SubItems.Add("Active");
                //listView_channel.Items.Add(lst);

                //CurrntSourceUser = e.Message.Split('^')[1];
                //richTextBox1.AppendText("File Buffering Started.........." + e.Message.Split('^')[1]);
                //FTserver.ReceivedPath = "C:\\Rcv";
                //ThreadStart para = delegate { FTserver.redirectRecive(e.Message.Split('^')[1], 5657); };
                //Thread thr = new Thread(para);
                //thr.Start();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TsSender ts = new TsSender(IPAddress.Parse("192.168.0.16"), 8000);
            ts.SendMessage("testmsg");
        }
        public void FillTree()
        {
            string[] IPparts = Network.getHostIP().Split('.');

            for (int i = 1; i < 255; i++)
            {
                string ip = IPparts[0] + "." + IPparts[1] + "." + IPparts[2] + "." + i.ToString();
                Ping pingObject = new Ping();
                PingReply rp = pingObject.Send(IPAddress.Parse(ip), 500);
                if (rp.Status == IPStatus.Success)
                {

                    ListViewItem lst = new ListViewItem(i.ToString());
                    lst.ForeColor = Color.Green;
                    lst.SubItems.Add(ip);
                    lst.SubItems.Add("Success");
                    listView2.Items.Add(lst);
                }
                else
                {
                    ListViewItem lst = new ListViewItem(i.ToString());
                    lst.ForeColor = Color.Red;
                    lst.SubItems.Add(ip);
                    lst.SubItems.Add("Failed");
                    listView2.Items.Add(lst);
                }

            }
        }
        private void backPeerdetails_DoWork(object sender, DoWorkEventArgs e)
        {
            FillTree();
        }

       
        }

        
    }

