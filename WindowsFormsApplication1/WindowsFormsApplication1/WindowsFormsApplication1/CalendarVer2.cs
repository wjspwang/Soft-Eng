using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class CalendarVer2 : Form
    {
        MySqlConnection conn;
        public Form previousform;
        string dateFormat = "yyyy-MM-dd";

        public CalendarVer2()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loadall();
        }
        void loadall()
        {
            date_text.Value = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd"));

            string query = "select c.sched_id, c.staff_id, lname," +
                " fname, sched_start, sched_end, sched_date," +
                " start_time, end_time, status, shour, sminute, sday, ehour, eminute, eday from staff " +
                "inner join person on staff.person_id = person.person_id  " +
                "inner join dc_sched c on staff.staff_id = c.staff_id " +
                "order by sched_date, start_time";

            string query2 = "select activity from scheduletasks";

            string query3 = "select staff_id, lname, fname from staff inner join person on staff.person_id = person.person_id ";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            MySqlCommand comm2 = new MySqlCommand(query2, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);

            MySqlCommand comm3 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["staff_id"].Visible = false;dataGridView1.Columns["sched_id"].Visible = false;
            dataGridView1.Columns["sched_start"].Visible = false;
            dataGridView1.Columns["sched_end"].Visible = false;
            dataGridView1.Columns["lname"].HeaderText = "Last Name";
            dataGridView1.Columns["fname"].HeaderText = "First Name";
            dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
            dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
            dataGridView1.Columns["start_time"].HeaderText = "Time Start";
            dataGridView1.Columns["end_time"].HeaderText = "Time End";
            dataGridView1.Columns["status"].HeaderText = "Shift";
            dataGridView1.Columns["shour"].Visible = false;
            dataGridView1.Columns["sminute"].Visible = false;
            dataGridView1.Columns["sday"].Visible = false;
            dataGridView1.Columns["ehour"].Visible = false;
            dataGridView1.Columns["eminute"].Visible = false;
            dataGridView1.Columns["eday"].Visible = false;

            dataGridView2.DataSource = dt2;
            dataGridView2.Columns["activity"].HeaderText = "Shift";

            dataGridView3.DataSource = dt3;
            dataGridView3.Columns["staff_id"].Visible = false;
            dataGridView3.Columns["lname"].HeaderText = "Last Name";
            dataGridView3.Columns["fname"].HeaderText = "First Name";

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            
            string query = "select dc_sched.sched_id, dc_sched.staff_id, fname" +
               ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
               " status, shour, sminute, sday, ehour, eminute, eday from staff inner join person on staff.person_id = person.person_id" +
               "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date = '" +
                 cur_date + "' order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Debug.WriteLine(query);
            dataGridView1.DataSource = dt;
        }

        private void ShowAllBtn_Click(object sender, EventArgs e)
        {
            loadall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchByBox.Text = "Name";
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
            else{
                SearchByLabel.Visible = true;
                SearchByBox.Visible = true;
                InputLbl.Visible = true;
                inputField.Visible = true;

            }

           

            if(to_date.Visible == true &&
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

        private void SearchByBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SearchByBox.Text == "Name" || SearchByBox.Text == "Last Name" || SearchByBox.Text == "First Name")
            {
                InputLbl.Text = "Name";
                inputField.Visible = true;
                to_date.Visible = false;
                from_date.Visible = false;
                startDateLbl.Visible = false;
                endDateLbl.Visible = false;
            }
            else if (SearchByBox.Text == "Shift")
            {
                InputLbl.Text = "Shift";
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
            }
        }

        private void inputField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SearchByBox.Text == "Name")
            {
                string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname ,sched_start, sched_end," +
                    " sched_date, start_time, end_time, status, shour, sminute, sday, ehour, eminute, eday" +
                    " from staff inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                    "where lname like '%" + inputField.Text + "%' OR fname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;dataGridView1.Columns["sched_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
                dataGridView1.Columns["shour"].Visible = false;
                dataGridView1.Columns["sminute"].Visible = false;
                dataGridView1.Columns["sday"].Visible = false;
                dataGridView1.Columns["ehour"].Visible = false;
                dataGridView1.Columns["eminute"].Visible = false;
                dataGridView1.Columns["eday"].Visible = false;
            }
            else if (SearchByBox.Text == "Shift")
            {
                string query = "select dc_sched.sched_id, dc_sched.staff_id, CONCAT(lname,', ',fname) " +
                    "AS Staff ,sched_start, sched_end, sched_date, start_time, end_time," +
                    " status, shour, sminute, sday, ehour, eminute, eday" +
                    " from staff inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                    "where status like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;dataGridView1.Columns["sched_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
                dataGridView1.Columns["shour"].Visible = false;
                dataGridView1.Columns["sminute"].Visible = false;
                dataGridView1.Columns["sday"].Visible = false;
                dataGridView1.Columns["ehour"].Visible = false;
                dataGridView1.Columns["eminute"].Visible = false;
                dataGridView1.Columns["eday"].Visible = false;
            }
            else if (SearchByBox.Text == "Last Name")
            {
                string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname, sched_start, sched_end, sched_date, start_time, end_time, " +
                    "status, shour, sminute, sday, ehour, eminute, eday " +
                    "from staff inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                    "where lname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;dataGridView1.Columns["sched_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
                dataGridView1.Columns["shour"].Visible = false;
                dataGridView1.Columns["sminute"].Visible = false;
                dataGridView1.Columns["sday"].Visible = false;
                dataGridView1.Columns["ehour"].Visible = false;
                dataGridView1.Columns["eminute"].Visible = false;
                dataGridView1.Columns["eday"].Visible = false;
            }
            else if (SearchByBox.Text == "First Name")
            {
                string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname, sched_start, sched_end, " +
                    "sched_date, start_time, end_time, status, shour, sminute, sday, ehour, eminute, eday from staff " +
                    "inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                    "where fname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;dataGridView1.Columns["sched_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
                dataGridView1.Columns["shour"].Visible = false;
                dataGridView1.Columns["sminute"].Visible = false;
                dataGridView1.Columns["sday"].Visible = false;
                dataGridView1.Columns["ehour"].Visible = false;
                dataGridView1.Columns["eminute"].Visible = false;
                dataGridView1.Columns["eday"].Visible = false;
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void inputField_TextChanged(object sender, EventArgs e)
        {

        }

        private void from_date_ValueChanged(object sender, EventArgs e)
        {
            string query = "select dc_sched.sched_id, dc_sched.staff_id, CONCAT(lname,', ',fname)" +
               " AS Staff ,sched_start, sched_end, sched_date, start_time, end_time," +
               " status, shour, sminute, sday, ehour, eminute, eday" +
               " from staff inner join person on staff.person_id = person.person_id" +
               "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date >= '" +
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
            
            string query = "select dc_sched.sched_id, dc_sched.staff_id, CONCAT(lname,', ',fname)" +
                " AS Staff ,sched_start, sched_end, sched_date, start_time, end_time," +
                " status, shour, sminute, sday, ehour, eminute, eday from staff " +
                "inner join person on staff.person_id = person.person_id" +
                "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date >= '" +
                from_date.Text + "' AND sched_date <= '" + to_date.Text + "' order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void inputField_KeyDown(object sender, KeyEventArgs e)
        {
            if (SearchByBox.Text == "Name")
            {
                string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname ,sched_start, sched_end, sched_date, start_time, end_time, " +
                    "status, shour, sminute, sday, ehour, eminute, eday from staff " +
                    "inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                    "where lname like '%" + inputField.Text + "%' OR fname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;dataGridView1.Columns["sched_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
                dataGridView1.Columns["shour"].Visible = false;
                dataGridView1.Columns["sminute"].Visible = false;
                dataGridView1.Columns["sday"].Visible = false;
                dataGridView1.Columns["ehour"].Visible = false;
                dataGridView1.Columns["eminute"].Visible = false;
                dataGridView1.Columns["eday"].Visible = false;
            }
            else if (SearchByBox.Text == "Shift")
            {
                string query = "select dc_sched.sched_id, dc_sched.staff_id, CONCAT(lname,', ',fname) AS Staff ,sched_start, sched_end, sched_date, start_time," +
                    " end_time, status from staff, shour, sminute, sday, ehour, eminute, eday" +
                    "inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id where status like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;dataGridView1.Columns["sched_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
                dataGridView1.Columns["shour"].Visible = false;
                dataGridView1.Columns["sminute"].Visible = false;
                dataGridView1.Columns["sday"].Visible = false;
                dataGridView1.Columns["ehour"].Visible = false;
                dataGridView1.Columns["eminute"].Visible = false;
                dataGridView1.Columns["eday"].Visible = false;
            }
            else if (SearchByBox.Text == "Last Name")
            {
                string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname, sched_start, sched_end, sched_date, start_time, end_time," +
                    " status from staff, shour, sminute, sday, ehour, eminute, eday " +
                    "inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                    "where lname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;dataGridView1.Columns["sched_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
                dataGridView1.Columns["shour"].Visible = false;
                dataGridView1.Columns["sminute"].Visible = false;
                dataGridView1.Columns["sday"].Visible = false;
                dataGridView1.Columns["ehour"].Visible = false;
                dataGridView1.Columns["eminute"].Visible = false;
                dataGridView1.Columns["eday"].Visible = false;
            }
            else if (SearchByBox.Text == "First Name")
            {
                string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname, sched_start, sched_end, sched_date, start_time," +
                    " end_time, status, shour, sminute, sday, ehour, eminute, eday from staff " +
                    "inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                    "where fname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;dataGridView1.Columns["sched_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
                dataGridView1.Columns["shour"].Visible = false;
                dataGridView1.Columns["sminute"].Visible = false;
                dataGridView1.Columns["sday"].Visible = false;
                dataGridView1.Columns["ehour"].Visible = false;
                dataGridView1.Columns["eminute"].Visible = false;
                dataGridView1.Columns["eday"].Visible = false;
            }
        }

        private void inputField_KeyUp(object sender, KeyEventArgs e)
        {
            if (SearchByBox.Text == "Name")
            {
                string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname ,sched_start, sched_end, sched_date, start_time, end_time, " +
                    "status, shour, sminute, sday, ehour, eminute, eday from staff " +
                    "inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                    "where lname like '%" + inputField.Text + "%' OR fname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;dataGridView1.Columns["sched_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
                dataGridView1.Columns["shour"].Visible = false;
                dataGridView1.Columns["sminute"].Visible = false;
                dataGridView1.Columns["sday"].Visible = false;
                dataGridView1.Columns["ehour"].Visible = false;
                dataGridView1.Columns["eminute"].Visible = false;
                dataGridView1.Columns["eday"].Visible = false;
            }
            else if (SearchByBox.Text == "Shift")
            {
                string query = "select dc_sched.sched_id, dc_sched.staff_id, CONCAT(lname,', ',fname) AS Staff ,sched_start, sched_end, sched_date, start_time," +
                    " end_time, status from staff, shour, sminute, sday, ehour, eminute, eday" +
                    "inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id where status like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;dataGridView1.Columns["sched_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
                dataGridView1.Columns["shour"].Visible = false;
                dataGridView1.Columns["sminute"].Visible = false;
                dataGridView1.Columns["sday"].Visible = false;
                dataGridView1.Columns["ehour"].Visible = false;
                dataGridView1.Columns["eminute"].Visible = false;
                dataGridView1.Columns["eday"].Visible = false;
            }
            else if (SearchByBox.Text == "Last Name")
            {
                string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname, sched_start, sched_end, sched_date, start_time, end_time," +
                    " status from staff, shour, sminute, sday, ehour, eminute, eday " +
                    "inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                    "where lname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;dataGridView1.Columns["sched_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
                dataGridView1.Columns["shour"].Visible = false;
                dataGridView1.Columns["sminute"].Visible = false;
                dataGridView1.Columns["sday"].Visible = false;
                dataGridView1.Columns["ehour"].Visible = false;
                dataGridView1.Columns["eminute"].Visible = false;
                dataGridView1.Columns["eday"].Visible = false;
            }
            else if (SearchByBox.Text == "First Name")
            {
                string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname, sched_start, sched_end, sched_date, start_time," +
                    " end_time, status, shour, sminute, sday, ehour, eminute, eday from staff " +
                    "inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                    "where fname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;dataGridView1.Columns["sched_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
                dataGridView1.Columns["shour"].Visible = false;
                dataGridView1.Columns["sminute"].Visible = false;
                dataGridView1.Columns["sday"].Visible = false;
                dataGridView1.Columns["ehour"].Visible = false;
                dataGridView1.Columns["eminute"].Visible = false;
                dataGridView1.Columns["eday"].Visible = false;
            }
        }
        int selected_user_id;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                selected_user_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["sched_id"].Value.ToString());
                selected_staff_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["staff_id"].Value.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["lname"].Value.ToString() + ", " + dataGridView1.Rows[e.RowIndex].Cells["fname"].Value.ToString();
                date_text.Value =  Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["sched_date"].Value.ToString());
                sHour.Text = dataGridView1.Rows[e.RowIndex].Cells["shour"].Value.ToString();
                sMin.Text = dataGridView1.Rows[e.RowIndex].Cells["sminute"].Value.ToString();
                sDay.Text = dataGridView1.Rows[e.RowIndex].Cells["sday"].Value.ToString();
                eHour.Text = dataGridView1.Rows[e.RowIndex].Cells["ehour"].Value.ToString();
                eMin.Text = dataGridView1.Rows[e.RowIndex].Cells["eminute"].Value.ToString();
                eDay.Text = dataGridView1.Rows[e.RowIndex].Cells["eday"].Value.ToString();
                status.Text = dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString();
            }
        }
        //past sched
        private void button3_Click(object sender, EventArgs e)
        {
            string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");

            string query = "select dc_sched.sched_id, dc_sched.staff_id, fname" +
               ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
               " status, shour, sminute, sday, ehour, eminute, eday " +
               "from staff inner join person on staff.person_id = person.person_id" +
               "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date < '" +
                 cur_date + "' order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Debug.WriteLine(query);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");

            string query = "select dc_sched.sched_id, dc_sched.staff_id, fname" +
               ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
               " status , shour, sminute, sday, ehour, eminute, eday " +
               "from staff inner join person on staff.person_id = person.person_id" +
               "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date >= '" +
                 cur_date + "' order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            //Debug.WriteLine(query);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            dt = dataGridView1.DataSource as DataTable;
           // MessageBox.Show(dataGridView1.DataSource + "");
            ds.Tables.Add(dt);
            Form4 f = new Form4(ds, "staff_sched");
            f.Show();
        }
        int editSwitch = 0;
        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            if (editSwitch == 0)
            {
                groupBox1.Show();
                editSwitch = 1;
            }
            else
            {
                groupBox1.Hide();
                editSwitch = 0;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            editSwitch = 0;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            { 
                status.Text = dataGridView2.Rows[e.RowIndex].Cells["activity"].Value.ToString();
            }
        }
        int selected_staff_id;
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                selected_staff_id = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["staff_id"].Value.ToString());
                textBox1.Text = dataGridView3.Rows[e.RowIndex].Cells["lname"].Value.ToString() + ", " + dataGridView3.Rows[e.RowIndex].Cells["fname"].Value.ToString();

            }
        }
        int editSwitch2 = 0;
        private void button10_Click(object sender, EventArgs e)
        {
            groupBox2.Show();
            if (editSwitch2 == 0)
            {
                groupBox2.Show();
                editSwitch2 = 1;
            }
            else
            {
                groupBox2.Hide();
                editSwitch2 = 0;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox2.Hide();
            editSwitch2 = 0;
        }
        DateTime now = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd"));
        private void button6_Click(object sender, EventArgs e)
        {
            string start_time = sHour.Text + ":" + sMin.Text + " " + sDay.Text;
            string end_time = eHour.Text + ":" + eMin.Text + " " + eDay.Text;

            TimeSpan start_time1 = Convert.ToDateTime(start_time).TimeOfDay;
            TimeSpan end_time1 = Convert.ToDateTime(end_time).TimeOfDay;

            string sched_start = date_text.Text + " " + start_time1;
            string sched_end = date_text.Text + " " + end_time1;

            DateTime curr_schedDate = DateTime.Now;

            if (textBox1.Text == "" || date_text.Text == "" || sHour.Text == "" || sMin.Text == "" ||
                sDay.Text == "" || eHour.Text == "" || eMin.Text == "" || eDay.Text == "" || status.Text == "")
            {
                MessageBox.Show("Please supply missing fields", "Missing Fields", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            
            if (date_text.Value < now || Convert.ToDateTime(sched_start) < curr_schedDate || Convert.ToDateTime(sched_end) < curr_schedDate)
            {
                MessageBox.Show("Not Allowed to Update Past Schedules", "Date Restriction", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }else if(Convert.ToDateTime(sched_start) >= Convert.ToDateTime(sched_end))
            {
                MessageBox.Show("Invalid Start Time & End Time", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }else if (sDay.Text == "PM" && eDay.Text == "AM")
            {
                MessageBox.Show("Invalid Start Time & End Time", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {               

                string selectquery = "select * from dc_sched where staff_id = '" + selected_staff_id + "' AND sched_date = '" + date_text.Text + "' AND start_time = '" + start_time + "' AND end_time = '" + end_time + "' AND status = '"+status.Text+"' ";
                string selectquery2 = "SELECT * FROM dc_sched WHERE  ((sched_start <= '" + sched_start + "'  AND sched_end >= '" + sched_start + "' )" +
                "OR(sched_start <= '" + sched_end + "'  AND sched_end >= '" + sched_end + "'))" +
                "AND staff_id = " + selected_staff_id + " AND sched_id <> " + selected_user_id + "";

                conn.Open();

                MySqlCommand comm1 = new MySqlCommand(selectquery, conn);
                MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);

                MySqlCommand comm2 = new MySqlCommand(selectquery2, conn);
                MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                DataTable dt2 = new DataTable();
                adp2.Fill(dt2);

                conn.Close();

                if (dt1.Rows.Count > 0)
                {
                    MessageBox.Show("The selected employee is already assigned", "Invalid Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dt2.Rows.Count > 0)
                {
                    MessageBox.Show("Conflicting with an Existing Schedule", "Invalid Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string query0003 = "UPDATE dc_sched SET staff_id = " + selected_staff_id + ", sched_start = '" + sched_start + "'," +
                        "sched_end = '" + sched_end + "', sched_date = '" + date_text.Text + "', start_time = '" + start_time + "'," +
                        "end_time = '" + end_time + "', shour ='" + sHour.Text + "', sminute = '" + sMin.Text + "', sday = '" + sDay.Text + "'," +
                        "ehour = '" + eHour.Text + "',eminute = '" + eMin.Text + "',eday = '" + eDay.Text + "',status ='" + status.Text + "'" +
                        "WHERE sched_id = '" + selected_user_id + "'";
                    conn.Open();
                    MySqlCommand comm4 = new MySqlCommand(query0003, conn);
                    comm4.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Schedule Successfully Updated");

                    string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");

                    string query = "select dc_sched.sched_id, dc_sched.staff_id, fname" +
                       ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
                       " status , shour, sminute, sday, ehour, eminute, eday " +
                       "from staff inner join person on staff.person_id = person.person_id" +
                       "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date >= '" +
                         cur_date + "' order by sched_date, start_time";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    //Debug.WriteLine(query);
                    dataGridView1.DataSource = dt;

                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            string start_time = sHour.Text + ":" + sMin.Text + " " + sDay.Text;
            string end_time = eHour.Text + ":" + eMin.Text + " " + eDay.Text;

            TimeSpan start_time1 = Convert.ToDateTime(start_time).TimeOfDay;
            TimeSpan end_time1 = Convert.ToDateTime(end_time).TimeOfDay;

            string sched_start = date_text.Text + " " + start_time1;
            string sched_end = date_text.Text + " " + end_time1;

            DateTime curr_schedDate = DateTime.Now;

            if (textBox1.Text == "" || date_text.Text == "" || sHour.Text == "" || sMin.Text == "" ||
                sDay.Text == "" || eHour.Text == "" || eMin.Text == "" || eDay.Text == "" || status.Text == "")
            {
                MessageBox.Show("Please supply missing fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (date_text.Value < now || Convert.ToDateTime(sched_start) < curr_schedDate || Convert.ToDateTime(sched_end) < curr_schedDate)
            {
                MessageBox.Show("Not Allowed to Delete Past Schedules", "Date Restriction", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            DialogResult iExit;
            iExit = MessageBox.Show("Are you sure?", "Confirm Delete ?",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if(iExit == DialogResult.OK)
            {
                string query0003 = "DELETE FROM dc_sched WHERE sched_id = '" + selected_user_id + "'";
                conn.Open();
                MySqlCommand comm4 = new MySqlCommand(query0003, conn);
                comm4.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Schedule Successfully Deleted");
            }
            else
            {
                return;
            }
            

            string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");

            string query = "select dc_sched.sched_id, dc_sched.staff_id, fname" +
               ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
               " status , shour, sminute, sday, ehour, eminute, eday " +
               "from staff inner join person on staff.person_id = person.person_id" +
               "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date >= '" +
                 cur_date + "' order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            //Debug.WriteLine(query);
            dataGridView1.DataSource = dt;

        }
    }
}
