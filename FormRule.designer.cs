namespace WirelessNodeSimulation
{
    partial class FormRule
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
            this.trule = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dprotocol = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.s1 = new System.Windows.Forms.TextBox();
            this.tsourceport = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tdesport = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.daction = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.s2 = new System.Windows.Forms.TextBox();
            this.s3 = new System.Windows.Forms.TextBox();
            this.s4 = new System.Windows.Forms.TextBox();
            this.d4 = new System.Windows.Forms.TextBox();
            this.d3 = new System.Windows.Forms.TextBox();
            this.d2 = new System.Windows.Forms.TextBox();
            this.d1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // trule
            // 
            this.trule.Location = new System.Drawing.Point(124, 17);
            this.trule.Name = "trule";
            this.trule.Size = new System.Drawing.Size(186, 20);
            this.trule.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rule No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(334, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Protocol";
            // 
            // dprotocol
            // 
            this.dprotocol.FormattingEnabled = true;
            this.dprotocol.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.dprotocol.Location = new System.Drawing.Point(434, 16);
            this.dprotocol.Name = "dprotocol";
            this.dprotocol.Size = new System.Drawing.Size(121, 21);
            this.dprotocol.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Source IP";
            // 
            // s1
            // 
            this.s1.Location = new System.Drawing.Point(124, 59);
            this.s1.Name = "s1";
            this.s1.Size = new System.Drawing.Size(42, 20);
            this.s1.TabIndex = 5;
            // 
            // tsourceport
            // 
            this.tsourceport.Location = new System.Drawing.Point(434, 58);
            this.tsourceport.Name = "tsourceport";
            this.tsourceport.Size = new System.Drawing.Size(121, 20);
            this.tsourceport.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(334, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Source Port";
            // 
            // tdesport
            // 
            this.tdesport.Location = new System.Drawing.Point(434, 100);
            this.tdesport.Name = "tdesport";
            this.tdesport.Size = new System.Drawing.Size(121, 20);
            this.tdesport.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(333, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Destination Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Destination IP";
            // 
            // daction
            // 
            this.daction.FormattingEnabled = true;
            this.daction.Items.AddRange(new object[] {
            "deny",
            "allow"});
            this.daction.Location = new System.Drawing.Point(124, 138);
            this.daction.Name = "daction";
            this.daction.Size = new System.Drawing.Size(186, 21);
            this.daction.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Action";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(557, 89);
            this.dataGridView1.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(337, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Add Rule";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // s2
            // 
            this.s2.Location = new System.Drawing.Point(172, 59);
            this.s2.Name = "s2";
            this.s2.Size = new System.Drawing.Size(42, 20);
            this.s2.TabIndex = 21;
            // 
            // s3
            // 
            this.s3.Location = new System.Drawing.Point(220, 59);
            this.s3.Name = "s3";
            this.s3.Size = new System.Drawing.Size(42, 20);
            this.s3.TabIndex = 22;
            // 
            // s4
            // 
            this.s4.Location = new System.Drawing.Point(268, 59);
            this.s4.Name = "s4";
            this.s4.Size = new System.Drawing.Size(42, 20);
            this.s4.TabIndex = 23;
            // 
            // d4
            // 
            this.d4.Location = new System.Drawing.Point(268, 101);
            this.d4.Name = "d4";
            this.d4.Size = new System.Drawing.Size(42, 20);
            this.d4.TabIndex = 27;
            // 
            // d3
            // 
            this.d3.Location = new System.Drawing.Point(220, 101);
            this.d3.Name = "d3";
            this.d3.Size = new System.Drawing.Size(42, 20);
            this.d3.TabIndex = 26;
            // 
            // d2
            // 
            this.d2.Location = new System.Drawing.Point(172, 101);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(42, 20);
            this.d2.TabIndex = 25;
            // 
            // d1
            // 
            this.d1.Location = new System.Drawing.Point(124, 101);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(42, 20);
            this.d1.TabIndex = 24;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(416, 141);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 23);
            this.button2.TabIndex = 28;
            this.button2.Text = "Delete Rule";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(495, 141);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 23);
            this.button3.TabIndex = 29;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(582, 293);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.d4);
            this.Controls.Add(this.d3);
            this.Controls.Add(this.d2);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.s4);
            this.Controls.Add(this.s3);
            this.Controls.Add(this.s2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.daction);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tdesport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tsourceport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.s1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dprotocol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRule";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox trule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dprotocol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox s1;
        private System.Windows.Forms.TextBox tsourceport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tdesport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox daction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox s2;
        private System.Windows.Forms.TextBox s3;
        private System.Windows.Forms.TextBox s4;
        private System.Windows.Forms.TextBox d4;
        private System.Windows.Forms.TextBox d3;
        private System.Windows.Forms.TextBox d2;
        private System.Windows.Forms.TextBox d1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}