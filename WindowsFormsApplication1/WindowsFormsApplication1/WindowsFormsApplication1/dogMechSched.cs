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
        string dateFormat = "yyyy-MM-dd";
        string reminder;
        public dogMedSched()
        {
            
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");
        }
        public dogMedSched(string reminder)
        {

            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");

            this.reminder = reminder;
        }

        private void dogMedSched_Load(object sender, EventArgs e)
        {
            if(reminder == "reminder")
            {
                label1.Text = "Clinic Schedule";
                loadNotif();
            }
            else if(reminder == "playhouse")
            {
                label1.Text = "Dog Schedule";
                loadall();
            }
            else
            {
                label1.Text = "Clinic Schedule";
                loadall();
            }
            
        }
        

        public void loadNotif()
        {
            string today = DateTime.Now.Date.ToString(dateFormat);

            string editDogsList = "select dog_id,dog_name,dog_breed from dog "; 

            string tomorrow = DateTime.Now.Date.AddDays(2).ToString(dateFormat);
            string nearbyAppointment = "select dogsched_id, dc_dogsched.dog_id, dog_name, " +
            "dog_breed,dog_clinic.clinic_name, dc_dogsched.clinic_id, dogsched_start, dogsched_end, dogsched_date, " +
            "dogstart_time, dogend_time, dog_vaccination, dog_status, " +
            "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +
            "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
            "inner join dog_clinic on dc_dogsched.clinic_id = dog_clinic.clinic_id " +
            "where dogsched_date >= '" + today + "' " +
            "AND dogsched_date <= '" + tomorrow + "' AND dog_status = 'To Be Taken' Order by dogsched_date, dogstart_time  ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(nearbyAppointment, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            MySqlCommand comm2 = new MySqlCommand(editDogsList, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);


            dataGridView1.DataSource = dt;
            dataGridView1.Columns["dogsched_id"].Visible = false;
            dataGridView1.Columns["dog_id"].Visible = false;
            dataGridView1.Columns["dogsched_start"].Visible = false;
            dataGridView1.Columns["dogsched_end"].Visible = false;
            dataGridView1.Columns["dog_breed"].HeaderText = "Dog Breed";
            dataGridView1.Columns["dog_name"].HeaderText = "Dog Name";
            dataGridView1.Columns["clinic_name"].HeaderText = "Clinic";
            dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
            dataGridView1.Columns["dogsched_date"].DefaultCellStyle.Format = dateFormat;
            dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
            dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
            dataGridView1.Columns["dog_vaccination"].HeaderText = "Medication";
            dataGridView1.Columns["dog_status"].HeaderText = "Status";
            dataGridView1.Columns["dog_shour"].Visible = false;
            dataGridView1.Columns["dog_smin"].Visible = false;
            dataGridView1.Columns["dog_sday"].Visible = false;
            dataGridView1.Columns["dog_ehour"].Visible = false;
            dataGridView1.Columns["dog_emin"].Visible = false;
            dataGridView1.Columns["dog_eday"].Visible = false;
            dataGridView1.Columns["clinic_id"].Visible = false;


            dataGridView3.DataSource = dt2;
            dataGridView3.Columns["dog_id"].Visible = false;
            dataGridView3.Columns["dog_breed"].HeaderText = "Dog Breed";
            dataGridView3.Columns["dog_name"].HeaderText = "Dog Name";

            string qry3 = "select * from dog_clinic";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(qry3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);
            clinic_grid.DataSource = dt3;
            //CLINIC GRID
            clinic_grid.Columns["clinic_id"].Visible = false;
            clinic_grid.Columns["clinic_name"].HeaderText = "Clinic";
            clinic_grid.Columns["clinic_address"].Visible = false;
            clinic_grid.Columns["clinic_contact"].Visible = false;

            clinic_text.Visible = true;
            button14.Visible = true;
            clinic.Visible = true;
            label3.Visible = true;
            vacc_Text.Visible = true;
            status_text.Items.Clear();
            status_text.Items.Add("Taken");
            status_text.Items.Add("To Be Taken");

        }
        public void loadall()
        {
            if (reminder == "playhouse")
            {
                string curr_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
                string curr_time = DateTime.Now.ToString("hh:mm tt");
                string curr_sched = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string updateToExpire = "UPDATE dc_dogsched SET dog_status = 'Overtime' WHERE (dogsched_end <= '" + curr_sched + "') AND sched_type = 0 AND dog_status != 'OUT' AND dogsched_date = '"+curr_date+"' ";
                string updateToPending = "UPDATE dc_dogsched SET dog_status = 'Pending' WHERE (dogsched_start <= '" + curr_sched + "') AND sched_type = 0 AND dog_status != 'IN' AND dog_status != 'OUT'  AND dogsched_date = '" + curr_date + "' ";

                conn.Open();

                MySqlCommand commz = new MySqlCommand(updateToExpire, conn);
                MySqlCommand comma = new MySqlCommand(updateToPending, conn);
                comma.ExecuteNonQuery();
                commz.ExecuteNonQuery();
                conn.Close();

                string editDogsList = "select dog_id,dog_name,dog_breed from dog ";
                string query = "select dogsched_id, dc_dogsched.dog_id, dog_name, " +
            "dog_breed, dogsched_start, dogsched_end, dogsched_date, " +
            "dogstart_time, dogend_time, dog_status, " +
            "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +
            "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
            "WHERE sched_type = 0 Order by dogsched_date, dogstart_time";
                //MessageBox.Show(query);
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                MySqlCommand comm2 = new MySqlCommand(editDogsList, conn);
                MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DataTable dt2 = new DataTable();
                adp2.Fill(dt2);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["dogsched_id"].Visible = false;
                dataGridView1.Columns["dog_id"].Visible = false;
                dataGridView1.Columns["dogsched_start"].Visible = false;
                dataGridView1.Columns["dogsched_end"].Visible = false;
                dataGridView1.Columns["dog_breed"].HeaderText = "Dog Breed";
                dataGridView1.Columns["dog_name"].HeaderText = "Dog Name";
                dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["dogsched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
                dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
                dataGridView1.Columns["dog_status"].HeaderText = "Status";
                dataGridView1.Columns["dog_shour"].Visible = false;
                dataGridView1.Columns["dog_smin"].Visible = false;
                dataGridView1.Columns["dog_sday"].Visible = false;
                dataGridView1.Columns["dog_ehour"].Visible = false;
                dataGridView1.Columns["dog_emin"].Visible = false;
                dataGridView1.Columns["dog_eday"].Visible = false;

                dataGridView3.DataSource = dt2;
                dataGridView3.Columns["dog_id"].Visible = false;
                dataGridView3.Columns["dog_breed"].HeaderText = "Dog Breed";
                dataGridView3.Columns["dog_name"].HeaderText = "Dog Name";

                dataGridView3.DataSource = dt2;
                dataGridView3.Columns["dog_id"].Visible = false;
                dataGridView3.Columns["dog_breed"].HeaderText = "Dog Breed";
                dataGridView3.Columns["dog_name"].HeaderText = "Dog Name";

                string qry3 = "select * from dog_clinic";
                conn.Open();
                MySqlCommand comm3 = new MySqlCommand(qry3, conn);
                MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
                conn.Close();
                DataTable dt3 = new DataTable();
                adp3.Fill(dt3);
                clinic_grid.DataSource = dt3;
                //CLINIC GRID
                clinic_grid.Columns["clinic_id"].Visible = false;
                clinic_grid.Columns["clinic_name"].HeaderText = "Clinic";
                clinic_grid.Columns["clinic_address"].Visible = false;
                clinic_grid.Columns["clinic_contact"].Visible = false;

                string pendCounter = "select * from dc_dogsched where dog_status = 'Pending' AND dogsched_date = '"+curr_date+"'";
                conn.Open();
                MySqlCommand comm4 = new MySqlCommand(pendCounter, conn);
                MySqlDataAdapter adp4 = new MySqlDataAdapter(comm4);
                conn.Close();
                DataTable dt4 = new DataTable();
                adp4.Fill(dt4);
                if (dt4.Rows.Count > 0)
                {
                    MessageBox.Show("There are " +dt4.Rows.Count +" Pending for Playhouse","",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
  

                clinic_text.Visible = false;
                button14.Visible = false;
                clinic.Visible = false;
                label3.Visible = false;
                vacc_Text.Visible = false;
                status_text.Items.Clear();
                status_text.Items.Add("Scheduled");
                status_text.Items.Add("IN");
                status_text.Items.Add("OUT");

                
            }
            else if(reminder == "reminder")
            {
                loadNotif();
            }
            else
            {
                string editDogsList = "select dog_id,dog_name,dog_breed from dog ";
                string query = "select dogsched_id, dc_dogsched.dog_id, dog_name, " +
            "dog_breed,dog_clinic.clinic_name, dc_dogsched.clinic_id, dogsched_start, dogsched_end, dogsched_date, " +
            "dogstart_time, dogend_time, dog_vaccination, dog_status, " +
            "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday  from dog " +
            "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
            "inner join dog_clinic on dc_dogsched.clinic_id = dog_clinic.clinic_id " +
            "WHERE sched_type = 1 Order by dogsched_date, dogstart_time";
                //MessageBox.Show(query);
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                MySqlCommand comm2 = new MySqlCommand(editDogsList, conn);
                MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DataTable dt2 = new DataTable();
                adp2.Fill(dt2);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["dogsched_id"].Visible = false;
                dataGridView1.Columns["dog_id"].Visible = false;
                dataGridView1.Columns["dogsched_start"].Visible = false;
                dataGridView1.Columns["dogsched_end"].Visible = false;
                dataGridView1.Columns["dog_breed"].HeaderText = "Dog Breed";
                dataGridView1.Columns["dog_name"].HeaderText = "Dog Name";
                dataGridView1.Columns["clinic_name"].HeaderText = "Clinic";
                dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["dogsched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
                dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
                dataGridView1.Columns["dog_vaccination"].HeaderText = "Medication";
                dataGridView1.Columns["dog_status"].HeaderText = "Status";
                dataGridView1.Columns["dog_shour"].Visible = false;
                dataGridView1.Columns["dog_smin"].Visible = false;
                dataGridView1.Columns["dog_sday"].Visible = false;
                dataGridView1.Columns["dog_ehour"].Visible = false;
                dataGridView1.Columns["dog_emin"].Visible = false;
                dataGridView1.Columns["dog_eday"].Visible = false;
                dataGridView1.Columns["clinic_id"].Visible = false;

                dataGridView3.DataSource = dt2;
                dataGridView3.Columns["dog_id"].Visible = false;
                dataGridView3.Columns["dog_breed"].HeaderText = "Dog Breed";
                dataGridView3.Columns["dog_name"].HeaderText = "Dog Name";

                dataGridView3.DataSource = dt2;
                dataGridView3.Columns["dog_id"].Visible = false;
                dataGridView3.Columns["dog_breed"].HeaderText = "Dog Breed";
                dataGridView3.Columns["dog_name"].HeaderText = "Dog Name";

                string qry3 = "select * from dog_clinic";
                conn.Open();
                MySqlCommand comm3 = new MySqlCommand(qry3, conn);
                MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
                conn.Close();
                DataTable dt3 = new DataTable();
                adp3.Fill(dt3);
                clinic_grid.DataSource = dt3;
                //CLINIC GRID
                clinic_grid.Columns["clinic_id"].Visible = false;
                clinic_grid.Columns["clinic_name"].HeaderText = "Clinic";
                clinic_grid.Columns["clinic_address"].Visible = false;
                clinic_grid.Columns["clinic_contact"].Visible = false;

                clinic_text.Visible = true;
                button14.Visible = true;
                clinic.Visible = true;
                label3.Visible = true;
                vacc_Text.Visible = true;
                status_text.Items.Clear();
                status_text.Items.Add("Taken");
                status_text.Items.Add("To Be Taken");
            }
            

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
            if (reminder == "playhouse")
            {
                if (SearchByBox.Text == "Dog Name")
                {
                    string query = "select dogsched_id, dc_dogsched.dog_id, dog_name ,dog_breed, dogsched_start," +
                        " dogsched_end, dogsched_date, dogstart_time, dogend_time, dog_status," +
                        " dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id" +
                        " where dog_name like '%" + inputField.Text + "%' AND sched_type = 0 order by dogsched_date";
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
                    dataGridView1.Columns["dog_breed"].HeaderText = "Breed";
                    dataGridView1.Columns["dog_name"].HeaderText = "Dog Name";
                    dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
                    dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
                    dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
                    dataGridView1.Columns["dog_status"].HeaderText = "Status";
                    dataGridView1.Columns["dog_shour"].Visible = false;
                    dataGridView1.Columns["dog_smin"].Visible = false;
                    dataGridView1.Columns["dog_sday"].Visible = false;
                    dataGridView1.Columns["dog_ehour"].Visible = false;
                    dataGridView1.Columns["dog_emin"].Visible = false;
                    dataGridView1.Columns["dog_eday"].Visible = false;
                }
                else if (SearchByBox.Text == "Breed")
                {
                    string query = "select dogsched_id, dc_dogsched.dog_id, dog_breed, dog_name ,dogsched_start, dogsched_end," +
                        " dogsched_date, dogstart_time, dogend_time, dog_status, " +
                        "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +
                        "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where dog_breed like '%" + inputField.Text + "%' " +
                        "AND sched_type = 0 order by dogsched_date";
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
                    dataGridView1.Columns["dog_breed"].HeaderText = "Breed";
                    dataGridView1.Columns["dog_name"].HeaderText = "Dog Name";
                    dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
                    dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
                    dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
                    dataGridView1.Columns["dog_status"].HeaderText = "Status";
                    dataGridView1.Columns["dog_shour"].Visible = false;
                    dataGridView1.Columns["dog_smin"].Visible = false;
                    dataGridView1.Columns["dog_sday"].Visible = false;
                    dataGridView1.Columns["dog_ehour"].Visible = false;
                    dataGridView1.Columns["dog_emin"].Visible = false;
                    dataGridView1.Columns["dog_eday"].Visible = false;
                }
                else if (SearchByBox.Text == "Status")
                {
                    string query = "select dogsched_id, dc_dogsched.dog_id, dog_breed, dog_name ,dogsched_start, dogsched_end," +
                        " dogsched_date, dogstart_time, dogend_time, dog_status, " +
                        "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +
                        "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where dog_status like '%" + inputField.Text + "%' " +
                        "AND sched_type = 0 order by dogsched_date";
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
                    dataGridView1.Columns["dog_breed"].HeaderText = "Breed";
                    dataGridView1.Columns["dog_name"].HeaderText = "Dog Name";
                    dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
                    dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
                    dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
                    dataGridView1.Columns["dog_status"].HeaderText = "Status";
                    dataGridView1.Columns["dog_shour"].Visible = false;
                    dataGridView1.Columns["dog_smin"].Visible = false;
                    dataGridView1.Columns["dog_sday"].Visible = false;
                    dataGridView1.Columns["dog_ehour"].Visible = false;
                    dataGridView1.Columns["dog_emin"].Visible = false;
                    dataGridView1.Columns["dog_eday"].Visible = false;
                }
            }
            else
            {
                if (SearchByBox.Text == "Dog Name")
                {
                    string query = "select dogsched_id, dc_dogsched.dog_id, dog_name ,dog_breed,dog_clinic.clinic_name, dc_dogsched.clinic_id, dogsched_start," +
                        " dogsched_end, dogsched_date, dogstart_time, dogend_time, dog_vaccination,  dog_status," +
                        " dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
                        "inner join dog_clinic on dc_dogsched.clinic_id = dog_clinic.clinic_id " +
                        "where dog_name like '%" + inputField.Text + "%' AND sched_type = 1 order by dogsched_date";
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
                    dataGridView1.Columns["dog_breed"].HeaderText = "Breed";
                    dataGridView1.Columns["dog_name"].HeaderText = "Dog Name";
                    dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
                    dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
                    dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
                    dataGridView1.Columns["dog_vaccination"].HeaderText = "Medication";
                    dataGridView1.Columns["dog_status"].HeaderText = "Status";
                    dataGridView1.Columns["dog_shour"].Visible = false;
                    dataGridView1.Columns["dog_smin"].Visible = false;
                    dataGridView1.Columns["dog_sday"].Visible = false;
                    dataGridView1.Columns["dog_ehour"].Visible = false;
                    dataGridView1.Columns["dog_emin"].Visible = false;
                    dataGridView1.Columns["dog_eday"].Visible = false;
                    dataGridView1.Columns["clinic_name"].HeaderText = "Clinic";
                    dataGridView1.Columns["clinic_id"].Visible = false;
                }
                else if (SearchByBox.Text == "Breed")
                {
                    string query = "select dogsched_id, dc_dogsched.dog_id, dog_breed, dog_name,dog_clinic.clinic_name, dc_dogsched.clinic_id,dogsched_start, dogsched_end," +
                        " dogsched_date, dogstart_time, dogend_time, dog_vaccination,  dog_status, " +
                        "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +                        
                        "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
                        "inner join dog_clinic on dc_dogsched.clinic_id = dog_clinic.clinic_id " +
                        "where dog_breed like '%" + inputField.Text + "%' AND sched_type = 1 order by dogsched_date";
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
                    dataGridView1.Columns["dog_breed"].HeaderText = "Breed";
                    dataGridView1.Columns["dog_name"].HeaderText = "Dog Name";
                    dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
                    dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
                    dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
                    dataGridView1.Columns["dog_vaccination"].HeaderText = "Medication";
                    dataGridView1.Columns["dog_status"].HeaderText = "Status";
                    dataGridView1.Columns["dog_shour"].Visible = false;
                    dataGridView1.Columns["dog_smin"].Visible = false;
                    dataGridView1.Columns["dog_sday"].Visible = false;
                    dataGridView1.Columns["dog_ehour"].Visible = false;
                    dataGridView1.Columns["dog_emin"].Visible = false;
                    dataGridView1.Columns["dog_eday"].Visible = false;
                    dataGridView1.Columns["clinic_name"].HeaderText = "Clinic";
                    dataGridView1.Columns["clinic_id"].Visible = false;
                }
                else if (SearchByBox.Text == "Status")
                {
                    string query = "select dogsched_id, dc_dogsched.dog_id, dog_breed, dog_name,dog_clinic.clinic_name, dc_dogsched.clinic_id,dogsched_start, dogsched_end," +
                        " dogsched_date, dogstart_time, dogend_time, dog_vaccination,  dog_status, " +
                        "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +                       
                        "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
                        "inner join dog_clinic on dc_dogsched.clinic_id = dog_clinic.clinic_id " +
                        "where dog_status like '%" + inputField.Text + "%' AND sched_type = 1 order by dogsched_date";
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
                    dataGridView1.Columns["dog_breed"].HeaderText = "Breed";
                    dataGridView1.Columns["dog_name"].HeaderText = "Dog Name";
                    dataGridView1.Columns["dogsched_date"].HeaderText = "Scheduled Date";
                    dataGridView1.Columns["dogstart_time"].HeaderText = "Time Start";
                    dataGridView1.Columns["dogend_time"].HeaderText = "Time End";
                    dataGridView1.Columns["dog_vaccination"].HeaderText = "Medication";
                    dataGridView1.Columns["dog_status"].HeaderText = "Status";
                    dataGridView1.Columns["dog_shour"].Visible = false;
                    dataGridView1.Columns["dog_smin"].Visible = false;
                    dataGridView1.Columns["dog_sday"].Visible = false;
                    dataGridView1.Columns["dog_ehour"].Visible = false;
                    dataGridView1.Columns["dog_emin"].Visible = false;
                    dataGridView1.Columns["dog_eday"].Visible = false;
                    dataGridView1.Columns["clinic_name"].HeaderText = "Clinic";
                    dataGridView1.Columns["clinic_id"].Visible = false;
                }
            }
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void from_date_ValueChanged(object sender, EventArgs e)
        {
            if (reminder == "playhouse")
            {
                string query = "select dogsched_id, dc_dogsched.dog_id, dog_name, " +
                            "dog_breed, dogsched_start, dogsched_end, dogsched_date, " +
                            "dogstart_time, dogend_time, dog_status, " +
                            "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +
                            "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
                            " where dogsched_date >= '" +
                               from_date.Text + "' AND dogsched_date <= '" + to_date.Text + "' AND sched_type = 0 order by dogsched_date, dogstart_time";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["dog_shour"].Visible = false;
                dataGridView1.Columns["dog_smin"].Visible = false;
                dataGridView1.Columns["dog_sday"].Visible = false;
                dataGridView1.Columns["dog_ehour"].Visible = false;
                dataGridView1.Columns["dog_emin"].Visible = false;
                dataGridView1.Columns["dog_eday"].Visible = false;
            }
            else
            {
                string query = "select dogsched_id, dc_dogsched.dog_id, dog_name, " +
            "dog_breed, dogsched_start, dogsched_end, dogsched_date, " +
            "dogstart_time, dogend_time, dog_status, " +
            "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +
            "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
            " where dogsched_date >= '" +
               from_date.Text + "' AND dogsched_date <= '" + to_date.Text + "' " +
               "AND sched_type = 1 order by dogsched_date, dogstart_time";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["dog_shour"].Visible = false;
                dataGridView1.Columns["dog_smin"].Visible = false;
                dataGridView1.Columns["dog_sday"].Visible = false;
                dataGridView1.Columns["dog_ehour"].Visible = false;
                dataGridView1.Columns["dog_emin"].Visible = false;
                dataGridView1.Columns["dog_eday"].Visible = false;
            }
            
        }

        private void to_date_ValueChanged(object sender, EventArgs e)
        {
            if (reminder == "playhouse")
            {
                string query = "select dogsched_id, dc_dogsched.dog_id, dog_name, " +
                            "dog_breed, dogsched_start, dogsched_end, dogsched_date, " +
                            "dogstart_time, dogend_time, dog_status, " +
                            "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +
                            "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
                            " where dogsched_date >= '" +
                               from_date.Text + "' AND dogsched_date <= '" + to_date.Text + "' AND sched_type = 0 order by dogsched_date, dogstart_time";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            else
            {
                string query = "select dogsched_id, dc_dogsched.dog_id, dog_name, " +
            "dog_breed, dogsched_start, dogsched_end, dogsched_date, " +
            "dogstart_time, dogend_time, dog_status from dog " +
            "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
            " where dogsched_date >= '" +
               from_date.Text + "' AND dogsched_date <= '" + to_date.Text + "' " +
               "AND sched_type = 1 order by dogsched_date, dogstart_time";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["dog_shour"].Visible = false;
                dataGridView1.Columns["dog_smin"].Visible = false;
                dataGridView1.Columns["dog_sday"].Visible = false;
                dataGridView1.Columns["dog_ehour"].Visible = false;
                dataGridView1.Columns["dog_emin"].Visible = false;
                dataGridView1.Columns["dog_eday"].Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowToday();
        }
        public void ShowToday()
        {
            if (reminder == "playhouse")
            {
                string cur_date = DateTime.Now.Date.ToString(dateFormat);
                string query = "select dogsched_id, dc_dogsched.dog_id, dog_name," +
                    " dog_breed, dogsched_start, dogsched_end, dogsched_date," +
                    " dogstart_time, dogend_time, dog_status," +
                    "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +
                    "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where dogsched_date = '" + cur_date + "' " +
                    "AND sched_type = 0 order by dogsched_date, dogstart_time";
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
                dataGridView1.Columns["dog_status"].HeaderText = "Status";
                dataGridView1.Columns["dog_shour"].Visible = false;
                dataGridView1.Columns["dog_smin"].Visible = false;
                dataGridView1.Columns["dog_sday"].Visible = false;
                dataGridView1.Columns["dog_ehour"].Visible = false;
                dataGridView1.Columns["dog_emin"].Visible = false;
                dataGridView1.Columns["dog_eday"].Visible = false;
            }
            else
            {
                string cur_date = DateTime.Now.Date.ToString(dateFormat);
                string query = "select dogsched_id, dc_dogsched.dog_id, dog_name," +
                    " dog_breed,dog_clinic.clinic_name, dc_dogsched.clinic_id, dogsched_start, dogsched_end, dogsched_date," +
                    " dogstart_time, dogend_time, dog_vaccination,  dog_status," +
                    "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +
                    "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
                    "inner join dog_clinic on dc_dogsched.clinic_id = dog_clinic.clinic_id " +
                    "where dogsched_date = '" + cur_date + "' " +
                    "AND sched_type = 1 order by dogsched_date, dogstart_time";
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
                dataGridView1.Columns["dog_shour"].Visible = false;
                dataGridView1.Columns["dog_smin"].Visible = false;
                dataGridView1.Columns["dog_sday"].Visible = false;
                dataGridView1.Columns["dog_ehour"].Visible = false;
                dataGridView1.Columns["dog_emin"].Visible = false;
                dataGridView1.Columns["dog_eday"].Visible = false;
                dataGridView1.Columns["clinic_name"].HeaderText = "Clinic";
                dataGridView1.Columns["clinic_id"].Visible = false;
            }
            
        }
        public void ShowIncoming()
        {
            if (reminder == "playhouse")
            {
                string cur_date = DateTime.Now.Date.ToString(dateFormat);
                string query = "select dogsched_id,dog.dog_id, dog_name," +
                    " dog_breed, dogsched_start, dogsched_end, dogsched_date," +
                    " dogstart_time, dogend_time, dog_status," +
                    "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +
                    "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where dogsched_date >= '" + cur_date + "' " +
                    "AND sched_type = 0 order by dogsched_date, dogstart_time";
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
                dataGridView1.Columns["dog_status"].HeaderText = "Status";
                dataGridView1.Columns["dog_shour"].Visible = false;
                dataGridView1.Columns["dog_smin"].Visible = false;
                dataGridView1.Columns["dog_sday"].Visible = false;
                dataGridView1.Columns["dog_ehour"].Visible = false;
                dataGridView1.Columns["dog_emin"].Visible = false;
                dataGridView1.Columns["dog_eday"].Visible = false;
            }
            else
            {
                string cur_date = DateTime.Now.Date.ToString(dateFormat);
                string query = "select dogsched_id, dc_dogsched.dog_id, dog_name," +
                    " dog_breed,dog_clinic.clinic_name, dc_dogsched.clinic_id, dc_dogsched.clinic_id, dogsched_start, dogsched_end, dogsched_date," +
                    " dogstart_time, dogend_time, dog_vaccination,  dog_status," +
                    "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +
                    "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
                    "inner join dog_clinic on dc_dogsched.clinic_id = dog_clinic.clinic_id " +
                    "where dogsched_date >= '" + cur_date + "' " +
                    "AND sched_type = 1 order by dogsched_date, dogstart_time";
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
                dataGridView1.Columns["dog_shour"].Visible = false;
                dataGridView1.Columns["dog_smin"].Visible = false;
                dataGridView1.Columns["dog_sday"].Visible = false;
                dataGridView1.Columns["dog_ehour"].Visible = false;
                dataGridView1.Columns["dog_emin"].Visible = false;
                dataGridView1.Columns["dog_eday"].Visible = false;
                dataGridView1.Columns["clinic_name"].HeaderText = "Clinic";
                dataGridView1.Columns["clinic_id"].Visible = false;
            }
            
        }
        public void ShowPast()
        {
            if (reminder == "playhouse")
            {
                string cur_date = DateTime.Now.Date.ToString(dateFormat);
                string query = "select dogsched_id, dc_dogsched.dog_id, dog_name," +
                    " dog_breed, dogsched_start, dogsched_end, dogsched_date," +
                    " dogstart_time, dogend_time, dog_status," +
                    "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +
                    "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id where dogsched_date < '" + cur_date + "' " +
                    "AND sched_type = 0 order by dogsched_date, dogstart_time";
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
                dataGridView1.Columns["dog_status"].HeaderText = "Status";
                dataGridView1.Columns["dog_shour"].Visible = false;
                dataGridView1.Columns["dog_smin"].Visible = false;
                dataGridView1.Columns["dog_sday"].Visible = false;
                dataGridView1.Columns["dog_ehour"].Visible = false;
                dataGridView1.Columns["dog_emin"].Visible = false;
                dataGridView1.Columns["dog_eday"].Visible = false;
            }
            else
            {
                string cur_date = DateTime.Now.Date.ToString(dateFormat);
                string query = "select dogsched_id, dc_dogsched.dog_id, dog_name," +
                    " dog_breed,dog_clinic.clinic_name, dc_dogsched.clinic_id, dc_dogsched.clinic_id, dogsched_start, dogsched_end, dogsched_date," +
                    " dogstart_time, dogend_time, dog_vaccination,  dog_status," +
                    "dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday from dog " +
                    "inner join dc_dogsched on dog.dog_id = dc_dogsched.dog_id " +
                    "inner join dog_clinic on dc_dogsched.clinic_id = dog_clinic.clinic_id " +
                    "where dogsched_date < '" + cur_date + "' " +
                    "AND sched_type = 1 order by dogsched_date, dogstart_time";
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
                dataGridView1.Columns["dog_shour"].Visible = false;
                dataGridView1.Columns["dog_smin"].Visible = false;
                dataGridView1.Columns["dog_sday"].Visible = false;
                dataGridView1.Columns["dog_ehour"].Visible = false;
                dataGridView1.Columns["dog_emin"].Visible = false;
                dataGridView1.Columns["dog_eday"].Visible = false;
                dataGridView1.Columns["clinic_name"].HeaderText = "Clinic";
                dataGridView1.Columns["clinic_id"].Visible = false;
            }
            
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
        string status_holder;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (reminder == "playhouse")
            {
                if (e.RowIndex > -1)
                {
                    selected_dogsched_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["dogsched_id"].Value.ToString());
                    selected_dog_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["dog_id"].Value.ToString());
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_name"].Value.ToString() + ", " + dataGridView1.Rows[e.RowIndex].Cells["dog_breed"].Value.ToString();
                    status_text.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_status"].Value.ToString();
                    status_holder = dataGridView1.Rows[e.RowIndex].Cells["dog_status"].Value.ToString();
                    date_text.Text = dataGridView1.Rows[e.RowIndex].Cells["dogsched_date"].Value.ToString();
                    sHour.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_shour"].Value.ToString();
                    sMin.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_smin"].Value.ToString();
                    sDay.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_sday"].Value.ToString();
                    eHour.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_ehour"].Value.ToString();
                    eMin.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_emin"].Value.ToString();
                    eDay.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_eday"].Value.ToString();

                }
            }
            else
            {
                if (e.RowIndex > -1)
                {
                    selected_dogsched_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["dogsched_id"].Value.ToString());
                    selected_dog_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["dog_id"].Value.ToString());
                    select_clinic_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["clinic_id"].Value.ToString());
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_name"].Value.ToString() + ", " + dataGridView1.Rows[e.RowIndex].Cells["dog_breed"].Value.ToString();
                    status_text.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_status"].Value.ToString();
                    date_text.Text = dataGridView1.Rows[e.RowIndex].Cells["dogsched_date"].Value.ToString();
                    sHour.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_shour"].Value.ToString();
                    sMin.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_smin"].Value.ToString();
                    sDay.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_sday"].Value.ToString();
                    eHour.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_ehour"].Value.ToString();
                    eMin.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_emin"].Value.ToString();
                    eDay.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_eday"].Value.ToString();
                    clinic_text.Text = dataGridView1.Rows[e.RowIndex].Cells["clinic_name"].Value.ToString();
                    vacc_Text.Text = dataGridView1.Rows[e.RowIndex].Cells["dog_vaccination"].Value.ToString();
                }
                //MessageBox.Show(select_clinic_id + "");
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
            status_text.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            if (reminder != "playhouse")
            {
                DateTime cur_date = DateTime.Now;
                TimeSpan cur_time = DateTime.Now.TimeOfDay;
                DateTime input_Date = Convert.ToDateTime(date_text.Text);

                int taken = 0;
                if (status_text.Text == "Taken")
                {
                    taken = 1;
                }
                else
                {
                    taken = 0;
                }

                if (clinic_text.Text == "" || clinic_text.Text == null)
                {
                    MessageBox.Show("Clinic is null");
                }
                if (selected_dog_id == -1)
                {
                    MessageBox.Show("Invalid Dog ID");
                }
                else if (textBox1.Text == "" || textBox1.Text == null)
                {
                    MessageBox.Show("Invalid Dog Name");
                }
                else if (date_text.Text == "" || date_text.Text == null)
                {
                    MessageBox.Show("Invalid Date");
                }
                else if (input_Date.Date < cur_date.Date && taken == 0)
                {
                    MessageBox.Show("Scheduled for past date.", "Invalid Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (sHour.Text == "" || sHour.Text == null ||
                    sMin.Text == "" || sMin.Text == null ||
                    eHour.Text == "" || eHour.Text == null ||
                    eMin.Text == "" || eMin.Text == null)
                {
                    MessageBox.Show("Invalid Start Time/ End time");
                }
                else if (sHour.Text != "13")
                {
                    if (sDay.Text == "PM" && eDay.Text == "AM")
                    {
                        MessageBox.Show("Invalid Time", "Invalid Start/End Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int sHour_int = Convert.ToInt32(sHour.Text);
                    int eHour_int = Convert.ToInt32(eHour.Text);
                    int sMin_int = Convert.ToInt32(sMin.Text);
                    int eMin_int = Convert.ToInt32(eMin.Text);


                    if (sHour_int >= eHour_int &&
                        sMin_int >= eMin_int && sHour.Text != "12" && sDay.Text == eDay.Text)
                    {
                        MessageBox.Show("Invalid Time", "Invalid Start/End Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (vacc_Text.Text == "" || vacc_Text.Text == null)
                    {
                        MessageBox.Show("Invalid Medication");
                    }
                    else if (status_text.Text == "" || status_text.Text == null)
                    {
                        MessageBox.Show("Invalid Status");
                    }
                    else
                    {
                        if (select_clinic_id == 0)
                        {
                            MessageBox.Show("Warning no clinic selected", "Warning Clinic ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string start_time = sHour.Text + ":" + sMin.Text + " " + sDay.Text;
                        string end_time = eHour.Text + ":" + eMin.Text + " " + eDay.Text;

                        TimeSpan start_time1 = Convert.ToDateTime(start_time).TimeOfDay;
                        TimeSpan end_time1 = Convert.ToDateTime(end_time).TimeOfDay;

                        string sched_start = date_text.Text + " " + start_time1;
                        string sched_end = date_text.Text + " " + end_time1;

                        if (input_Date.Date == cur_date.Date && start_time1 < cur_time && taken == 0 || input_Date.Date > cur_date.Date && start_time1 < cur_time && taken == 1)
                        {
                            MessageBox.Show("Invalid Date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string selectquery = "select * from dc_dogsched where dog_id = '" + selected_dog_id + "' AND dogsched_date = '" + date_text.Text + "' " +
                                    "AND dogstart_time = '" + start_time + "' AND dogend_time = '" + end_time + "' AND sched_type = 1 AND dog_status = '" + status_text.Text + "' " +
                                    "AND clinic_id = " + select_clinic_id + " AND dog_vaccination = '"+vacc_Text.Text+"'";
                            string selectquery2 = "SELECT * FROM dc_dogsched WHERE  ((dogsched_start <= '" + sched_start + "'  AND dogsched_end >= '" + sched_start + "' )" +
                            "OR(dogsched_start <= '" + sched_end + "'  AND dogsched_end >= '" + sched_end + "'))" +
                            "AND dog_id = " + selected_dog_id + " AND sched_type = 1  AND dogsched_id <> " + selected_dogsched_id ;
                            //string duplicates = "select * from dc_dogsched where dog_id = " + selected_dog_id + " " +
                            //    "AND clinic_id = " + select_clinic_id + " AND dogstart_time = '" + start_time + "' AND dogend_time = '" + end_time + "'" +
                            //    "AND dog_vaccination = '" + vacc_Text.Text + "' AND sched_type = 1 ";
                            //MessageBox.Show(duplicates);
                            conn.Open();

                            MySqlCommand comm1 = new MySqlCommand(selectquery, conn);
                            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                            DataTable dt1 = new DataTable();
                            adp1.Fill(dt1);

                            MySqlCommand comm2 = new MySqlCommand(selectquery2, conn);
                            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                            DataTable dt2 = new DataTable();
                            adp2.Fill(dt2);

                            //MySqlCommand commdup = new MySqlCommand(duplicates, conn);
                           // MySqlDataAdapter adpdup = new MySqlDataAdapter(commdup);
                           // DataTable dtdup = new DataTable();
                           // adpdup.Fill(dtdup);
                            //MessageBox.Show("Dup.Count = "+dtdup.Rows.Count + "");

                            conn.Close();


                            //MessageBox.Show(dtdup.Rows.Count + "");

                            if (dt1.Rows.Count > 0)
                            {
                                MessageBox.Show("The selected dog is already assigned for this period ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (dt2.Rows.Count > 0)
                            {
                                MessageBox.Show("Conflicting with an Existing Appointment", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                          //  else if (dtdup.Rows.Count > 0)
                          //  {
                           //     MessageBox.Show("Duplicated Entry", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           // }
                            else
                            {
                                /*
                                string query0003 = "INSERT INTO dc_dogsched(dog_id,clinic_id,dogsched_start, dogsched_end, dogsched_date," +
                                    " dogstart_time, dogend_time, dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday, dog_status, dog_vaccination, sched_type) VALUES('"
                                    + selected_dog_id + "','" + select_clinic_id + "','" + sched_start + "', '" + sched_end + "', '" + date_text.Text + "','"
                                    + start_time + "','" + end_time + "','" + sHour.Text + "', '" + sMin.Text + "','" + sDay.Text + "', '" + eHour.Text + "','" + eMin.Text + "','" +
                                    eDay.Text + "','" + status.Text + "', '" + vacc_Text.Text + "' , 1 )";
                                    */
                                if (status_text.Text == "Taken" && Convert.ToDateTime(sched_start) > DateTime.Now)
                                {
                                    MessageBox.Show("Invalid Status", "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                string query0003 = "UPDATE dc_dogsched SET dog_id = "+selected_dog_id+", clinic_id = "+select_clinic_id+", dogsched_start = '"+sched_start+"', " +
                                    "dogsched_end = '"+sched_end+"', dogsched_date = '"+date_text.Text+"', dogstart_time = '"+start_time+"', " +
                                    "dogend_time = '"+end_time+ "', dog_shour = '"+sHour.Text+"', dog_smin = '"+sMin.Text+"', dog_sday = '"+sDay.Text+"', " +
                                    "dog_ehour = '"+eHour.Text+"', dog_emin = '"+eMin.Text+"', dog_eday = '"+eDay.Text+"', dog_status = '"+status_text.Text+"', " +
                                    "dog_vaccination = '"+vacc_Text.Text+"' WHERE dogsched_id = "+selected_dogsched_id;
                                //MessageBox.Show(query0003);
                                //return;
                                conn.Open();

                                MySqlCommand comm4 = new MySqlCommand(query0003, conn);
                                comm4.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Medical Schedule Successfully Updated");
                                loadall();

                            }
                        }
                    }
                }
            }
            else
            {
                DateTime cur_date = DateTime.Now;
                TimeSpan cur_time = DateTime.Now.TimeOfDay;
                DateTime input_Date = Convert.ToDateTime(date_text.Text);


                if (selected_dogsched_id == -1)
                {
                    MessageBox.Show("Invalid Dog ID");
                }
                else if (textBox1.Text == "" || textBox1.Text == null)
                {
                    MessageBox.Show("Invalid Dog Name");
                }
                else if (date_text.Text == "" || date_text.Text == null)
                {
                    MessageBox.Show("Invalid Date");
                }
                else if (input_Date.Date < cur_date.Date)
                {
                    MessageBox.Show("Scheduled for past date.", "Invalid Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (sHour.Text == "" || sHour.Text == null ||
                    sMin.Text == "" || sMin.Text == null ||
                    eHour.Text == "" || eHour.Text == null ||
                    eMin.Text == "" || eMin.Text == null)
                {
                    MessageBox.Show("Invalid Start Time/ End time");
                }
                else if (sHour.Text != "13")
                {
                    if (sDay.Text == "PM" && eDay.Text == "AM")
                    {
                        MessageBox.Show("Invalid Time", "Invalid Start/End Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int sHour_int = Convert.ToInt32(sHour.Text);
                    int eHour_int = Convert.ToInt32(eHour.Text);
                    int sMin_int = Convert.ToInt32(sMin.Text);
                    int eMin_int = Convert.ToInt32(eMin.Text);


                    if (sHour_int >= eHour_int &&
                        sMin_int >= eMin_int && sHour.Text != "12" && sDay.Text == eDay.Text)
                    {
                        MessageBox.Show("Invalid Time", "Invalid Start/End Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (status_text.Text == "" || status_text.Text == null)
                    {
                        MessageBox.Show("Invalid Status");
                    }
                    else
                    {
                        string start_time = sHour.Text + ":" + sMin.Text + " " + sDay.Text;
                        string end_time = eHour.Text + ":" + eMin.Text + " " + eDay.Text;

                        TimeSpan start_time1 = Convert.ToDateTime(start_time).TimeOfDay;
                        TimeSpan end_time1 = Convert.ToDateTime(end_time).TimeOfDay;

                        string sched_start = date_text.Text + " " + start_time1;
                        string sched_end = date_text.Text + " " + end_time1;

                        //if (input_Date.Date == cur_date.Date && start_time1 < cur_time)
                        //{
                        //    MessageBox.Show("Invalid Date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        //else
                        //{
                            string selectquery = "select * from dc_dogsched where dog_id = '" + selected_dog_id + "' AND dogsched_date = '" + date_text.Text + "' AND dogstart_time = '" + start_time + "' AND dogend_time = '" + end_time + "' AND sched_type = 1 ";
                            string selectquery2 = "SELECT * FROM dc_dogsched WHERE  ((dogsched_start <= '" + sched_start + "'  AND dogsched_end >= '" + sched_start + "' )" +
                            "OR(dogsched_start <= '" + sched_end + "'  AND dogsched_end >= '" + sched_end + "'))" +
                            "AND dog_id = " + selected_dog_id + " AND sched_type = 1 AND dogsched_id <> " + selected_dogsched_id;
                            //string duplicates = "select * from dc_dogsched where dog_id = " + selected_dog_id + " " +
                            //    "AND dogstart_time = '" + start_time + "' AND dogend_time = '" + end_time + "' AND sched_type = 1";

                            //MessageBox.Show(duplicates);
                            conn.Open();

                            MySqlCommand comm1 = new MySqlCommand(selectquery, conn);
                            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                            DataTable dt1 = new DataTable();
                            adp1.Fill(dt1);

                            MySqlCommand comm2 = new MySqlCommand(selectquery2, conn);
                            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                            DataTable dt2 = new DataTable();
                            adp2.Fill(dt2);

                            //MySqlCommand commdup = new MySqlCommand(duplicates, conn);
                            //MySqlDataAdapter adpdup = new MySqlDataAdapter(commdup);
                            //DataTable dtdup = new DataTable();
                            //adpdup.Fill(dtdup);
                            //MessageBox.Show("Dup.Count = "+dtdup.Rows.Count + "");

                            conn.Close();


                            //MessageBox.Show(dtdup.Rows.Count + "");

                            if (dt1.Rows.Count > 0 )
                            {
                                MessageBox.Show("The selected dog is already assigned Medically for this period ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (dt2.Rows.Count > 0)
                            {
                                MessageBox.Show("Conflicting with an Existing Medical Schedule", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            //else if (dtdup.Rows.Count > 0)
                            //{
                            //    MessageBox.Show("Duplicated Entry", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                            else
                            {
                                string selectquery3 = "select * from dc_dogsched where dog_id = '" + selected_dog_id + "' AND dogsched_date = '" + date_text.Text + "' AND dogstart_time = '" + start_time + "' AND dogend_time = '" + end_time + "' AND sched_type = 0" +
                                    " AND dog_status = '"+status_text.Text+"' ";
                                //MessageBox.Show(selectquery3);
                                string selectquery4 = "SELECT * FROM dc_dogsched WHERE  ((dogsched_start <= '" + sched_start + "'  AND dogsched_end >= '" + sched_start + "' )" +
                                "OR(dogsched_start <= '" + sched_end + "'  AND dogsched_end >= '" + sched_end + "'))" +
                                "AND dog_id = " + selected_dog_id + " AND sched_type = 0 AND dogsched_id <> " + selected_dogsched_id;
                                //string duplicates = "select * from dc_dogsched where dog_id = " + selected_dog_id + " " +
                                //    "AND dogstart_time = '" + start_time + "' AND dogend_time = '" + end_time + "' AND sched_type = 1";

                                //MessageBox.Show(duplicates);
                                conn.Open();

                                MySqlCommand comm3 = new MySqlCommand(selectquery3, conn);
                                MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
                                DataTable dt3 = new DataTable();
                                adp3.Fill(dt3);

                                MySqlCommand comm4 = new MySqlCommand(selectquery4, conn);
                                MySqlDataAdapter adp4 = new MySqlDataAdapter(comm4);
                                DataTable dt4 = new DataTable();
                                adp4.Fill(dt4);

                                //MySqlCommand commdup = new MySqlCommand(duplicates, conn);
                                //MySqlDataAdapter adpdup = new MySqlDataAdapter(commdup);
                                //DataTable dtdup = new DataTable();
                                //adpdup.Fill(dtdup);
                                //MessageBox.Show("Dup.Count = "+dtdup.Rows.Count + "");

                                conn.Close();


                                //MessageBox.Show(dtdup.Rows.Count + "");

                                if (dt3.Rows.Count > 0)
                                {
                                    MessageBox.Show("The selected dog is already assigned for this period ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (dt4.Rows.Count > 0)
                                {
                                    MessageBox.Show("Conflicting with an Existing Playhouse Schedule", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //else if (dtdup.Rows.Count > 0)
                                //{
                                //    MessageBox.Show("Duplicated Entry", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                                else
                                {
                                    if (status_text.Text == "IN" && status_holder != "Pending")
                                    {
                                        MessageBox.Show("Unable to log in Dogs Not Scheduled for this Time", "Invalid Log In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    if (status_text.Text == "OUT" && (status_holder != "Overtime" && status_holder != "IN"))
                                    {
                                        MessageBox.Show("Unable to log out Dogs Not Scheduled for this Time", "Invalid Log Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    string query0003 = "UPDATE dc_dogsched SET dog_id = " + selected_dog_id + ", dogsched_start = '" + sched_start + "', " +
                                    "dogsched_end = '" + sched_end + "', dogsched_date = '" + date_text.Text + "', dogstart_time = '" + start_time + "', " +
                                    "dogend_time = '" + end_time + "', dog_shour = '" + sHour.Text + "', dog_smin = '" + sMin.Text + "', dog_sday = '" + sDay.Text + "', " +
                                    "dog_ehour = '" + eHour.Text + "', dog_emin = '" + eMin.Text + "', dog_eday = '" + eDay.Text + "', dog_status = '" + status_text.Text + "'" +
                                    "  WHERE dogsched_id = " + selected_dogsched_id;

                                    conn.Open();
                                    MySqlCommand comm5 = new MySqlCommand(query0003, conn);
                                    comm5.ExecuteNonQuery();
                                    conn.Close();
                                    MessageBox.Show("Playhouse Schedule Successfully Updated");
                                    loadall();
                                }

                            }
                        //}
                    }
                }
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

        private void SearchByBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SearchByBox.Text == "Dog Name")
            {
                InputLbl.Text = "Name";
                inputField.Visible = true;
                to_date.Visible = false;
                from_date.Visible = false;
                startDateLbl.Visible = false;
                endDateLbl.Visible = false;
            }
            else if (SearchByBox.Text == "Breed")
            {
                InputLbl.Text = "Breed";
                inputField.Visible = true;
                to_date.Visible = false;
                from_date.Visible = false;
                startDateLbl.Visible = false;
                endDateLbl.Visible = false;
            }
            else if (SearchByBox.Text == "Date")
            {
                InputLbl.Text = "Date";
                inputField.Visible = false;
                to_date.Visible = true;
                from_date.Visible = true;
                startDateLbl.Visible = true;
                endDateLbl.Visible = true;
            }else if (SearchByBox.Text == "Status")
            {
                InputLbl.Text = "Status";
                inputField.Visible = true;
                to_date.Visible = false;
                from_date.Visible = false;
                startDateLbl.Visible = false;
                endDateLbl.Visible = false;
            }
        }

        private void inputField_TextChanged(object sender, EventArgs e)
        {

        }
        int editSwitch = 0;
        private void button12_Click(object sender, EventArgs e)
        {
            groupBox2.Show();
            if (editSwitch == 0)
            {
                groupBox2.Show();
                editSwitch = 1;
            }
            else
            {
                groupBox2.Hide();
                editSwitch = 0;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            groupBox2.Hide();
            editSwitch = 0;
        }
        int selected_dog_id;
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                selected_dog_id = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["dog_id"].Value.ToString());
                textBox1.Text = dataGridView3.Rows[e.RowIndex].Cells["dog_name"].Value.ToString() + ", " + dataGridView3.Rows[e.RowIndex].Cells["dog_breed"].Value.ToString();

            }
        }
        int editSwitch2 = 0;
        private void button14_Click(object sender, EventArgs e)
        {
            groupBox3.Show();
            if (editSwitch2 == 0)
            {
                groupBox3.Show();
                editSwitch2 = 1;
            }
            else
            {
                groupBox3.Hide();
                editSwitch2 = 0;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            groupBox3.Hide();
            editSwitch2 = 0;
        }
        int select_clinic_id;
        private void clinic_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {


                select_clinic_id = int.Parse(clinic_grid.Rows[e.RowIndex].Cells["clinic_id"].Value.ToString());
                clinic_text.Text = clinic_grid.Rows[e.RowIndex].Cells["clinic_name"].Value.ToString();



            }
        }
        DateTime now = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd"));
        private void button10_Click(object sender, EventArgs e)
        {
            string start_time = sHour.Text + ":" + sMin.Text + " " + sDay.Text;
            string end_time = eHour.Text + ":" + eMin.Text + " " + eDay.Text;

            TimeSpan start_time1 = Convert.ToDateTime(start_time).TimeOfDay;
            TimeSpan end_time1 = Convert.ToDateTime(end_time).TimeOfDay;

            string sched_start = date_text.Text + " " + start_time1;
            string sched_end = date_text.Text + " " + end_time1;

            DateTime curr_schedDate = DateTime.Now;

            if (textBox1.Text == "" || date_text.Text == "" || sHour.Text == "" || sMin.Text == "" ||
                sDay.Text == "" || eHour.Text == "" || eMin.Text == "" || eDay.Text == "")
            {
                MessageBox.Show("Please supply missing fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /*
            if (date_text.Value < now || Convert.ToDateTime(sched_start) < curr_schedDate || Convert.ToDateTime(sched_end) < curr_schedDate)
            {
                MessageBox.Show("Not Allowed to Delete Past Schedules", "Date Restriction", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }*/
            DialogResult iExit;
            iExit = MessageBox.Show("Are you sure?", "Confirm Delete ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (iExit == DialogResult.OK)
            {
                string query0003 = "DELETE FROM dc_dogsched WHERE dogsched_id = '" + selected_dogsched_id + "'";
                conn.Open();
                MySqlCommand comm4 = new MySqlCommand(query0003, conn);
                comm4.ExecuteNonQuery();
                conn.Close();
                if (reminder == "playhouse")
                {
                    MessageBox.Show("Dog Schedule Successfully Deleted");
                    ShowIncoming();
                }
                else
                {
                    MessageBox.Show("Medical Appointment Successfully Deleted");
                    ShowIncoming();
                }
            }
            else
            {
                return;
            }
                
            
        }
    }
}
