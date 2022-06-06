using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WirelessNodeSimulation
{
    public partial class login : Form
    {
       // AdminConnection obj = new AdminConnection();
        public login()
        {
            InitializeComponent();
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            if (tB_username.Text == "admin" && tB_passwd.Text == "admin")
            {
                MDIParent1 obj = new MDIParent1();
                ActiveForm.Hide();
                obj.Show();
            }
            else
            {
                MessageBox.Show("invalid username or password");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
