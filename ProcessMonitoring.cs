using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Diagnostics;
using Scripting;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;

public enum protocol
{
    TCP = 6,
    UDP = 17,
    Unknown = -1
};
public struct NetworkStatics1
{
    public string rpacket, pfwd, pdel, pdis;

}
namespace WirelessNodeSimulation
{
    public partial class ProcessMonitoring : Form
    {
        public string routerip = "192.168.0.1", localip = null, lastdnsid = null;
        public int curansrr = -1, curauth = -1, preauth = -1, preansrr = -1, anomipcount = 0, totalanomalydetected = 0, processidentify = 0;
        public int ipheadanmcnt = 0, pktpoint = 0, unidentprotocol = 0, pktcount = 0;
        public int[] protocolstream = new int[10];
        Portact pplist = new Portact();
        public static int lcount = 0;
        public static int cwcount = 0;
        public static int ercount = 0;
        public static int ecount = 0;
        public static int twcount = 0;
        public static int wcount = 0;
        public static int ccount = 0;
        static int Rcount = 0;
        static int Dcount = 0;
        static int Ccount = 0;
        static int Chcount = 0;
        private bool m_bDirty;
        private System.IO.FileSystemWatcher m_Watcher;
        FileSystemWatcher[] fsw = null;
        private bool m_bIsWatching;
        private StringBuilder m_Sb;
        public string x1, lastiphdanm, stw;
        string s = "";
        string[] ipf = null;
        TreeNode n;
        bool iscontinue = true;
        int receive;
        Socket mainSocket;
        byte[] bData = new byte[4096];
        string[] arr = new string[96];
        string[] array1 = new string[50];
        static int i = 0;
        bool rs = true;
        int pt = 0;
        IPAddress ipaddTcpScan;
        int[] ports = new int[5000];
        //ListViewItem _listItemLogEntry;
        public int ise = 0, tm = 0;

