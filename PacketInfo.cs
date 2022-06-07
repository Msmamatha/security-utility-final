using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;


namespace WirelessNodeSimulation
{
   
    class PacketInfo
    {

        private bool bContinueCapturing = false;            //A flag to check if packets are to be captured or not
        private Socket mainSocket;
        private byte[] byteData = new byte[4096];
        public event EventHandler<TCP_evntmsg> TCP_Packet_Capture;
        public event EventHandler<UDP_eventmsg> UDP_Packet_Capture;
        public event EventHandler<IP_eventmsg> IP_Packet_capture;
        public event EventHandler<Dns_eventmsg> DNS_Packet_capture;
        public event EventHandler<IP_address> IP_cap_Event;
        
        public void start(string IP)
        {
            try
            {
                bContinueCapturing = true;
                if (bContinueCapturing)
                {
                    //Start capturing the packets...

                    bContinueCapturing = true;

                    //For sniffing the socket to capture the packets has to be a raw socket, with the
                    //address family being of type internetwork, and protocol being IP
                    mainSocket = new Socket(AddressFamily.InterNetwork,
                        SocketType.Raw, ProtocolType.IP);

                    //Bind the socket to the selected IP address
                    mainSocket.Bind(new IPEndPoint(IPAddress.Parse(IP), 0));

                    //Set the socket  options
                    mainSocket.SetSocketOption(SocketOptionLevel.IP,            //Applies only to IP packets
                                               SocketOptionName.HeaderIncluded, //Set the include the header
                                               true);                           //option to true

                    byte[] byTrue = new byte[4] { 1, 0, 0, 0 };
                    byte[] byOut = new byte[4] { 1, 0, 0, 0 }; //Capture outgoing packets

                    //Socket.IOControl is analogous to the WSAIoctl method of Winsock 2
                    mainSocket.IOControl(IOControlCode.ReceiveAll,              //Equivalent to SIO_RCVALL constant
                        //of Winsock 2
                                         byTrue,
                                         byOut);

                    //Start receiving the packets asynchronously
                    mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                        new AsyncCallback(OnReceive), null);
                }
                else
                {
                   
                    bContinueCapturing = false;
                    //To stop capturing the packets close the socket
                    mainSocket.Close();

                }
            }
            catch (Exception ert)
            {
            }
        }

        public void stop()
        {
            try
            {
                bContinueCapturing = false;
                mainSocket.Close();
            }
            catch(Exception rr)
            {
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                int nReceived = mainSocket.EndReceive(ar);

                //Analyze the bytes received...

                ParseData(byteData, nReceived);

                if (bContinueCapturing)
                {
                    byteData = new byte[4096];

                    //Another call to BeginReceive so that we continue to receive the incoming
                    //packets
                    mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                        new AsyncCallback(OnReceive), null);
                }
            }
            catch (ObjectDisposedException)
            {
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void ParseData(byte[] byteData, int nReceived)
        {

            IPHeader ipHeader = new IPHeader(byteData, nReceived);
            string srcip = ipHeader.SourceAddress.ToString();
            string destip = ipHeader.DestinationAddress.ToString();
            //fire new ipaddress event
            EventHandler<IP_address> ip_pack_cap1 = IP_cap_Event;
            if (IP_cap_Event != null)
                this.IP_cap_Event(this, new IP_address(srcip, destip));

            //ip packet header event
            EventHandler<IP_eventmsg> IP_Packet_capture1 = IP_Packet_capture;
            if (IP_Packet_capture != null)
                this.IP_Packet_capture(this, new IP_eventmsg(ipHeader));

            switch (ipHeader.ProtocolType)
            {
                case Protocol.TCP:

                    TCPHeader tcpHeader = new TCPHeader(ipHeader.Data, ipHeader.MessageLength);
                    EventHandler<TCP_evntmsg> TCP_Packet_Capture1 = TCP_Packet_Capture;
                    if (TCP_Packet_Capture != null)
                        this.TCP_Packet_Capture(this, new TCP_evntmsg(tcpHeader,srcip,destip)); 

                    

                  
                    break;
             
                case Protocol.UDP:            

                   UDPHeader udpHeader = new UDPHeader(ipHeader.Data, (int)ipHeader.MessageLength);
                   EventHandler<UDP_eventmsg> UDP_Packet_Capture1 = UDP_Packet_Capture;
                   if (UDP_Packet_Capture != null)
                       this.UDP_Packet_Capture(this, new UDP_eventmsg(udpHeader, srcip, destip));

                   if (udpHeader.DestinationPort == "53" || udpHeader.SourcePort == "53")
                   {

                       DNSHeader dnsHeader = new DNSHeader(udpHeader.Data, Convert.ToInt32(udpHeader.Length) - 8);
                       EventHandler<Dns_eventmsg> DNS_packet_capture1 = DNS_Packet_capture;
                       if(DNS_Packet_capture!=null)
                           this.DNS_Packet_capture(this,new Dns_eventmsg(dnsHeader));
                   }
                  

                    break;
            
                case Protocol.Unknown:
                    break;
            }
            




        }
    }

