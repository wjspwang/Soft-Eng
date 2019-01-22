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
    public partial class Form4 : Form
    {
        
        public Form previousform;
        public Form4()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");

        }
        MySqlConnection conn;

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        public int hours;
        public int custID { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            string now = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string stime = DateTime.Now.ToString("hh:mm tt");
            string etime = DateTime.Now.AddHours(hours).ToString("hh:mm tt");
            if (textBox1.Text != null || textBox1.Text != "")
            {
                
                hours = Convert.ToInt32(textBox1.Text);
                
                string qry = "insert into playhouse(customer_id, sched_date, start_time, end_time) values(" +
                ""+custID+", '"+now+"', '"+stime+"', '"+etime+"')";
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
