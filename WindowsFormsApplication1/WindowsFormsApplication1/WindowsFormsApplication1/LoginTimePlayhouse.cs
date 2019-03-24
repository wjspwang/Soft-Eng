using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class LoginTimePlayhouse : Form
    {
        public Form previousform;
        public int invoice_num;

        public LoginTimePlayhouse()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");

        }

        public LoginTimePlayhouse(int invoice_num)
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");
            this.invoice_num = invoice_num;
        }
        MySqlConnection conn;
        public string lname { get; set; }
        public string fname { get; set; }
        public int selected_user_id { get; set; }
        public int custID { get; set; }
        int hours;

        private void Form4_Load(object sender, EventArgs e)
        {
            label3.Text = selected_user_id + "";
            full_name.Text = fname + " " + lname;
        }
       
        
        private void button1_Click(object sender, EventArgs e)
        {
            string now = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string stime = DateTime.Now.ToString("hh:mm tt");
            hours = Convert.ToInt32(textBox1.Text);
            string etime = DateTime.Now.AddHours(hours).ToString("hh:mm tt");

            TimeSpan start_time1 = Convert.ToDateTime(stime).TimeOfDay;
            TimeSpan end_time1 = Convert.ToDateTime(etime).TimeOfDay;

            string sched_start = now + " " + start_time1;
            string sched_end = now + " " + end_time1;

            string validate = "select * from playhouse" +
                " WHERE ((sched_start <= '"+sched_start+"' AND sched_end >= '"+sched_start+"')" +
                "OR(sched_start <= '" + sched_end + "'  AND sched_end >= '" + sched_end + "'))" +
                "AND customer_id = " + selected_user_id + " AND status = 'IN'";

            MySqlCommand cmd = new MySqlCommand(validate, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            adp.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                MessageBox.Show("Customer already in Playhouse!");
                return;
            }


            if (textBox1.Text != null || textBox1.Text != "")
            {

                //calculate here
                string s = "select * from ph_cred inner join sales_tbl on invoice_num = invoice_id where invoice_num = " + invoice_num;
                conn.Open();
                MySqlCommand a = new MySqlCommand(s, conn);
                MySqlDataAdapter a1 = new MySqlDataAdapter(a);
                conn.Close();
                DataTable a2 = new DataTable();
                a1.Fill(a2);
                if (a2.Rows.Count != 1)
                {
                    MessageBox.Show("Invoice Number does not exist/Invalid Invoice Number",
                    "Invalid Invoice Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {

                    foreach (DataRow dr in a2.Rows)
                    {
                        Decimal total_balance;
                        total_balance = Convert.ToDecimal(dr["cred_count"].ToString());

                        int hours = Convert.ToInt32(textBox1.Text);
                        Decimal checker = total_balance - (200 * hours);
                        MessageBox.Show(checker + "");
                        if (checker < 0)
                        {
                            MessageBox.Show("Insufficient Playhouse Fee or Load");
                            return;
                           
                        }

                        total_balance = total_balance - (200 * hours );

                        string abc = "update ph_cred set cred_count = " + total_balance + " where invoice_num = " + invoice_num;
                        conn.Open();
                        MySqlCommand sq = new MySqlCommand(abc, conn);
                        sq.ExecuteNonQuery();
                        conn.Close();

                        string qry = "insert into playhouse(customer_id,sched_start,sched_end, sched_date, start_time, end_time,status) values(" +
                        "" + selected_user_id + ",'" + sched_start + "','" + sched_end + "', '" + now + "', '" + stime + "', '" + etime + "', 'IN')";
                        conn.Open();

                        MySqlCommand comm4 = new MySqlCommand(qry, conn);
                        comm4.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Schedule Successfully Added");
                        previousform.Show();
                        this.Hide();

                    }

                }
                //end calculation here

                

            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