    public class TCP_evntmsg : EventArgs
    {
        //TCP header fields
        private string usSourcePort;              //Sixteen bits for the source port number
        private string usDestinationPort;         //Sixteen bits for the destination port number
        private string uiSequenceNumber = "555";          //Thirty two bits for the sequence number
        private string uiAcknowledgementNumber = "555";   //Thirty two bits for the acknowledgement number
        private string usWindow = "555";                  //Sixteen bits for the window size
        private string sChecksum = "555";                 //Sixteen bits for the checksum
        //(checksum can be negative so taken as short)
        private string usUrgentPointer;           //Sixteen bits for the urgent pointer
        //End TCP header fields
        string srip = "0.0.0.0";
        string dsip = "0.0.0.0";

        string strFlags=null;
        private string byHeaderLength;            //Header length
        private ushort usMessageLength;           //Length of the data being carried
        private byte[] byTCPData = new byte[4096];//Data carried by the TCP packet

        public TCP_evntmsg(TCPHeader tcpHeader,string sip,string dip)
        {
            usSourcePort = tcpHeader.SourcePort;
            usDestinationPort = tcpHeader.DestinationPort;
            uiSequenceNumber = tcpHeader.SequenceNumber;
            uiAcknowledgementNumber = tcpHeader.AcknowledgementNumber;
            byHeaderLength = tcpHeader.HeaderLength;
            usWindow = tcpHeader.WindowSize;
            usUrgentPointer = tcpHeader.UrgentPointer;
            strFlags = tcpHeader.Flags;
            sChecksum = tcpHeader.Checksum;
            byTCPData = tcpHeader.Data;
            usMessageLength = tcpHeader.MessageLength;

            srip = sip;
            dsip = dip;
        }

        #region propertise
        public string SourcePort
        {
            get
            {
                return usSourcePort.ToString();
            }
        }

        public string DestinationPort
        {
            get
            {
                return usDestinationPort.ToString();
            }
        }

        public string SequenceNumber
        {
            get
            {
                return uiSequenceNumber.ToString();
            }
        }

        public string AcknowledgementNumber
        {
            get
            {               
                
                    return uiAcknowledgementNumber;
               
            }
        }

        public string HeaderLength
        {
            get
            {
                return byHeaderLength.ToString();
            }
        }

        public string WindowSize
        {
            get
            {
                return usWindow.ToString();
            }
        }

        public string UrgentPointer
        {
            get
            {
                return usUrgentPointer;
            }
               
        }

        public string Flags
        {
            get
            {
               

                return strFlags;
            }
        }

        public string Checksum
        {
            get
            {
                return strFlags;
            }
        }

        public byte[] Data
        {
            get
            {
                return byTCPData;
            }
        }

        public ushort MessageLength
        {
            get
            {
                return usMessageLength;
            }
        }

        public string SourceIP
        {
            get
            {
                return srip;
            }
        }

        public string DestinationIP
        {
            get
            {
                return dsip;
            }
        }
        #endregion
    }

    public class UDP_eventmsg : EventArgs
    {
        //UDP header fields
        private string usSourcePort;            //Sixteen bits for the source port number        
        private string usDestinationPort;       //Sixteen bits for the destination port number
        private string usLength;                //Length of the UDP header
        private string sChecksum;                //Sixteen bits for the checksum
        private byte[] byUDPData = new byte[4096];  //Data carried by the UDP packet
        string srip = null;
        string dsip = null;
        public UDP_eventmsg(UDPHeader udpHeader, string sip, string dip)
        {
            usSourcePort = udpHeader.SourcePort;
            usDestinationPort = udpHeader.DestinationPort;
            usLength = udpHeader.Length;
            sChecksum = udpHeader.Checksum;
            byUDPData = udpHeader.Data;

            srip = sip;
            dsip = dip;
        }
        #region Propertise
        public string SourcePort
        {
            get
            {
                return usSourcePort;
            }
        }

        public string DestinationPort
        {
            get
            {
                return usDestinationPort;
            }
        }

        public string Length
        {
            get
            {
                return usLength;
            }
        }

        public string Checksum
        {
            get
            {
               
                return sChecksum;
            }
        }

        public byte[] Data
        {
            get
            {
                return byUDPData;
            }
        }
        public string SourceIP
        {
            get
            {
                return srip;
            }
        }

        public string DestinationIP
        {
            get
            {
                return dsip;
            }
        }
        #endregion



    }

    public class IP_eventmsg : EventArgs
    {
       
