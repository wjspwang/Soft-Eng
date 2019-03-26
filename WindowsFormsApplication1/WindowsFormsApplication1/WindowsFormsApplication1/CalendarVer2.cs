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
        public string calendar;

        public CalendarVer2()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");
        }
        public CalendarVer2(string calendar)
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");
            this.calendar = calendar;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loadall();
        }
        public void StaffTableUpdate()
        {
            string curr_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string curr_time = DateTime.Now.ToString("hh:mm tt");
            string curr_sched = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string updateToExpire = "UPDATE dc_sched SET status2 = 'Overtime' WHERE (sched_end <= '" + curr_sched + "') AND status2 != 'OUT' AND sched_date <= '" + curr_date + "' ";
            string updateToPending = "UPDATE dc_sched SET status2 = 'Pending' WHERE (sched_start <= '" + curr_sched + "') AND status2 != 'IN' AND status = 'Playhouse' AND status2 != 'OUT' AND sched_date <= '" + curr_date + "'";

            conn.Open();

            MySqlCommand commz = new MySqlCommand(updateToExpire, conn);
            MySqlCommand comma = new MySqlCommand(updateToPending, conn);
            comma.ExecuteNonQuery();
            commz.ExecuteNonQuery();
            conn.Close();
        }
        public void StaffOvertime()
        {
            string currdate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string StaffOvertime = "Select * from dc_sched where status2 = 'Overtime' AND sched_date = '" + currdate + "' AND status = 'Playhouse'";
            conn.Open();
            MySqlCommand a = new MySqlCommand(StaffOvertime, conn);
            MySqlDataAdapter a1 = new MySqlDataAdapter(a);
            conn.Close();
            DataTable dt = new DataTable();
            a1.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(dt.Rows.Count + " Staff(s) currently on Overtime!", "Staff Overtime Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void StaffPending()
        {
            string curr_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string pendCounter = "select * from dc_sched where status2 = 'Pending' AND sched_date = '" + curr_date + "'";
            conn.Open();
            MySqlCommand comm4 = new MySqlCommand(pendCounter, conn);
            MySqlDataAdapter adp4 = new MySqlDataAdapter(comm4);
            conn.Close();
            DataTable dt4 = new DataTable();
            adp4.Fill(dt4);
            if (dt4.Rows.Count > 0)
            {
                MessageBox.Show("There are " + dt4.Rows.Count + " Staff(s) Pending for Playhouse", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void loadall()
        {
            StaffTableUpdate();
            if (calendar == "playhouse")
            {
                date_text.Value = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd"));
  
                

                string querya = "select c.sched_id, c.staff_id, lname," +
                    " fname, sched_start, sched_end, sched_date," +
                    " start_time, end_time, status, status2, shour, sminute, sday, ehour, eminute, eday from staff " +
                    "inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched c on staff.staff_id = c.staff_id " +
                    "where status = 'Playhouse' order by sched_start, start_time";

                string queryb = "select activity from scheduletasks";

                string queryc = "select staff_id, lname, fname from staff inner join person on staff.person_id = person.person_id ";

                conn.Open();
                MySqlCommand comma = new MySqlCommand(querya, conn);
                MySqlDataAdapter adpa = new MySqlDataAdapter(comma);

                MySqlCommand commb = new MySqlCommand(queryb, conn);
                MySqlDataAdapter adpb = new MySqlDataAdapter(commb);

                MySqlCommand commc = new MySqlCommand(queryc, conn);
                MySqlDataAdapter adpc = new MySqlDataAdapter(commc);
                conn.Close();
                DataTable dta = new DataTable();
                adpa.Fill(dta);
                DataTable dtb = new DataTable();
                adpb.Fill(dtb);
                DataTable dtc = new DataTable();
                adpc.Fill(dtc);

                dataGridView1.DataSource = dta;
                dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
                dataGridView1.Columns["status2"].HeaderText = "Status";
                dataGridView1.Columns["shour"].Visible = false;
                dataGridView1.Columns["sminute"].Visible = false;
                dataGridView1.Columns["sday"].Visible = false;
                dataGridView1.Columns["ehour"].Visible = false;
                dataGridView1.Columns["eminute"].Visible = false;
                dataGridView1.Columns["eday"].Visible = false;

                dataGridView2.DataSource = dtb;
                dataGridView2.Columns["activity"].HeaderText = "Shift";

                dataGridView3.DataSource = dtc;
                dataGridView3.Columns["staff_id"].Visible = false;
                dataGridView3.Columns["lname"].HeaderText = "Last Name";
                dataGridView3.Columns["fname"].HeaderText = "First Name";

                label2.Visible = true;
                comboBox1.Visible = true;
                status_lbl.Visible = false;
                status.Visible = false;
                edit_btn.Visible = false;
                
                return;
            }
            date_text.Value = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd"));

            string query = "select c.sched_id, c.staff_id, lname," +
                " fname, sched_start, sched_end, sched_date," +
                " start_time, end_time, status, shour, sminute, sday, ehour, eminute, eday from staff " +
                "inner join person on staff.person_id = person.person_id  " +
                "inner join dc_sched c on staff.staff_id = c.staff_id " +
                "order by sched_start, start_time";

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

            label2.Visible = false;
            comboBox1.Visible = false;
            status_lbl.Visible = true;
            status.Visible = true;
            edit_btn.Visible = true;

        }
        public void PlayhouseShowToday()
        {
            string cur_date1 = DateTime.Now.Date.ToString("yyyy-MM-dd");

            string query1 = "select dc_sched.sched_id, dc_sched.staff_id, fname" +
               ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
               " status, status2, shour, sminute, sday, ehour, eminute, eday from staff inner join person on staff.person_id = person.person_id" +
               "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date = '" +
                 cur_date1 + "' AND status = 'Playhouse' order by sched_start, start_time";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);
            Debug.WriteLine(query1);
            dataGridView1.DataSource = dt1;
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            if (calendar == "playhouse")
            {
                PlayhouseShowToday();
                return;
            }
            string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");

            string query = "select dc_sched.sched_id, dc_sched.staff_id, fname" +
               ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
               " status, shour, sminute, sday, ehour, eminute, eday from staff inner join person on staff.person_id = person.person_id" +
               "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date = '" +
                 cur_date + "' order by sched_start, start_time";
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
            if (calendar == "playhouse")
            {
                if (SearchByBox.Text == "Name")
                {
                    string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname ,sched_start, sched_end," +
                        " sched_date, start_time, end_time, status, status2, shour, sminute, sday, ehour, eminute, eday" +
                        " from staff inner join person on staff.person_id = person.person_id  " +
                        "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                        "where status = 'Playhouse' AND lname like '%" + inputField.Text + "%' OR fname like '%" + inputField.Text + "%' order by sched_start";
                    //MessageBox.Show(query);
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
                    dataGridView1.Columns["sched_start"].Visible = false;
                    dataGridView1.Columns["sched_end"].Visible = false;
                    dataGridView1.Columns["lname"].HeaderText = "Last Name";
                    dataGridView1.Columns["fname"].HeaderText = "First Name";
                    dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                    dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                    dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                    dataGridView1.Columns["end_time"].HeaderText = "Time End";
                    dataGridView1.Columns["status"].HeaderText = "Shift";
                    dataGridView1.Columns["status2"].HeaderText = "Status";
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
                        "status, status2, shour, sminute, sday, ehour, eminute, eday " +
                        "from staff inner join person on staff.person_id = person.person_id  " +
                        "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                        "where status = 'Playhouse' AND lname like '%" + inputField.Text + "%' order by sched_start";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
                    dataGridView1.Columns["sched_start"].Visible = false;
                    dataGridView1.Columns["sched_end"].Visible = false;
                    dataGridView1.Columns["lname"].HeaderText = "Last Name";
                    dataGridView1.Columns["fname"].HeaderText = "First Name";
                    dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                    dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                    dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                    dataGridView1.Columns["end_time"].HeaderText = "Time End";
                    dataGridView1.Columns["status"].HeaderText = "Shift";
                    dataGridView1.Columns["status2"].HeaderText = "Status";
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
                        "sched_date, start_time, end_time, status, status2, shour, sminute, sday, ehour, eminute, eday from staff " +
                        "inner join person on staff.person_id = person.person_id  " +
                        "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                        "where status = 'Playhouse' AND fname like '%" + inputField.Text + "%' order by sched_start";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
                    dataGridView1.Columns["sched_start"].Visible = false;
                    dataGridView1.Columns["sched_end"].Visible = false;
                    dataGridView1.Columns["lname"].HeaderText = "Last Name";
                    dataGridView1.Columns["fname"].HeaderText = "First Name";
                    dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                    dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                    dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                    dataGridView1.Columns["end_time"].HeaderText = "Time End";
                    dataGridView1.Columns["status"].HeaderText = "Shift";
                    dataGridView1.Columns["status2"].HeaderText = "Status";
                    dataGridView1.Columns["shour"].Visible = false;
                    dataGridView1.Columns["sminute"].Visible = false;
                    dataGridView1.Columns["sday"].Visible = false;
                    dataGridView1.Columns["ehour"].Visible = false;
                    dataGridView1.Columns["eminute"].Visible = false;
                    dataGridView1.Columns["eday"].Visible = false;
                }
            }
            else //DO not cross
            {
                if (SearchByBox.Text == "Name")
                {
                    string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname ,sched_start, sched_end," +
                        " sched_date, start_time, end_time, status, shour, sminute, sday, ehour, eminute, eday" +
                        " from staff inner join person on staff.person_id = person.person_id  " +
                        "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                        "where lname like '%" + inputField.Text + "%' OR fname like '%" + inputField.Text + "%' order by sched_start";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
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
                        "where status like '%" + inputField.Text + "%' order by sched_start";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
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
                        "where lname like '%" + inputField.Text + "%' order by sched_start";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
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
                        "where fname like '%" + inputField.Text + "%' order by sched_start";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
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
               from_date.Text + "' AND sched_date <= '" + to_date.Text + "' order by sched_start, start_time";
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
                from_date.Text + "' AND sched_date <= '" + to_date.Text + "' order by sched_start, start_time";
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
                    "where lname like '%" + inputField.Text + "%' OR fname like '%" + inputField.Text + "%' order by sched_start";
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
                    " end_time, shour, sminute, sday, ehour, eminute, eday, status from staff " +
                    "inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id where status like '%" + inputField.Text + "%' order by sched_start";
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
                    " status , shour, sminute, sday, ehour, eminute, eday from staff " +
                    "inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                    "where lname like '%" + inputField.Text + "%' order by sched_start";
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
                    "where fname like '%" + inputField.Text + "%' order by sched_start";
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
                    "where lname like '%" + inputField.Text + "%' OR fname like '%" + inputField.Text + "%' order by sched_start";
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
                string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname,sched_start, sched_end, sched_date, start_time," +
                    " end_time, status , shour, sminute, sday, ehour, eminute, eday from staff " +
                    "inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id where status like '%" + inputField.Text + "%' order by sched_start";
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
            else if (SearchByBox.Text == "Last Name")
            {
                string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname, sched_start, sched_end, sched_date, start_time, end_time," +
                    " status from staff, shour, sminute, sday, ehour, eminute, eday " +
                    "inner join person on staff.person_id = person.person_id  " +
                    "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                    "where lname like '%" + inputField.Text + "%' order by sched_start";
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
                    "where fname like '%" + inputField.Text + "%' order by sched_start";
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
            if (calendar == "playhouse")
            {
                if (e.RowIndex > -1)
                {
                    selected_user_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["sched_id"].Value.ToString());
                    selected_staff_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["staff_id"].Value.ToString());
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["lname"].Value.ToString() + ", " + dataGridView1.Rows[e.RowIndex].Cells["fname"].Value.ToString();
                    date_text.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["sched_date"].Value.ToString());
                    sHour.Text = dataGridView1.Rows[e.RowIndex].Cells["shour"].Value.ToString();
                    sMin.Text = dataGridView1.Rows[e.RowIndex].Cells["sminute"].Value.ToString();
                    sDay.Text = dataGridView1.Rows[e.RowIndex].Cells["sday"].Value.ToString();
                    eHour.Text = dataGridView1.Rows[e.RowIndex].Cells["ehour"].Value.ToString();
                    eMin.Text = dataGridView1.Rows[e.RowIndex].Cells["eminute"].Value.ToString();
                    eDay.Text = dataGridView1.Rows[e.RowIndex].Cells["eday"].Value.ToString();
                    status.Text = dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString();
                    comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["status2"].Value.ToString();
                }
                return;
            }
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
            if (calendar == "playhouse")
            {
                string cur_date1 = DateTime.Now.Date.ToString("yyyy-MM-dd");

                string query1 = "select dc_sched.sched_id, dc_sched.staff_id, fname" +
                   ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
                   " status, status2, shour, sminute, sday, ehour, eminute, eday from staff inner join person on staff.person_id = person.person_id" +
                   "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date < '" +
                     cur_date1 + "' AND status = 'Playhouse' order by sched_start, start_time";
                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(query1, conn);
                MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                conn.Close();
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);
                Debug.WriteLine(query1);
                dataGridView1.DataSource = dt1;
                return;
            }
            string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");

            string query = "select dc_sched.sched_id, dc_sched.staff_id, fname" +
               ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
               " status, shour, sminute, sday, ehour, eminute, eday " +
               "from staff inner join person on staff.person_id = person.person_id" +
               "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date < '" +
                 cur_date + "' order by sched_start, start_time";
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
            if (calendar == "playhouse")
            {
                string cur_date1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string query1 = "select dc_sched.sched_id, dc_sched.staff_id, fname" +
                   ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
                   " status, status2, shour, sminute, sday, ehour, eminute, eday from staff inner join person on staff.person_id = person.person_id" +
                   "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_start >= '" +
                     cur_date1 + "' AND status = 'Playhouse' order by sched_start, start_time";
                //MessageBox.Show(query1);
                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(query1, conn);
                MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                conn.Close();
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);
                Debug.WriteLine(query1);
                dataGridView1.DataSource = dt1;
                return;
            }
            string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");

            string query = "select dc_sched.sched_id, dc_sched.staff_id, fname" +
               ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
               " status , shour, sminute, sday, ehour, eminute, eday " +
               "from staff inner join person on staff.person_id = person.person_id" +
               "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date >= '" +
                 cur_date + "' order by sched_start, start_time";
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
            if (calendar == "playhouse")
            {
                string start_timeA = sHour.Text + ":" + sMin.Text + " " + sDay.Text;
                string end_timeA = eHour.Text + ":" + eMin.Text + " " + eDay.Text;

                TimeSpan start_time1A = Convert.ToDateTime(start_timeA).TimeOfDay;
                TimeSpan end_time1A = Convert.ToDateTime(end_timeA).TimeOfDay;

                string sched_startA = date_text.Text + " " + start_time1A;
                string sched_endA = date_text.Text + " " + end_time1A;

                DateTime curr_schedDateA = DateTime.Now;

                if (textBox1.Text == "" || date_text.Text == "" || sHour.Text == "" || sMin.Text == "" ||
                    sDay.Text == "" || eHour.Text == "" || eMin.Text == "" || eDay.Text == "" || status.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Please supply missing fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (date_text.Value < now || Convert.ToDateTime(sched_startA) < curr_schedDateA || Convert.ToDateTime(sched_endA) < curr_schedDateA)
                {
                    MessageBox.Show("Not Allowed to Update Past Schedules", "Date Restriction", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                }
                else if (Convert.ToDateTime(sched_startA) >= Convert.ToDateTime(sched_endA))
                {
                    MessageBox.Show("Invalid Start Time & End Time", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (sDay.Text == "PM" && eDay.Text == "AM")
                {
                    MessageBox.Show("Invalid Start Time & End Time", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {

                    string selectquery = "select * from dc_sched where staff_id = '" + selected_staff_id + "' AND sched_date = '" + date_text.Text + "' AND start_time = '" + start_timeA + "' AND end_time = '" + end_timeA + "' AND status = '" + status.Text + "' AND status2 = '"+comboBox1.Text+"' ";
                    string selectquery2 = "SELECT * FROM dc_sched WHERE  ((sched_start <= '" + sched_startA + "'  AND sched_end >= '" + sched_startA + "' )" +
                    "OR(sched_start <= '" + sched_endA + "'  AND sched_end >= '" + sched_endA + "'))" +
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

                            string query0003 = "UPDATE dc_sched SET staff_id = " + selected_staff_id + ", sched_start = '" + sched_startA + "'," +
                            "sched_end = '" + sched_endA + "', sched_date = '" + date_text.Text + "', start_time = '" + start_timeA + "'," +
                            "end_time = '" + end_timeA + "', shour ='" + sHour.Text + "', sminute = '" + sMin.Text + "', sday = '" + sDay.Text + "'," +
                            "ehour = '" + eHour.Text + "',eminute = '" + eMin.Text + "',eday = '" + eDay.Text + "',status ='" + status.Text + "', " +
                            "status2 = '"+comboBox1.Text+"' WHERE sched_id = '" + selected_user_id + "'";
                            conn.Open();
                            MessageBox.Show(query0003);
                            MySqlCommand comm4 = new MySqlCommand(query0003, conn);
                            comm4.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Schedule Successfully Updated");
                        

                        string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");

                        string query = "select dc_sched.sched_id, dc_sched.staff_id, fname" +
                           ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
                           " status, status2, shour, sminute, sday, ehour, eminute, eday " +
                           "from staff inner join person on staff.person_id = person.person_id" +
                           "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date >= '" +
                             cur_date + "' AND status2 = '"+comboBox1.Text+"' order by sched_start, start_time";
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
                return;
            }
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
                    if (status.Text == "Playhouse")
                    {
                        string query0003 = "UPDATE dc_sched SET staff_id = " + selected_staff_id + ", sched_start = '" + sched_start + "'," +
                        "sched_end = '" + sched_end + "', sched_date = '" + date_text.Text + "', start_time = '" + start_time + "'," +
                        "end_time = '" + end_time + "', shour ='" + sHour.Text + "', sminute = '" + sMin.Text + "', sday = '" + sDay.Text + "'," +
                        "ehour = '" + eHour.Text + "',eminute = '" + eMin.Text + "',eday = '" + eDay.Text + "',status ='" + status.Text + "', " +
                        "status2 = 'Scheduled' WHERE sched_id = '" + selected_user_id + "'";
                        conn.Open();
                        MessageBox.Show(query0003);
                        MySqlCommand comm4 = new MySqlCommand(query0003, conn);
                        comm4.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Schedule Successfully Updated");
                    }
                    else
                    {
                        string query0003 = "UPDATE dc_sched SET staff_id = " + selected_staff_id + ", sched_start = '" + sched_start + "'," +
                        "sched_end = '" + sched_end + "', sched_date = '" + date_text.Text + "', start_time = '" + start_time + "'," +
                        "end_time = '" + end_time + "', shour ='" + sHour.Text + "', sminute = '" + sMin.Text + "', sday = '" + sDay.Text + "'," +
                        "ehour = '" + eHour.Text + "',eminute = '" + eMin.Text + "',eday = '" + eDay.Text + "',status ='" + status.Text + "', " +
                        "status2 = 'N/A' WHERE sched_id = '" + selected_user_id + "'";
                        MessageBox.Show(query0003);
                        conn.Open();
                        MySqlCommand comm4 = new MySqlCommand(query0003, conn);
                        comm4.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Schedule Successfully Updated");
                    }

                    string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");

                    string query = "select dc_sched.sched_id, dc_sched.staff_id, fname" +
                       ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
                       " status , shour, sminute, sday, ehour, eminute, eday " +
                       "from staff inner join person on staff.person_id = person.person_id" +
                       "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date >= '" +
                         cur_date + "' order by sched_start, start_time";
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
            if (calendar == "playhouse")
            {
                string start_timeA = sHour.Text + ":" + sMin.Text + " " + sDay.Text;
                string end_timeA = eHour.Text + ":" + eMin.Text + " " + eDay.Text;

                TimeSpan start_time1A = Convert.ToDateTime(start_timeA).TimeOfDay;
                TimeSpan end_time1A = Convert.ToDateTime(end_timeA).TimeOfDay;

                string sched_startA = date_text.Text + " " + start_time1A;
                string sched_endA = date_text.Text + " " + end_time1A;

                DateTime curr_schedDateA = DateTime.Now;

                if (textBox1.Text == "" || date_text.Text == "" || sHour.Text == "" || sMin.Text == "" ||
                    sDay.Text == "" || eHour.Text == "" || eMin.Text == "" || eDay.Text == "" || status.Text == "")
                {
                    MessageBox.Show("Please supply missing fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (date_text.Value < now || Convert.ToDateTime(sched_startA) < curr_schedDateA || Convert.ToDateTime(sched_endA) < curr_schedDateA)
                {
                    MessageBox.Show("Not Allowed to Delete Past Schedules", "Date Restriction", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                DialogResult iExitA;
                iExitA = MessageBox.Show("Are you sure?", "Confirm Delete ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (iExitA == DialogResult.OK)
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


                string cur_dateA = DateTime.Now.Date.ToString("yyyy-MM-dd");

                string queryA = "select dc_sched.sched_id, dc_sched.staff_id, fname" +
                   ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
                   " status, status2, shour, sminute, sday, ehour, eminute, eday " +
                   "from staff inner join person on staff.person_id = person.person_id" +
                   "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date >= '" +
                     cur_dateA + "' AND status = 'Playhouse' order by sched_start, start_time";
                conn.Open();
                MySqlCommand commA = new MySqlCommand(queryA, conn);
                MySqlDataAdapter adpA = new MySqlDataAdapter(commA);
                conn.Close();
                DataTable dtA = new DataTable();
                adpA.Fill(dtA);
                //Debug.WriteLine(query);
                dataGridView1.DataSource = dtA;
                return;
            }
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
               " status, status2, shour, sminute, sday, ehour, eminute, eday " +
               "from staff inner join person on staff.person_id = person.person_id" +
               "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date >= '" +
                 cur_date + "' AND status = 'Playhouse' order by sched_start, start_time";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            //Debug.WriteLine(query);
            dataGridView1.DataSource = dt;

        }

        private void inputField_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (calendar == "playhouse")
            {
                if (SearchByBox.Text == "Name")
                {
                    string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname ,sched_start, sched_end," +
                        " sched_date, start_time, end_time, status, status2, shour, sminute, sday, ehour, eminute, eday" +
                        " from staff inner join person on staff.person_id = person.person_id  " +
                        "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                        "where status = 'Playhouse' AND (lname like '%" + inputField.Text + "%' OR fname like '%" + inputField.Text + "%') order by sched_start";
                    //MessageBox.Show(query);
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
                    dataGridView1.Columns["sched_start"].Visible = false;
                    dataGridView1.Columns["sched_end"].Visible = false;
                    dataGridView1.Columns["lname"].HeaderText = "Last Name";
                    dataGridView1.Columns["fname"].HeaderText = "First Name";
                    dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                    dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                    dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                    dataGridView1.Columns["end_time"].HeaderText = "Time End";
                    dataGridView1.Columns["status"].HeaderText = "Shift";
                    dataGridView1.Columns["status2"].HeaderText = "Status";
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
                        "status, status2, shour, sminute, sday, ehour, eminute, eday " +
                        "from staff inner join person on staff.person_id = person.person_id  " +
                        "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                        "where status = 'Playhouse' AND lname like '%" + inputField.Text + "%' order by sched_start";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
                    dataGridView1.Columns["sched_start"].Visible = false;
                    dataGridView1.Columns["sched_end"].Visible = false;
                    dataGridView1.Columns["lname"].HeaderText = "Last Name";
                    dataGridView1.Columns["fname"].HeaderText = "First Name";
                    dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                    dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                    dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                    dataGridView1.Columns["end_time"].HeaderText = "Time End";
                    dataGridView1.Columns["status"].HeaderText = "Shift";
                    dataGridView1.Columns["status2"].HeaderText = "Status";
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
                        "sched_date, start_time, end_time, status, status2, shour, sminute, sday, ehour, eminute, eday from staff " +
                        "inner join person on staff.person_id = person.person_id  " +
                        "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                        "where status = 'Playhouse' AND fname like '%" + inputField.Text + "%' order by sched_start";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
                    dataGridView1.Columns["sched_start"].Visible = false;
                    dataGridView1.Columns["sched_end"].Visible = false;
                    dataGridView1.Columns["lname"].HeaderText = "Last Name";
                    dataGridView1.Columns["fname"].HeaderText = "First Name";
                    dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                    dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                    dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                    dataGridView1.Columns["end_time"].HeaderText = "Time End";
                    dataGridView1.Columns["status"].HeaderText = "Shift";
                    dataGridView1.Columns["status2"].HeaderText = "Status";
                    dataGridView1.Columns["shour"].Visible = false;
                    dataGridView1.Columns["sminute"].Visible = false;
                    dataGridView1.Columns["sday"].Visible = false;
                    dataGridView1.Columns["ehour"].Visible = false;
                    dataGridView1.Columns["eminute"].Visible = false;
                    dataGridView1.Columns["eday"].Visible = false;
                }
            }
            else //DO not cross
            {
                if (SearchByBox.Text == "Name")
                {
                    string query = "select dc_sched.sched_id, dc_sched.staff_id, lname, fname ,sched_start, sched_end," +
                        " sched_date, start_time, end_time, status, shour, sminute, sday, ehour, eminute, eday" +
                        " from staff inner join person on staff.person_id = person.person_id  " +
                        "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                        "where lname like '%" + inputField.Text + "%' OR fname like '%" + inputField.Text + "%' order by sched_start";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
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
                        "where status like '%" + inputField.Text + "%' order by sched_start";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
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
                        "where lname like '%" + inputField.Text + "%' order by sched_start";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
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
                        "where fname like '%" + inputField.Text + "%' order by sched_start";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["staff_id"].Visible = false; dataGridView1.Columns["sched_id"].Visible = false;
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
        }

        private void CalendarVer2_Shown(object sender, EventArgs e)
        {
            StaffOvertime();
            StaffPending();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (selected_staff_id == 0)
            {
                MessageBox.Show("Invalid");
            }
            else
            {
                string check = "select status2 from dc_sched WHERE sched_id = " + selected_user_id + "";
                string query = "UPDATE dc_sched SET status2 = 'OUT' WHERE sched_id = " + selected_user_id + "";
                conn.Open();
                MySqlCommand comm_check = new MySqlCommand(check, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm_check);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                conn.Close();
                //MessageBox.Show(dt.Rows.Count + "");
                foreach (DataRow dr in dt.Rows)
                {
                    string checker = dr["status2"] + "";
                    MessageBox.Show("Checker" + checker);
                    if (checker == "IN")
                    {
                        DialogResult dialogResult = MessageBox.Show("Staff Time has not expired yet", "Are you sure ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.OK)
                        {
                            conn.Open();
                            MySqlCommand comm = new MySqlCommand(query, conn);
                            comm.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Log out success");
                            PlayhouseShowToday();
                        }
                        else if (dialogResult == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else if (checker == "Overtime")
                    {
                        //MessageBox.Show(query);
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand(query, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Log out success");
                        PlayhouseShowToday();
                    }
                    else
                    {
                        MessageBox.Show("Staff already logged out");
                    }
                }
            }

        }
    }
}
