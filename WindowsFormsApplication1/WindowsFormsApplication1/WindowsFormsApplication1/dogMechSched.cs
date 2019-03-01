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
            string query = "select dogsched_id, dc_dogsched.dog_id, dog_name," +
                " dog_breed, dogsched_start, dogsched_end, dogsched_date," +
                " dogstart_time, dogend_time, dog_vaccination, dog_status from dog " +
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
            dataGridView1.Columns["dogsched_id"].Visible = false;
            dataGridView1.Columns["dog_id"].Visible = false;
            dataGridView1.Columns["dogsched_start"].Visible = false;
            dataGridView1.Columns["dogsched_end"].Visible = false;
            dataGridView1.Columns["dog_breed"].HeaderText = "Dog Breed";
            dataGridView1.Columns["dog_name"].HeaderText = "Dog Name";
            dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
            dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
            dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
            dataGridView1.Columns["dog_vaccination"].HeaderText = "Medication";
            dataGridView1.Columns["dog_status"].HeaderText = "Status";

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
                string query = "select dogsched_id, dc_dogsched.dog_id, dog_name ,dog_breed, dogsched_start, dogsched_end, dogsched_date, dogstart_time, dogend_time, dog_vaccination, dog_status from dog inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where dog_name like '%" + inputField.Text + "%' order by dogsched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["dogsched_id"].Visible = false;
                dataGridView1.Columns["dog_id"].Visible = false;
                dataGridView1.Columns["dogsched_start"].Visible = false;
                dataGridView1.Columns["dogsched_end"].Visible = false;
                dataGridView1.Columns["dog_breed"].HeaderText = "Last Name";
                dataGridView1.Columns["dog_name"].HeaderText = "First Name";
                dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
                dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
                dataGridView1.Columns["dog_vaccination"].HeaderText = "Medication";
                dataGridView1.Columns["dog_status"].HeaderText = "Status";
            }
            else if (SearchByBox.Text == "Breed")
            {
                string query = "select dogsched_id, dc_dogsched.dog_id, dog_breed, dog_name ,dogsched_start, dogsched_end," +
                    " dogsched_date, dogstart_time, dogend_time, dog_status from dog " +
                    "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where dog_breed like '%" + inputField.Text + "%' order by dogsched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["dogsched_id"].Visible = false;
                dataGridView1.Columns["dog_id"].Visible = false;
                dataGridView1.Columns["dogsched_start"].Visible = false;
                dataGridView1.Columns["dogsched_end"].Visible = false;
                dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
                dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
                dataGridView1.Columns["dog_vaccination"].HeaderText = "Medication";
                dataGridView1.Columns["dog_status"].HeaderText = "Status";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void from_date_ValueChanged(object sender, EventArgs e)
        {
            string query = "select dogsched_id, dc_dogsched.dog_id, dog_breed, dog_name ,dogsched_start, dogsched_end," +
                    " dogsched_date, dogstart_time, dogend_time, dog_status from dog " +
                    "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where dogsched_date >= '" +
               from_date.Text + "' AND dogsched_date <= '" + to_date.Text + "' order by dogsched_date, dogstart_time";
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
            string query = "select dogsched_id, dc_dogsched.dog_id, dog_breed, dog_name ,dogsched_start, dogsched_end," +
                    " dogsched_date, dogstart_time, dogend_time, dog_status from dog " +
                    "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where dogsched_date >= '" +
               from_date.Text + "' AND dogsched_date <= '" + to_date.Text + "' order by dogsched_date, dogstart_time";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowToday();
        }
        public void ShowToday()
        {
            string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string query = "select dogsched_id, dc_dogsched.dog_id, dog_name," +
                " dog_breed, dogsched_start, dogsched_end, dogsched_date," +
                " dogstart_time, dogend_time, dog_vaccination, dog_status from dog " +
                //  "inner join person on staff.person_id = person.person_id  " +
                "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where dogsched_date = '"+ cur_date + "' " +
                "order by dogsched_date, dogstart_time";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["dogsched_id"].Visible = false;
            dataGridView1.Columns["dog_id"].Visible = false;
            dataGridView1.Columns["dogsched_start"].Visible = false;
            dataGridView1.Columns["dogsched_end"].Visible = false;
            dataGridView1.Columns["dog_breed"].HeaderText = "Dog Breed";
            dataGridView1.Columns["dog_name"].HeaderText = "Dog Name";
            dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
            dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
            dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
            dataGridView1.Columns["dog_vaccination"].HeaderText = "Medication";
            dataGridView1.Columns["dog_status"].HeaderText = "Status";
        }
        public void ShowIncoming()
        {
            string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string query = "select dogsched_id, dc_dogsched.dog_id, dog_name," +
                " dog_breed, dogsched_start, dogsched_end, dogsched_date," +
                " dogstart_time, dogend_time, dog_vaccination, dog_status from dog " +
                //  "inner join person on staff.person_id = person.person_id  " +
                "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where dogsched_date >= '" + cur_date + "' " +
                "order by dogsched_date, dogstart_time";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["dogsched_id"].Visible = false;
            dataGridView1.Columns["dog_id"].Visible = false;
            dataGridView1.Columns["dogsched_start"].Visible = false;
            dataGridView1.Columns["dogsched_end"].Visible = false;
            dataGridView1.Columns["dog_breed"].HeaderText = "Dog Breed";
            dataGridView1.Columns["dog_name"].HeaderText = "Dog Name";
            dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
            dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
            dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
            dataGridView1.Columns["dog_vaccination"].HeaderText = "Medication";
            dataGridView1.Columns["dog_status"].HeaderText = "Status";
        }
        public void ShowPast()
        {
            string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string query = "select dogsched_id, dc_dogsched.dog_id, dog_name," +
                " dog_breed, dogsched_start, dogsched_end, dogsched_date," +
                " dogstart_time, dogend_time, dog_vaccination, dog_status from dog " +
                //  "inner join person on staff.person_id = person.person_id  " +
                "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where dogsched_date < '" + cur_date + "' " +
                "order by dogsched_date, dogstart_time";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["dogsched_id"].Visible = false;
            dataGridView1.Columns["dog_id"].Visible = false;
            dataGridView1.Columns["dogsched_start"].Visible = false;
            dataGridView1.Columns["dogsched_end"].Visible = false;
            dataGridView1.Columns["dog_breed"].HeaderText = "Dog Breed";
            dataGridView1.Columns["dog_name"].HeaderText = "Dog Name";
            dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
            dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
            dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
            dataGridView1.Columns["dog_vaccination"].HeaderText = "Medication";
            dataGridView1.Columns["dog_status"].HeaderText = "Status";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowPast();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowIncoming();
        }
        int selected_dogsched_id;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                selected_dogsched_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["dogsched_id"].Value.ToString());
                dog_name.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_name"].Value.ToString();
                dog_status.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_status"].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows.Count < 2) 
            {
                groupBox1.Visible = true;


                
            }
            else
            {
                MessageBox.Show("Select a report");
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            comboBox1.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Fill out combo box!");
            }
            else
            {
                if (comboBox1.Text == "")
                {
                    return;
                }
                string query = "UPDATE dc_dogsched set dog_status = '" + comboBox1.Text + "' WHERE dogsched_id = " + selected_dogsched_id + " ";
                //MessageBox.Show(query);
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Status Updated");
                loadall();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            dt = dataGridView1.DataSource as DataTable;
            // MessageBox.Show(dataGridView1.DataSource + "");
            ds.Tables.Add(dt);
            Form4 f = new Form4(ds, "dog_med");
            f.Show();
        }
    }
}
