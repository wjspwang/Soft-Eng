using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class PlayhouseManagement : Form
    {
        public Form previousform;
        MySqlConnection conn;
        public PlayhouseManagement()
        {
            InitializeComponent();
        }
        public PlayhouseManagement(int cust_id, string fname, string lname)
        {
            InitializeComponent();
            this.selected_user_id = cust_id;
            this.fname.Text = fname;
            this.lname.Text = lname;
        }
        public int selected_user_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        private void loadall()
        {

            cust_id.Text = this.selected_user_id + "";
            string curr_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string curr_time = DateTime.Now.ToString("hh:mm tt");
            string curr_sched = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string query1 = "select playhouse_id, playhouse.customer_id, lname," +
                " fname, sched_start, sched_end, sched_date," +
                " start_time, end_time, status from person " +
                "inner join playhouse on person.person_id = playhouse.customer_id " +
                "order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            dataGridView2.DataSource = dt1;
            dataGridView2.Columns["playhouse_id"].Visible = false;
            dataGridView2.Columns["customer_id"].Visible = false;
            dataGridView2.Columns["sched_start"].Visible = false;
            dataGridView2.Columns["sched_end"].Visible = false;
            dataGridView2.Columns["lname"].HeaderText = "Last Name";
            dataGridView2.Columns["fname"].HeaderText = "First Name";
            dataGridView2.Columns["sched_date"].HeaderText = "Scheduled Date";
            dataGridView2.Columns["sched_date"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridView2.Columns["start_time"].HeaderText = "Time Start";
            dataGridView2.Columns["end_time"].HeaderText = "Time End";
            dataGridView2.Columns["status"].HeaderText = "Status";

            //dataGridView2.Rows[-1].Selected = true;
            
            string updateToExpire = "UPDATE playhouse SET status = 'Overtime' WHERE sched_end <= '"+curr_sched+"' ";
            
            conn.Open();

            MySqlCommand comm = new MySqlCommand(updateToExpire, conn);
            comm.ExecuteNonQuery();
            conn.Close();

        }

        private void btnSave_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");
            loadall();

            string query = "select * from person where person_type = 1";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["person_id"].HeaderText = "Customer ID";
            dataGridView1.Columns["lname"].HeaderText = "Family Name";
            dataGridView1.Columns["fname"].HeaderText = "Given Name";
            dataGridView1.Columns["gender"].HeaderText = "Gender";
            dataGridView1.Columns["contact"].HeaderText = "Contact no.";
            dataGridView1.Columns["person_type"].Visible = false;

           
        }

        private void PlayhouseManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            previousform.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }



        private void new_cust_Click(object sender, EventArgs e)
        {
            Profiles a = new Profiles();
            TabControl b = new TabControl();
            a.tabc.SelectedTab = a.tabc.TabPages["tabPage1"];
            a.Show();
            a.previousform = this;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadall();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if(cust_id.Text == ""|| cust_id.Text == Convert.ToString(0))
            {
                MessageBox.Show("Invalid");
            }
            else
            {
                LoginTimePlayhouse form = new LoginTimePlayhouse();               
                form.previousform = this;
                form.selected_user_id = Convert.ToInt32(this.selected_user_id);
                form.lname = lname.Text;
                form.fname = fname.Text;
                form.Show();
            }
            
            
        }
        int selected_playhouse_id = -1;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime time, etime;

            int select_cust_id;

            if (e.RowIndex > -1)
            {

                selected_playhouse_id = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["playhouse_id"].Value.ToString());
                select_cust_id = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["customer_id"].Value.ToString());
                lname.Text = dataGridView2.Rows[e.RowIndex].Cells["lname"].Value.ToString();
                fname.Text = dataGridView2.Rows[e.RowIndex].Cells["fname"].Value.ToString();
                //status.Text = dataGridView2.Rows[e.RowIndex].Cells["status"].Value.ToString();
                time = Convert.ToDateTime(dataGridView2.Rows[e.RowIndex].Cells["start_time"].Value.ToString());
                etime = Convert.ToDateTime(dataGridView2.Rows[e.RowIndex].Cells["end_time"].Value.ToString());
                selected_user_id = select_cust_id;



            }
            cust_id.Text = selected_user_id + "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cust_id.Text == "" || cust_id.Text == Convert.ToString(0))
            {
                MessageBox.Show("Invalid");
            }
            else
            {
                    string check = "select status from playhouse WHERE playhouse_id = " + selected_playhouse_id + "";
                    string query = "UPDATE playhouse SET status = 'OUT' WHERE playhouse_id = "+selected_playhouse_id+"";
                    conn.Open();
                    MySqlCommand comm_check = new MySqlCommand(check, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm_check);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    conn.Close();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string checker = dr["status"] + "";
                        if (checker == "IN")
                        {
                            DialogResult dialogResult = MessageBox.Show("Customer Time has not expired yet", "Are you sure ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.OK)
                            {
                            conn.Open();
                            MySqlCommand comm = new MySqlCommand(query, conn);
                            comm.ExecuteNonQuery();
                            conn.Close();
                            ShowTodayIn();
                            fname.Clear();
                            lname.Clear();
                            }
                            else if (dialogResult == DialogResult.Cancel)
                            {
                            return;
                            }
                        }else if(checker == "Overtime")
                    {
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand(query, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                        ShowTodayIn();
                        fname.Clear();
                        lname.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Customer already logged out");
                    }
                    }
            }
            
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cust_id.Text == "" || cust_id.Text == Convert.ToString(0))
            {
                MessageBox.Show("Invalid");
            }
            else
            {
            //string endtime = eHour.Text + ":" + eMin.Text;
            PlayhouseExtend frm4 = new PlayhouseExtend();
            frm4.selected_user_id = Convert.ToInt32(this.selected_user_id);
            frm4.lname = lname.Text;
            frm4.fname = fname.Text;
            frm4.Show();
            frm4.previousform = this;
            }
            
        }

        private void PlayhouseManagement_Activated(object sender, EventArgs e)
        {
            string curr_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            //fname.Text = firstname;
            //lname.Text = lastname;
            //cust_id.Text = selected_user_id + "";
            string query1 = "select playhouse_id, playhouse.customer_id, lname," +
                " fname, sched_start, sched_end, sched_date," +
                " start_time, end_time, status from person " +
                "inner join playhouse on person.person_id = playhouse.customer_id " +
                "where sched_date = '" + curr_date + "'"+
                "order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            dataGridView2.DataSource = dt1;
            dataGridView2.Columns["playhouse_id"].Visible = false;
            dataGridView2.Columns["customer_id"].Visible = false;
            dataGridView2.Columns["sched_start"].Visible = false;
            dataGridView2.Columns["sched_end"].Visible = false;
            dataGridView2.Columns["lname"].HeaderText = "Last Name";
            dataGridView2.Columns["fname"].HeaderText = "First Name";
            dataGridView2.Columns["sched_date"].HeaderText = "Scheduled Date";
            dataGridView2.Columns["sched_date"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridView2.Columns["start_time"].HeaderText = "Time Start";
            dataGridView2.Columns["end_time"].HeaderText = "Time End";
            dataGridView2.Columns["status"].HeaderText = "Status";
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            gbSelect.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadall();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowTodayIn();
        }

        private void ShowTodayIn()
        {
            string curr_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            fname.Text = firstname;
            lname.Text = lastname;
            cust_id.Text = selected_user_id + "";
            string query1 = "select playhouse_id, playhouse.customer_id, lname," +
                " fname, sched_start, sched_end, sched_date," +
                " start_time, end_time, status from person " +
                "inner join playhouse on person.person_id = playhouse.customer_id " +
                "where status = 'IN'" +
                "order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            dataGridView2.DataSource = dt1;
            dataGridView2.Columns["playhouse_id"].Visible = false;
            dataGridView2.Columns["customer_id"].Visible = false;
            dataGridView2.Columns["sched_start"].Visible = false;
            dataGridView2.Columns["sched_end"].Visible = false;
            dataGridView2.Columns["lname"].HeaderText = "Last Name";
            dataGridView2.Columns["fname"].HeaderText = "First Name";
            dataGridView2.Columns["sched_date"].HeaderText = "Scheduled Date";
            dataGridView2.Columns["sched_date"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridView2.Columns["start_time"].HeaderText = "Time Start";
            dataGridView2.Columns["end_time"].HeaderText = "Time End";
            dataGridView2.Columns["status"].HeaderText = "Status";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string curr_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            fname.Text = firstname;
            lname.Text = lastname;
            cust_id.Text = selected_user_id + "";
            string query1 = "select playhouse_id, playhouse.customer_id, lname," +
                " fname, sched_start, sched_end, sched_date," +
                " start_time, end_time, status from person " +
                "inner join playhouse on person.person_id = playhouse.customer_id " +
                "where status = 'Overtime'" +
                "order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            dataGridView2.DataSource = dt1;
            dataGridView2.Columns["playhouse_id"].Visible = false;
            dataGridView2.Columns["customer_id"].Visible = false;
            dataGridView2.Columns["sched_start"].Visible = false;
            dataGridView2.Columns["sched_end"].Visible = false;
            dataGridView2.Columns["lname"].HeaderText = "Last Name";
            dataGridView2.Columns["fname"].HeaderText = "First Name";
            dataGridView2.Columns["sched_date"].HeaderText = "Scheduled Date";
            dataGridView2.Columns["sched_date"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridView2.Columns["start_time"].HeaderText = "Time Start";
            dataGridView2.Columns["end_time"].HeaderText = "Time End";
            dataGridView2.Columns["status"].HeaderText = "Status";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowTodayAll();
        }

        private void ShowTodayAll()
        {
            string curr_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            fname.Text = firstname;
            lname.Text = lastname;
            cust_id.Text = selected_user_id + "";
            string query1 = "select playhouse_id, playhouse.customer_id, lname," +
                " fname, sched_start, sched_end, sched_date," +
                " start_time, end_time, status from person " +
                "inner join playhouse on person.person_id = playhouse.customer_id " +
                "where sched_date = '" + curr_date + "'" +
                "order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            dataGridView2.DataSource = dt1;
            dataGridView2.Columns["playhouse_id"].Visible = false;
            dataGridView2.Columns["customer_id"].Visible = false;
            dataGridView2.Columns["sched_start"].Visible = false;
            dataGridView2.Columns["sched_end"].Visible = false;
            dataGridView2.Columns["lname"].HeaderText = "Last Name";
            dataGridView2.Columns["fname"].HeaderText = "First Name";
            dataGridView2.Columns["sched_date"].HeaderText = "Scheduled Date";
            dataGridView2.Columns["sched_date"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridView2.Columns["start_time"].HeaderText = "Time Start";
            dataGridView2.Columns["end_time"].HeaderText = "Time End";
            dataGridView2.Columns["status"].HeaderText = "Status";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string curr_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            fname.Text = firstname;
            lname.Text = lastname;
            cust_id.Text = selected_user_id + "";
            string query1 = "select playhouse_id, playhouse.customer_id, lname," +
                " fname, sched_start, sched_end, sched_date," +
                " start_time, end_time, status from person " +
                "inner join playhouse on person.person_id = playhouse.customer_id " +
                "where status = 'Overtime' AND sched_date = '"+curr_date+"'" +
                "order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            dataGridView2.DataSource = dt1;
            dataGridView2.Columns["playhouse_id"].Visible = false;
            dataGridView2.Columns["customer_id"].Visible = false;
            dataGridView2.Columns["sched_start"].Visible = false;
            dataGridView2.Columns["sched_end"].Visible = false;
            dataGridView2.Columns["lname"].HeaderText = "Last Name";
            dataGridView2.Columns["fname"].HeaderText = "First Name";
            dataGridView2.Columns["sched_date"].HeaderText = "Scheduled Date";
            dataGridView2.Columns["sched_date"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridView2.Columns["start_time"].HeaderText = "Time Start";
            dataGridView2.Columns["end_time"].HeaderText = "Time End";
            dataGridView2.Columns["status"].HeaderText = "Status";
        }

        private void status_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            /*DateTime time, etime;
            string shour, smin, sday,
                ehour, emin, eday; ;
            if (e.RowIndex > -1)
            {

                selected_playhouse_id = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["playhouse_id"].Value.ToString());
                selected_user_id = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["customer_id"].Value.ToString());
                lname.Text = dataGridView2.Rows[e.RowIndex].Cells["lname"].Value.ToString();
                fname.Text = dataGridView2.Rows[e.RowIndex].Cells["fname"].Value.ToString();
                status.Text = dataGridView2.Rows[e.RowIndex].Cells["status"].Value.ToString();
                time = Convert.ToDateTime(dataGridView2.Rows[e.RowIndex].Cells["start_time"].Value.ToString());
                etime = Convert.ToDateTime(dataGridView2.Rows[e.RowIndex].Cells["end_time"].Value.ToString());
                cust_id.Text = Convert.ToString(selected_user_id);

                shour = time.Hour.ToString();
                smin = time.Minute.ToString();
                sday = time.Day.ToString();
                ehour = etime.Hour.ToString();
                emin = etime.Minute.ToString();
                eday = etime.Day.ToString();

                string ampm;
                if (Convert.ToInt32(shour) > 12 && Convert.ToInt32(ehour) > 12)
                {
                    shour = Convert.ToString(Convert.ToInt32(shour) - 12);
                    ehour = Convert.ToString(Convert.ToInt32(ehour) - 12);
                    ampm = "PM";
                }
                else if (Convert.ToInt32(shour) > 12 && Convert.ToInt32(ehour) < 12)
                {
                    shour = Convert.ToString(Convert.ToInt32(shour) - 12);
                    ampm = "PM";
                }
                else if (Convert.ToInt32(ehour) > 12 && Convert.ToInt32(ehour) < 12)
                {
                    ehour = Convert.ToString(Convert.ToInt32(ehour) - 12);
                    ampm = "PM";
                }
                else
                {
                    ampm = "AM";
                }

                switch (Convert.ToInt32(smin))
                {
                    case 0:
                        smin = "00";
                        break;
                    case 1:
                        smin = "01";
                        break;
                    case 2:
                        smin = "02";
                        break;
                    case 3:
                        smin = "03";
                        break;
                    case 4:
                        smin = "04";
                        break;
                    case 5:
                        smin = "05";
                        break;
                    case 6:
                        smin = "06";
                        break;
                    case 7:
                        smin = "07";
                        break;
                    case 8:
                        smin = "08";
                        break;
                    case 9:
                        smin = "09";
                        break;
                    default:
                        break;


                }
                switch (Convert.ToInt32(emin))
                {
                    case 0:
                        emin = "00";
                        break;
                    case 1:
                        emin = "01";
                        break;
                    case 2:
                        emin = "02";
                        break;
                    case 3:
                        emin = "03";
                        break;
                    case 4:
                        emin = "04";
                        break;
                    case 5:
                        emin = "05";
                        break;
                    case 6:
                        emin = "06";
                        break;
                    case 7:
                        emin = "07";
                        break;
                    case 8:
                        emin = "08";
                        break;
                    case 9:
                        emin = "09";
                        break;
                    default:
                        break;


                }

                sHour.Text = shour;
                sMin.Text = smin;
                sDay.Text = ampm;
                eHour.Text = ehour;
                eMin.Text = emin;
                eDay.Text = ampm;
            }
            */
        }

        private void cust_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null || textBox1.Text != "")
            {
                string query = "select * from person where person_type = 1 AND lname like '%" + textBox1.Text + "%'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["person_id"].HeaderText = "Customer ID";
                dataGridView1.Columns["lname"].HeaderText = "Family Name";
                dataGridView1.Columns["fname"].HeaderText = "Given Name";
                dataGridView1.Columns["gender"].HeaderText = "Gender";
                dataGridView1.Columns["contact"].HeaderText = "Contact no.";
                dataGridView1.Columns["person_type"].Visible = false;
            }
            else if (textBox2.Text != null || textBox2.Text != "")
            {


                string query = "select * from person where person_type = 1 where lname = '" + textBox2.Text + "'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["person_id"].HeaderText = "Customer ID";
                dataGridView1.Columns["lname"].HeaderText = "Family Name";
                dataGridView1.Columns["fname"].HeaderText = "Given Name";
                dataGridView1.Columns["gender"].HeaderText = "Gender";
                dataGridView1.Columns["contact"].HeaderText = "Contact no.";
                dataGridView1.Columns["person_type"].Visible = false;


            }
            else
            {
                string query = "select * from person where person_type = 1 where lname = '" + textBox2.Text + "' && fname ='" + textBox1.Text + "'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["person_id"].HeaderText = "Customer ID";
                dataGridView1.Columns["lname"].HeaderText = "Family Name";
                dataGridView1.Columns["fname"].HeaderText = "Given Name";
                dataGridView1.Columns["gender"].HeaderText = "Gender";
                dataGridView1.Columns["contact"].HeaderText = "Contact no.";
                dataGridView1.Columns["person_type"].Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {


                selected_user_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["person_id"].Value.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["lname"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["fname"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["person_id"].Value.ToString();

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            gbSelect.Visible = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == null || textBox3.Text == "" || Regex.IsMatch(textBox3.Text, @"^[a-zA-Z]+$"))
            {
                return;
            }
            else
            {
                cust_id.Text = Convert.ToInt32(textBox3.Text) + "";
                selected_user_id = Convert.ToInt32(textBox3.Text);
                fname.Text = textBox2.Text;
                lname.Text = textBox1.Text;
                gbSelect.Visible = false;
            }
        }

        private void gbSelect_Enter(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            dt = dataGridView2.DataSource as DataTable;
            // MessageBox.Show(dataGridView1.DataSource + "");
            ds.Tables.Add(dt);
            Form4 f = new Form4(ds, "playhouse_report");
            f.Show();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void PlayhouseManagement_Shown(object sender, EventArgs e)
        {
            string curr_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            cust_id.Text = selected_user_id + "";
            string query1 = "select playhouse_id, playhouse.customer_id, lname," +
                " fname, sched_start, sched_end, sched_date," +
                " start_time, end_time, status from person " +
                "inner join playhouse on person.person_id = playhouse.customer_id " +
                "where status = 'Overtime' AND sched_date = '" + curr_date + "'" +
                "order by sched_date, start_time";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            if (dt1.Rows.Count > 0)
            {
                MessageBox.Show(dt1.Rows.Count + " Customer Overtime","Overtime Notification",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
    }
        
    }