        void getPacket()
        {
            if (iscontinue)
            {
                iscontinue = true;
                IPHostEntry ipentry = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress[] addr = ipentry.AddressList;
                string s1 = addr[3].ToString();
                // string s1 = lbaport.Text.ToString();
                mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
                mainSocket.Bind(new IPEndPoint(IPAddress.Parse(s1), 0));
                mainSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

                byte[] byTrue = new byte[4] { 1, 0, 0, 0 };
                byte[] byOut = new byte[4];
                mainSocket.IOControl(IOControlCode.ReceiveAll, byTrue, byOut);
                mainSocket.BeginReceive(bData, 0, bData.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
            }
            else
            {
                iscontinue = false;
                mainSocket.Close();
            }
        }

        void Listlog()
        {
            lstpdet.Items.Clear();
            lstpdet.Columns.Clear();
            lstpdet.Columns.Add("Source IP", 200);
            lstpdet.Columns.Add("Destination IP", 200);
            lstpdet.Columns.Add("Date Time", 210);
        }
        void ListIp()
        {
            lsvip.Items.Clear();
            lsvip.Columns.Clear();
            lsvip.Columns.Add("Source IP", 100);
            lsvip.Columns.Add("Destination IP", 135);
            lsvip.Columns.Add("Version", 95);
            lsvip.Columns.Add("HeaderLength", 115);
            lsvip.Columns.Add("Differentiated sevice", 165);
            lsvip.Columns.Add("Total length", 105);
            lsvip.Columns.Add("Identification", 115);
            lsvip.Columns.Add("Flags", 75);
            lsvip.Columns.Add("Fragmentation", 105);
            lsvip.Columns.Add("Protocol", 95);
            lsvip.Columns.Add("Time to live", 95);
            lsvip.Columns.Add("Checksum", 95);

            //lsvip.Columns.Add("Source address", 145);
            //lsvip.Columns.Add("Destination address", 135);
            lsvip.Columns.Add("Date", 140);
            lsvip.Columns.Add("Time", 160);

        }

        void ListTcp()
        {
            lsvtcp.Items.Clear();
            lsvtcp.Columns.Clear();
            lsvtcp.Columns.Add("Source IP", 140);
            lsvtcp.Columns.Add("Destination IP", 140);
            lsvtcp.Columns.Add("Source Port", 130);
            lsvtcp.Columns.Add("Destination Port", 140);
            lsvtcp.Columns.Add("Sequence No", 100);
            lsvtcp.Columns.Add("Acknowledgement No", 170);
            lsvtcp.Columns.Add("Header Length", 135);
            lsvtcp.Columns.Add("Flag", 135);
            lsvtcp.Columns.Add("Window Size", 100);
            lsvtcp.Columns.Add("Checksum", 100);
            lsvtcp.Columns.Add("Urgent pointer", 120);


            lsvtcp.Columns.Add("Date", 150);
            lsvtcp.Columns.Add("Time", 160);


        }

        void ListUdp()
        {
            lsvudp.Items.Clear();
            lsvudp.Columns.Clear();
            lsvudp.Columns.Add("Source IP", 180);
            lsvudp.Columns.Add("Destination IP", 180);
            lsvudp.Columns.Add("Source Port", 180);
            lsvudp.Columns.Add("Destination Port", 180);
            lsvudp.Columns.Add("Length", 180);
            lsvudp.Columns.Add("Check sum", 180);
            //lsvudp.Columns.Add("Date Time", 190);


            lsvudp.Columns.Add("Date", 140);
            lsvudp.Columns.Add("Time", 160);

        }
   
        public ProcessMonitoring()
        {
            InitializeComponent();
            ClientInfo();
            listView1.Columns.Add("Sl.No", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Drive", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Type", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Total Size", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Free Space", 150, HorizontalAlignment.Left);
           // pplist.portlistevent += new EventHandler<PortEvent>(pplist_portlistevent);
            pplist.portlistevent += new EventHandler<PortEvent>(pplist_portlistevent);
           
            pplist.Start();
            GetDriveInfo();
            GetInstalledProgs();
            GetProcesses();
            selNetwork();
            m_Sb = new StringBuilder();
            m_bDirty = false;
            m_bIsWatching = false;
            newfileacess();
            CheckForIllegalCrossThreadCalls = false;
            lbt.Text = DateTime.Now.ToLongTimeString();
            ListIp();
            Listlog();
            ListTcp();
            ListUdp();
            ListDns();
            getPacket();
        }

        void pplist_portlistevent(object sender, PortEvent e)
        {
             throw new NotImplementedException();
        }

        public void getNetstatus()
        {

            NetworkStatics1 nt = new NetworkStatics1();
            IPGlobalProperties ipg = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics IPStatus = ipg.GetIPv4GlobalStatistics();
            nt.rpacket = IPStatus.ReceivedPackets.ToString();
            //nt.pfwd=IPStatus.ReceivedPacketsForwarded.ToString();
            nt.pdis = IPStatus.ReceivedPacketsDiscarded.ToString();
            nt.pdel = IPStatus.ReceivedPacketsDelivered.ToString();

            lbrp.Text = nt.rpacket.ToString();
            //lbrf.Text = nt.pfwd.ToString();
            lbpd.Text = nt.pdel.ToString();
            lbpds.Text = nt.pdis.ToString();
        }
        void OnReceive(IAsyncResult ir)
        {
            int receive = mainSocket.EndReceive(ir);
            PData(bData, receive);
            checkAnomaly();
            if (iscontinue)
            {
                bData = new byte[4096];
                mainSocket.BeginReceive(bData, 0, bData.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
            }

        }
        void checkAnomaly()
        {
            lsvdet.Clear();
            try
            {

                if (totalanomalydetected == 0)
                {
                    ListViewItem it11 = new ListViewItem(" No Anomaly Detected So Far ");
                    it11.ForeColor = Color.White;
                    lsvdet.Items.Add(it11);

                }
                else
                {
                    ListViewItem it11 = new ListViewItem(" Anomaly Detected  !!!!! ");
                    it11.ForeColor = Color.Red;
                    lsvdet.Items.Add(it11);

                }
                if (anomipcount > 0)
                {
                    ListViewItem it22 = new ListViewItem(" Illegal Packet Stream Detected ");
                    it22.ForeColor = Color.Red;
                    lsvdet.Items.Add(it22);
                    AnomalySummary("THIRD LAYER", "Illegal Packet Stream Detected", DateTime.Now.ToLongTimeString());
                    ListViewItem it33 = new ListViewItem(" Packet  Count : " + anomipcount);
                    it33.ForeColor = Color.Red;
                    lsvdet.Items.Add(it33);
                    ListViewItem it44 = new ListViewItem(" Last DNS ID   : " + lastdnsid);
                    it44.ForeColor = Color.Red;
                    lsvdet.Items.Add(it44);
                }
                if (ipheadanmcnt > 0)
                {
                    ListViewItem it55 = new ListViewItem(" Packets with Invalide Header Length Detected ");
                    it55.ForeColor = Color.Red;
                    lsvdet.Items.Add(it55);
                    AnomalySummary("SECOND LAYER", "Packets with Invalide Header Length Detected", DateTime.Now.ToLongTimeString());
                    ListViewItem it56 = new ListViewItem(" Packet  Count : " + ipheadanmcnt);
                    it56.ForeColor = Color.Red;
                    lsvdet.Items.Add(it56);
                    ListViewItem it57 = new ListViewItem(" Last Detection : " + lastiphdanm);
                    it57.ForeColor = Color.Red;
                    lsvdet.Items.Add(it57);

                }
                if (unidentprotocol > 0)
                {
                    pktcount = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        if (protocolstream[i] == 1)
                        {
                            pktcount++;
                        }
                    }
                    if (pktcount > 4)
                    {
                        ListViewItem it58 = new ListViewItem(" Unknown Protocol Stream Detected");
                        it58.ForeColor = Color.Red;
                        lsvdet.Items.Add(it58);

                        int cou = 0;
                        string st = "Unknown Protocol Stream Detected";
                        for (int i = 0; i < lstadet.Items.Count; i++)
                        {
                            string strlist = lstadet.Items[i].SubItems[1].Text.ToString();
                            if (st.Trim() == strlist.Trim())
                                cou++;
                        }
                        if (cou == 0)
                        {
                            AnomalySummary("SECOND LAYER", "Unknown Protocol Stream Detected", DateTime.Now.ToLongTimeString());
                        }
                    }

                }
            }

            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "check", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddTolistEntry(string sourceip, string destinationip, string datetime)
        {
            ListViewItem Log = new ListViewItem(sourceip);
            // Log.ForeColor = Color.Red;
            // lstpdet.Items.Add(sourceip);
            Log.SubItems.Add(destinationip);
            Log.SubItems.Add(datetime);
            lstpdet.Items.Add(Log);

        }
        void AddIp(Ipheader1 ipobj)
        {
            ListViewItem it1 = new ListViewItem(ipobj.sourceaddr.ToString());

            bool _status = GetStatusColorIP(ipobj.sourceaddr.ToString());


            if (_status)
                it1.ForeColor = Color.Red;
            else
                it1.ForeColor = Color.White;
            //it1.ForeColor = Color.Green;
            it1.SubItems.Add(ipobj.destaddr.ToString());
            it1.SubItems.Add(ipobj.Version);
            it1.SubItems.Add(ipobj.Headerlength);
            it1.SubItems.Add(ipobj.diffservice);
            it1.SubItems.Add(ipobj.TotalLength);
            it1.SubItems.Add(ipobj.Identification);
            it1.SubItems.Add(ipobj.Flags);
            it1.SubItems.Add(ipobj.Fragmentationoffset);
            it1.SubItems.Add(ipobj.Protocoltype.ToString());
            it1.SubItems.Add(ipobj.TTL);
            it1.SubItems.Add(ipobj.Checksum);
            it1.SubItems.Add(DateTime.Now.ToShortDateString());
            it1.SubItems.Add(DateTime.Now.ToLongTimeString());
            lsvip.Items.Add(it1);



        }
        void AddUdp(Udpheader udpobj, Ipheader1 ipobj)
        {
            ListViewItem it2 = new ListViewItem(ipobj.sourceaddr.ToString());
            bool udpcolor = GetStatusColorIP(ipobj.sourceaddr.ToString());
            if (udpobj.SourcePort.ToString() == udpobj.DestinationPort.ToString())
            {
                // if(ipobj.sourceaddr.ToString()==ipobj.destaddr.ToString())
                // {
                int ct = 0;

                string x = ipobj.sourceaddr.ToString();
                for (int i = 0; i < lstip.Items.Count; i++)
                {
                    if (x.ToString().Trim() == lstip.Items[i].ToString().Trim())
                        ct++;
                }
                if (ct == 0)
                {
                    lstip.Items.Add(ipobj.sourceaddr.ToString());
                }

                it2.ForeColor = Color.Red;

                AddTolistEntry(ipobj.sourceaddr.ToString(), ipobj.destaddr.ToString(), DateTime.Now.ToString());

            

            }

         
            else
            {
                it2.ForeColor = Color.White;
            }
          
            it2.SubItems.Add(ipobj.destaddr.ToString());
            it2.SubItems.Add(udpobj.SourcePort);
            it2.SubItems.Add(udpobj.DestinationPort);
            it2.SubItems.Add(udpobj.Length);
            it2.SubItems.Add(udpobj.Checksum);
            it2.SubItems.Add(DateTime.Now.ToShortDateString());
            it2.SubItems.Add(DateTime.Now.ToLongTimeString());
            lsvudp.Items.Add(it2);
            checkDosLayer();
        }
        void checkDosLayer()
        {
            int count = 0;
            for (int i = 0; i < lstip.Items.Count; i++)
            {
                string x = lstip.Items[i].ToString();
                //MessageBox.Show(x);
                for (int k = 0; k < lstpdet.Items.Count; k++)
                {
                    if (x.ToString().Trim() == lstpdet.Items[k].SubItems[0].Text.ToString().Trim())
                    {
                        count++;
                        if (count > 20)
                        {
                            int cou = 0;
                            string st = "Anomaly detected in IP Address :" + x;
                            for (int ii = 0; ii < lstadet.Items.Count; ii++)
                            {
                                string strlist = lstadet.Items[ii].SubItems[1].Text.ToString();
                                if (st.Trim() == strlist.Trim())
                                    cou++;
                            }
                            if (cou == 0)
                            {
                                //DialogResult d = MessageBox.Show("ANOMALY DETECTED IN IP ADDRESS :" + x, "CHECKING IP ADDRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                
                                AnomalySummary("SECOND LAYER", "Anomaly detected in IP Address :" + x, DateTime.Now.ToLongTimeString());
                                ListViewItem ltdt = new ListViewItem("SECOND LAYER Anomaly detected in IP Address :" + x);
                                //ltdt.SubItems.Add();
                                lsvdet.Items.Add(ltdt);




                            }
                        }
                    }
                }
                count = 0;
            }
        }
        void AddTcp(Tcpheader tcpobj, Ipheader1 ipobj)
        {
            ListViewItem it3 = new ListViewItem(ipobj.sourceaddr.ToString());
            bool _status = GetStatusColorIP(ipobj.sourceaddr.ToString());

            // it3 = lsvtcp.Items.Add(ipobj.sourceaddr.ToString());
            if (_status)
                it3.ForeColor = Color.Red;
            else
                it3.ForeColor = Color.White;
            // it3.ForeColor = Color.Green;
            it3.SubItems.Add(ipobj.destaddr.ToString());
            it3.SubItems.Add(tcpobj.Sourceport);
            it3.SubItems.Add(tcpobj.Destinationport);
            it3.SubItems.Add(tcpobj.SequenceNo);
            it3.SubItems.Add(tcpobj.AckNo);
            it3.SubItems.Add(tcpobj.HeaderLength);
            it3.SubItems.Add(tcpobj.Flags);
            it3.SubItems.Add(tcpobj.Windsize);
            it3.SubItems.Add(tcpobj.Checksum);
            it3.SubItems.Add(tcpobj.UrgentPtr);
            if (tcpobj.UrgentPtr != "")
                it3.SubItems.Add(tcpobj.UrgentPtr);
      
            it3.SubItems.Add(DateTime.Now.ToShortDateString());
            it3.SubItems.Add(DateTime.Now.Date.ToLongTimeString());
            lsvtcp.Items.Add(it3);
            // anomaly detection
            String SourceIP = "";
            int DestPort, i, k, count, index = 0;
            SourceIP = ipobj.sourceaddr.ToString();
            count = lsvtcp.Items.Count;
            IPHostEntry iphost = Dns.GetHostEntry(Dns.GetHostName());
            ipaddTcpScan = iphost.AddressList[0];
            for (i = 0; i < count; i++)
            {
                if (SourceIP == lsvtcp.Items[i].SubItems[0].Text)
                {
                    DestPort = int.Parse(lsvtcp.Items[i].SubItems[3].Text);
                    k = System.Array.IndexOf(ports, DestPort);
                    if (k == -1)
                    {
                        ports[index] = DestPort;
                        index++;
                    }
                    if (index >= 3 && SourceIP != ipaddTcpScan.ToString())
                    {
                        index = 0;
                        if (System.Array.IndexOf(array1, SourceIP) == -1)
                        {
                            array1[++pt] = SourceIP;
                            //DialogResult d = MessageBox.Show("ANOMALY DETECTED IP ADDRESS : " + SourceIP, "PORT SCANNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            AnomalySummary("SECOND LAYER", "Anomaly detected IP Address" + SourceIP, DateTime.Now.ToLongTimeString());
                            lstip.Items.Add(SourceIP);

                        }
                    }
                }
            }
        }
        void DnsCheckTcp(Tcpheader tcpobj, Ipheader1 ipobj)
        {


            if (tcpobj.Destinationport == "53" || tcpobj.Sourceport == "53")
            {
                DNSHeader dnsobj = new DNSHeader(tcpobj.Data, (int)tcpobj.MsgLength);
                ListViewItem item1 = new ListViewItem(ipobj.sourceaddr.ToString());
                item1.SubItems.Add(dnsobj.Identification);
                item1.SubItems.Add(dnsobj.Flags);
                item1.SubItems.Add(dnsobj.TotalQuestions);
                item1.SubItems.Add(dnsobj.TotalAnswerRRs);
                item1.SubItems.Add(dnsobj.TotalAuthorityRRs);
                item1.SubItems.Add(dnsobj.TotalAdditionalRRs);
                lstdns.Items.Add(item1);

                if (ipobj.sourceaddr.ToString() == routerip && ipobj.sourceaddr.ToString() != localip)
                {

                    curansrr = Convert.ToInt32(dnsobj.TotalAnswerRRs);
                    curauth = Convert.ToInt32(dnsobj.TotalAuthorityRRs);
                    if (preauth == 1 && curauth == 1)
                    {
                        if (preansrr == 0 && curansrr == 0)
                        {
                            anomipcount++;
                            lastdnsid = dnsobj.Identification;
                            totalanomalydetected++;
                        }
                    }
                }
            }


        }
        void DnsCheckUdp(Udpheader udpobj, Ipheader1 ipobj)
        {

            if (udpobj.DestinationPort == "53" || udpobj.SourcePort == "53")
            {
                DNSHeader dnsobj = new DNSHeader(udpobj.Data, Convert.ToInt32(udpobj.Length) - 8);
                ListViewItem item1 = new ListViewItem(ipobj.sourceaddr.ToString());
                item1.SubItems.Add(dnsobj.Identification);
                item1.SubItems.Add(dnsobj.Flags);
                item1.SubItems.Add(dnsobj.TotalQuestions);
                item1.SubItems.Add(dnsobj.TotalAnswerRRs);
                item1.SubItems.Add(dnsobj.TotalAuthorityRRs);
                item1.SubItems.Add(dnsobj.TotalAdditionalRRs);
                lstdns.Items.Add(item1);
                if (ipobj.sourceaddr.ToString() == routerip && ipobj.sourceaddr.ToString() != localip)
                {
                    curansrr = Convert.ToInt32(dnsobj.TotalAnswerRRs);
                    curauth = Convert.ToInt32(dnsobj.TotalAuthorityRRs);
                    if (preauth == 1 && curauth == 1)
                    {
                        if (preansrr == 0 && curansrr == 0)
                        {
                            anomipcount++;
                            lastdnsid = dnsobj.Identification;
                            totalanomalydetected++;
                        }
                    }
                }
            }
        }

        void PData(byte[] bData, int receive)
        {
            Ipheader1 ipob = new Ipheader1(bData, receive);
            AddIp(ipob);
            switch (ipob.Protocoltype)
            {
                case protocol.TCP: Tcpheader tcpob = new Tcpheader(ipob.Data, (int)ipob.Messagelength);
                    AddTcp(tcpob, ipob);
                    DnsCheckTcp(tcpob, ipob);
                    break;


                case protocol.UDP: Udpheader udpob = new Udpheader(ipob.Data, (int)ipob.Messagelength);
                    AddUdp(udpob, ipob);
                    DnsCheckUdp(udpob, ipob);
                    break;

            }
            if (Convert.ToInt32(ipob.Headerlength) < 20)
            {
                ipheadanmcnt += 1;
                lastiphdanm = ipob.sourceaddr.ToString();
                totalanomalydetected++;
            }
            if (ipob.Protocoltype.ToString() == "TCP" || ipob.Protocoltype.ToString() == "UDP")
            {
                protocolstream[pktpoint] = 0;
                pktpoint++;
                if (pktpoint == 10)
                    pktpoint = 0;
            }
            else if (ipob.Protocoltype.ToString() == "Unknown")
            {
                unidentprotocol++;
                protocolstream[pktpoint] = 1;
                pktpoint++;
                if (pktpoint == 10)
                    pktpoint = 0;

                pktcount = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (protocolstream[i] == 1)
                    {
                        pktcount++;
                    }
                }
                if (pktcount > 6)
                {
                    totalanomalydetected++;
                }
            }
        }
        private bool GetStatusColorIP(string sourceIP)
        {
            bool _STATUS = false;
            foreach (string ip in lstip.Items)
            {
                if (ip == sourceIP)
                    _STATUS = true;
            }
            return _STATUS;
        }
        public void newfileacess()
        {
            if (m_bIsWatching)
            {
                m_bIsWatching = false;
                m_Watcher.EnableRaisingEvents = false;
                m_Watcher.Dispose();


            }
            else
            {
                string[] drives = System.IO.Directory.GetLogicalDrives();
                fsw = new FileSystemWatcher[drives.Length];
                for (int i = 0; i < drives.Length; i++)
                {
                m_bIsWatching = true;
                m_Watcher = new System.IO.FileSystemWatcher();
               
                     if (Directory.Exists(drives[i]))
                     {
                         m_Watcher.Filter = "*.*";
                         m_Watcher.Path = drives[i];
                         m_Watcher.IncludeSubdirectories = true;
                         m_Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                              | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                         m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
                         m_Watcher.Created += new FileSystemEventHandler(OnChanged3);
                         m_Watcher.Deleted += new FileSystemEventHandler(OnChanged2);
                         m_Watcher.Renamed += new RenamedEventHandler(OnRenamed);
                         m_Watcher.EnableRaisingEvents = true;
                     }
                 }
            }
        }

        private void OnChanged2(object sender, FileSystemEventArgs e)
        {
            Dcount++;
           

            if (!m_bDirty)
            {
                m_Sb.Remove(0, m_Sb.Length);
                m_Sb.Append(e.FullPath);
                m_Sb.Append(" ");
                m_Sb.Append(e.ChangeType.ToString());
                m_Sb.Append("    ");
                m_Sb.Append(DateTime.Now.ToString());


                ListViewItem it = new ListViewItem(e.FullPath);
                it.ForeColor = Color.Red;
                it.SubItems.Add(e.ChangeType.ToString());
                it.SubItems.Add(DateTime.Now.ToString());
                listView4.Items.Add(it);

                m_bDirty = true;





            }
        }

        private void OnChanged3(object sender, FileSystemEventArgs e)
        {


            if (!m_bDirty)
            {
                Ccount++;
             

                m_Sb.Remove(0, m_Sb.Length);
                m_Sb.Append(e.FullPath);
                m_Sb.Append(" ");
                m_Sb.Append(e.ChangeType.ToString());
                m_Sb.Append("    ");

                m_Sb.Append(DateTime.Now.ToString());


                m_bDirty = true;
              
                 

                    ListViewItem it = new ListViewItem(e.FullPath);
                    it.ForeColor = Color.White;
                    it.SubItems.Add(e.ChangeType.ToString());
                    it.SubItems.Add(DateTime.Now.ToString());
                    listView4.Items.Add(it);
              



            }
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {


            if (!m_bDirty)
            {


                m_Sb.Remove(0, m_Sb.Length);
                m_Sb.Append(e.FullPath);
                m_Sb.Append(" ");
                m_Sb.Append(e.ChangeType.ToString());
                m_Sb.Append("    ");

                m_Sb.Append(DateTime.Now.ToString());


                m_bDirty = true;



                if (e.ChangeType.ToString() == "Changed")
                {
                    Chcount++;
                   
                    ListViewItem it = new ListViewItem(e.FullPath);
                    it.ForeColor = Color.White;
                    it.SubItems.Add(e.ChangeType.ToString());
                    it.SubItems.Add(DateTime.Now.ToString());
                    listView4.Items.Add(it);
                }
                else
                {
                    ListViewItem it = new ListViewItem(e.FullPath);
                    it.ForeColor = Color.White;
                    it.SubItems.Add(e.ChangeType.ToString());
                    it.SubItems.Add(DateTime.Now.ToString());
                    listView4.Items.Add(it);

                }
                if (Chcount > 100)
                {
                    x1 = e.Name;
                }
                string x = e.Name;
                int l = x.LastIndexOf("\\");
                string x2 = x.Substring(l + 1);
                string[] a = x2.Split('.');
                string x3 = a[0];

                int l11 = x2.LastIndexOf(".");
                string x4 = x2.Substring(l11 + 1);
                if (x4.ToString().Trim() == x3.ToString().Trim())
                {
                    int ct = 0;
                    for (int i = 0; i < lstf.Items.Count; i++)
                    {
                        if (x3.ToString().Trim() == lstf.Items[i].Text.ToString().Trim())
                            ct++;
                    }
                    if (ct == 0)
                    {
                        lstf.Items.Add(x2.ToString());
                        //MessageBox.Show(x.ToString());
                        AnomalySummary("FIRST LAYER", "File Modifications at" + x2, System.DateTime.Now.ToShortTimeString());

                    }

                }
               

                           
                  
                

            }
        }
        void AnomalySummary(string s, string s1, string s2)
        {
            ListViewItem lt0 = new ListViewItem(s);
            if (s == "FIRST LAYER")
                lt0.ForeColor = Color.White;
            if (s == "SECOND LAYER")
                lt0.ForeColor = Color.Red;
            if (s == "THIRD LAYER")
                lt0.ForeColor = Color.Blue;
            lt0.SubItems.Add(s1);
            lt0.SubItems.Add(s2);
            lstadet.Items.Add(lt0);
        }
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            Rcount++;
            label32.Text = "Renamed Files :" + Rcount;
            if (!m_bDirty)
            {
                m_Sb.Remove(0, m_Sb.Length);
                m_Sb.Append(e.OldFullPath);
                m_Sb.Append(" ");
                m_Sb.Append(e.ChangeType.ToString());
                m_Sb.Append(" ");
                m_Sb.Append("to ");
                m_Sb.Append(e.Name);
                m_Sb.Append("    ");
                m_Sb.Append(DateTime.Now.ToString());
                m_bDirty = true;

                ListViewItem it = new ListViewItem(e.OldFullPath);
                it.ForeColor = Color.Blue;
                it.SubItems.Add(e.ChangeType.ToString() + " to " + e.Name);

                it.SubItems.Add(DateTime.Now.ToString());
                listView4.Items.Add(it);

                m_Watcher.Filter = e.Name;
                m_Watcher.Path = e.FullPath.Substring(0, e.FullPath.Length - m_Watcher.Filter.Length);

            }
        }

        void Form2_Renamed(object sender, RenamedEventArgs e)
        {

         
            if (Rcount > 20)
            {
                x1 = e.Name;
            }
        }

        void Form2_Created(object sender, FileSystemEventArgs e)
        {
         
            if (Ccount > 20)
            {
                x1 = e.Name;
            }
        }

        void Form2_Deleted(object sender, FileSystemEventArgs e)
        {

            if (Dcount > 20)
            {
                x1 = e.Name;
            }
        }
        public void selNetwork()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            for (int i = 0; i < interfaces.Length; i++)
            {
                lstnet.Items.Add("\n");
                lstnet.Items.Add("NAME                                   " + interfaces[i].Name);
                lstnet.Items.Add("ID                                          " + interfaces[i].Id);
                lstnet.Items.Add("DESCRIPTION                       " + interfaces[i].Description);
                lstnet.Items.Add("SPEED                                   " + interfaces[i].Speed);
                lstnet.Items.Add("INTERFACE TYPE                   " + interfaces[i].NetworkInterfaceType);
                lstnet.Items.Add("\n\n");

                //Txtnet.Text = "Name :" + interfaces[i].Name + "\n" + "Id :" + interfaces[i].Id + "\n" + "Description :" + interfaces[i].Description + "\n" + "Speed :" + interfaces[i].Speed +"\n"+ "Interface type :" + interfaces[i].NetworkInterfaceType  ;
            }
        }

