using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.InteropServices;

namespace POS_Eatery
{
    class General_Class_Imp
    {

        MySqlDataReader dr;

       /* public string set_system_time()
        { 
      public struct SYSTEMTIME 
{
    public ushort Year;
    public ushort Month;
    public ushort DayOfWeek;
    public ushort Day;
    public ushort Hour;
    public ushort Minute;
    public ushort Second;
    public ushort Millisecond;
      }
 
[DllImport("kernel32.dll", EntryPoint = "GetSystemTime", SetLastError = true)]
public extern static void Win32GetSystemTime(ref SYSTEMTIME sysTime);
 
[DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
public extern static bool Win32SetSystemTime(ref SYSTEMTIME sysTime);
        return "Sola";
    }*/

        public string export_to_excell(DataGridView dataGridView1)
        {
           try
            {
                dataGridView1.SelectAll();
                DataObject dataObj = dataGridView1.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);

                // copyAlltoClipboard();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "sola";
        }

        public string printdocument(DataGridView dgv_to_print, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(dgv_to_print.Width, dgv_to_print.Height);
            dgv_to_print.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, dgv_to_print.Width, dgv_to_print.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
            int row = 1;
            if (row <= 12)
            {
                e.HasMorePages = false;
            }
            return "Sola";
        }

        public string print(PrintDocument printDocument1)
        {
            PrintDialog printDlg = new PrintDialog();
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
            return "Sola";
        }

        public string insert(string query)
        {
            DialogResult dr = MessageBox.Show("Do you Really want to Save this Record? \n \n Click yes to Confirm Submission", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand(query, cn);
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cn.Close();
                    cmd.Dispose();
                }
            }
            return "Sola";
        }

        public string insert_online(string query)
        {
            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                // MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring_online"].ConnectionString);
                cn.Open();
                // MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }
            return "Sola";
        }

