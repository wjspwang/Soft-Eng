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
    public partial class PlayhouseExtend : Form
    {
        public Form previousform;
        string endtime;
        public PlayhouseExtend()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");
            
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
            string stime = DateTime.Now.ToString("h:mm tt");
            hours = Convert.ToInt32(textBox1.Text);



            string find ="select * from playhouse where customer_id = '"+selected_user_id+ "' AND status = 'IN' OR status = 'Overtime' AND sched_date = '" + now + "' ";
            string find2 = "select * from playhouse where customer_id = '" + selected_user_id + "' AND sched_date = '"+now+"'";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(find, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

            MySqlCommand cmd2 = new MySqlCommand(find2, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd2);

            conn.Close();
            DataTable tb = new DataTable();
            adp.Fill(tb);
            DataTable tb2 = new DataTable();
            adp2.Fill(tb2);

            if (tb.Rows.Count < 1)
            {
                MessageBox.Show("Customer not in Playhouse", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (tb2.Rows.Count < 1)
            {
                MessageBox.Show("Playhouse Date not for Today", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show(tb.Rows.Count + "");
            foreach (DataRow dr in tb.Rows)
            {
                endtime = dr["end_time"].ToString();
                string etime = Convert.ToDateTime(endtime).AddHours(hours).ToString("hh:mm tt");
                string qry2 = "update playhouse SET end_time = '" + etime + "' WHERE customer_id = " + selected_user_id + " AND status = 'IN'";
                conn.Open();
                MySqlCommand comm5 = new MySqlCommand(qry2, conn);
                comm5.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Schedule Successfully Updated");
                
            }
            previousform.Show();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