        private string byVersionAndHeaderLength;   
        private string byDifferentiatedServices;   
        private string usTotalLength;              
        private string usIdentification;           
        private string usFlagsAndOffset,flags;           
        private string byTTL;                     
        private string byProtocol;                 
        private string sChecksum;                  
        private string uiSourceIPAddress;          
        private string uiDestinationIPAddress;
        private string version,msglength;
        

        private string byHeaderLength=null;             
        private byte[] byIPData = new byte[4096];  //Data carried by the datagram

        public IP_eventmsg(IPHeader ipheader)
        {
            uiSourceIPAddress = ipheader.SourceAddress.ToString();
            uiDestinationIPAddress = ipheader.DestinationAddress.ToString();
            byHeaderLength = ipheader.HeaderLength;
            sChecksum= ipheader.Checksum;
            byIPData= ipheader.Data;
            byDifferentiatedServices= ipheader.DifferentiatedServices;
           flags= ipheader.Flags;
            usFlagsAndOffset= ipheader.FragmentationOffset;
            byVersionAndHeaderLength= ipheader.HeaderLength;
            usIdentification= ipheader.Identification;
            msglength= ipheader.MessageLength.ToString();
            byProtocol= ipheader.ProtocolType.ToString();
            usTotalLength= ipheader.TotalLength;
            byTTL= ipheader.TTL;
            version= ipheader.Version;
        }
        #region Propertise
        public string Version
        {
            get
            {
                return version;
            }
        }

        public string HeaderLength
        {
            get
            {
                return byHeaderLength.ToString();
            }
        }

        public string MessageLength
        {
            get
            {
                
                return msglength;
            }
        }

        public string DifferentiatedServices
        {
            get
            {
                return byDifferentiatedServices;
            }
        }

        public string Flags
        {
            get
            {
                return flags;
            }
        }

        public string FragmentationOffset
        {
            get
            {
               return usFlagsAndOffset;
            }
        }

        public string TTL
        {
            get
            {
                return byTTL.ToString();
            }
        }

        public string ProtocolType
        {
            get
            {
                return byProtocol;
            }
        }

        public string Checksum
        {
            get
            {
               
                return sChecksum;
            }
        }

        public string SourceAddress
        {
            get
            {
                return uiSourceIPAddress;
            }
        }

        public string DestinationAddress
        {
            get
            {
                return uiDestinationIPAddress;
            }
        }

        public string TotalLength
        {
            get
            {
                return usTotalLength;
            }
        }

        public string Identification
        {
            get
            {
                return usIdentification;
            }
        }

        public byte[] Data
        {
            get
            {
                return byIPData;
            }
        }
        #endregion
    }

    public class Dns_eventmsg : EventArgs
    {
        //DNS header fields
        private string usIdentification;        //Sixteen bits for identification
        private string usFlags;                 //Sixteen bits for DNS flags
        private string usTotalQuestions;        //Sixteen bits indicating the number of entries 
        //in the questions list
        private string usTotalAnswerRRs;        //Sixteen bits indicating the number of entries
        //entries in the answer resource record list
        private string usTotalAuthorityRRs;     //Sixteen bits indicating the number of entries
        //entries in the authority resource record list
        private string usTotalAdditionalRRs;    //Sixteen bits indicating the number of entries
        //entries in the additional resource record list
        //End DNS header fields
        public Dns_eventmsg(DNSHeader dnsHeader)
        {
            usIdentification = dnsHeader.Identification;
            usFlags = dnsHeader.Flags;
            usTotalQuestions = dnsHeader.TotalQuestions;
            usTotalAnswerRRs = dnsHeader.TotalAnswerRRs;
            usTotalAuthorityRRs = dnsHeader.TotalAuthorityRRs;
            usTotalAdditionalRRs = dnsHeader.TotalAdditionalRRs;
            
        }

        public string Identification
        {
            get
            {
                return usIdentification;
            }
        }

        public string Flags
        {
            get
            {
                return usFlags;
            }
        }

        public string TotalQuestions
        {
            get
            {
                return usTotalQuestions;
            }
        }

        public string TotalAnswerRRs
        {
            get
            {
                return usTotalAnswerRRs;
            }
        }

        public string TotalAuthorityRRs
        {
            get
            {
                return usTotalAuthorityRRs;
            }
        }

        public string TotalAdditionalRRs
        {
            get
            {
                return usTotalAdditionalRRs;
            }
        }
    }

    public class IP_address : EventArgs
    {
        string sip = null,dip=null;

        public IP_address(string srip, string drip)
        {
            sip = srip;
            dip = drip;
        }

        public string SourceIP
        {
            get
            {
                return sip;
            }
        }

        public string DestinationIP
        {
            get
            {
                return dip;
            }
        }

    }
}
