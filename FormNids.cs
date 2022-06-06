using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
//using FormPacketCapture;
//using Packet_Manager;
using System.Net;
using System.IO;
using System.DirectoryServices;
using System.Threading;
using WirelessNodeSimulation;
using System.Net.NetworkInformation;
//using NIDs;
using System.Data.SqlClient;

namespace WirelessNodeSimulation
{
    //public enum Protocol
    //{
    //    TCP = 6,
    //    UDP = 17,
    //    Unknown = -1
    //};
    public partial class FormNids : Form
    { 
        #region Global variables for Packet Analyzer
        Socket mainSocket = null;
        byte[] bData = new byte[4096];
        bool IsContinueCapture = false;
        ListViewItem _listItemIp, _listItemTcp,_listItemTcpb, _listItemUdp,_listItemUdpb, _listItemLogEntry = null;
        int[] array = new int[50];
        string[] array1 = new string[50];
        int[] ports = new int[5000];
        int pt = 0;
        IPAddress ipaddTcpScan;

        public static string protocol = "";
        public static string sip = "";
        public static string sport = "";
        public static string dip = "";
        public static string dport = "";
        public static string action = "";

        #endregion

        #region Global variables for Machines On LAN
        ListViewItem _Lwl = null;
        Thread _theGetComputer = null;
      //  FormPing _frmPing = null;
       // NidsNetworkManager _Nm = null;
        #endregion

        BaseConnection con = new BaseConnection();
        public FormNids()
        {

            InitializeComponent();
            GetIPAdd();
            fillcombo();
            CheckForIllegalCrossThreadCalls = false;
            butGetPackets.Enabled = true;
            //Machines On LAN
           // progressBar1.Visible = false;
          //  textBoxMLip.Visible = false;
            //butStopScan.Enabled = false;
          //  labelMLCount.Visible = false;
        }

        public void fillcombo()
        {
            string query = "select rules from detection";
            SqlDataReader dr = con.ret_dr(query);
            while (dr.Read())
            {
                comboRules.Items.Add(dr[0].ToString());
            }
            

        }

        #region Enumarator WellKnown ports
        enum WellKnownPorts
        {
            Unknown = 0,
            TCPMUX = 1,
            RJE = 5, ECHO = 7,
            MSP = 18,
            FTPData = 20,
            FTPControl = 21,
            SSH = 22,
            Telnet = 23,
            SMTP = 25,
            MSGICP = 29,
            Time = 37,
            HostNameServer = 42,
            WhoIs = 43,
            LoginHostProtocol = 49,
            DNS = 53,
            TFTP = 69,
            GopherServices = 70,
            Finger = 79,
            HTTP = 80,
            X400Standard = 103,
            SNAGatewayAccessServer = 108,
            POP2 = 109,
            POP3 = 110,
            SFTP = 115,
            SQLServices = 118,
            NNTP = 119,
            NetBIOSNameService = 137,
            NetBIOSDatagramService = 139,
            IMAP = 143,
            NetBIOSSessionService = 150,
            SQLServer = 156,
            SNMP = 161,
            BGP = 179,
            GACP = 190,
            IRC = 194,
            DLS = 197,
            LDAP = 389,
            NovellNetwareoverIP = 396,
            HTTPS = 443,
            SNPP = 444,
            MicrosoftDS = 445,
            AppleQuickTime = 458,
            DHCPClient = 546,
            DHCPServer = 547,
            SNEWS = 563,
            MSN = 569,
            Socks = 1080

        }
        #endregion

