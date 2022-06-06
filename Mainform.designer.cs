namespace WirelessNodeSimulation
{
    partial class Mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusMain = new System.Windows.Forms.StatusStrip();
            this.status_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_no = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip_main = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_ip = new System.Windows.Forms.ToolStripLabel();
            this.PCK_counter = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl_nwstat = new System.Windows.Forms.TabControl();
            this.TP_statics = new System.Windows.Forms.TabPage();
            this.listv_netstat = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.list_tcpActivity = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl_port = new System.Windows.Forms.TabControl();
            this.TP_Aport = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.prt_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Protocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status_dscr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.listView_activity = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tab_packect = new System.Windows.Forms.TabControl();
            this.tabPage_IP = new System.Windows.Forms.TabPage();
            this.listView_IP = new System.Windows.Forms.ListView();
            this.Source_IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Destin_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pro_typ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Headr_lnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.msg_lgth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.to_lenth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ver = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ttl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.frag_offst = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.identi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Diff_serv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage_TCP = new System.Windows.Forms.TabPage();
            this.listView_tcp = new System.Windows.Forms.ListView();
            this.src_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.src_prt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dst_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dst_prt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sq_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ack_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Header_lth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wnd_sz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chk_sum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.urgnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage_UDP = new System.Windows.Forms.TabPage();
            this.listView_udp = new System.Windows.Forms.ListView();
            this.s_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.S_port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.d_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.d_port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Lengh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chk_sum1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl_Histogram = new System.Windows.Forms.TabControl();
            this.tabPage_hist = new System.Windows.Forms.TabPage();
            this.histogramaDesenat1 = new WirelessNodeSimulation.HistogramaDesenat();
            this.MainMenu.SuspendLayout();
            this.StatusMain.SuspendLayout();
            this.toolStrip_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl_nwstat.SuspendLayout();
            this.TP_statics.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabControl_port.SuspendLayout();
            this.TP_Aport.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tab_packect.SuspendLayout();
            this.tabPage_IP.SuspendLayout();
            this.tabPage_TCP.SuspendLayout();
            this.tabPage_UDP.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl_Histogram.SuspendLayout();
            this.tabPage_hist.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.DarkBlue;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem2});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(988, 29);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitToolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(51, 25);
            this.exitToolStripMenuItem2.Text = "Exit";
            this.exitToolStripMenuItem2.Click += new System.EventHandler(this.exitToolStripMenuItem2_Click);
            // 
            // StatusMain
            // 
            this.StatusMain.BackColor = System.Drawing.Color.Transparent;
            this.StatusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_label,
            this.label_no});
            this.StatusMain.Location = new System.Drawing.Point(0, 628);
            this.StatusMain.Name = "StatusMain";
            this.StatusMain.Size = new System.Drawing.Size(988, 22);
            this.StatusMain.TabIndex = 1;
            this.StatusMain.Text = "statusStrip1";
            // 
            // status_label
            // 
            this.status_label.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(39, 17);
            this.status_label.Text = "Ready";
            // 
            // label_no
            // 
            this.label_no.Name = "label_no";
            this.label_no.Size = new System.Drawing.Size(36, 17);
            this.label_no.Text = "None";
            // 
            // toolStrip_main
            // 
            this.toolStrip_main.BackColor = System.Drawing.Color.White;
            this.toolStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStrip_ip});
            this.toolStrip_main.Location = new System.Drawing.Point(0, 29);
            this.toolStrip_main.Name = "toolStrip_main";
            this.toolStrip_main.Size = new System.Drawing.Size(988, 25);
            this.toolStrip_main.TabIndex = 2;
            this.toolStrip_main.Text = "Maintool";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Start Capturing";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Enabled = false;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Stop capturing";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStrip_ip
            // 
            this.toolStrip_ip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStrip_ip.Name = "toolStrip_ip";
            this.toolStrip_ip.Size = new System.Drawing.Size(40, 22);
            this.toolStrip_ip.Text = "0.0.0.0";
            // 
            // PCK_counter
            // 
            this.PCK_counter.Interval = 2000;
            this.PCK_counter.Tick += new System.EventHandler(this.PCK_counter_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 15000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 54);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.DarkBlue;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(988, 574);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tabControl_nwstat, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tabControl_port, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 410);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(959, 164);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tabControl_nwstat
            // 
            this.tabControl_nwstat.Controls.Add(this.TP_statics);
            this.tabControl_nwstat.Controls.Add(this.tabPage5);
            this.tabControl_nwstat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_nwstat.Location = new System.Drawing.Point(3, 3);
            this.tabControl_nwstat.Name = "tabControl_nwstat";
            this.tabControl_nwstat.SelectedIndex = 0;
            this.tabControl_nwstat.Size = new System.Drawing.Size(473, 158);
            this.tabControl_nwstat.TabIndex = 0;
            // 
            // TP_statics
            // 
            this.TP_statics.Controls.Add(this.listv_netstat);
            this.TP_statics.Location = new System.Drawing.Point(4, 22);
            this.TP_statics.Name = "TP_statics";
            this.TP_statics.Padding = new System.Windows.Forms.Padding(3);
            this.TP_statics.Size = new System.Drawing.Size(465, 132);
            this.TP_statics.TabIndex = 0;
            this.TP_statics.Text = "Network Activity";
            this.TP_statics.UseVisualStyleBackColor = true;
            // 
            // listv_netstat
            // 
            this.listv_netstat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listv_netstat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listv_netstat.Location = new System.Drawing.Point(3, 3);
            this.listv_netstat.Name = "listv_netstat";
            this.listv_netstat.Size = new System.Drawing.Size(459, 126);
            this.listv_netstat.TabIndex = 0;
            this.listv_netstat.UseCompatibleStateImageBehavior = false;
            this.listv_netstat.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 500;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.list_tcpActivity);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(465, 132);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "UDP/TCP Packet Info";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // list_tcpActivity
            // 
            this.list_tcpActivity.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.list_tcpActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_tcpActivity.Location = new System.Drawing.Point(3, 3);
            this.list_tcpActivity.Name = "list_tcpActivity";
            this.list_tcpActivity.Size = new System.Drawing.Size(380, 126);
            this.list_tcpActivity.TabIndex = 0;
            this.list_tcpActivity.UseCompatibleStateImageBehavior = false;
            this.list_tcpActivity.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Activity";
            this.columnHeader2.Width = 500;
            // 
            // tabControl_port
            // 
            this.tabControl_port.Controls.Add(this.TP_Aport);
            this.tabControl_port.Controls.Add(this.tabPage7);
            this.tabControl_port.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_port.Location = new System.Drawing.Point(482, 3);
            this.tabControl_port.Name = "tabControl_port";
            this.tabControl_port.SelectedIndex = 0;
            this.tabControl_port.Size = new System.Drawing.Size(474, 158);
            this.tabControl_port.TabIndex = 1;
            // 
            // TP_Aport
            // 
            this.TP_Aport.Controls.Add(this.listView1);
            this.TP_Aport.Location = new System.Drawing.Point(4, 22);
            this.TP_Aport.Name = "TP_Aport";
            this.TP_Aport.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Aport.Size = new System.Drawing.Size(466, 132);
            this.TP_Aport.TabIndex = 0;
            this.TP_Aport.Text = "Ports";
            this.TP_Aport.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.prt_no,
            this.Protocol,
            this.Status_dscr});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(460, 126);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // prt_no
            // 
            this.prt_no.Text = "Port No.";
            this.prt_no.Width = 78;
            // 
            // Protocol
            // 
            this.Protocol.Text = "Protocol";
            this.Protocol.Width = 100;
            // 
            // Status_dscr
            // 
            this.Status_dscr.Text = "Packet Count";
            this.Status_dscr.Width = 150;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.listView_activity);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(466, 132);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Activity list";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // listView_activity
            // 
            this.listView_activity.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView_activity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_activity.Location = new System.Drawing.Point(3, 3);
            this.listView_activity.Name = "listView_activity";
            this.listView_activity.Size = new System.Drawing.Size(381, 126);
            this.listView_activity.TabIndex = 0;
            this.listView_activity.UseCompatibleStateImageBehavior = false;
            this.listView_activity.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Protocol";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "PortNo.";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Status";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Process";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "PID";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tab_packect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(959, 182);
            this.panel1.TabIndex = 1;
            // 
            // tab_packect
            // 
            this.tab_packect.Controls.Add(this.tabPage_IP);
            this.tab_packect.Controls.Add(this.tabPage_TCP);
            this.tab_packect.Controls.Add(this.tabPage_UDP);
            this.tab_packect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_packect.Location = new System.Drawing.Point(0, 0);
            this.tab_packect.Name = "tab_packect";
            this.tab_packect.SelectedIndex = 0;
            this.tab_packect.Size = new System.Drawing.Size(959, 182);
            this.tab_packect.TabIndex = 0;
            this.tab_packect.SelectedIndexChanged += new System.EventHandler(this.tab_packect_SelectedIndexChanged);
            // 
            // tabPage_IP
            // 
            this.tabPage_IP.Controls.Add(this.listView_IP);
            this.tabPage_IP.Location = new System.Drawing.Point(4, 22);
            this.tabPage_IP.Name = "tabPage_IP";
            this.tabPage_IP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_IP.Size = new System.Drawing.Size(951, 156);
            this.tabPage_IP.TabIndex = 0;
            this.tabPage_IP.Text = "IP Packet";
            this.tabPage_IP.UseVisualStyleBackColor = true;
            // 
            // listView_IP
            // 
            this.listView_IP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Source_IP,
            this.Destin_ip,
            this.Pro_typ,
            this.Headr_lnt,
            this.msg_lgth,
            this.to_lenth,
            this.ver,
            this.chk,
            this.flg,
            this.ttl,
            this.frag_offst,
            this.identi,
            this.Diff_serv});
            this.listView_IP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_IP.GridLines = true;
            this.listView_IP.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_IP.Location = new System.Drawing.Point(3, 3);
            this.listView_IP.Name = "listView_IP";
            this.listView_IP.Size = new System.Drawing.Size(945, 150);
            this.listView_IP.TabIndex = 0;
            this.listView_IP.UseCompatibleStateImageBehavior = false;
            this.listView_IP.View = System.Windows.Forms.View.Details;
            // 
            // Source_IP
            // 
            this.Source_IP.Text = "Source IP";
            this.Source_IP.Width = 100;
            // 
            // Destin_ip
            // 
            this.Destin_ip.Text = "Destination IP";
            this.Destin_ip.Width = 100;
            // 
            // Pro_typ
            // 
            this.Pro_typ.Text = "Protocol Type";
            this.Pro_typ.Width = 100;
            // 
            // Headr_lnt
            // 
            this.Headr_lnt.Text = "Header Length";
            this.Headr_lnt.Width = 100;
            // 
            // msg_lgth
            // 
            this.msg_lgth.DisplayIndex = 10;
            this.msg_lgth.Text = "Message Length";
            this.msg_lgth.Width = 100;
            // 
            // to_lenth
            // 
            this.to_lenth.DisplayIndex = 4;
            this.to_lenth.Text = "Total Length";
            this.to_lenth.Width = 100;
            // 
            // ver
            // 
            this.ver.DisplayIndex = 12;
            this.ver.Text = "Version";
            this.ver.Width = 100;
            // 
            // chk
            // 
            this.chk.DisplayIndex = 5;
            this.chk.Text = "Check Sum";
            this.chk.Width = 100;
            // 
            // flg
            // 
            this.flg.DisplayIndex = 7;
            this.flg.Text = "Flags";
            this.flg.Width = 100;
            // 
            // ttl
            // 
            this.ttl.DisplayIndex = 11;
            this.ttl.Text = "TTL";
            this.ttl.Width = 100;
            // 
            // frag_offst
            // 
            this.frag_offst.DisplayIndex = 8;
            this.frag_offst.Text = "Fragmentation Offset";
            this.frag_offst.Width = 100;
            // 
            // identi
            // 
            this.identi.DisplayIndex = 9;
            this.identi.Text = "Identification";
            this.identi.Width = 100;
            // 
            // Diff_serv
            // 
            this.Diff_serv.DisplayIndex = 6;
            this.Diff_serv.Text = "Differntiated Service";
            this.Diff_serv.Width = 100;
            // 
            // tabPage_TCP
            // 
            this.tabPage_TCP.Controls.Add(this.listView_tcp);
            this.tabPage_TCP.Location = new System.Drawing.Point(4, 22);
            this.tabPage_TCP.Name = "tabPage_TCP";
            this.tabPage_TCP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_TCP.Size = new System.Drawing.Size(951, 156);
            this.tabPage_TCP.TabIndex = 1;
            this.tabPage_TCP.Text = "TCP Packet";
            this.tabPage_TCP.UseVisualStyleBackColor = true;
            // 
            // listView_tcp
            // 
            this.listView_tcp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.src_ip,
            this.src_prt,
            this.dst_ip,
            this.dst_prt,
            this.sq_no,
            this.ack_no,
            this.Header_lth,
            this.wnd_sz,
            this.chk_sum,
            this.urgnt});
            this.listView_tcp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_tcp.GridLines = true;
            this.listView_tcp.Location = new System.Drawing.Point(3, 3);
            this.listView_tcp.Name = "listView_tcp";
            this.listView_tcp.Size = new System.Drawing.Size(787, 150);
            this.listView_tcp.TabIndex = 0;
            this.listView_tcp.UseCompatibleStateImageBehavior = false;
            this.listView_tcp.View = System.Windows.Forms.View.Details;
            // 
            // src_ip
            // 
            this.src_ip.Text = "Source IP";
            this.src_ip.Width = 100;
            // 
            // src_prt
            // 
            this.src_prt.Text = "Source Port";
            this.src_prt.Width = 100;
            // 
            // dst_ip
            // 
            this.dst_ip.Text = "Destination IP";
            this.dst_ip.Width = 100;
            // 
            // dst_prt
            // 
            this.dst_prt.Text = "Destination Port";
            this.dst_prt.Width = 100;
            // 
            // sq_no
            // 
            this.sq_no.Text = "Sequence Number";
            this.sq_no.Width = 100;
            // 
            // ack_no
            // 
            this.ack_no.Text = "Ack no.";
            this.ack_no.Width = 100;
            // 
            // Header_lth
            // 
            this.Header_lth.Text = "Header Length";
            this.Header_lth.Width = 100;
            // 
            // wnd_sz
            // 
            this.wnd_sz.Text = "Window Size";
            this.wnd_sz.Width = 100;
            // 
            // chk_sum
            // 
            this.chk_sum.Text = "Check sum";
            this.chk_sum.Width = 100;
            // 
            // urgnt
            // 
            this.urgnt.Text = "Urgent Pointer";
            this.urgnt.Width = 100;
            // 
            // tabPage_UDP
            // 
            this.tabPage_UDP.Controls.Add(this.listView_udp);
            this.tabPage_UDP.Location = new System.Drawing.Point(4, 22);
            this.tabPage_UDP.Name = "tabPage_UDP";
            this.tabPage_UDP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_UDP.Size = new System.Drawing.Size(951, 156);
            this.tabPage_UDP.TabIndex = 2;
            this.tabPage_UDP.Text = "UDP Packet";
            this.tabPage_UDP.UseVisualStyleBackColor = true;
            // 
            // listView_udp
            // 
            this.listView_udp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.s_ip,
            this.S_port,
            this.d_ip,
            this.d_port,
            this.Lengh,
            this.chk_sum1});
            this.listView_udp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_udp.GridLines = true;
            this.listView_udp.Location = new System.Drawing.Point(3, 3);
            this.listView_udp.Name = "listView_udp";
            this.listView_udp.Size = new System.Drawing.Size(787, 150);
            this.listView_udp.TabIndex = 0;
            this.listView_udp.UseCompatibleStateImageBehavior = false;
            this.listView_udp.View = System.Windows.Forms.View.Details;
            // 
            // s_ip
            // 
            this.s_ip.Text = "Source IP";
            this.s_ip.Width = 150;
            // 
            // S_port
            // 
            this.S_port.Text = "Source Port";
            this.S_port.Width = 100;
            // 
            // d_ip
            // 
            this.d_ip.Text = "Destination IP";
            this.d_ip.Width = 150;
            // 
            // d_port
            // 
            this.d_port.Text = "Destination Port";
            this.d_port.Width = 100;
            // 
            // Lengh
            // 
            this.Lengh.Text = "Length";
            this.Lengh.Width = 100;
            // 
            // chk_sum1
            // 
            this.chk_sum1.Text = "Check sum";
            this.chk_sum1.Width = 100;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 97.62797F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.372035F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl_Histogram, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(959, 228);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl_Histogram
            // 
            this.tabControl_Histogram.Controls.Add(this.tabPage_hist);
            this.tabControl_Histogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Histogram.Location = new System.Drawing.Point(3, 3);
            this.tabControl_Histogram.Name = "tabControl_Histogram";
            this.tabControl_Histogram.SelectedIndex = 0;
            this.tabControl_Histogram.Size = new System.Drawing.Size(930, 222);
            this.tabControl_Histogram.TabIndex = 1;
            // 
            // tabPage_hist
            // 
            this.tabPage_hist.Controls.Add(this.histogramaDesenat1);
            this.tabPage_hist.Location = new System.Drawing.Point(4, 22);
            this.tabPage_hist.Name = "tabPage_hist";
            this.tabPage_hist.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_hist.Size = new System.Drawing.Size(922, 196);
            this.tabPage_hist.TabIndex = 0;
            this.tabPage_hist.Text = "Histogram";
            this.tabPage_hist.UseVisualStyleBackColor = true;
            // 
            // histogramaDesenat1
            // 
            this.histogramaDesenat1.BackColor = System.Drawing.Color.White;
            this.histogramaDesenat1.DisplayColor = System.Drawing.Color.Black;
            this.histogramaDesenat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histogramaDesenat1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.histogramaDesenat1.Location = new System.Drawing.Point(3, 3);
            this.histogramaDesenat1.Name = "histogramaDesenat1";
            this.histogramaDesenat1.Offset = 20;
            this.histogramaDesenat1.Size = new System.Drawing.Size(916, 190);
            this.histogramaDesenat1.TabIndex = 0;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(88)))), ((int)(((byte)(184)))));
            this.ClientSize = new System.Drawing.Size(988, 650);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip_main);
            this.Controls.Add(this.StatusMain);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "Mainform";
            this.Text = "FireCol";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mainform_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.StatusMain.ResumeLayout(false);
            this.StatusMain.PerformLayout();
            this.toolStrip_main.ResumeLayout(false);
            this.toolStrip_main.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl_nwstat.ResumeLayout(false);
            this.TP_statics.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabControl_port.ResumeLayout(false);
            this.TP_Aport.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tab_packect.ResumeLayout(false);
            this.tabPage_IP.ResumeLayout(false);
            this.tabPage_TCP.ResumeLayout(false);
            this.tabPage_UDP.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl_Histogram.ResumeLayout(false);
            this.tabPage_hist.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.StatusStrip StatusMain;
        private System.Windows.Forms.ToolStripStatusLabel status_label;
        private System.Windows.Forms.ToolStrip toolStrip_main;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tab_packect;
        private System.Windows.Forms.TabPage tabPage_IP;
        private System.Windows.Forms.TabPage tabPage_TCP;
        private System.Windows.Forms.TabPage tabPage_UDP;
        private System.Windows.Forms.TabControl tabControl_nwstat;
        private System.Windows.Forms.TabPage TP_statics;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabControl tabControl_port;
        private System.Windows.Forms.TabPage TP_Aport;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.ListView listView_IP;
        private System.Windows.Forms.ColumnHeader Source_IP;
        private System.Windows.Forms.ColumnHeader Destin_ip;
        private System.Windows.Forms.ColumnHeader Pro_typ;
        private System.Windows.Forms.ColumnHeader Headr_lnt;
        private System.Windows.Forms.ColumnHeader to_lenth;
        private System.Windows.Forms.ColumnHeader chk;
        private System.Windows.Forms.ColumnHeader Diff_serv;
        private System.Windows.Forms.ColumnHeader flg;
        private System.Windows.Forms.ColumnHeader frag_offst;
        private System.Windows.Forms.ListView listView_tcp;
        private System.Windows.Forms.ListView listView_udp;
        private System.Windows.Forms.ColumnHeader identi;
        private System.Windows.Forms.ColumnHeader msg_lgth;
        private System.Windows.Forms.ColumnHeader ttl;
        private System.Windows.Forms.ColumnHeader ver;
        private System.Windows.Forms.ColumnHeader src_ip;
        private System.Windows.Forms.ColumnHeader src_prt;
        private System.Windows.Forms.ColumnHeader dst_ip;
        private System.Windows.Forms.ColumnHeader dst_prt;
        private System.Windows.Forms.ColumnHeader sq_no;
        private System.Windows.Forms.ColumnHeader ack_no;
        private System.Windows.Forms.ColumnHeader Header_lth;
        private System.Windows.Forms.ColumnHeader wnd_sz;
        private System.Windows.Forms.ColumnHeader chk_sum;
        private System.Windows.Forms.ColumnHeader urgnt;
        private System.Windows.Forms.ColumnHeader s_ip;
        private System.Windows.Forms.ColumnHeader S_port;
        private System.Windows.Forms.ColumnHeader d_ip;
        private System.Windows.Forms.ColumnHeader d_port;
        private System.Windows.Forms.ColumnHeader Lengh;
        private System.Windows.Forms.ColumnHeader chk_sum1;
        private System.Windows.Forms.Timer PCK_counter;
        private System.Windows.Forms.ToolStripLabel toolStrip_ip;
        private System.Windows.Forms.ToolStripStatusLabel label_no;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Protocol;
        private System.Windows.Forms.ColumnHeader prt_no;
        private System.Windows.Forms.ColumnHeader Status_dscr;
        private System.Windows.Forms.ListView listView_activity;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView listv_netstat;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView list_tcpActivity;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.TabControl tabControl_Histogram;
        private System.Windows.Forms.TabPage tabPage_hist;
        private HistogramaDesenat histogramaDesenat1;
    }
}

