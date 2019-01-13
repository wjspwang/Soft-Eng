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
    
    public partial class dogMedSched : Form
    {
        MySqlConnection conn;
        public Form previousform;
        public dogMedSched()
        {
            
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");
        }

        private void dogMedSched_Load(object sender, EventArgs e)
        {
            loadall();
        }
        public void loadall()
        {
            string query = "select dc_dogsched.dog_id, dog_name," +
                " dog_breed, dogsched_start, dogsched_end, dogsched_date," +
                " dogstart_time, dogend_time, dog_status from dog " +
              //  "inner join person on staff.person_id = person.person_id  " +
                "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
                "order by dogsched_date, dogstart_time";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["dog_id"].Visible = false;
            dataGridView1.Columns["dogsched_start"].Visible = false;
            dataGridView1.Columns["dogsched_end"].Visible = false;
            dataGridView1.Columns["dog_breed"].HeaderText = "Dog Breed";
            dataGridView1.Columns["dog_name"].HeaderText = "Dog Name";
            dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
            dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
            dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
            dataGridView1.Columns["dog_status"].HeaderText = "Status";

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            loadall();
        }

        private void ShowAllBtn_Click(object sender, EventArgs e)
        {
            loadall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchByBox.Text = "Dog Name";
            if (SearchByLabel.Visible == true && SearchByBox.Visible == true && InputLbl.Visible == true)
            {
                SearchByLabel.Visible = false;
                SearchByBox.Visible = false;
                InputLbl.Visible = false;
                inputField.Visible = false;
                to_date.Visible = false;
                from_date.Visible = false;
                startDateLbl.Visible = false;
                endDateLbl.Visible = false;
            }
            else
            {
                SearchByLabel.Visible = true;
                SearchByBox.Visible = true;
                InputLbl.Visible = true;
                inputField.Visible = true;

            }



            if (to_date.Visible == true &&
            from_date.Visible == true &&
            startDateLbl.Visible == true &&
            endDateLbl.Visible == true)
            {
                to_date.Visible = false;
                from_date.Visible = false;
                startDateLbl.Visible = false;
                endDateLbl.Visible = false;
            }
        }

        private void inputField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SearchByBox.Text == "Dog Name")
            {
                string query = "select dc_dogsched.dog_id, dog_name ,dog_breed, dogsched_start, dogsched_end, dogsched_date, dogstart_time, dogend_time, dog_status from dog inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where dog_name like '%" + inputField.Text + "%' order by dogsched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["dog_id"].Visible = false;
                dataGridView1.Columns["dogsched_start"].Visible = false;
                dataGridView1.Columns["dogsched_end"].Visible = false;
                dataGridView1.Columns["dog_breed"].HeaderText = "Last Name";
                dataGridView1.Columns["dog_name"].HeaderText = "First Name";
                dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
                dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
                dataGridView1.Columns["dog_status"].HeaderText = "Shift";
            }
            else if (SearchByBox.Text == "Breed")
            {
                string query = "select dc_dogsched.dog_id, dog_breed, dog_name ,dogsched_start, dogsched_end," +
                    " sched_date, start_time, end_time, status from dog " +
                    "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where dog_breed like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;
                dataGridView1.Columns["dogsched_start"].Visible = false;
                dataGridView1.Columns["dogsched_end"].Visible = false;
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void from_date_ValueChanged(object sender, EventArgs e)
        {
            string query = "select dc_dogsched.dog_id, dog_breed, dog_name ,dogsched_start, dogsched_end," +
                    " sched_date, start_time, end_time, status from dog " +
                    "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where sched_date >= '" +
               from_date.Text + "' AND sched_date <= '" + to_date.Text + "' order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void to_date_ValueChanged(object sender, EventArgs e)
        {
            string query = "select dc_dogsched.dog_id, dog_breed, dog_name ,dogsched_start, dogsched_end," +
                    " sched_date, start_time, end_time, status from dog " +
                    "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where sched_date >= '" +
               from_date.Text + "' AND sched_date <= '" + to_date.Text + "' order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}