        void pplist_portlistevent(object sender, PortEvent1 e)
        {

            //lstport.Items.Clear();
            lcount = 0;
            cwcount = 0;
            ecount = 0;
            twcount = 0;
            wcount = 0;
            CheckForIllegalCrossThreadCalls = false;
            foreach (PortInfo prt in e.Portarg)
            {
                ListViewItem it = new ListViewItem(prt.process);
                it.SubItems.Add(prt.port);
                it.SubItems.Add(prt.protocol);
                it.SubItems.Add(prt.PID);
                it.SubItems.Add(prt.status);
                if (prt.status.ToString() == "LISTENING")
                {
                    it.ForeColor = Color.White;
                    lcount++;
                }
                else if (prt.status.ToString() == "CLOSE_WAIT")
                {
                    it.ForeColor = Color.Purple;
                    cwcount++;
                }
                else if (prt.status.ToString() == "ESTABLISHED")
                {
                    it.ForeColor = Color.SkyBlue;
                    ecount++;
                }
                else if (prt.status.ToString() == "TIME_WAIT")
                {
                    it.ForeColor = Color.Blue;
                    twcount++;
                }
                else if (prt.status.ToString() == "WAITING")
                {
                    it.ForeColor = Color.Red;
                    wcount++;
                }

                //lstport.Items.Add(it);

            }

            //listBox1.Items.Clear();
            //listBox1.Items.Add("Listening ports: " + lcount);
            //listBox1.Items.Add("Close wait ports: " + cwcount);
            //listBox1.Items.Add("Established ports: " + ecount);
            //listBox1.Items.Add("Time waitng ports: " + twcount);
            //listBox1.Items.Add("Waitng ports: " + wcount);



        
        }
        // Structure to hold Memory Details

