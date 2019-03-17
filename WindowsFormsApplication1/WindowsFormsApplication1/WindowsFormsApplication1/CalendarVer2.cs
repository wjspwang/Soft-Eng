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
            string query = "select dc_sched.staff_id, lname," +
                " fname, sched_start, sched_end, sched_date," +
                " start_time, end_time, status from staff " +
                "inner join person on staff.person_id = person.person_id  " +
                "inner join dc_sched on staff.staff_id = dc_sched.staff_id " +
                "order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["staff_id"].Visible = false;
            dataGridView1.Columns["sched_start"].Visible = false;
            dataGridView1.Columns["sched_end"].Visible = false;
            dataGridView1.Columns["lname"].HeaderText = "Last Name";
            dataGridView1.Columns["fname"].HeaderText = "First Name";
            dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
            dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
            dataGridView1.Columns["start_time"].HeaderText = "Time Start";
            dataGridView1.Columns["end_time"].HeaderText = "Time End";
            dataGridView1.Columns["status"].HeaderText = "Shift";



        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            
            string query = "select dc_sched.staff_id, fname" +
               ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
               " status from staff inner join person on staff.person_id = person.person_id" +
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
                string query = "select dc_sched.staff_id, lname, fname ,sched_start, sched_end, sched_date, start_time, end_time, status from staff inner join person on staff.person_id = person.person_id  inner join dc_sched on staff.staff_id = dc_sched.staff_id where lname like '%" + inputField.Text + "%' OR fname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
            }
            else if (SearchByBox.Text == "Shift")
            {
                string query = "select dc_sched.staff_id, CONCAT(lname,', ',fname) AS Staff ,sched_start, sched_end, sched_date, start_time, end_time, status from staff inner join person on staff.person_id = person.person_id  inner join dc_sched on staff.staff_id = dc_sched.staff_id where status like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
            }
            else if (SearchByBox.Text == "Last Name")
            {
                string query = "select dc_sched.staff_id, lname, fname, sched_start, sched_end, sched_date, start_time, end_time, status from staff inner join person on staff.person_id = person.person_id  inner join dc_sched on staff.staff_id = dc_sched.staff_id where lname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
            }
            else if (SearchByBox.Text == "First Name")
            {
                string query = "select dc_sched.staff_id, lname, fname, sched_start, sched_end, sched_date, start_time, end_time, status from staff inner join person on staff.person_id = person.person_id  inner join dc_sched on staff.staff_id = dc_sched.staff_id where fname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
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
            string query = "select dc_sched.staff_id, CONCAT(lname,', ',fname)" +
               " AS Staff ,sched_start, sched_end, sched_date, start_time, end_time," +
               " status from staff inner join person on staff.person_id = person.person_id" +
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
            
            string query = "select dc_sched.staff_id, CONCAT(lname,', ',fname)" +
                " AS Staff ,sched_start, sched_end, sched_date, start_time, end_time," +
                " status from staff inner join person on staff.person_id = person.person_id" +
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
                string query = "select dc_sched.staff_id, lname, fname ,sched_start, sched_end, sched_date, start_time, end_time, status from staff inner join person on staff.person_id = person.person_id  inner join dc_sched on staff.staff_id = dc_sched.staff_id where lname like '%" + inputField.Text + "%' OR fname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
            }
            else if (SearchByBox.Text == "Shift")
            {
                string query = "select dc_sched.staff_id, CONCAT(lname,', ',fname) AS Staff ,sched_start, sched_end, sched_date, start_time, end_time, status from staff inner join person on staff.person_id = person.person_id  inner join dc_sched on staff.staff_id = dc_sched.staff_id where status like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
            }
            else if (SearchByBox.Text == "Last Name")
            {
                string query = "select dc_sched.staff_id, lname, fname, sched_start, sched_end, sched_date, start_time, end_time, status from staff inner join person on staff.person_id = person.person_id  inner join dc_sched on staff.staff_id = dc_sched.staff_id where lname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
            }
            else if (SearchByBox.Text == "First Name")
            {
                string query = "select dc_sched.staff_id, lname, fname, sched_start, sched_end, sched_date, start_time, end_time, status from staff inner join person on staff.person_id = person.person_id  inner join dc_sched on staff.staff_id = dc_sched.staff_id where fname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
            }
        }

        private void inputField_KeyUp(object sender, KeyEventArgs e)
        {
            if (SearchByBox.Text == "Name")
            {
                string query = "select dc_sched.staff_id, lname, fname ,sched_start, sched_end, sched_date, start_time, end_time, status from staff inner join person on staff.person_id = person.person_id  inner join dc_sched on staff.staff_id = dc_sched.staff_id where lname like '%" + inputField.Text + "%' OR fname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
            }
            else if (SearchByBox.Text == "Shift")
            {
                string query = "select dc_sched.staff_id, CONCAT(lname,', ',fname) AS Staff ,sched_start, sched_end, sched_date, start_time, end_time, status from staff inner join person on staff.person_id = person.person_id  inner join dc_sched on staff.staff_id = dc_sched.staff_id where status like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
            }
            else if (SearchByBox.Text == "Last Name")
            {
                string query = "select dc_sched.staff_id, lname, fname, sched_start, sched_end, sched_date, start_time, end_time, status from staff inner join person on staff.person_id = person.person_id  inner join dc_sched on staff.staff_id = dc_sched.staff_id where lname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
            }
            else if (SearchByBox.Text == "First Name")
            {
                string query = "select dc_sched.staff_id, lname, fname, sched_start, sched_end, sched_date, start_time, end_time, status from staff inner join person on staff.person_id = person.person_id  inner join dc_sched on staff.staff_id = dc_sched.staff_id where fname like '%" + inputField.Text + "%' order by sched_date";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["staff_id"].Visible = false;
                dataGridView1.Columns["sched_start"].Visible = false;
                dataGridView1.Columns["sched_end"].Visible = false;
                dataGridView1.Columns["lname"].HeaderText = "Last Name";
                dataGridView1.Columns["fname"].HeaderText = "First Name";
                dataGridView1.Columns["sched_date"].HeaderText = "Scheduled Date";
                dataGridView1.Columns["sched_date"].DefaultCellStyle.Format = dateFormat;
                dataGridView1.Columns["start_time"].HeaderText = "Time Start";
                dataGridView1.Columns["end_time"].HeaderText = "Time End";
                dataGridView1.Columns["status"].HeaderText = "Shift";
            
        }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //past sched
        private void button3_Click(object sender, EventArgs e)
        {
            string cur_date = DateTime.Now.Date.ToString("yyyy-MM-dd");

            string query = "select dc_sched.staff_id, fname" +
               ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
               " status from staff inner join person on staff.person_id = person.person_id" +
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

            string query = "select dc_sched.staff_id, fname" +
               ", lname ,sched_start, sched_end, sched_date, start_time, end_time," +
               " status from staff inner join person on staff.person_id = person.person_id" +
               "  inner join dc_sched on staff.staff_id = dc_sched.staff_id where sched_date >= '" +
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
    }
}
