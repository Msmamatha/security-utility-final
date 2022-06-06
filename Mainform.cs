using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using AForge.Math;
using System.Threading;
using ZedGraph;
using System.Net.NetworkInformation;

namespace WirelessNodeSimulation
{
    
    public partial class Mainform : Form
    {
        static double gtimer = 0, entropyip = 0, entropytcp = 0, entropyudp = 0,entropydns=0;
        static int ip = 0, tcp = 0, udp = 0,dns=0;

        static Queue<long> pkip = new Queue<long>();
        static Queue<long> pktcp = new Queue<long>();
        static Queue<long> pkudp = new Queue<long>();
        static Queue<long> pkDns = new Queue<long>();
        static List<IPandPort> ipandprt = new List<IPandPort>();
        static List<double> listent_ip = new List<double>();
        static List<double> listent_tcp = new List<double>();
        static List<double> listent_udp = new List<double>();
        static List<double> listent_dns = new List<double>();

        PacketInfo pckt = new PacketInfo();
        PortList pll = new PortList();        
        PointPairList garphlist = new PointPairList();
        Queue<string> timeq = new Queue<string>();


        delegate void deladdtreenode(TreeNode node);
        delegate void addlistview(string prtno, string protocol);
        delegate void drawhist(long[] lng);
        delegate void delportadder(List<Portinfo> List);
        delegate double entroper(long[] a);
       
        public Mainform()
        {
            InitializeComponent();

            gtimer = 0;
            entropyip = 0;
            entropytcp = 0;
            entropyudp = 0;
            rest();
            CheckForIllegalCrossThreadCalls = false;
            pckt.IP_Packet_capture += new EventHandler<IP_eventmsg>(pckt_IP_Packet_capture);
            pckt.TCP_Packet_Capture += new EventHandler<TCP_evntmsg>(pckt_TCP_Packet_Capture);
            pckt.UDP_Packet_Capture += new EventHandler<UDP_eventmsg>(pckt_UDP_Packet_Capture);
            pckt.DNS_Packet_capture += new EventHandler<Dns_eventmsg>(pckt_DNS_Packet_capture);
            pckt.IP_cap_Event += new EventHandler<IP_address>(pckt_IP_cap_Event);
            pll.Port_List_event += new EventHandler<PortEvent>(pll_Port_List_event);
            pll.NewPort_event += new EventHandler<PortEvent>(pll_NewPort_event);
        }

        

        
        #region Custom Events

        void pll_NewPort_event(object sender, PortEvent e)
        {
            string pp = null;
            foreach (Portinfo prt in e.Portargs)
            {
                pp += prt.process + "&";
                pp += prt.port + "&";
                pp += prt.PID + "^";
            }
            ALERT ddd = new ALERT(pp);
            ddd.ShowDialog();
        }
        void pll_Port_List_event(object sender, PortEvent e)
        {
            delportadder ssd = new delportadder(portadding);
            listView_activity.BeginInvoke(ssd, new object[] { e.Portargs });
        }

        void pckt_IP_cap_Event(object sender, IP_address e)
        {
            //delegate creation
            deladdtreenode addnode = new deladdtreenode(addTreenode);
            TreeNode node = new TreeNode(e.SourceIP);
            //treeView1.Invoke(addnode, new object[] { node });

        }
        void pckt_DNS_Packet_capture(object sender, Dns_eventmsg e)
        {
            dns++;
            ListViewItem dnsitm = new ListViewItem(e.Identification);
            dnsitm.SubItems.Add(e.Flags);
            dnsitm.SubItems.Add(e.TotalQuestions);
            dnsitm.SubItems.Add(e.TotalAnswerRRs);
            dnsitm.SubItems.Add(e.TotalAuthorityRRs);
            dnsitm.SubItems.Add(e.TotalAdditionalRRs);
            dnsitm.ForeColor = Color.Green;
            //listView_Dns.Items.Add(dnsitm);

        }
        void pckt_UDP_Packet_Capture(object sender, UDP_eventmsg e)
        {
            udp++;

            ListViewItem udpitm = new ListViewItem(e.SourceIP);
            udpitm.ForeColor = Color.Green;
            udpitm.SubItems.Add(e.SourcePort);
            udpitm.SubItems.Add(e.DestinationIP);
            udpitm.SubItems.Add(e.DestinationPort);
            udpitm.SubItems.Add(e.Length);
            udpitm.SubItems.Add(e.Checksum);
            listView_udp.Items.Add(udpitm);

            addlistview lstadd = new addlistview(addListitems);
            listView1.Invoke(lstadd, new object[] { e.DestinationPort.ToString(), "UDP" });
            listView1.Invoke(lstadd, new object[] { e.SourcePort.ToString(), "UDP" });
            //addListitems(e.DestinationPort.ToString(), "UDP");
            //addListitems(e.SourcePort.ToString(), "UDP");
           
            
        }