        public struct MEMORYSTATUS
        {
            public long dwLength;
            public long dwMemoryLoad;
            public long dwTotalPhys;
            public long dwAvailPhys;
            public long dwTotalPagefile;
            public long dwAvailPagefile;
            public long dwTotalVirtual;
            public long dwAvailVirtual;

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MemoryStatusEx
        {
            public int dwLength;
            public int dwMemoryLoad;
            public long dwTotalPhys;
            public long dwAvailPhys;
            public long dwTotalPageFile;
            public long dwAvailPageFile;
            public long dwTotalVirtual;
            public long dwAvailVirtual;
            public long dwAvailExtendedVirtual;
        }


        private void MemoryInfo()
        {
            string minfo = "";

            MemoryStatusEx ms = new MemoryStatusEx();
            ms.dwLength = Marshal.SizeOf(typeof(MemoryStatusEx));
            bool res = GlobalMemoryStatusEx(ref ms);

            label9.Text = ms.dwMemoryLoad.ToString();
            label10.Text = (((double.Parse(ms.dwTotalPhys.ToString())) / 1024) / 1024).ToString() + " MB";
            label11.Text=  (((double.Parse(ms.dwAvailPhys.ToString()))/1024)/1024).ToString() +" MB";
            label12.Text = (((double.Parse(ms.dwTotalVirtual.ToString())) / 1024) / 1024).ToString() + " MB";
            label13.Text = (((double.Parse(ms.dwAvailVirtual.ToString())) / 1024) / 1024).ToString() + " MB";
            label14.Text = (((double.Parse(ms.dwTotalPageFile.ToString())) / 1024) / 1024).ToString() + " MB";
            label15.Text = (((double.Parse(ms.dwAvailPageFile.ToString())) / 1024) / 1024).ToString() + " MB";
            label16.Text = ms.dwLength.ToString();

          
        }