        #region Packet Analyzer Code
        private void setIpLIstView()
        {
            listViewIPPacket.Items.Clear();
            listViewIPPacket.Columns.Clear();
            listViewIPPacket.Columns.Add("Source IP", 100);
            listViewIPPacket.Columns.Add("Destination IP", 100);
            listViewIPPacket.Columns.Add("Version", 40);
            listViewIPPacket.Columns.Add("Header Length", 100);
            listViewIPPacket.Columns.Add("Differentiated Services", 120);
            listViewIPPacket.Columns.Add("Total Length", 80);
            listViewIPPacket.Columns.Add("Identification", 80);
            listViewIPPacket.Columns.Add("Flags", 80);
            listViewIPPacket.Columns.Add("Fragmentaion Offset", 80);
            listViewIPPacket.Columns.Add("Time to live", 80);
            listViewIPPacket.Columns.Add("Check Sum", 80);
            listViewIPPacket.Columns.Add("Date Time", 80);
            listViewIPPacket.View = View.Details;
            listViewIPPacket.GridLines = true;
            //TcpListview
            listViewTCP.Items.Clear();
            listViewTCP.Columns.Add("Source IP", 100);
            listViewTCP.Columns.Add("Destination IP", 100);
            listViewTCP.Columns.Add("Source Port", 120);
            listViewTCP.Columns.Add("Destination Port", 120);
            listViewTCP.Columns.Add("Sequence Number", 120);
            listViewTCP.Columns.Add("Acknowledgement", 120);
            listViewTCP.Columns.Add("Header Length", 120);
            listViewTCP.Columns.Add("Flags", 120);
            listViewTCP.Columns.Add("Windowsize", 120);
            listViewTCP.Columns.Add("CheckSum", 120);
            listViewTCP.Columns.Add("Urgent Pointer", 120);
            listViewTCP.Columns.Add("Date Time", 120);
            listViewTCP.View = View.Details;
            listViewTCP.GridLines = true;


            listView1.Items.Clear();
            listView1.Columns.Add("Source IP", 100);
            listView1.Columns.Add("Destination IP", 100);
            listView1.Columns.Add("Source Port", 120);
            listView1.Columns.Add("Destination Port", 120);
            listView1.Columns.Add("Sequence Number", 120);
            listView1.Columns.Add("Acknowledgement", 120);
            listView1.Columns.Add("Header Length", 120);
            listView1.Columns.Add("Flags", 120);
            listView1.Columns.Add("Windowsize", 120);
            listView1.Columns.Add("CheckSum", 120);
            listView1.Columns.Add("Urgent Pointer", 120);
            listView1.Columns.Add("Date Time", 120);
            listView1.View = View.Details;
            listView1.GridLines = true;
            //UDPListView
            listViewUDP.Items.Clear();
            listViewUDP.Columns.Add("Source IP", 120);
            listViewUDP.Columns.Add("Destination IP", 120);
            listViewUDP.Columns.Add("Source Port", 120);
            listViewUDP.Columns.Add("Destination Port", 120);
            listViewUDP.Columns.Add("Length", 120);
            listViewUDP.Columns.Add("Checksum", 120);
            listViewUDP.Columns.Add("Date Time", 120);
            listViewUDP.View = View.Details;
            listViewUDP.GridLines = true;


            listView2.Items.Clear();
            listView2.Columns.Add("Source IP", 120);
            listView2.Columns.Add("Destination IP", 120);
            listView2.Columns.Add("Source Port", 120);
            listView2.Columns.Add("Destination Port", 120);
            listView2.Columns.Add("Length", 120);
            listView2.Columns.Add("Checksum", 120);
            listView2.Columns.Add("Date Time", 120);
            listView2.View = View.Details;
            listView2.GridLines = true;
            //Log Entry ListView
            //listViewLogEntry.Items.Clear();
            //listViewLogEntry.Columns.Add("Source IP", 150);
            //listViewLogEntry.Columns.Add("Destination IP", 150);
            //listViewLogEntry.Columns.Add("Date Time", 150);
            //listViewLogEntry.View = View.Details;
            //listViewLogEntry.GridLines = true;
        }
        #region IPAddress Fetching
        private void GetIPAdd()
        {
            IPHostEntry ipHe = Dns.GetHostEntry(Dns.GetHostName());
            if (ipHe.AddressList.Length > 0)
            {
                foreach (IPAddress IpEach in ipHe.AddressList)
                    comboIPlist.Items.Add(IpEach.ToString());
            }
        }
        #endregion
        private void CapturePackets()
        {
            if (!IsContinueCapture)
            {
                IsContinueCapture = true;
                mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
                mainSocket.Bind(new IPEndPoint(IPAddress.Parse(comboIPlist.Text), 0));
                mainSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);
                byte[] bTrue = new byte[4] { 1, 0, 0, 0 };
                byte[] bOut = new byte[4];
                mainSocket.IOControl(IOControlCode.ReceiveAll, bTrue, bOut);
                mainSocket.BeginReceive(bData, 0, bData.Length, SocketFlags.None, new AsyncCallback(OnRecieve), null);
            }
            else
            {
                IsContinueCapture = false;
                mainSocket.Close();
            }
        }
        private void OnRecieve(IAsyncResult iR)
        {
            int intRecieved = mainSocket.EndReceive(iR);
            ParseData(bData, intRecieved);
            if (IsContinueCapture)
            {
                bData = new byte[4096];
                mainSocket.BeginReceive(bData, 0, bData.Length, SocketFlags.None, new AsyncCallback(OnRecieve), null);
            }
        }
        private void ParseData(byte[] tempData, int intRecieved)
        {
            IPHeader ipHead = new IPHeader(tempData, intRecieved);
            AddIPInformation(ipHead);
            switch (ipHead.ProtocolType)
            {
                case Protocol.TCP:
                    TCPHeader tcpHeader = new TCPHeader(ipHead.Data, ipHead.MessageLength);
                    AddTcpInformation(tcpHeader, ipHead);
                    break;
                case Protocol.UDP:
                    UDPHeader udpHeader = new UDPHeader(ipHead.Data, (int)ipHead.MessageLength);
                    AddUdpInformation(udpHeader, ipHead);
                    break;
            }
        }
        #region UdpInformation Listing Functions
        private void AddUdpInformation(UDPHeader udpHeader, IPHeader ipHead)
        {
            _listItemUdp = listViewUDP.Items.Add(ipHead.SourceAddress.ToString());
          //  bool udpcolor = GetStatusColorIP(ipHead.SourceAddress.ToString());
            RuleCheck2(udpHeader, ipHead);
            if (udpHeader.SourcePort == udpHeader.DestinationPort)
            {
                AddToLogEntry(ipHead.SourceAddress.ToString(), ipHead.DestinationAddress.ToString(), DateTime.Now.ToString());
              //  udpcolor = true;
            }
            //if (udpcolor)
            //{
            //    _listItemUdp.ForeColor = Color.Red;
            //    AddToLogEntry(ipHead.SourceAddress.ToString(), ipHead.DestinationAddress.ToString(), DateTime.Now.ToString());
            //}
            else
                _listItemUdp.ForeColor = Color.Green;
            _listItemUdp.SubItems.Add(ipHead.DestinationAddress.ToString());
            _listItemUdp.SubItems.Add(udpHeader.SourcePort);
            _listItemUdp.SubItems.Add(udpHeader.DestinationPort);
            _listItemUdp.SubItems.Add(udpHeader.Length);
            _listItemUdp.SubItems.Add(udpHeader.Checksum);
            _listItemUdp.SubItems.Add(DateTime.Now.ToString());
        }
        #endregion
        #region TcpInformation Listing Functions
        private void AddTcpInformation(TCPHeader tcpHeader, IPHeader ipHead)
        {
            _listItemTcp = listViewTCP.Items.Add(ipHead.SourceAddress.ToString());
            RuleCheck(tcpHeader,ipHead);
            //bool tcpColor = GetStatusColorIP(ipHead.SourceAddress.ToString());
            //if (tcpColor)
            //    _listItemTcp.ForeColor = Color.Red;
            //else
            //    _listItemTcp.ForeColor = Color.Green;


            
            _listItemTcp.SubItems.Add(ipHead.DestinationAddress.ToString());
            _listItemTcp.SubItems.Add(tcpHeader.SourcePort);
            _listItemTcp.SubItems.Add(tcpHeader.DestinationPort);
            _listItemTcp.SubItems.Add(tcpHeader.SequenceNumber);
            _listItemTcp.SubItems.Add(tcpHeader.AcknowledgementNumber);
            _listItemTcp.SubItems.Add(tcpHeader.HeaderLength);
            _listItemTcp.SubItems.Add(tcpHeader.Flags);
            _listItemTcp.SubItems.Add(tcpHeader.WindowSize);
            _listItemTcp.SubItems.Add(tcpHeader.Checksum);
            if (tcpHeader.UrgentPointer != "")
                _listItemTcp.SubItems.Add(tcpHeader.UrgentPointer);
            else
                _listItemTcp.SubItems.Add("");
            _listItemTcp.SubItems.Add(DateTime.Now.ToString());

//--------------------------------Port Scan Detection----------------------------------
            String SourceIP = "";
            int DestPort, i, k, count, index = 0;
            SourceIP = ipHead.SourceAddress.ToString();
            count = listViewTCP.Items.Count;
            IPHostEntry iphost = Dns.GetHostEntry(Dns.GetHostName());
            ipaddTcpScan = iphost.AddressList[0];
            for (i = 0; i < count; i++)
            {
                if (SourceIP == listViewTCP.Items[i].SubItems[0].Text)
                {
                    DestPort = int.Parse(listViewTCP.Items[i].SubItems[3].Text);
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
                            MessageBox.Show(SourceIP + " Port Scanning " + ipHead.DestinationAddress.ToString());
                            //listBoxBlockIP.Items.Add(SourceIP);
                        }
                    }
                }
            }