        void pckt_TCP_Packet_Capture(object sender, TCP_evntmsg e)
        {
            tcp++;
            ListViewItem tcpitm = new ListViewItem(e.SourceIP);
            tcpitm.ForeColor = Color.Green;
            tcpitm.SubItems.Add(e.SourcePort);
            tcpitm.SubItems.Add(e.DestinationIP);
            tcpitm.SubItems.Add(e.DestinationPort);
            tcpitm.SubItems.Add(e.SequenceNumber);
            tcpitm.SubItems.Add(e.AcknowledgementNumber);
            tcpitm.SubItems.Add(e.HeaderLength);
            tcpitm.SubItems.Add(e.WindowSize);
            tcpitm.SubItems.Add(e.Checksum);
            tcpitm.SubItems.Add(e.UrgentPointer);
            listView_tcp.Items.Add(tcpitm);

            addlistview lstadd = new addlistview(addListitems);
            listView1.Invoke(lstadd,new object[]{e.DestinationPort.ToString(), "TCP"});
            listView1.Invoke(lstadd, new object[] { e.SourcePort.ToString(), "TCP" });
            //addListitems(e.DestinationPort.ToString(), "TCP");
            //addListitems(e.SourcePort.ToString(), "TCP");

            int f = 0;
            IPandPort ip = new IPandPort();
            ip.port = new List<int>();
            ip.ipaddress = e.SourceIP;
            ip.port.Add(Convert.ToInt32( e.DestinationPort));
            
            for (int k = 0; k < ipandprt.Count; k++)
            {
                int ind = ipandprt[k].port.IndexOf(Convert.ToInt32(e.DestinationPort));
                if (ipandprt[k].ipaddress == ip.ipaddress)
                {
                    f = 1;
                    if (ind == -1)
                    {
                        ipandprt[k].port.Add(Convert.ToInt32(e.DestinationPort));
                        break;
                    }
                    
                }
                
            }
            if (f == 0)
            {
                ipandprt.Add(ip);
               // listBox1.Items.Add(ip.ipaddress);
              //  listBox1.Refresh();
            }
        }

        void pckt_IP_Packet_capture(object sender, IP_eventmsg e)
        {
            ListViewItem ipitem = new ListViewItem(e.SourceAddress);
            ipitem.ForeColor = Color.DarkGreen;
            ipitem.SubItems.Add(e.DestinationAddress);
            ipitem.SubItems.Add(e.ProtocolType);
            ipitem.SubItems.Add(e.HeaderLength);
            ipitem.SubItems.Add(e.MessageLength);
            ipitem.SubItems.Add(e.TotalLength);
            ipitem.SubItems.Add(e.Version);
            ipitem.SubItems.Add(e.Checksum);
            ipitem.SubItems.Add(e.Flags);
            ipitem.SubItems.Add(e.TTL);
            ipitem.SubItems.Add(e.FragmentationOffset);
            ipitem.SubItems.Add(e.Identification);
            ipitem.SubItems.Add(e.DifferentiatedServices);
            ip++;
            listView_IP.Items.Add(ipitem);


        }
        #endregion