        private void ClientInfo()
        {
            string msg = string.Empty;
            label17.Text = SystemInformation.ComputerName;
           label18.Text=SystemInformation.UserName;
           label19.Text = SystemInformation.UserDomainName;
           label20.Text = SystemInformation.Network.ToString();
           label21.Text = SystemInformation.MousePresent.ToString();
          

          
            //evSendInfo("CLIENTINFO|" + msg);
        }


        private void GetDriveInfo()
        {
            string driveinfo = string.Empty;
            FileSystemObject f = new Scripting.FileSystemObject();
            Drives drives = f.Drives;

            foreach (Drive dri in drives)
            {
                driveinfo = driveinfo + "|DRIVE|" + dri.DriveLetter + "|" + dri.DriveType + "|";

                if (dri.IsReady)
                {
                    double TotalSize1 = (((double.Parse(dri.TotalSize.ToString())) / 1024) / 1024);
                    string TotalSize = string.Format("{0:N2}" + " MB", TotalSize1);

                    double FreeSpace1 = (((double.Parse(dri.FreeSpace.ToString())) / 1024) / 1024);
                    string FreeSpace = string.Format("{0:N2}" + " MB", FreeSpace1);

                    driveinfo = driveinfo + TotalSize + "|" + FreeSpace;

                    //driveinfo=driveinfo+dri.TotalSize+"|"+dri.FreeSpace;					
                }
                else
                {
                    driveinfo = driveinfo + "Unknown|Unknown";

                }
            }
            DisplayInfo(driveinfo);

        }

