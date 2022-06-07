using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace WirelessNodeSimulation
{
    public class PacketManager
    {
        //Paquets pret a l'emploi sauf le dernier
        private Queue<Message> packets = new Queue<Message>();
        private StringBuilder buffer = new StringBuilder();

        // constructeur
        public PacketManager()
        { }

        // prendre un paquet
        public Message DequeuePacket()
        {
            lock (this)
            {
                if (packets.Count != 0) return packets.Dequeue();
            }
            return new Message();
        }

        //un paquet est pret
        public bool IsPacketAvailable()
        {
            //return the number of received data
            lock (this)
            {
                return packets.Count != 0;
            }
        }

        //ajout de donnÃ©e
        public bool AddPacketData(byte[] in_data, int in_dataLength)
        {
            //if there is no data
            if (in_dataLength == 0)
            {
                return false;
            }
            lock (this)
            {
                //convert data
                buffer.Append(Encoding.UTF8.GetString(in_data, 0, in_dataLength));
                string data = buffer.ToString();

                int startIndex = 0;
                int endIndex = 0;
                try
                {
                    while ((endIndex = data.IndexOf("#", startIndex)) != -1)
                    {
                        packets.Enqueue(new Message(data.Substring(startIndex, endIndex - startIndex)));
                        startIndex = endIndex + 1;
                    }
                }
                catch
                { }
                buffer.Length = 0;
                if (data.Length > startIndex) buffer.Append(data.Substring(startIndex));
            }
            return IsPacketAvailable();
        }

        public class Message
        {


            public int SourceNodeId;
            public int DestinationNodeId;

            public int MessageId;
            public string NodePath = string.Empty;
            public string Type = string.Empty;


            public Message()
            {
            }
            public Message(string in_data)
            {
                try
                {
                    string[] splited = in_data.Split('$');
                    SourceNodeId = Convert.ToInt32(splited[0]);
                    DestinationNodeId = Convert.ToInt32(splited[1]);
                    MessageId = Convert.ToInt32(splited[2]);
                    NodePath = splited[3];
                    Type= splited[4];

                }
                catch { }
            }
        }
    }
}