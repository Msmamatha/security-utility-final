//<-------------------------------------------------------------------->
//  NIDS is the project work done by:
//  Bijoy Gopalakrishnan, Murali Sankar V.K and Nikhil V Nair 
//  Students of Computer Science Department, SIST, Tvm (2004-2008 batch)
//  as the Major Project which is part of the B.Tech course. 
//<-------------------------------------------------------------------->

namespace WirelessNodeSimulation
{
    partial class FormNids
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNids));
            this.contextMenuExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportAsExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuPing = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListCommon = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.comboRules = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.laction = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.ldestinationport = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ldestinationip = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lsourceport = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lsource = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lprotocol = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.listViewIPPacket = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboIPlist = new System.Windows.Forms.ComboBox();
            this.butGetPackets = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.listViewTCP = new System.Windows.Forms.ListView();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.listViewUDP = new System.Windows.Forms.ListView();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuExport.SuspendLayout();
            this.contextMenuPing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuExport
            // 
            this.contextMenuExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAsExcelToolStripMenuItem,
            this.clearListToolStripMenuItem});
            this.contextMenuExport.Name = "contextMenuExport";
            this.contextMenuExport.Size = new System.Drawing.Size(151, 48);
            // 
            // exportAsExcelToolStripMenuItem
            // 
            this.exportAsExcelToolStripMenuItem.Name = "exportAsExcelToolStripMenuItem";
            this.exportAsExcelToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exportAsExcelToolStripMenuItem.Text = "Export as Excel";
            // 
            // clearListToolStripMenuItem
            // 
            this.clearListToolStripMenuItem.Name = "clearListToolStripMenuItem";
            this.clearListToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.clearListToolStripMenuItem.Text = "Clear List";
            // 
            // contextMenuPing
            // 
            this.contextMenuPing.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pingToolStripMenuItem});
            this.contextMenuPing.Name = "contextMenuPing";
            this.contextMenuPing.Size = new System.Drawing.Size(99, 26);
            // 
            // pingToolStripMenuItem
            // 
            this.pingToolStripMenuItem.Name = "pingToolStripMenuItem";
            this.pingToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.pingToolStripMenuItem.Text = "Ping";
            // 
            // imageListCommon
            // 
            this.imageListCommon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCommon.ImageStream")));
            this.imageListCommon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListCommon.Images.SetKeyName(0, "mynetworkplaces.ico");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Rules";
            // 
            // comboRules
            // 
            this.comboRules.FormattingEnabled = true;
            this.comboRules.Location = new System.Drawing.Point(12, 24);
            this.comboRules.Name = "comboRules";
            this.comboRules.Size = new System.Drawing.Size(164, 21);
            this.comboRules.TabIndex = 10;
            this.comboRules.SelectedIndexChanged += new System.EventHandler(this.comboRules_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(994, 442);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 12;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.laction);
            this.splitContainer2.Panel2.Controls.Add(this.label18);
            this.splitContainer2.Panel2.Controls.Add(this.ldestinationport);
            this.splitContainer2.Panel2.Controls.Add(this.label16);
            this.splitContainer2.Panel2.Controls.Add(this.ldestinationip);
            this.splitContainer2.Panel2.Controls.Add(this.label14);
            this.splitContainer2.Panel2.Controls.Add(this.lsourceport);
            this.splitContainer2.Panel2.Controls.Add(this.label12);
            this.splitContainer2.Panel2.Controls.Add(this.lsource);
            this.splitContainer2.Panel2.Controls.Add(this.label10);
            this.splitContainer2.Panel2.Controls.Add(this.lprotocol);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.comboRules);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Size = new System.Drawing.Size(257, 442);
            this.splitContainer2.SplitterDistance = 139;
            this.splitContainer2.TabIndex = 0;
            // 
            // laction
            // 
            this.laction.AutoSize = true;
            this.laction.Location = new System.Drawing.Point(106, 239);
            this.laction.Name = "laction";
            this.laction.Size = new System.Drawing.Size(16, 13);
            this.laction.TabIndex = 23;
            this.laction.Text = "...";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 239);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "Action";
            // 
            // ldestinationport
            // 
            this.ldestinationport.AutoSize = true;
            this.ldestinationport.Location = new System.Drawing.Point(106, 207);
            this.ldestinationport.Name = "ldestinationport";
            this.ldestinationport.Size = new System.Drawing.Size(16, 13);
            this.ldestinationport.TabIndex = 21;
            this.ldestinationport.Text = "...";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 207);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "Destination Port";
            // 
            // ldestinationip
            // 
            this.ldestinationip.AutoSize = true;
            this.ldestinationip.Location = new System.Drawing.Point(106, 174);
            this.ldestinationip.Name = "ldestinationip";
            this.ldestinationip.Size = new System.Drawing.Size(16, 13);
            this.ldestinationip.TabIndex = 19;
            this.ldestinationip.Text = "...";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 139);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "Source Port";
            // 
            // lsourceport
            // 
            this.lsourceport.AutoSize = true;
            this.lsourceport.Location = new System.Drawing.Point(106, 139);
            this.lsourceport.Name = "lsourceport";
            this.lsourceport.Size = new System.Drawing.Size(16, 13);
            this.lsourceport.TabIndex = 17;
            this.lsourceport.Text = "...";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 174);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Destination IP";
            // 
            // lsource
            // 
            this.lsource.AutoSize = true;
            this.lsource.Location = new System.Drawing.Point(106, 105);
            this.lsource.Name = "lsource";
            this.lsource.Size = new System.Drawing.Size(16, 13);
            this.lsource.TabIndex = 15;
            this.lsource.Text = "...";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Source IP";
            // 
            // lprotocol
            // 
            this.lprotocol.AutoSize = true;
            this.lprotocol.Location = new System.Drawing.Point(106, 72);
            this.lprotocol.Name = "lprotocol";
            this.lprotocol.Size = new System.Drawing.Size(16, 13);
            this.lprotocol.TabIndex = 13;
            this.lprotocol.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Protocol";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.MediumBlue;
            this.splitContainer3.Panel2.Controls.Add(this.tabControl3);
            this.splitContainer3.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer3.Size = new System.Drawing.Size(733, 442);
            this.splitContainer3.SplitterDistance = 227;
            this.splitContainer3.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(733, 227);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(725, 201);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Packet Analyzer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button2.Location = new System.Drawing.Point(790, -20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 19);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(721, 192);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.listViewIPPacket);
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Controls.Add(this.comboIPlist);
            this.tabPage5.Controls.Add(this.butGetPackets);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(713, 166);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "IP";
            this.tabPage5.ToolTipText = "IP Informations";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // listViewIPPacket
            // 
            this.listViewIPPacket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewIPPacket.ContextMenuStrip = this.contextMenuExport;
            this.listViewIPPacket.Location = new System.Drawing.Point(0, 41);
            this.listViewIPPacket.Name = "listViewIPPacket";
            this.listViewIPPacket.Size = new System.Drawing.Size(713, 129);
            this.listViewIPPacket.TabIndex = 9;
            this.listViewIPPacket.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "IPAddress";
            // 
            // comboIPlist
            // 
            this.comboIPlist.FormattingEnabled = true;
            this.comboIPlist.Location = new System.Drawing.Point(81, 10);
            this.comboIPlist.Name = "comboIPlist";
            this.comboIPlist.Size = new System.Drawing.Size(164, 21);
            this.comboIPlist.TabIndex = 6;
            // 
            // butGetPackets
            // 
            this.butGetPackets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butGetPackets.Location = new System.Drawing.Point(278, 12);
            this.butGetPackets.Name = "butGetPackets";
            this.butGetPackets.Size = new System.Drawing.Size(105, 23);
            this.butGetPackets.TabIndex = 5;
            this.butGetPackets.Text = "Get Packets";
            this.butGetPackets.UseVisualStyleBackColor = true;
            this.butGetPackets.Click += new System.EventHandler(this.butGetPackets_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.listViewTCP);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(713, 141);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "TCP";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // listViewTCP
            // 
            this.listViewTCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewTCP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTCP.Location = new System.Drawing.Point(3, 3);
            this.listViewTCP.Name = "listViewTCP";
            this.listViewTCP.Size = new System.Drawing.Size(707, 135);
            this.listViewTCP.TabIndex = 2;
            this.listViewTCP.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.listViewUDP);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(713, 141);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "UDP";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // listViewUDP
            // 
            this.listViewUDP.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listViewUDP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewUDP.Location = new System.Drawing.Point(0, 0);
            this.listViewUDP.Name = "listViewUDP";
            this.listViewUDP.Size = new System.Drawing.Size(864, 149);
            this.listViewUDP.TabIndex = 3;
            this.listViewUDP.UseCompatibleStateImageBehavior = false;
            // 
            // tabControl3
            // 
            this.tabControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl3.Controls.Add(this.tabPage11);
            this.tabControl3.Controls.Add(this.tabPage12);
            this.tabControl3.Location = new System.Drawing.Point(6, 22);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(721, 167);
            this.tabControl3.TabIndex = 2;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.listView1);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(713, 141);
            this.tabPage11.TabIndex = 1;
            this.tabPage11.Text = "TCP";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(707, 135);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.listView2);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Size = new System.Drawing.Size(713, 141);
            this.tabPage12.TabIndex = 2;
            this.tabPage12.Text = "UDP";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(713, 141);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.White;
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(733, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(117, 22);
            this.toolStripLabel1.Text = "Ruleset Classification";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormNids
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(88)))), ((int)(((byte)(184)))));
            this.ClientSize = new System.Drawing.Size(994, 442);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormNids";
            this.Text = " ";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.FormNids_Load);
            this.contextMenuExport.ResumeLayout(false);
            this.contextMenuPing.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuExport;
        private System.Windows.Forms.ToolStripMenuItem exportAsExcelToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuPing;
        private System.Windows.Forms.ToolStripMenuItem pingToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListCommon;
        private System.Windows.Forms.ToolStripMenuItem clearListToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboRules;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lsourceport;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lsource;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lprotocol;
        private System.Windows.Forms.Label laction;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label ldestinationport;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label ldestinationip;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ListView listViewIPPacket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboIPlist;
        private System.Windows.Forms.Button butGetPackets;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ListView listViewTCP;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.ListView listViewUDP;

    }
}
//<-------------------------------------------------------------------->
//  NIDS is the project work done by:
//  Bijoy Gopalakrishnan, Murali Sankar V.K and Nikhil V Nair 
//  Students of Computer Science Department, SIST, Tvm (2004-2008 batch)
//  as the Major Project which is part of the B.Tech course. 
//<-------------------------------------------------------------------->