        private void GetInstalledProgs()
        {
            string progs = string.Empty;
            string key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey rkey = Registry.LocalMachine.OpenSubKey(key);
            foreach (string keyName in rkey.GetSubKeyNames())
            {
                RegistryKey k = rkey.OpenSubKey(keyName);
                if (k.GetValue("DisplayName") != null)
                {

                    progs = progs + "|" + k.GetValue("DisplayName").ToString();
                }
            }

            DisplayInfo2(progs);


        }

        private void GetProcesses()
        {
            string proinfo = string.Empty;
            Process[] pro = Process.GetProcesses();
            foreach (Process p in pro)
            {
                proinfo = proinfo + "|" + p.ProcessName;
              
              
            }

            DisplayInfo3(proinfo);

        }

        public void DisplayInfo(string Information)
        {


            listView1.Items.Clear();
           

            string[] strArray = Information.Split((char)124);

            int k = -1;

            foreach (string drives in strArray)
            {

                if (drives.Equals("DRIVEINFO") || drives.Equals(string.Empty) || (drives.Equals("T") && k == -1))
                    continue;
                if (drives.Equals("DRIVE"))
                {
                    k++;
                    listView1.Items.Add((k + 1).ToString());

                }
                else
                {
                    listView1.Items[k].SubItems.Add(drives);

                }


            }

        }


