using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WirelessNodeSimulation;
using System.Net;
using System.IO;
using WirelessNodeSimulation.Channel;
using EncryptionLib;
using System.Threading;
using System.Data.SqlClient;
using Channel;


namespace WirelessNodeSimulation
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;
        TSReceiver TCPreceiver = new TSReceiver(8000);
        List<ChannelInfo> userChanel = new List<ChannelInfo>();
        DBcon con = new DBcon(Program.ServerIP);

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        }
        #region Functions

        //AES key genarator
        public string AESKeygen(int size)
        {
            StringBuilder build = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26*random.NextDouble()+65)));
                build.Append(ch);
            }

            return build.ToString();

        }

        //start user Request processing

        void UserProcess(object msg)
        {
            string message = (string)msg;
            StatusLabel1.Text = "userProcess";
            string[] infom = message.Split('^');
            ChannelInfo ch = new ChannelInfo();
            ch.SendEvent += new EventHandler(ch_SendEvent);
            ch.UserName = infom[1];
            ch.IPaddress = infom[2];
            ch.PortNumber = infom[3];
            ch.AESKey = AESKeygen(32);
            ch.filename = infom[4];
            userChanel.Add(ch);

           // Processlist();
        }

        void ch_SendEvent(object sender, EventArgs e)
        {
            ChannelInfo ch = (ChannelInfo)sender;
        }

        //void Processlist()
        //{
        //    AESProvider AESprv = new AESProvider();
           
        //    string prvKey = "";
        //    foreach (ChannelInfo ch in userChanel)
        //    {
        //        StatusLabel1.Text = "Encrypting..."+ch.UserName;
        //        if (File.Exists(ch.filename)&&ch.IsEncypted==false)
        //        {
        //            TsSender ts = new TsSender(IPAddress.Parse(ch.IPaddress), 8000);
        //            ts.SendMessage("Handshake^" + Program.userName + "^" + ch.AESKey);

        //            ch.Encryptedfilename = ch.filename.Replace(".", "_E.");
        //            AESprv.Encrypt(ch.filename, ch.Encryptedfilename, ch.AESKey);
        //            ch.IsEncypted = true;
                                        
                    
        //            //sening message
        //            string replyserver="nope";
        //            TsSender tsSend = new TsSender(IPAddress.Parse(Program.ServerIP), 9000);
        //            tsSend.SendMessage("filebuff^"+ch.IPaddress, out replyserver);

        //            if (replyserver != null && replyserver != "nope")
        //            {
        //                StatusLabel1.Text = "file sending";
        //                FTClientCode.ip = Program.ServerIP;
        //                new FTClientCode().SendFile(ch.filename);
        //                StatusLabel1.Text = FTClientCode.curMsg;
        //            }
        //        }
        //    }
        //}

        #endregion

        #region
        public MDIParent1()
        {
            InitializeComponent();
        }
        #endregion

        #region FormEvents

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(AESKeygen(32));
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

       

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

     

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("C:\\UPRShare"))
            {
                Directory.CreateDirectory("C:\\UPRShare");
            }
            //welcome_label.Text ="Welcome "+ Program.userName;
            backgroundWorker1.RunWorkerAsync();
        }

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        

        private void viewServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBcon Rcon = new DBcon(Program.ServerIP);
            Rcon.ExecuteQuery("update Proxy set ipaddress='0.0.0.0' where username='" +Program.userName + "'");
            TsSender ts = new TsSender(IPAddress.Parse(Program.ServerIP), 9000);
            ts.SendMessage("logout001^" + Program.userName);
            foreach (Form fm in Application.OpenForms)
            {
                if (fm.Name == "LOGIN")
                {
                    fm.Show();
                }
            }
        }

       

        private void secureFileTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        #endregion


        #region CustomEvents

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            TCPreceiver.MessageReceived += new EventHandler<TcpMessageReceivedEventArgs>(TCPreceiver_MessageReceived);
            TCPreceiver.Listen();
        }

        void TCPreceiver_MessageReceived(object sender, TcpMessageReceivedEventArgs e)
        {
            if (e.Message.StartsWith("filelist"))
            {
                userChanel.Clear();
                string[] flist = Directory.GetFiles("C:\\UPRShare");
                string f = "";
                foreach (string ff in flist)
                {
                    f += new FileInfo(ff).Name + "^";
                }

                TsSender ts = new TsSender(IPAddress.Parse(e.SourceIP.Split(':')[0]), 8000);
                ts.SendMessage("fileack^" + f);
            }

            else if (e.Message.StartsWith("fileselect"))
            {

                
                ParameterizedThreadStart pp = new ParameterizedThreadStart(UserProcess);
                Thread th = new Thread(pp);
                th.Start((object)e.Message);

            }
        }
        #endregion

        private void newServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void editServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void deleteServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void editProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRule frm = new FormRule();
            frm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Mainform mf = new Mainform();
            mf.MdiParent = this;
            mf.Show();
            //AdminMain am = new AdminMain();
            //am.MdiParent = this;
            //am.Show();


            
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //DBcon Rcon = new DBcon(Program.ServerIP);
            //Rcon.ExecuteQuery("update Proxy set ipaddress='0.0.0.0' where username='" + Program.userName + "'");
            //TsSender ts = new TsSender(IPAddress.Parse(Program.ServerIP), 9000);
            //ts.SendMessage("logout001^" + Program.userName);
            //foreach (Form fm in Application.OpenForms)
            //{
            //    if (fm.Name == "LOGIN")
            //    {
            //        fm.Show();
            //    }
            //}
            Application.Exit();
        }

        private void rulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNids frm = new FormNids();
            frm.MdiParent = this;
            frm.Show();
        }


        private void routingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessMonitoring frm = new ProcessMonitoring();
            frm.MdiParent = this;
            frm.Show();
        }

       
    }
}
