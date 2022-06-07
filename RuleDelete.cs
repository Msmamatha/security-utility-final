using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WirelessNodeSimulation
{
    public partial class RuleDelete : Form
    {
        BaseConnection con = new BaseConnection();
        public RuleDelete()
        {
            InitializeComponent();
            filldb();
            fillcombo();
        }
        public void filldb()
        {
            string query = "select * from detection";
            DataSet ds = con.ret_ds(query);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        public void fillcombo()
        {
            try
            {
                comboBox1.Items.Clear();
                string st = "select * from detection";
                SqlDataReader dr = con.ret_dr(st);
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0].ToString());
                }

            }
            catch (Exception ex)
            { 
            }
 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               
                string st ="delete from detection where rules='"+comboBox1.Text.ToString()+"'";
                if (con.exec1(st) > 0)
                {
                    MessageBox.Show("Rule deleted....");
                    fillcombo();
                    filldb();
                }

            }
            catch (Exception ex)
            {
                fillcombo();
                filldb();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRule obj = new FormRule();
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
