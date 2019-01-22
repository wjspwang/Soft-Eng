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
    public partial class PlayhouseManagement : Form
    {
        public Form previousform;
        MySqlConnection conn;
        public PlayhouseManagement()
        {
            InitializeComponent();
        }

        private void loadall()
        {
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

            /*string query1 = "select * from playhouse";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);
            dataGridView2.DataSource = dt1;*/

            string query1 = "select playhouse.customer_id, lname," +
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
            dataGridView2.Columns["customer_id"].Visible = false;
            dataGridView2.Columns["sched_start"].Visible = false;
            dataGridView2.Columns["sched_end"].Visible = false;
            dataGridView2.Columns["lname"].HeaderText = "Last Name";
            dataGridView2.Columns["fname"].HeaderText = "First Name";
            dataGridView2.Columns["sched_date"].HeaderText = "Scheduled Date";
            dataGridView2.Columns["start_time"].HeaderText = "Time Start";
            dataGridView2.Columns["end_time"].HeaderText = "Time End";
            dataGridView2.Columns["status"].HeaderText = "Status";

        }

        private void btnSave_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");
            loadall();
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
            DateTime cur_date = DateTime.Now;
            TimeSpan cur_time = DateTime.Now.TimeOfDay;
            DateTime input_Date = Convert.ToDateTime(date.Text);
            string login_time = DateTime.Now.TimeOfDay.ToString("HH:mm dd");



            if (selected_user_id == -1)
            {
                MessageBox.Show("case 1 : No Staff ID");
            }
            else if (lname.Text == "" || fname.Text == null)
            {
                MessageBox.Show("case 2 : No Customer Selected");
            }
            else if (date.Text == "" || date.Text == null)
            {
                MessageBox.Show("case 3 : No Date");
            }
            else if (input_Date.Date < cur_date.Date)
            {
                MessageBox.Show("case 4 : Scheduled for past date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (sHour.Text == "" || sHour.Text == null ||
                sMin.Text == "" || sMin.Text == null ||
                eHour.Text == "" || eHour.Text == null ||
                eMin.Text == "" || eMin.Text == null ||
                sDay.Text == "" || eDay.Text == null)
            {
                MessageBox.Show("case 5 : No Start Time/ End time");
            }
            else if (sHour.Text != "13")
            {
                int sHour_int = Convert.ToInt32(sHour.Text);
                int eHour_int = Convert.ToInt32(eHour.Text);
                int sMin_int = Convert.ToInt32(sMin.Text);
                int eMin_int = Convert.ToInt32(eMin.Text);


                if (sHour_int >= eHour_int &&
                    sMin_int >= eMin_int && sHour.Text != "12")
                {
                    MessageBox.Show("case 6 : Invalid Time.", "Invalid Start/End Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (status.Text == "" || status.Text == null)
                {
                    MessageBox.Show("case 7 : No Activity");
                }
                else
                {
                    string sched_start = date.Text + " " + sHour.Text + ":" + sMin.Text;
                    string sched_end = date.Text + " " + eHour.Text + ":" + eMin.Text;
                    string start_time = sHour.Text + ":" + sMin.Text + " " + sDay.Text;
                    string end_time = eHour.Text + ":" + eMin.Text + " " + eDay.Text;

                    TimeSpan start_time1 = Convert.ToDateTime(start_time).TimeOfDay;
                    if (input_Date.Date == cur_date.Date && start_time1 < cur_time)
                    {
                        MessageBox.Show("case 4 : Scheduled for past time.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string selectquery = "select * from playhouse where customer_id = '" + cust_id.Text + "' AND sched_date = '" + date.Text + "' AND start_time = '" + start_time + "' AND end_time = '" + end_time + "' ";
                        string selectquery2 = "select * from playhouse where customer_id = '" + cust_id.Text + "' AND sched_date = '" + date.Text + "' AND start_time = '" + start_time + "' ";
                        string stquery = "SELECT * FROM playhouse WHERE ('" + sched_start + "' BETWEEN sched_start AND sched_end) OR ('" + sched_end + "' BETWEEN sched_start AND sched_end) ";
                        string etquery = "SELECT * FROM playhouse WHERE (sched_start BETWEEN '" + sched_start + "' AND '" + sched_end + "' AND customer_id = '" + cust_id.Text + "') OR  (sched_end BETWEEN '" + sched_start + "' AND '" + sched_end + "'AND customer_id = '" + cust_id.Text + "')";

                        conn.Open();

                        MySqlCommand comm1 = new MySqlCommand(selectquery, conn);
                        MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                        DataTable dt1 = new DataTable();
                        adp1.Fill(dt1);

                        MySqlCommand comm2 = new MySqlCommand(selectquery2, conn);
                        MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                        DataTable dt2 = new DataTable();
                        adp2.Fill(dt2);

                        MySqlCommand commStartSelect = new MySqlCommand(stquery, conn);
                        MySqlDataAdapter adps = new MySqlDataAdapter(commStartSelect);
                        DataTable dtst = new DataTable();
                        adps.Fill(dtst);

                        MySqlCommand commEndSelect = new MySqlCommand(etquery, conn);
                        MySqlDataAdapter adpe = new MySqlDataAdapter(commEndSelect);
                        DataTable dtet = new DataTable();
                        adpe.Fill(dtet);

                        conn.Close();




                        if (dt1.Rows.Count > 0)
                        {
                            MessageBox.Show("The selected customer is already assigned for this period ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (dt2.Rows.Count > 0)
                        {
                            MessageBox.Show("The selected customer is already assigned for this period", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (dtst.Rows.Count > 0 || dtet.Rows.Count > 0)
                        {
                            MessageBox.Show("Time in Conflict with another schedule!", "Conflict Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            string query0003 = "INSERT INTO playhouse(customer_id,sched_start, sched_end, sched_date," +
                                " start_time, end_time, shour, sminute, sday, ehour, eminute, eday, status) VALUES('"
                                + selected_user_id + "','" + sched_start + "', '" + sched_end + "', '" + date.Text + "','"
                                + start_time + "','" + end_time + "','" + sHour.Text + "', '" + sMin.Text + "','" + sDay.Text + "', '" + eHour.Text + "','" + eMin.Text + "','" +
                                eDay.Text + "','" + status.Text + "' )";
                            conn.Open();

                            MySqlCommand comm4 = new MySqlCommand(query0003, conn);
                            comm4.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Schedule Successfully Added");
                            loadall();

                        }
                    }



                }


            }
        }

        public int selected_user_id = -1;
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                selected_user_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["person_id"].Value.ToString());

                lname.Text = dataGridView1.Rows[e.RowIndex].Cells["lname"].Value.ToString();
                fname.Text = dataGridView1.Rows[e.RowIndex].Cells["fname"].Value.ToString();
                Form4 form4 = new Form4();
                form4.custID = selected_user_id;
            }
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
            Form4 form = new Form4();
            form.Show();
            form.previousform = this;
            
        }
    }
        
    }
