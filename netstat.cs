using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net;
using System.Collections;
using Microsoft.Win32;

namespace WirelessNodeSimulation
{
    #region Stuructres
  public struct NetworkStatics
    {
       public string ReceivedPackets,
           ReceivedPacketsForwarded, 
           ReceivedPacketsDelivered, 
           ReceivedPacketsDiscarded;
    }

    public struct DnsAddress
    {
        public string dnsServer;
        public List<IPAddress> Ipaddress;
    }


    #endregion
    class netstat
    {
        
        public NetworkStatics getNetworkStatics()
        {
            NetworkStatics nt = new NetworkStatics();
            IPGlobalProperties pp = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics ipstat = pp.GetIPv4GlobalStatistics();           
          
           nt.ReceivedPackets= ipstat.ReceivedPackets.ToString();            
           nt.ReceivedPacketsForwarded= ipstat.ReceivedPacketsForwarded.ToString();
            nt.ReceivedPacketsDelivered = ipstat.ReceivedPacketsDelivered.ToString();
            nt.ReceivedPacketsDiscarded = ipstat.ReceivedPacketsDiscarded.ToString();
            return nt;
        }

        public DnsAddress[] getDnsAddress()
        {
            
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            DnsAddress[] adp = new DnsAddress[adapters.Length];
            int i = 0;
            foreach (NetworkInterface adapter in adapters)
            {
                adp[i].Ipaddress = new List<IPAddress>();
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                IPAddressCollection dnsServers = adapterProperties.DnsAddresses;
                
                if (dnsServers.Count > 0)
                {
                  adp[i].dnsServer= adapter.Description;
                    foreach (IPAddress dns in dnsServers)
                    {
                        adp[i].Ipaddress.Add(dns);

                    }
                    
                }
                i++;
            }

            return adp;
        }

        public string getNICName()
        {
            RegistryKey start = Registry.LocalMachine;
            RegistryKey cardServiceName, networkKey;
            string networkcardKey = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\NetworkCards";
            string serviceKey = "SYSTEM\\CurrentControlSet\\Services\\";
            string networkcardKeyName, deviceName=null, deviceServiceName, serviceName = null;

            RegistryKey serviceNames = start.OpenSubKey(networkcardKey);
            if (serviceNames == null)
            {
                Console.WriteLine("Bad registry key");
                
            }

            string[] networkCards = serviceNames.GetSubKeyNames();
            serviceNames.Close();

            foreach (string keyName in networkCards)
            {
                networkcardKeyName = networkcardKey + "\\" + keyName;
                cardServiceName = start.OpenSubKey(networkcardKeyName);
                if (cardServiceName == null)
                {
                    Console.WriteLine("Bad registry key: {0}", networkcardKeyName);
                    
                }
                deviceServiceName = (string)cardServiceName.GetValue("ServiceName");
                deviceName = (string)cardServiceName.GetValue("Description");
               

            }
            
            start.Close();
            return deviceName;
        }

        public IcmpV4Statistics getIcmpV4Statics()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IcmpV4Statistics stat = properties.GetIcmpV4Statistics();
            return stat;
        }

        public TcpConnectionInformation[] getTcpInformation()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            return connections;
        }

        public UdpStatistics getUdpInformation()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            UdpStatistics udpStat = null;
            udpStat = properties.GetUdpIPv4Statistics();
            return udpStat;
        }
    }
}
