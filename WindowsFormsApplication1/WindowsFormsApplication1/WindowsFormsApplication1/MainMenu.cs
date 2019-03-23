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
    public partial class MainMenu : Form
    {
        MySqlConnection conn;
        public Form previousform;
        string dateFormat = "yyyy-MM-dd";
  
        public bool Noti;
        int utype;

        public MainMenu()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root;");
            
        }

        public MainMenu(int utype)
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root;");
            this.utype = utype;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profiles a = new Profiles();
            a.Show();
            a.previousform = this;


        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(utype + "");
            label9.Text = DateTime.Now.ToString();

            string today = DateTime.Now.Date.ToString(dateFormat);
            string tomorrow = DateTime.Now.Date.AddDays(2).ToString(dateFormat);
            string nearbyAppointment = "select dogsched_id, dc_dogsched.dog_id, dog_name, " +
            "dog_breed,dog_clinic.clinic_name, dogsched_start, dogsched_end, dogsched_date, " +
            "dogstart_time, dogend_time, dog_vaccination, dog_status from dog " +
            "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
            "inner join dog_clinic on dc_dogsched.clinic_id = dog_clinic.clinic_id " +
            "where dogsched_date >= '" + today + "' " +
            "AND dogsched_date <= '" + tomorrow + "' AND dog_status = 'To Be Taken' Order by dogsched_date, dogstart_time  ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(nearbyAppointment, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            label17.Text = dt.Rows.Count.ToString();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            PassChange a = new PassChange();
            a.Show();
            a.previousform = this;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductList a = new ProductList();
            a.Show();
            a.previousform = this;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("utype = " + utype);
            if (this.utype == 0)
            {
                MessageBox.Show("You are not authorized to use this module", "Access Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Hide();
            UserList a = new UserList();
            a.Show();
            a.previousform = this;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            PoS a = new PoS();
            a.Show();
            a.previousform = this;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            PoS a = new PoS();
            a.Show();
            a.previousform = this;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            StaffScheduler a = new StaffScheduler();
            a.Show();
            a.previousform = this;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            PlayhouseManagement a = new PlayhouseManagement();
            a.Show();
            a.previousform = this;
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            ProductList p = new ProductList();
            p.autoExpireLog();
            string query1 = "SELECT COUNT(*) from product  where prodquant <= restock_val ";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataReader rdr = comm1.ExecuteReader();
            conn.Close();


            conn.Open();
            label10.Text = comm1.ExecuteScalar().ToString();
            conn.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string query = "Select prodname from product where prodquant <= restock_val ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm);
            MySqlDataReader reader = comm.ExecuteReader();
            StringBuilder productNames = new StringBuilder();

            while (reader.Read())
            {
                productNames.Append(reader["prodname"].ToString() + Environment.NewLine);
            }
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            if(dt2.Rows.Count > 0)
            {
                MessageBox.Show("Following Product(s) need to restock: \n\n" + productNames,
                                "Warning Low Stocks", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("No Stocks below Re-stock Value", "No Low Stocks",MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            salesReport a = new salesReport();
            a.Show();
            a.previousform = this;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("utype = " + utype);
            if (this.utype == 0)
            {
                MessageBox.Show("You are not authorized to use this module", "Access Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Hide();
            StaffScheduler a = new StaffScheduler();
            a.Show();
            a.previousform = this;
            /*
            this.Hide();
            Form12 a = new Form12();
            a.Show();
            a.previousform = this;*/
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("utype = " + utype);
            if (this.utype == 0)
            {
                MessageBox.Show("You are not authorized to use this module", "Access Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
            form2.previousform = this;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Hide();
            PlayhouseManagement a = new PlayhouseManagement();
            a.Show();
            a.previousform = this;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profiles a = new Profiles();
            a.Show();
            a.previousform = this;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductList a = new ProductList();
            a.Show();
            a.previousform = this;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            PoS a = new PoS();
            a.Show();
            a.previousform = this;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesReport a = new salesReport();
            a.Show();
            a.previousform = this;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("utype = " + utype);
            if (this.utype == 0)
            {
                MessageBox.Show("You are not authorized to use this module", "Access Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Hide();
            StaffScheduler a = new StaffScheduler();
            a.Show();
            a.previousform = this;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("utype = " + utype);
            if (this.utype == 0)
            {
                MessageBox.Show("You are not authorized to use this module", "Access Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
            form2.previousform = this;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("utype = " + utype);
            if (this.utype == 0)
            {
                MessageBox.Show("You are not authorized to use this module", "Access Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Hide();
            UserList a = new UserList();
            a.Show();
            a.previousform = this;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            PassChange a = new PassChange();
            a.Show();
            a.previousform = this;
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 login = new Form1();
            previousform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(label17.Text != Convert.ToString(0))
            {
                dogMedSched f = new dogMedSched("reminder");
                f.Show();
                f.previousform = this;
            }
            else
            {
                MessageBox.Show("No Dog Medical Appointment within the next 2 days", "No Appointment Found",
                    MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
            
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
