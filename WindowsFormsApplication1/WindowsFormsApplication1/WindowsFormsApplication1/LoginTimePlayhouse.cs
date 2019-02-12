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
        public LoginTimePlayhouse()
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
            string etime = DateTime.Now.AddHours(hours).ToString("h:mm tt");

            string validate = "select * from playhouse where customer_id = " + selected_user_id + " AND '"+stime+"' BETWEEN start_time AND end_time AND sched_date = '"+now+"'";
            MySqlCommand cmd = new MySqlCommand(validate, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            adp.Fill(tb);
            
            if(tb.Rows.Count > 0)
            {
                MessageBox.Show("Customer already in Playhouse!");
                return;
            }


            if (textBox1.Text != null || textBox1.Text != "")
            {
                
                
                string qry = "insert into playhouse(customer_id, sched_date, start_time, end_time,status) values(" +
                ""+selected_user_id+", '"+now+"', '"+stime+"', '"+etime+"', 'IN')";
                conn.Open();

                MySqlCommand comm4 = new MySqlCommand(qry, conn);
                comm4.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Schedule Successfully Added");
                previousform.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