        #region FormEvents
        private void Form1_Load(object sender, EventArgs e)
        {
           // CreateGraph(linegraph1.zg1);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress[] ipsd = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress pp in ipsd)
                {
                    if (pp.AddressFamily == AddressFamily.InterNetwork)
                    {
                        toolStrip_ip.Text = pp.ToString();
                        status_label.Text = "Capturing started...";

                        pckt.start(pp.ToString());
                        toolStripButton3.Enabled = false;
                        toolStripButton4.Enabled = true;
                        PCK_counter.Enabled = true;

                    }
                }
                pll.start();
            }
            catch (Exception eer)
            {
                Console.WriteLine(eer.Message);
            }
        }

        
        private void PCK_counter_Tick(object sender, EventArgs e)
        {
            gtimer++;
            drawhist ddrw = new drawhist(drawHistogram);
            pkip.Enqueue(ip);
            label_no.Text = ip.ToString();
            ip = 0;
            pktcp.Enqueue(tcp);
            label_no.Text = tcp.ToString();
            tcp = 0;
            pkudp.Enqueue(udp);
            label_no.Text = udp.ToString();
            udp = 0;

            pkDns.Enqueue(dns);
            dns = 0;
            //for ip tab
            if (tab_packect.SelectedIndex == 0)
            {
               
                long[] lng = pkip.ToArray();
                
              //invoking method for drawing histogram
                histogramaDesenat1.BeginInvoke(ddrw, new object[] { lng });
                //histogramaDesenat1.DrawHistogram(lng);

                //Entropy Calculation
                entroper ert = new entroper(Entropy);
               double dd= ert.Invoke(lng);
               double cc = dd - entropyip;
               entropyip = dd;
               listent_ip.Add(cc);
              // label_mean.Text =Convert.ToString( Math.Round(cc,4));
             //  label4.Text = entropyip.ToString();
             //  label5.Text = "IP";

               garphlist.Add(gtimer, cc);
             //  linegraph1.zg1.AxisChange();
             //  linegraph1.zg1.Refresh();
                
            }
            //for TCP tab
            else if (tab_packect.SelectedIndex == 1)
            {
               
                long[] lng = pktcp.ToArray();
                histogramaDesenat1.BeginInvoke(ddrw, new object[] { lng });
                
                
                //Entropy Calculation
                entroper ert = new entroper(Entropy);
                double dd = ert.Invoke(lng);
                double cc = dd - entropytcp;
                listent_tcp.Add(cc);
               // label_mean.Text = Convert.ToString(Math.Round(cc, 4));
                entropytcp = dd;
                //label4.Text = entropytcp.ToString();

               // label5.Text = "TCP";

                garphlist.Add(gtimer, cc);
               // linegraph1.zg1.AxisChange();
                //linegraph1.zg1.Refresh();
            }
            //for UDP tab
            else if (tab_packect.SelectedIndex == 2)
            {
                
                long[] lng = pkudp.ToArray();
                histogramaDesenat1.BeginInvoke(ddrw, new object[] { lng });

                //Entropy Calculation
                entroper ert = new entroper(Entropy);
                double dd = ert.Invoke(lng);
                double cc = dd - entropyudp;
                listent_udp.Add(cc);
              //  label_mean.Text = Convert.ToString(Math.Round(cc, 4));
                entropyudp = dd;
               // label4.Text = entropyudp.ToString();

              //  label5.Text = "UDP";

                garphlist.Add(gtimer, cc);
               // linegraph1.zg1.AxisChange();
                //linegraph1.zg1.Refresh();
                
            }
            else if (tab_packect.SelectedIndex == 3)
            {

                long[] lng = pkDns.ToArray();
                histogramaDesenat1.BeginInvoke(ddrw, new object[] { lng });

                //Entropy Calculation
                entroper ert = new entroper(Entropy);
                double dd = ert.Invoke(lng);
                double cc = dd - entropydns;
                listent_dns.Add(cc);
              //  label_mean.Text = Convert.ToString(Math.Round(cc, 4));
                entropydns = dd;
              //  label4.Text = entropydns.ToString();

              //  label5.Text = "DNS";

                garphlist.Add(gtimer, cc);
              //  linegraph1.zg1.AxisChange();
              //  linegraph1.zg1.Refresh();

            }
            networkState();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            PCK_counter.Enabled = false;
            pckt.stop();
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = false;
            pll.stop();
            toolStrip_ip.Text = "0.0.0.0";
            status_label.Text = "Capturing Stopped...";
            timer1.Enabled = false;
        }

        private void tab_packect_SelectedIndexChanged(object sender, EventArgs e)
        {
            garphlist.Clear();
           // linegraph1.zg1.AxisChange();
          //  linegraph1.zg1.Refresh();

            if (PCK_counter.Enabled == false)
            {
                if (tab_packect.SelectedIndex == 0)
                {

                    long[] lng = pkip.ToArray();
                    histogramaDesenat1.DrawHistogram(lng);
                    
                }
                else if (tab_packect.SelectedIndex == 1)
                {

                    long[] lng = pktcp.ToArray();
                    histogramaDesenat1.DrawHistogram(lng);

                    
                }
                else if (tab_packect.SelectedIndex == 2)
                {

                    long[] lng = pkudp.ToArray();
                    histogramaDesenat1.DrawHistogram(lng);
                    
                    
                }
                else if (tab_packect.SelectedIndex == 3)
                {

                    long[] lng = pkDns.ToArray();
                    histogramaDesenat1.DrawHistogram(lng);


                }
            }
            switch (tab_packect.SelectedIndex)
            {
                case 0:
                    DrawlineGraph(listent_ip);
                    break;
                case 1:
                    DrawlineGraph(listent_tcp);
                    break;
                case 2:
                    DrawlineGraph(listent_udp);
                    break;
                case 3:
                    DrawlineGraph(listent_dns);
                    break;
            }

            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem lst = new ListViewItem();

        }

