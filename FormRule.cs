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
    public partial class FormRule : Form
    {
        BaseConnection obj = new BaseConnection();
       SqlConnection con = new SqlConnection("server=localhost;database=Rules;uid=sa;pwd=yuva");
        //SqlConnection con = new SqlConnection("Data Source=RESHMA-PC\\SQLEXPRESS;Initial Catalog=Rules;Integrated Security=True");
        public FormRule()
        {
            InitializeComponent();
            id();
            filldb();
        }
        public void id()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select isnull(substring(max(Rules),2,4),1)+1 from Detection ", con);
            SqlDataReader dr=cmd.ExecuteReader();
            if (dr.Read())
            {
                trule.Text = "r" + dr[0].ToString();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public void filldb()
        {
            string query = "select * from detection";
            DataSet ds = obj.ret_ds(query);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sourceip = "";
                string destinationip = "";

                if (s1.Text == "" || s1.Text == "*")
                {
                    sourceip = "*.*.*.*";
                  
                }else if (s2.Text == "" || s2.Text == "*")
                {
                    sourceip = s1.Text + ".*.*.*";
                  
                }else if (s3.Text == "" || s3.Text == "*")
                {
                    sourceip = s1.Text + "." + s2.Text + ".*.*";
                          
                }else if (s4.Text == ""|| s4.Text == "*")
                {
                    sourceip = s1.Text + "." + s2.Text + "." + s3.Text + ".*";
                }
                else
                {
                    sourceip = s1.Text + "." + s2.Text + "." + s3.Text + ".*" + s4.Text;
               
                }


                if (d1.Text == "" || d1.Text == "*")
                {
                    destinationip = "*.*.*.*";

                }
                else if (d2.Text == "" || d2.Text == "*")
                {
                    destinationip = d1.Text + ".*.*.*";

                }
                else if (d3.Text == "" || d3.Text == "*")
                {
                    destinationip = d1.Text + "." + d2.Text + ".*.*";

                }
                else if (d4.Text == "" || d4.Text == "*")
                {
                    destinationip = d1.Text + "." + d2.Text + "." + d3.Text + ".*";
                }
                else
                {
                    destinationip = d1.Text + "." + d2.Text + "." + d3.Text + ".*" + d4.Text;

                }


                string query = "insert into detection values('" + trule.Text + "','" + dprotocol.SelectedItem.ToString() + "','" + sourceip + "','" + tsourceport.Text + "','" + destinationip + "','" + tdesport.Text + "','" + daction.SelectedItem.ToString() + "')";
                if (obj.exec1(query) > 0)
                {
                    MessageBox.Show("Inserted Successfully");
                    filldb();
                }

               

            }
            catch (Exception ex)
            {
                MessageBox.Show("exception.....");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RuleDelete obj = new RuleDelete();
            ActiveForm.Hide();
            obj.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