//--------------------------------------------------------------------------------------------
        }
        #endregion
        #region IPInformation Listing Functions
        //IP Informations are listed in the listview
        private void AddIPInformation(IPHeader ipHead)
        {

           // bool _status = GetStatusColorIP(ipHead.SourceAddress.ToString());
            _listItemIp = listViewIPPacket.Items.Add(ipHead.SourceAddress.ToString());
            //if (_status)
            //    _listItemIp.ForeColor = Color.Red;
            //else
            //    _listItemIp.ForeColor = Color.Green;



            _listItemIp.SubItems.Add(ipHead.DestinationAddress.ToString());
            _listItemIp.SubItems.Add(ipHead.Version);
            _listItemIp.SubItems.Add(ipHead.HeaderLength);
            _listItemIp.SubItems.Add(ipHead.DifferentiatedServices);
            _listItemIp.SubItems.Add(ipHead.TotalLength);
            _listItemIp.SubItems.Add(ipHead.Identification);
            _listItemIp.SubItems.Add(ipHead.Flags);
            _listItemIp.SubItems.Add(ipHead.FragmentationOffset);
            _listItemIp.SubItems.Add(ipHead.TTL);
            _listItemIp.SubItems.Add(ipHead.Checksum);
            _listItemIp.SubItems.Add(DateTime.Now.ToString());
        }
        //Checking for IP Address in the Monitered IP List
        //private bool GetStatusColorIP(string sourceIP)
        //{
        //    bool _STATUS = false;
        //    //foreach (string ip in listBoxBlockIP.Items)
        //    //{
        //    //    if (ip == sourceIP)
        //    //        _STATUS = true;
        //    //}
        //    //return _STATUS;
        //}

        #endregion
        #region Monitor IPs

        //Adds the IP Address to be Monitored
        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //IPAddress ip = IPAddress.Parse(textBoxMonitorIP.Text);
                //if (ip.ToString() != null && int.Parse(ip.ToString().Substring(0, 1).ToString()) != 0)
                //{
                //    if (listBoxBlockIP.Items.IndexOf(textBoxMonitorIP.Text) < 0)
                //        listBoxBlockIP.Items.Add(textBoxMonitorIP.Text);
                //    else
                //        MessageBox.Show("IP address already exists in the list", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    textBoxMonitorIP.Text = "";
                //}
                //else
                //    MessageBox.Show("Check IP Address Entry", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                //MessageBox.Show("IP Address not valid", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //textBoxMonitorIP.Text = "";
                //textBoxMonitorIP.Focus();
            }
        }
        //Saves the IP Address in the listbox to file to be used later
        private void butApply_Click(object sender, EventArgs e)
        {
            FileStream Fs = new FileStream("PacketAnalyzerMonitorIP.nids", FileMode.Create);
            StreamWriter Sw = new StreamWriter(Fs);
            //foreach (string ipAdd in listBoxBlockIP.Items)
            //{
            //    Sw.WriteLine(ipAdd);
            //}
            Sw.Close();
            Fs.Close();
        }
        //Delete an IP from the listbox
       // private void butDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    //{
        //    //    if (listBoxBlockIP.SelectedItem.ToString() != "")
        //    //    {
        //    //        listBoxBlockIP.Items.Remove(listBoxBlockIP.SelectedItem);
        //    //        MessageBox.Show("IP Removed from List", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //    }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Select an IP to remove", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //loads the IP Monitor listbox entries which are Saved in the file
        //private void LoadBlockedIps(string file)
        //{
        //    try
        //    {
        //        FileStream Fs = new FileStream(file, FileMode.Open);
        //        StreamReader Sr = new StreamReader(Fs);
        //        while (!Sr.EndOfStream)
        //        {
        //            listBoxBlockIP.Items.Add(Sr.ReadLine());
        //        }
        //        Sr.Close();
        //        Fs.Close();
        //    }
        //    catch { }
        //}
        
        #endregion
        /*private void FormMain_Load(object sender, EventArgs e)
        {
            LoadBlockedIps("BlockedIP.nids");
        }*/
        private void butGetPackets_Click(object sender, EventArgs e)
        {
            int numips = 0; bool st = false;
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            numips = int.Parse(ipHost.AddressList.Length.ToString());
            try
            {
                IPAddress ipGet = IPAddress.Parse(comboIPlist.Text);
                if (ipGet.ToString() != null)
                {
                    for (int i = 0; i < numips; i++)
                    {
                        if (ipHost.AddressList[i].ToString() == comboIPlist.Text)
                        {
                            setIpLIstView();
                            CapturePackets();
                            st = true;
                            butGetPackets.Enabled = false;
                        }
                    }
                }
                if (!st)
                {
                    MessageBox.Show("Invalid IP Address", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboIPlist.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Invalid IP Format", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboIPlist.Focus();
            }
        }

        #region Save TCP Details to File code
        //Saving the TCP List to Excel sheet....
        private void SaveFileAs(string FileName, ListView selectedListView)
        {
            FileStream fStrem = new FileStream(FileName, FileMode.Create);
            StreamWriter sWritter = new StreamWriter(fStrem);

            int columnCount = selectedListView.Columns.Count;
            string columnHeader = "";
            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                columnHeader = columnHeader + "\t" + selectedListView.Columns[columnIndex].Text;
            }

            sWritter.WriteLine(columnHeader.Trim());

            foreach (ListViewItem eachRow in selectedListView.Items)
            {
                string sLine = "";
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    sLine = sLine + "\t" + eachRow.SubItems[columnIndex].Text;
                }
                sWritter.WriteLine(sLine.Trim());
            }

            sWritter.Close();
            fStrem.Close();
        }
        //Save to Excel Dialog Box to the user to give the name of the file
        private void exportAsExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel sheet|*.xls|Text File |*.txt|Html|*.html";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                //mainSocket.Shutdown(SocketShutdown.Receive);
                SaveFileAs(saveDialog.FileName, listViewIPPacket);
            }
        }
        //Clears the TCP ListView Items
        private void clearListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewIPPacket.Items.Clear();
        }

        #endregion

        #region LogEntry
        //Detected PortSacns And IP Monitorig are entered 
        private void AddToLogEntry(string sourceip, string destinationip, string datetime)
        {
           // _listItemLogEntry = listViewLogEntry.Items.Add(sourceip);
           // _listItemLogEntry.SubItems.Add(destinationip);
          //  _listItemLogEntry.SubItems.Add(datetime);
        }
        #endregion   

        private void FormNids_Load(object sender, EventArgs e)
        {
            //butLocateMachine.Enabled = false;
           // butMLStop.Enabled = false;
          //  LoadBlockedIps("PacketAnalyzerMonitorIP.nids");
            FileInfo file = new FileInfo("LanMachine.nids");
            file.Delete();
        }
        #endregion

        #region Machines On Lan Code

        //Get Machine Informations in the Lan
        private void SearchMachines()
        {
            //listViewComputers.Clear();
            //listViewComputers.Items.Clear();
            //listViewComputers.Columns.Add("Host Name",150);
            //listViewComputers.Columns.Add("IPAddress",150);
            //listViewComputers.Columns.Add("MAC", 150);
            //listViewComputers.GridLines = true;
            //listViewComputers.View = View.Details;
            string ipRanges = "192.168.0.0";
            string r1, r2, r3, r4;
            r1 = ipRanges.Split('.')[0];
            r2 = ipRanges.Split('.')[1];
            r3 = ipRanges.Split('.')[2];
            r4 = ipRanges.Split('.')[3];
            ListViewItem lwl=null;
            string IPAdd = "";
            for (int k = 0; k < 256; k++)//r3
            {
                for (int l = 0; l < 256; l++)//r4
                {
                    IPAdd = r1 + "." + r2 + "." + int.Parse(r3 + k.ToString()).ToString() + "." + int.Parse(r4 + l.ToString()).ToString();
                   // textBoxMLip.Text = IPAdd.ToString();
                    bool tr=IsMachineAlive(IPAdd);
                    if (tr)
                    {
                      //  lwl=listViewComputers.Items.Add(Dns.GetHostEntry(IPAdd).HostName.ToString(),0);//name
                        lwl.SubItems.Add(IPAdd);//address
                       // lwl.SubItems.Add(GetMac(Dns.GetHostEntry(IPAdd).HostName.ToString()));//mac
                       // progressBar1.Value += 1;
                       // labelMLCount.Text = progressBar1.Value.ToString() + " %";
                        //SaveMachineInfo(listViewComputers);
                    }
                }
            }
           // SaveMachineInfo(listViewComputers);
        }
        //Is Machine ON or OFF
        private bool IsMachineAlive(string ipAddress)
        {
            bool isAlive = false;
            Ping _pingComputer = null;
            string ipStatus = "";
            try
            {
                _pingComputer = new Ping();
                PingReply pReply = _pingComputer.Send(ipAddress, 10);
                if (pReply.Status == IPStatus.Success)
                    isAlive = true;
                ipStatus = pReply.Status.ToString();
            }
            catch
            {
                isAlive = false;
            }
            return isAlive;
        }
        //Get Mac Address of Machine in Lan
        //private string GetMac(string machineName)
        //{
        //    string Mac = "";
        //    _Nm = new NidsNetworkManager();
        //    try
        //    {
        //        Mac = _Nm.GetMac(machineName);
        //    }
        //    catch
        //    {
        //        Mac = "Disconnected";
        //    }
        //    return Mac;
        //}
        //Start Lan Machine Search
        private void butGetMachines_Click(object sender, EventArgs e)
        {
            _theGetComputer = new Thread(new ThreadStart(SearchMachines));
            _theGetComputer.Priority = ThreadPriority.Highest;
           // progressBar1.Value = 0;
          //  progressBar1.Maximum = 100;
            //textBoxMLip.Visible = true;
            _theGetComputer.Start();
            //butGetMachines.Enabled = false;
            //butMLStop.Enabled = true;
           // progressBar1.Visible = true;
           // labelMLCount.Visible = true;
        }
        //To Abort Lan Machine Search
        private void butMLStop_Click(object sender, EventArgs e)
        {
            //butGetMachines.Enabled = true;
           // butLocateMachine.Enabled = true;
         //   butMLStop.Enabled = false;
          //  textBoxMLip.Visible = false;
          //  progressBar1.Visible = false;
           // labelMLCount.Visible = false;
           // SaveMachineInfo(listViewComputers);
          //  _theGetComputer.Abort();
        }
        //Save Machine Informatins to a File to Display the Locate Machine On LAN
        private void SaveMachineInfo(ListView selectedListView)
        {
            FileStream fStrem = new FileStream("LanMachine.nids", FileMode.Create);
            StreamWriter sWritter = new StreamWriter(fStrem);
            int columnCount = selectedListView.Columns.Count;
            //foreach (ListViewItem eachRow in listViewComputers.Items)
            //{
            //    string sLine = "";
            //    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            //    {
            //        sLine = sLine + "@" + eachRow.SubItems[columnIndex].Text;
            //    }
            //    sWritter.WriteLine(sLine.Trim());
            //}
            sWritter.Close();
            fStrem.Close();
           // butLocateMachine.Enabled = true;
        }
        //Ping ToolStrip to Ping a Machine displayed in Machines on Lan
        private void pingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
              //  _frmPing = new FormPing(listViewComputers.SelectedItems[0].SubItems[1].Text);
               // _frmPing.Show();
            }
            catch { }
        }

        #endregion

        #region Active Ports on Computers Code
        
        #region PortScan variables
        TcpClient _tcpClient = null;
        Thread _thePortScan = null;
        #endregion
        //Checking for Active Ports on a Machine on the Lan
        private void getPorts(int fromPort, int toPort, string ipAdd)
        {
            string status = "";
            while (fromPort < toPort)
            {
                int curPort = fromPort;

                try
                {
                    _tcpClient = new TcpClient(ipAdd, curPort);
                    if (_tcpClient.Client.Connected)
                        status = "Connected";
                    else
                        status = "Not Connected";
                }
                catch
                {
                    status = "Host Unreachable or Not connected";
                }

               // _Lwl = listViewPorts.Items.Add(curPort.ToString());
                WellKnownPorts port;
                if (status != "Host Unreachable or Not connected")
                {
                    try
                    {
                        port = (WellKnownPorts)fromPort;
                    }
                    catch
                    {
                        port = WellKnownPorts.Unknown;
                    }
                }
                else
                    port = WellKnownPorts.Unknown;
                _Lwl.SubItems.Add(port.ToString());
                _Lwl.SubItems.Add(status);
                if (status == "Connected")
                    _Lwl.ForeColor = Color.Green;
                else
                    _Lwl.ForeColor = Color.Red;
               // progressBarPorts.Value += 1;
                fromPort++;
            }
            //butStartScan.Enabled = true;
            //butStopScan.Enabled = false;
            _thePortScan.Abort();

        }

        private void getDetails()
        {
           // getPorts((int)numericUpStartFrm.Value, (int)numericUpTo.Value, textIPPortScan.Text.Trim());
        }

        private void setListView()
        {
            //listViewPorts.Items.Clear();
            //listViewPorts.Columns.Clear();
            //listViewPorts.Columns.Add("Port", 120);
            //listViewPorts.Columns.Add("Server Name", 120);
            //listViewPorts.Columns.Add("Status", 120);
            //listViewPorts.View = View.Details;
            //listViewPorts.GridLines = true;
        }
        //To Start the Active Port Scan
        private void butStartScan_Click(object sender, EventArgs e)
        {
            //try
            //{
               // IPAddress portScanip = IPAddress.Parse(textIPPortScan.Text);
                //if (portScanip.ToString().Split('.')[0] != "0")
                //{
                //    setListView();
                //    _thePortScan = new Thread(new ThreadStart(getDetails));
                   // progressBarPorts.Maximum = (int)numericUpTo.Value;
                    //progressBarPorts.Value = 0;
                   // _thePortScan.Start();
                   // butStartScan.Enabled = false;
                   // butStopScan.Enabled = true;
               // }
                //else
                //{
                //    MessageBox.Show("Invalid IP ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    //textIPPortScan.Select();
                //}
            //}
            //catch
            //{
            //    MessageBox.Show("Invalid IP Format", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //textIPPortScan.Select();
            //}
        }
        //To Stop the Active Port Scan
        private void butStopScan_Click(object sender, EventArgs e)
        {
            if (_thePortScan != null)
            {
                if (_thePortScan.ThreadState == ThreadState.Running)
                {
                    //butStartScan.Enabled = true;
                    //butStopScan.Enabled = false;
                    _thePortScan.Abort();
                }
            }
        }

        #endregion

        #region Locate Machines Code
        private void butLocateMachine_Click(object sender, EventArgs e)
        {
           // ActiveMachines pic;
            int x = 10, y = 20, x1 = 0, y1 = 0;
           // y1 = int.Parse(groupBoxLocateMachine.Height.ToString());
            FileStream fStream = new FileStream("LanMachine.nids", FileMode.OpenOrCreate);
            StreamReader rStream = new StreamReader(fStream);
            while (!rStream.EndOfStream)
            {
                    string rline = rStream.ReadLine();
                    string machineLanName = rline.Split('@')[1];
                    string machineLanip = rline.Split('@')[2];
                    string machineLanMac = rline.Split('@')[3];
                    if (machineLanip != "Not Alive")
                    {
                       // pic = new ActiveMachines();
                      //  pic.Location = new Point(x + x1, y);
                     //   groupBoxLocateMachine.Controls.Add(pic);
                       // pic.ShowImg(machineLanMac.ToString());
                    }
                    else
                    {
                        machineLanMac = "00-00-00-00-00-00";
                        //pic = new ActiveMachines();
                        //pic.Location = new Point(x + x1, y);
                      //  groupBoxLocateMachine.Controls.Add(pic);
                        //pic.ShowImg(machineLanMac);
                    }
                    y = y + 80;
                    if (y > 580)
                    {
                        y = 20;
                        x1 = x1 + 140;
                    }
                }
                rStream.Close();
                fStream.Close();
        }
        #endregion

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        public void RuleCheck(TCPHeader tcpHeader, IPHeader ipHead)
        {
            try
            {
                string sipindex = "", finalsip = "", finalsp2 = "", finaldip = "", finaldp2="";
                string sourceaddress = ipHead.SourceAddress.ToString();
                string destinationaddress = ipHead.DestinationAddress.ToString();

                string adip = dip.Trim();
                string asip = sip.Trim();

                string ipresult = "";
                string portresult = "";
                string dipresult = "";

                string[] splitactualsip=asip.Split('.');
                string[] splitsource = sourceaddress.Split('.');

                string[] splitactualdip = adip.Split('.');
                string[] splitdestination = destinationaddress.Split('.');

                if (splitactualsip[0] == "*")
                {
                    ipresult = "match";
                }
                else if (splitactualsip[1] == "*")
                {
                    if (splitactualsip[0] == splitsource[0])
                    {
                        ipresult = "match";
                    }
                }
                else if (splitactualsip[2] == "*")
                {
                    finalsip = splitactualsip[0] + "." + splitactualsip[1];
                    finalsp2 = splitsource[0] + "." + splitsource[1];

                    if (finalsip == finalsp2)
                    {
                        ipresult = "match";
                    }
                }
                else if (splitactualsip[3] == "*")
                {
                    finalsip = splitactualsip[0] + "." + splitactualsip[1]+"."+splitactualsip[2];
                    finalsp2 = splitsource[0] + "." + splitsource[1]+"."+splitsource[2];

                    if (finalsip == finalsp2)
                    {
                        ipresult = "match";
                    }
 
                }


                if (splitactualdip[0] == "*")
                {
                    dipresult = "match";
                }
                else if (splitactualdip[1] == "*")
                {
                    if (splitactualdip[0] == splitdestination[0])
                    {
                        dipresult = "match";
                    }
                }
                else if (splitactualdip[2] == "*")
                {
                    finaldip = splitactualdip[0] + "." + splitdestination[1];
                    finaldp2 = splitdestination[0] + "." + splitdestination[1];

                    if (finaldip == finaldp2)
                    {
                        dipresult = "match";
                    }
                }
                else if (splitactualdip[3] == "*")
                {
                    finaldip = splitactualdip[0] + "." + splitactualdip[1] + "." + splitactualdip[2];
                    finaldp2 = splitdestination[0] + "." + splitdestination[1] + "." + splitdestination[2];

                    if (finaldip == finaldp2)
                    {
                        dipresult = "match";
                    }

                }


                if (ipresult == "match")
                {
                    if (dipresult == "match")
                    {
                        if (sport == tcpHeader.SourcePort || sport == "*")
                        {
                            portresult = "match";

                        }
                    }
                }
                if (portresult == "match")
                {
                    _listItemTcpb = listView1.Items.Add(ipHead.SourceAddress.ToString());
                    _listItemTcpb.ForeColor = Color.DarkOrange;
                    _listItemTcpb.SubItems.Add(ipHead.DestinationAddress.ToString());
                    _listItemTcpb.SubItems.Add(tcpHeader.SourcePort);
                    _listItemTcpb.SubItems.Add(tcpHeader.DestinationPort);
                    _listItemTcpb.SubItems.Add(tcpHeader.SequenceNumber);
                    _listItemTcpb.SubItems.Add(tcpHeader.AcknowledgementNumber);
                    _listItemTcpb.SubItems.Add(tcpHeader.HeaderLength);
                    _listItemTcpb.SubItems.Add(tcpHeader.Flags);
                    _listItemTcpb.SubItems.Add(tcpHeader.WindowSize);
                    _listItemTcpb.SubItems.Add(tcpHeader.Checksum);
                    if (tcpHeader.UrgentPointer != "")
                        _listItemTcpb.SubItems.Add(tcpHeader.UrgentPointer);
                    else
                        _listItemTcp.SubItems.Add("");
                    _listItemTcpb.SubItems.Add(DateTime.Now.ToString());
                    ipresult = "";
                    portresult = "";
                    dipresult = "";
                }



            }
            catch (Exception ex)
            {

            }

        }


        public void RuleCheck2(UDPHeader udpHeader, IPHeader ipHead)
        {
            try
            {
                string sipindex = "", finalsip = "", finalsp2 = "", finaldip = "", finaldp2 = "";
                string sourceaddress = ipHead.SourceAddress.ToString();
                string destinationaddress = ipHead.DestinationAddress.ToString();

                string adip = dip.Trim();
                string asip = sip.Trim();

                string ipresult = "";
                string portresult = "";
                string dipresult = "";

                string[] splitactualsip = asip.Split('.');
                string[] splitsource = sourceaddress.Split('.');

                string[] splitactualdip = adip.Split('.');
                string[] splitdestination = destinationaddress.Split('.');

                if (splitactualsip[0] == "*")
                {
                    ipresult = "match";
                }
                else if (splitactualsip[1] == "*")
                {
                    if (splitactualsip[0] == splitsource[0])
                    {
                        ipresult = "match";
                    }
                }
                else if (splitactualsip[2] == "*")
                {
                    finalsip = splitactualsip[0] + "." + splitactualsip[1];
                    finalsp2 = splitsource[0] + "." + splitsource[1];

                    if (finalsip == finalsp2)
                    {
                        ipresult = "match";
                    }
                }
                else if (splitactualsip[3] == "*")
                {
                    finalsip = splitactualsip[0] + "." + splitactualsip[1] + "." + splitactualsip[2];
                    finalsp2 = splitsource[0] + "." + splitsource[1] + "." + splitsource[2];

                    if (finalsip == finalsp2)
                    {
                        ipresult = "match";
                    }

                }


                if (splitactualdip[0] == "*")
                {
                    dipresult = "match";
                }
                else if (splitactualdip[1] == "*")
                {
                    if (splitactualdip[0] == splitdestination[0])
                    {
                        dipresult = "match";
                    }
                }
                else if (splitactualdip[2] == "*")
                {
                    finaldip = splitactualdip[0] + "." + splitdestination[1];
                    finaldp2 = splitdestination[0] + "." + splitdestination[1];

                    if (finaldip == finaldp2)
                    {
                        dipresult = "match";
                    }
                }
                else if (splitactualdip[3] == "*")
                {
                    finaldip = splitactualdip[0] + "." + splitactualdip[1] + "." + splitactualdip[2];
                    finaldp2 = splitdestination[0] + "." + splitdestination[1] + "." + splitdestination[2];

                    if (finaldip == finaldp2)
                    {
                        dipresult = "match";
                    }

                }


                if (ipresult == "match")
                {
                    if (dipresult == "match")
                    {
                        if (sport == udpHeader.SourcePort || sport == "*")
                        {
                            portresult = "match";

                        }
                    }
                }
                if (portresult == "match")
                {
                    _listItemUdp = listView2.Items.Add(ipHead.SourceAddress.ToString());
                    _listItemUdp.SubItems.Add(ipHead.DestinationAddress.ToString());
                    _listItemUdp.SubItems.Add(udpHeader.SourcePort);
                    _listItemUdp.SubItems.Add(udpHeader.DestinationPort);
                    _listItemUdp.SubItems.Add(udpHeader.Length);
                    _listItemUdp.SubItems.Add(udpHeader.Checksum);
                    _listItemUdp.SubItems.Add(DateTime.Now.ToString());
                    ipresult = "";
                    portresult = "";
                    dipresult = "";
                }





          

            }
            catch (Exception ex)
            {

            }

        }
      

        //public void RuleCheck(string checkprotocol, string checksip, string checksport, string checkdip, string checkdport, string action)
       

        private void comboRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from detection where rules='" + comboRules.SelectedItem.ToString() + "'";
                SqlDataReader dr = con.ret_dr(query);
                if (dr.Read())
                {
                    protocol = dr[1].ToString();
                    sip = dr[2].ToString();
                    sport = dr[3].ToString();
                    dip = dr[4].ToString();
                    dport = dr[5].ToString();
                    action = dr[6].ToString();
                    lprotocol.Text = protocol;
                    lsource.Text = sip;
                    lsourceport.Text = sport;
                    ldestinationip.Text = dip;
                    ldestinationport.Text = dport;
                    laction.Text = action;

 
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lprotocol.Text == "TCP")
            {
                listView1.Visible = true;
                listView2.Visible = false;
            }
            else if (lprotocol.Text == "UDP")
            {
                listView1.Visible = false;
                listView2.Visible = true;
            }
            else
            {
                listView1.Visible = false;
                listView2.Visible = false;
            }
        }


    }
}