        private void Mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            pckt.stop();
            Application.ExitThread();
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(ipandprt[listBox1.SelectedIndex].port.Count.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < ipandprt.Count; i++)
            {

                if (ipandprt[i].port.Count > 10 && ipandprt[i].ipaddress != toolStrip_ip.Text)
                {
                    MessageBox.Show(ipandprt[i].ipaddress.ToString() + " Prot scaning");
                }
            }
        }
        #endregion

        #region Functions
        public void rest()
        {
            ip = 0;
            tcp = 0;
            udp = 0;
            dns = 0;
            gtimer = 0;

            pkip.Clear();
            pktcp.Clear();
            pkudp.Clear();
            pkDns.Clear();
            ipandprt.Clear();

            listent_ip.Clear();
            listent_tcp.Clear();
            listent_udp.Clear();
            listent_dns.Clear();
        }

        public void addTreenode(TreeNode node)
        {
           bool flag =false;
            string nwidhst=toolStrip_ip.Text.Substring(0,toolStrip_ip.Text.IndexOf('.',5));
            string nwid2 = node.Text.Substring(0, node.Text.IndexOf('.', 5));
            

            if (nwidhst == nwid2)
            {
                //for (int i = 0; i < treeView1.Nodes[0].Nodes[0].Nodes.Count;i++)
                //{
                //    TreeNode tr = treeView1.Nodes[0].Nodes[0].Nodes[i];
                //    if (tr.Text == node.Text)
                //    {
                //        flag = true;
                //        break;
                //    }
                //}

                
                //if (!flag)
                //{
                //    treeView1.Nodes[0].Nodes[0].Nodes.Add(node);
                //}
            }
            else
            {
            //    for (int i = 0; i < treeView1.Nodes[0].Nodes[1].Nodes.Count; i++)
            //    {
            //        TreeNode tr = treeView1.Nodes[0].Nodes[1].Nodes[i];
                    
            //        if (tr.Text == node.Text)
            //        {
            //            flag = true;
                        
            //            break;
            //        }
            //    }
            //    if (!flag)
            //    {
            //        treeView1.Nodes[0].Nodes[1].Nodes.Add(node);
            //    }
            }
        }

        public void addListitems(string prtno,string protocol)
        {
            bool pflg = false;
           ListViewItem p_list = new ListViewItem(prtno.ToString());
           p_list.SubItems.Add(protocol);
           p_list.SubItems.Add("1");
           for(int i=0;i<listView1.Items.Count;i++)
           {
               
               if (listView1.Items[i].Text == prtno)
               {
                   int temp=Convert.ToInt32(listView1.Items[i].SubItems[2].Text);
                   temp++;
                   
                   listView1.Items[i].SubItems[2].Text = temp.ToString();
                   pflg = true;
               }
           }
           if (!pflg)
               listView1.Items.Add(p_list);

          // listView1.Refresh();

        }

        public void drawHistogram(long[] lng)
        {
            histogramaDesenat1.DrawHistogram(lng);
        }

        public void portadding(List<Portinfo> pinfo)
        {
            listView_activity.Items.Clear();
            foreach (Portinfo d in pinfo)
            {
                ListViewItem tt = new ListViewItem(d.protocol);
                tt.SubItems.Add(d.port);
                tt.SubItems.Add(d.status);
                tt.SubItems.Add(d.process);
                tt.SubItems.Add(d.PID);

                listView_activity.Items.Add(tt);
                listView_activity.Refresh();

            }
        }

        public double Entropy(long[] arr)
        {
            int[] a = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                a[i] = Convert.ToInt32(arr[i]);
            }
            double e=Statistics.Entropy(a);
            return e;
        }

        private void CreateGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "Mean Variation Entropy";
            myPane.XAxis.Title.Text = "Time";
            myPane.YAxis.Title.Text = "mean change";



            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve = myPane.AddCurve("My Curve", garphlist, Color.Blue, SymbolType.Triangle);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            myCurve.Line.Fill = new Fill(Color.White, Color.Aqua, 45F);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.AliceBlue, 45F);

            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);



        }

        private void DrawlineGraph(List<double> listp)
        {
            for(int j=0;j<listp.Count;j++)
            {
                garphlist.Add(j, listp[j]);
            }
         //   linegraph1.zg1.AxisChange();
          //  linegraph1.zg1.Refresh();
            gtimer = listp.Count;
        }

        private void networkState()
        {
            netstat obj = new netstat();
            listv_netstat.Items.Clear();

            DnsAddress[] ddr = obj.getDnsAddress();
            foreach (DnsAddress ss in ddr)
            {
                if (ss.dnsServer != null)
                {
                    Console.WriteLine(ss.dnsServer);
                    foreach (IPAddress dns in ss.Ipaddress)
                    {
                        ListViewItem itemdns = new ListViewItem("Default Gateway........:"+dns.ToString());
                        itemdns.ForeColor = Color.Black;
                        listv_netstat.Items.Add(itemdns);
                    }
                }
            }
           
            ListViewItem item = new ListViewItem("Network Card");
            item.ForeColor = Color.Green;
            listv_netstat.Items.Add(item);
            
            ListViewItem item1 = new ListViewItem("   "+obj.getNICName());
            item1.ForeColor = Color.Red;
            listv_netstat.Items.Add(item1);

            NetworkStatics nst = obj.getNetworkStatics();
            ListViewItem item2 = new ListViewItem("Network Activity");
            item2.ForeColor = Color.Green;
            listv_netstat.Items.Add(item2);           

            ListViewItem item5 = new ListViewItem("  Received Packets...."+nst.ReceivedPackets);
            item5.ForeColor = Color.Red;
            listv_netstat.Items.Add(item5);

            ListViewItem item4 = new ListViewItem("  Packets Send...." + nst.ReceivedPacketsDelivered);
            item4.ForeColor = Color.Red;
            listv_netstat.Items.Add(item4);

            ListViewItem item6 = new ListViewItem("  Packets Discarded...."+nst.ReceivedPacketsDiscarded);
            item6.ForeColor = Color.Red;
            listv_netstat.Items.Add(item6);

            ListViewItem item7 = new ListViewItem("  Packets Forwarded...."+nst.ReceivedPacketsForwarded);
            item7.ForeColor = Color.Red;
            listv_netstat.Items.Add(item7);

            //TCP & UDP activity
            list_tcpActivity.Items.Clear();
            TcpConnectionInformation[] connections = obj.getTcpInformation();
            ListViewItem tcpitem = new ListViewItem("TCP Activity");
            tcpitem.ForeColor = Color.Red;
            list_tcpActivity.Items.Add(tcpitem);
            foreach (TcpConnectionInformation t in connections)
            {
                string nt = "Local endpoint: " + t.LocalEndPoint.Address + " " + "Remote endpoint: " + t.RemoteEndPoint.Address + " " + t.State;
                ListViewItem llst = new ListViewItem(nt);
                llst.ForeColor = Color.Green;
                list_tcpActivity.Items.Add(llst);


            }

             UdpStatistics udpStat = obj.getUdpInformation();
            ListViewItem udpitem = new ListViewItem("UDP Activity");
          udpitem.ForeColor = Color.Red;
            list_tcpActivity.Items.Add(udpitem);
            for (int ii = 0; ii <= 4; ii++)
            {
                switch (ii)
                {
                    case 0:
                        ListViewItem llst=new ListViewItem( "Datagrams Received ...."+udpStat.DatagramsReceived);
                        llst.ForeColor = Color.Green;
                        list_tcpActivity.Items.Add(llst);
                        break;
                    case 1:
                        ListViewItem llst1 = new ListViewItem("Datagrams Sent ...." + udpStat.DatagramsSent);
                        llst1.ForeColor = Color.Green;
                        list_tcpActivity.Items.Add(llst1);
                        break;
                    case 2:
                        ListViewItem llst2 = new ListViewItem(" Incoming Datagrams Discarded ...."+udpStat.IncomingDatagramsDiscarded);
                        llst2.ForeColor = Color.Green;
                        list_tcpActivity.Items.Add(llst2);
                        break;
                    case 3:
                        ListViewItem llst3 = new ListViewItem("Incoming Datagrams With Errors ...."+udpStat.IncomingDatagramsWithErrors);
                        llst3.ForeColor = Color.Green;
                        list_tcpActivity.Items.Add(llst3);
                        break;
                    case 4:
                        ListViewItem llst4 = new ListViewItem("UDP Listeners .............. : "+udpStat.UdpListeners);
                        llst4.ForeColor = Color.Green;
                        list_tcpActivity.Items.Add(llst4);
                        break;
                }
                
                
                
                
                
            }
        }
        #endregion

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ruleSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRule frm = new FormRule();
            frm.Show();
        }

        private void packetFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




    }


}