        public void DisplayInfo2(string Information)
        {

            listView2.Items.Clear();

            string[] strArray = Information.Split((char)124);

            int k = 0;
            foreach (string programs in strArray)
            {

                if (programs.Equals("INSTALLEDPROG") || programs.Equals(string.Empty) || (programs.Equals("T") && k == 0))
                    continue;
                listView2.Items.Add(programs);
                k = k + 1;


            }
        }


        public void DisplayInfo3(string Information)
        {
            listView3.Items.Clear();

            string[] strArray = Information.Split((char)124);


            foreach (string process in strArray)
            {
                if (process.Equals("PROCESS") || process.Equals(string.Empty) || process.Equals("T"))
                    continue;
                listView3.Items.Add(process);

            }
        }
        // Windows API used to get Memory Information.

        [DllImport("Kernel32.dll", ExactSpelling = true)]
        private static extern void GlobalMemoryStatus(ref MEMORYSTATUS mm);



        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool GlobalMemoryStatusEx([In, Out] ref MemoryStatusEx mse);



        // Windows API used to execute CD Drive Operations like Open and Close Drive

        [DllImport("winmm.dll", ExactSpelling = true)]
        public static extern long mciSendStringA(string lpstrCommand, string lpstrReturnString, long uReturnLength, long hwndCallback);

    
        private System.Windows.Forms.Label lblMessage;


        TcpListener tcpListner1;
        TcpClient tcpClient1;

