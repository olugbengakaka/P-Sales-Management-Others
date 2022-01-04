using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace POS_Eatery
{
    public partial class P_N : Form
    {
        public P_N()
        {
            InitializeComponent();
        }
        General_Class_Imp gclass = new General_Class_Imp();
        private void Form6_Load(object sender, EventArgs e)
        {
            gclass.display_in_combobox("SELECT DISTINCT Branch from table_Mr ORDER BY Branch", branch, "Branch");
            branch.SelectedIndex = -1;
            /*// string s = "IGE TOSIN";
             try
             {
                 var s = "IGE   TOSIN  ";
                 string firstword;
                  firstword = s.Substring(0, s.IndexOf(" "));
                 // MessageBox.Show(firstWord);
             }
             catch
             { 

             }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Enter Admin Number for SMS Notification ...");
            }
            else if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Enter Number of Recipt to print per Transaction ...");
            }
            else if (branch.SelectedIndex == -1)
            {
                MessageBox.Show("Select Plant Location ...");
            }
            else
            {
                gclass.insert("INSERT INTO Table_Number(number,no_receipt,Branch)values('" + textBox1.Text + "','" + textBox2.Text + "','"+ branch.Text +"')");

            }
           /* gclass.display_in_dgv("Select distinct receipt_no from table_sales_confirmed where year='" + DateTime.Now.Year + "'", dataGridView7);
            for (int i = 0; i < dataGridView7.Rows.Count; i++)
            {
                string a = null;
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT SUM(Item_value) from table_sales_confirmed where receipt_no='" + Convert.ToString(dataGridView7.Rows[i].Cells[0].Value) + "'", cn);
                MySqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    if (dr.Read())
                    {
                        a = (string)dr.GetValue(0).ToString();
                    }
                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex.Message);
                }
                finally
                {
                    cn.Close(); cn.Dispose();
                    cmd.Dispose();
                    dr.Close(); dr.Dispose();
                }
                gclass.Update1("UPDATE table_sales_lump set item_value='" + a + "' where receipt_no='" + Convert.ToString(dataGridView7.Rows[i].Cells[0].Value) + "'");
            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*try
            {
                int a = int.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Only Numeric Character is allowed ...");
                textBox1.Text = null;
            }*/
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(textBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No. of Receipt to Print can only contain Integer ...", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = ex.Message;
            }

        }
    }
}