        public string get_on(WebBrowser wb1, System.Windows.Forms.TextBox g_school)
        {
            try
            {
                bool bb = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                if (bb == true)
                {
                    string web = "http://memesco.com/schools.aspx?school=" + g_school.Text; //+ textBox1.Text;localhost:37214/Brightest%20Star%20Group%20of%20Schools
                    wb1.Navigate(web); //style=" visibility:hidden;"
                    System.Threading.Thread.Sleep(15000);
                }
                else
                {
                    MessageBox.Show("Unable to Connect to Internet ...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "Sola";
        }

        public string get_time_server(WebBrowser wb1,System.Windows.Forms.TextBox branch)
        {
            try
            {
                bool bb = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                if (bb == true)
                {
                    string web = "http://memesco.com/timer.aspx?branch=" + branch.Text;  //+ textBox1.Text;localhost:37214/Brightest%20Star%20Group%20of%20Schools
                    wb1.Navigate(web); //style=" visibility:hidden;"
                    System.Threading.Thread.Sleep(10000);
                }
                else
                {
                    MessageBox.Show("Unable to Connect to Internet ...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "Sola";
        }

        public string fff()
        {
            try
            {
                Form7 fm = new Form7();
                fm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "Sola";
        }


        public string get_on1(WebBrowser wb1)
        {
            try
            {
                bool bb = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                if (bb == true)
                {
                    string web = "http://memesco.com/cstring.aspx";
                    wb1.Navigate(web);
                    System.Threading.Thread.Sleep(15000);
                }
                else
                {
                    MessageBox.Show("Unable to Connect to Internet ...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "Sola";
        }

        public string display_in_dgv_Online_v(string query, DataGridView DGV)
        {
            DGV.DataSource = null;
            DGV.Rows.Clear();
            try
            {
                //MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring_online"].ConnectionString);
                MySqlConnection cn = new MySqlConnection("Server=MYSQL5008.Smarterasp.net;Database=db_9b1853_sact;Uid=9b1853_sact;Pwd=admin1234;Connection Timeout=75500;");
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                DGV.DataSource = dt;
                cn.Close();
                cmd.Dispose();
                //MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "Sola";
        }

        public MySqlDataReader display_in_box1(string query, MySqlConnection cn, MySqlCommand cmd)
        {
            try
            {
                cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                //MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dr;
        }



        public string insert1(string query)
        {
            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                //  MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                //MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                // MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }
            return "Sola";
        }

        public string insert_nil(string query)
        {
            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                //  MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                //MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                // MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }
            return "Sola";
        }

        public string insert_timer_server(string query)
        {
            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                //  MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                //MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                 MessageBox.Show("Sever Verification was Succesful ...", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }
            return "Sola";
        }


        public string Update(string query)
        {
            DialogResult dr = MessageBox.Show("Do you Really want to Save Update on this Record? \n \n Click yes to Confirm Submission", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand(query, cn);
                try
                {
                    // MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    //MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update was Successfull!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cn.Close();
                    cmd.Dispose();
                }
            }
            return "Sola";
        }

        public string Update_Online(string query)
        {
            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                // MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring_online"].ConnectionString);
                cn.Open();
                // MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update was Successfull!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cn.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }
            return "Sola";
        }

        public string Update_Online1(string query)
        {
            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                //  MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring_online"].ConnectionString);
                cn.Open();
                // MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update was Successfull!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cn.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }
            return "Sola";
        }

        public string Update1(string query)
        {
            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                // MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                // MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //  MessageBox.Show("Update was Successfull!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }
            return "Sola";
        }

        public string Expand_Database(string query)
        {
            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                // MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                // MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //  MessageBox.Show("Update was Successfull!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }
            return "Sola";
        }

        public string Delete(string query)
        {
            DialogResult dr = MessageBox.Show("Do you Really want to Delete Selected/ Displayed Record? \n \n The Record will be Permanently Deleted from the Database! \n \n  Click Yes to Confirm Delete or No to Abort...", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand(query, cn);
                try
                {
                    // MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                    cn.Open();
                    // MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Successfully Deleted! \n \n You might need to Re-login to see the Effect!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Delete Not Permitted for the Selected Record! ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.Close();
                    cmd.Dispose();
                }
            }
            return "Sola";
        }

        public string Delete1(string query)
        {
           
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                try
                {
                    // MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                   
                    // MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                  //  MessageBox.Show("Record Successfully Deleted! \n \n You might need to Re-login to see the Effect!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Delete Not Permitted for the Selected Record! ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.Close();
                    cmd.Dispose();
                }
            return "Sola";
        }

        public string display_in_dgv(string query, DataGridView DGV)
        {
            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                DGV.DataSource = null;
                DGV.Rows.Clear();

                // MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                // MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                DGV.DataSource = dt;
                //MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }
            return "Sola";
        }

        public string display_in_dgv_online(string query, DataGridView DGV, string con)
        {
            DGV.DataSource = null;
            DGV.Rows.Clear();
            try
            {
                //  MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring_online"].ConnectionString);
                MySqlConnection cn = new MySqlConnection(con);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                try
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    DGV.DataSource = dt;
                    cn.Close();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cn.Close(); cn.Dispose(); cmd.Dispose();
                }
                //MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "Sola";
        }

        public MySqlDataReader display_in_box(string query)
        {

            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                //MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dr;
        }

        public string display_in_combobox(string query, ComboBox cbobox, string vmember)
        {
            MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                //  MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                // MySqlCommand cmd = new MySqlCommand(query, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                cbobox.DataSource = dt;
                cbobox.ValueMember = vmember;
                //MessageBox.Show("Record Successfully Saved!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }
            return "Sola";
        }

        public string verify_id_availability(string query, System.Windows.Forms.TextBox txt)
        {

            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("ID/ Ref No already exists!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt.Text = null;
                    dr.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return "Sola";
        }

        public string validate_for_int(string input, System.Windows.Forms.TextBox txt)
        {
            try
            {
                decimal a = decimal.Parse(txt.Text);
            }
            catch
            {
                MessageBox.Show("Enter Numbers only!", "Confirmation Box!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Text = "0";
            }
            return "sola";
        }

        public string calculation_add(string variable, string variable_net, System.Windows.Forms.TextBox txt_net)
        {

            int var = Convert.ToInt32(variable);
            int net = Convert.ToInt32(variable_net);
            if (var >= 0)
            {
                try
                {
                    txt_net.Text = (variable_net + var).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return "Sola";
        }

        public string calculation_subtract(string variable, string variable_net, System.Windows.Forms.TextBox txt_net)
        {

            int var = Convert.ToInt32(variable);
            int net = Convert.ToInt32(variable_net);
            if (var > 0)
            {
                try
                {
                    txt_net.Text = (var - net).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return "Sola";
        }

        public string images(PictureBox pbox)
        {
            pbox.BorderStyle = BorderStyle.FixedSingle;
            // pbox.SizeMode = PictureBoxSizeMode.StretchImage;
            pbox.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "/images/medical2.jpg");
            return "Sola";
        }

        public string treat_panel_main(Panel panel1)
        {
            panel1.BackColor = Color.Peru;
            return "Sola";
        }

        public string treat_panel_inner(Panel panel1)
        {
            panel1.BackColor = Color.Black;
            return "Sola";
        }

        public string treat_panel_banner(Panel panel1)
        {
            panel1.BackColor = Color.Black;
            return "Sola";
        }

        public string treat_groupbox(System.Windows.Forms.GroupBox gbox1)
        {
            gbox1.BackColor = Color.Black;
            return "Sola";
        }

        public string treat_title(System.Windows.Forms.Label label1)
        {
            label1.BackColor = Color.Black;
            return "Sola";
        }

        public string treat_strip(StatusStrip strip1)
        {
            strip1.BackColor = Color.Black;
            return "Sola";
        }

        public string panel_format(Panel panel1)
        {
            // panel3 = new Panel();
            foreach (Control control in panel1.Controls)
            {
                if (control is System.Windows.Forms.TextBox)
                {
                    (control as System.Windows.Forms.TextBox).Clear();
                    control.ForeColor = Color.Crimson;
                    // control.Font.Size=new 
                    control.Text = null;
                }

                if (control is ComboBox)
                {
                    (control as ComboBox).SelectedIndex = -1;
                    control.ForeColor = Color.Crimson;
                }
            }
            return "Sola";
        }

        public string panel_format_money(Panel panel1)
        {
            // panel3 = new Panel();
            foreach (Control control in panel1.Controls)
            {
               // control.ForeColor = Color.DeepPink;
                if (control is System.Windows.Forms.TextBox && string.IsNullOrWhiteSpace(control.Text))
                {
                    control.ForeColor = Color.DeepPink;
                    control.Text = "0.00";
                }

                if (control is System.Windows.Forms.TextBox)
                {
                    control.ForeColor = Color.DeepPink;
                }
            }
            return "Sola";
        }
        public string message()
        {
            MessageBox.Show(" This Application Module has Limited Access. Access Deny ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "Sola";
        }

        public string format_form(Panel pan,System.Windows.Forms.GroupBox gbox,PictureBox pbox,StatusStrip strip,ToolStripStatusLabel stlab)
        {
            try
            {
                pan.BackColor = Color.Firebrick;
                gbox.BackColor = Color.Black;
                gbox.ForeColor = Color.White;
                strip.BackColor = Color.Black;
                strip.ForeColor = Color.White;
                pbox.Image = Image.FromFile("C:/POST/images/Img2.JPG");
                stlab.Text = "Point of Sales Application ... v1.0.0.0";
                foreach (Control control in pan.Controls)
                {
                    if (control is System.Windows.Forms.TextBox)
                    {
                        control.ForeColor = Color.Crimson;
                    }

                    if (control is ComboBox)
                    {
                        control.ForeColor = Color.Crimson;
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
           // pan.Font = new Font("Arial", 12.0F, FontStyle.Italic);
            return "Sola";
        }

        public string display_in_box_server_t(System.Windows.Forms.TextBox day,System.Windows.Forms.TextBox month,System.Windows.Forms.TextBox year,System.Windows.Forms.TextBox date,System.Windows.Forms.TextBox time)
        {

            try
            {
                MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT* FROM TABLE_S_T order by p_id desc limit 1", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    day.Text = (string)dr.GetValue(1).ToString();
                    month.Text = (string)dr.GetValue(2).ToString();
                    year.Text = (string)dr.GetValue(3).ToString();
                    date.Text = (string)dr.GetValue(4).ToString();
                    time.Text = (string)dr.GetValue(5).ToString();
                }
                else
                {
                    MessageBox.Show(" Invalid Verification ... Re-start the Server to Continue ... ", " Error Alert ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "SOLA";
        }

        public string message_reject()
        {
            MessageBox.Show(" Module Strictly for Admin Staff. Access Deny ... ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "Sola";
        }

    }
}