        Thread thrListen;
        public Thread thrShowForm;

        delegate void delGetData();
        delegate void delSendData();
        delegate void delSendSize();

        delegate void delGetInfo(string s1);
        delegate void delSendInfo(string s2);

        event delGetData evGetData;
        event delSendData evSendData;
        event delSendSize evSendSize;

        event delSendInfo evGetInfo;
        event delSendInfo evSendInfo;

        string MessageToDisplay;

        CapLib.CaptureDesktop Cap = new CapLib.CaptureDesktop();

      

        IPAddress ipServerIP;
        string strServerIP;


        // Port where RDM client listens to incoming request from RDM server program

        int intLocalPort = 9998;

        private System.Windows.Forms.NotifyIcon notifyIcon1;


        // Port where RDM server listens and RDM client send information to that port.

        int intRemotePort = 9999;

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void MemoryTimer_Tick(object sender, EventArgs e)
        {

            MemoryInfo();
            ClientInfo();
           
        }

        private void Programstimer_Tick(object sender, EventArgs e)
        {
            GetDriveInfo();
            GetInstalledProgs();
            GetProcesses();
        }
        void ListDns()
        {
            lstdns.Items.Clear();
            lstdns.Columns.Clear();
            lstdns.Columns.Add("DNS Source", 140);
            lstdns.Columns.Add("Identification", 140);
            lstdns.Columns.Add("Flags", 130);
            lstdns.Columns.Add("Questions", 140);
            lstdns.Columns.Add("Answer RR", 100);
            lstdns.Columns.Add("Authority RR", 170);
            lstdns.Columns.Add("Additional RRs", 135);

        }

        private void tmrEditNotify_Tick(object sender, EventArgs e)
        {
            getNetstatus();
            if (m_bDirty)
            {

                m_bDirty = false;
            }
            lfs1.Text = Ccount.ToString();
            lfs2.Text = Dcount.ToString();
            lfs3.Text = Chcount.ToString();
            lfs4.Text = Rcount.ToString();
            if (Ccount > 20)
            {
                lfa1.ForeColor = Color.Red;
                lfa1.Text = "Anomaly detected while file creation pls check the file";

                int cou = 0;
                string st = "Anomaly detected while file creation   " + x1;
                for (int i = 0; i < lstadet.Items.Count; i++)
                {
                    string strlist = lstadet.Items[i].SubItems[1].Text.ToString();
                    if (st.Trim() == strlist.Trim())
                        cou++;
                }
                if (cou == 0)
                {

                    AnomalySummary("FIRST LAYER", "Anomaly detected while file creation   " + x1, DateTime.Now.ToLongTimeString());

                }
            }
            else
            {
                lfa1.ForeColor = Color.White;
                lfa1.Text = "File created normally";
            }

            if (Dcount > 20)
            {
                lfa2.ForeColor = Color.Red;
                lfa2.Text = "Anomaly detected while file deletion pls check the file";

                int cou1 = 0;
                string st1 = "Anomaly detected while file deletion    " + x1;
                for (int i = 0; i < lstadet.Items.Count; i++)
                {
                    string strlist = lstadet.Items[i].SubItems[1].Text.ToString();
                    if (st1.Trim() == strlist.Trim())
                        cou1++;
                }
                if (cou1 == 0)
                {
                    AnomalySummary("FIRST LAYER", "Anomaly detected while file deletion    " + x1, DateTime.Now.ToLongTimeString());
                }
            }
            else
            {
                lfa2.ForeColor = Color.White;
                lfa2.Text = "File deleted normally";
            }

            if (Chcount > 100)
            {
                lfa3.ForeColor = Color.Red;
                lfa3.Text = "Anomaly detected while file changed pls check the file";
                /*ListViewItem lt2 = new ListViewItem("PROBE LAYER");
                lt2.SubItems.Add("Anomaly detected while file changed ");
                lt2.SubItems.Add(DateTime.Now.ToString());
                lstadet.Items.Add(lt2);*/
                int cou2 = 0;
                string st2 = "Anomaly detected while file changed    " + x1;
                for (int i = 0; i < lstadet.Items.Count; i++)
                {
                    string strlist = lstadet.Items[i].SubItems[1].Text.ToString();
                    if (st2.Trim() == strlist.Trim())
                        cou2++;
                }
                if (cou2 == 0)
                {
                    AnomalySummary("FIRST LAYER", "Anomaly detected while file changed    " + x1, DateTime.Now.ToLongTimeString());
                }
            }
            else
            {
                lfa3.ForeColor = Color.White;
                lfa3.Text = "File changed normally";
            }


            if (Rcount > 20)
            {
                lfa4.ForeColor = Color.Red;
                lfa4.Text = "Anomaly detected while file renamed pls check the file ";

                int cou3 = 0;
                string st3 = "Anomaly detected while file renamed     " + x1;
                for (int i = 0; i < lstadet.Items.Count; i++)
                {
                    string strlist = lstadet.Items[i].SubItems[1].Text.ToString();
                    if (st3.Trim() == strlist.Trim())
                        cou3++;
                }
                if (cou3 == 0)
                {
                    AnomalySummary("FIRST LAYER", "Anomaly detected while file renamed     " + x1, DateTime.Now.ToLongTimeString());
                }
            }
            else
            {
                lfa4.ForeColor = Color.White;
                lfa4.Text = "File renamed normally";
            }

        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstadet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage9)
            {
                this.Close();
            }
        }
    }
}
