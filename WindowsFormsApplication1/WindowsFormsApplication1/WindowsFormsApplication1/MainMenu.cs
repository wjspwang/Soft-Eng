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

            string currdate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string DogOvertime = "Select * from dc_dogsched where dog_status = 'Overtime' AND dogsched_date = '" + currdate + "'";
            conn.Open();
            MySqlCommand a = new MySqlCommand(DogOvertime, conn);
            MySqlDataAdapter a1 = new MySqlDataAdapter(a);
            conn.Close();
            DataTable dt2 = new DataTable();
            a1.Fill(dt2);

            label20.Text = dt2.Rows.Count.ToString();

            string DogPending = "Select * from dc_dogsched where dog_status = 'Pending'";
            conn.Open();
            MySqlCommand b = new MySqlCommand(DogPending, conn);
            MySqlDataAdapter b1 = new MySqlDataAdapter(b);
            conn.Close();
            DataTable dt3 = new DataTable();
            b1.Fill(dt3);
            //MessageBox.Show(dt3.Rows.Count.ToString());
            label23.Text = dt3.Rows.Count.ToString();
            
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
            dogMedSched dog1 = new dogMedSched();
            dog1.DogTableUpdate();
            CalendarVer2 staff1 = new CalendarVer2();
            staff1.StaffTableUpdate();


            string currdate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string DogOvertime = "Select * from dc_dogsched where dog_status = 'Overtime' AND dogsched_date = '" + currdate + "'";
            conn.Open();
            MySqlCommand a = new MySqlCommand(DogOvertime, conn);
            MySqlDataAdapter a1 = new MySqlDataAdapter(a);
            conn.Close();
            DataTable dt = new DataTable();
            a1.Fill(dt);
            label20.Text = dt.Rows.Count.ToString();
            //
            string DogPending = "Select * from dc_dogsched where dog_status = 'Pending'";
            conn.Open();
            MySqlCommand b = new MySqlCommand(DogPending, conn);
            MySqlDataAdapter b1 = new MySqlDataAdapter(b);
            conn.Close();
            DataTable dt3 = new DataTable();
            b1.Fill(dt3);

            label23.Text = dt3.Rows.Count.ToString();

            string query1 = "SELECT COUNT(*) from product  where prodquant <= restock_val ";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataReader rdr = comm1.ExecuteReader();
            conn.Close();


            conn.Open();
            label10.Text = comm1.ExecuteScalar().ToString();
            conn.Close();

            //--------------------------------------------------------------------------------------
            string StaffPending = "Select * from dc_sched where status2 = 'Pending' AND status = 'Playhouse'";
            conn.Open();
            MySqlCommand sp = new MySqlCommand(StaffPending, conn);
            MySqlDataAdapter sp1 = new MySqlDataAdapter(sp);
            conn.Close();
            DataTable SP_tb = new DataTable();
            sp1.Fill(SP_tb);

            label21.Text = SP_tb.Rows.Count.ToString();

            string StaffOvertime = "Select * from dc_sched where status2 = 'Overtime' AND status = 'Playhouse'";
            conn.Open();
            MySqlCommand so = new MySqlCommand(StaffOvertime, conn);
            MySqlDataAdapter so1 = new MySqlDataAdapter(so);
            conn.Close();
            DataTable SO_tb = new DataTable();
            so1.Fill(SO_tb);

            label26.Text = SO_tb.Rows.Count.ToString();

            //--------------------------------------------------------------------------------------------
            string CustOvertime = "Select lname, fname from person a " +
                "inner join playhouse b on a.person_id = b.customer_id " +
                "where status = 'Overtime' AND sched_date = '" + currdate + "' ";
            conn.Open();
            MySqlCommand co = new MySqlCommand(CustOvertime, conn);
            MySqlDataAdapter co1 = new MySqlDataAdapter(co);
            conn.Close();
            DataTable CO_tb = new DataTable();
            co1.Fill(CO_tb);

            label30.Text = CO_tb.Rows.Count.ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (label17.Text != Convert.ToString(0))
            {
                dogMedSched f = new dogMedSched("reminder");
                f.Show();
                f.previousform = this;
            }
            else
            {
                MessageBox.Show("No Dogs on Overtime", "That's good",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string currdate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string query = "Select dog_name, dog_breed from dog a " +
                "inner join dc_dogsched b on a.dog_id = b.dog_id " +
                "where dog_status = 'Overtime' AND dogsched_date = '" + currdate + "' ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm);
            MySqlDataReader reader = comm.ExecuteReader();
            StringBuilder dogNames = new StringBuilder();

            while (reader.Read())
            {
                dogNames.Append(reader["dog_name"].ToString() + " " + reader["dog_breed"].ToString() + Environment.NewLine);
            }
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                MessageBox.Show("Following Dog(s) on Overtime: \n\n" + dogNames,
                                "Warning Dog Overtime", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("No Dogs on Overtime", "Dog notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string currdate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string query = "Select dog_name, dog_breed from dog a " +
                "inner join dc_dogsched b on a.dog_id = b.dog_id " +
                "where dog_status = 'Pending' AND dogsched_date = '" + currdate + "' ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm);
            MySqlDataReader reader = comm.ExecuteReader();
            StringBuilder dogNames = new StringBuilder();

            while (reader.Read())
            {
                dogNames.Append(reader["dog_name"].ToString() + " " + reader["dog_breed"].ToString() + Environment.NewLine);
            }
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                MessageBox.Show("Following Dog(s) is/are Pending: \n\n" + dogNames,
                                "Dog Pending", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("No Dogs that are Pending", "Dog notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void MainMenu_Shown(object sender, EventArgs e)
        {
            dogMedSched a = new dogMedSched();
            a.DogTableUpdate();
            a.DogOvertime();
            a.DogPending();
            CalendarVer2 b = new CalendarVer2();
            b.StaffTableUpdate();
            b.StaffOvertime();
            b.StaffPending();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string currdate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string query = "Select lname, fname from person a " +
                "inner join staff b on a.person_id = b.person_id " +
                "inner join dc_sched c on b.staff_id = c.staff_id "+
                "where status2 = 'Pending' AND sched_date = '" + currdate + "' ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm);
            MySqlDataReader reader = comm.ExecuteReader();
            StringBuilder dogNames = new StringBuilder();

            while (reader.Read())
            {
                dogNames.Append(reader["fname"].ToString() + " " + reader["lname"].ToString() + Environment.NewLine);
            }
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                MessageBox.Show("Following Staff(s) Pending: \n\n" + dogNames,
                                "Warning Staff Pending", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("No Staffs Pending", "Staff notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string currdate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string query = "Select lname, fname from person a " +
                "inner join staff b on a.person_id = b.person_id " +
                "inner join dc_sched c on b.staff_id = c.staff_id " +
                "where status = 'Playhouse' AND status2 = 'Overtime' AND sched_date = '" + currdate + "' ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm);
            MySqlDataReader reader = comm.ExecuteReader();
            StringBuilder dogNames = new StringBuilder();

            while (reader.Read())
            {
                dogNames.Append(reader["fname"].ToString() + " " + reader["lname"].ToString() + Environment.NewLine);
            }
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                MessageBox.Show("Following Staff(s) on Overtime: \n\n" + dogNames,
                                "Warning Staff Overtime", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("No Staffs on Overtime", "Staff notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string currdate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string query = "Select lname, fname from person a " +
                "inner join playhouse b on a.person_id = b.customer_id " +
                "where status = 'Overtime' AND sched_date = '" + currdate + "' ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm);
            MySqlDataReader reader = comm.ExecuteReader();
            StringBuilder dogNames = new StringBuilder();

            while (reader.Read())
            {
                dogNames.Append(reader["fname"].ToString() + " " + reader["lname"].ToString() + Environment.NewLine);
            }
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                MessageBox.Show("Following Customer(s) on Overtime: \n\n" + dogNames,
                                "Warning Customer Overtime", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("No Staffs on Overtime", "Staff notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
