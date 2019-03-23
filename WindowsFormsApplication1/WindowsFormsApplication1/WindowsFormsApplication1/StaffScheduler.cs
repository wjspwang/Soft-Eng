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
    public partial class StaffScheduler : Form
    {
        MySqlConnection conn;
        public Form previousform;
        public StaffScheduler()
        {
            InitializeComponent();
            MainMenu f2 = new MainMenu();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");
        }
        private void executeQuery(string q)
        {
            conn.Open();
            MySqlCommand comm = new MySqlCommand(q, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            loadall();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            date.Value = DateTime.Now.Date;
            loadall();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox22_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime cur_date = DateTime.Now;
            TimeSpan cur_time = DateTime.Now.TimeOfDay;
            DateTime input_Date = Convert.ToDateTime(date.Text);



            if (selected_user_id == -1)
            {
                MessageBox.Show("case 1 : No Staff ID");
            }else if(staff_name.Text == "" || staff_name.Text == null)
            {
                MessageBox.Show("case 2 : No Staff Name");
            }
            else if (date.Text == "" || date.Text == null)
            {
                MessageBox.Show("case 3 : No Date");
            }
            else if (input_Date.Date < cur_date.Date)
            {
                MessageBox.Show("case 4 : Scheduled for past date.", "Invalid Date", MessageBoxButtons.OK,MessageBoxIcon.Error);
                
            }
            else if (sHour.Text == "" || sHour.Text == null ||
                sMin.Text == "" || sMin.Text == null ||
                eHour.Text == "" || eHour.Text == null ||
                eMin.Text == "" || eMin.Text == null)
            {
                MessageBox.Show("case 5 : No Start Time/ End time");
            }else if ( sHour.Text != "13")
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
                else if (act_box.Text == "" || act_box.Text == null)
                {
                    MessageBox.Show("case 7 : No Activity");
                }
                else
                {                
                    string start_time = sHour.Text + ":" + sMin.Text + " " + sday.Text;
                    string end_time = eHour.Text + ":" + eMin.Text + " " + eday.Text;

                    TimeSpan start_time1 = Convert.ToDateTime(start_time).TimeOfDay;
                    TimeSpan end_time1 = Convert.ToDateTime(end_time).TimeOfDay;

                    string sched_start = date.Text + " " +start_time1;
                    string sched_end = date.Text + " " +end_time1;

                    // MessageBox.Show("start_time1 = "+start_time1 + "");
                    if (input_Date.Date == cur_date.Date && start_time1 < cur_time)
                    {
                        MessageBox.Show("case 4 : Scheduled for past time.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string selectquery = "select * from dc_sched where staff_id = '" + staff_id.Text + "' AND sched_date = '" + date.Text + "' AND start_time = '" + start_time + "' AND end_time = '" + end_time + "' ";
                        string selectquery2 = "SELECT * FROM dc_sched WHERE  ((sched_start <= '"+sched_start+"'  AND sched_end >= '"+ sched_start + "' )" +
                        "OR(sched_start <= '"+sched_end+"'  AND sched_end >= '"+sched_end+"'))"+ 
                        "AND staff_id = "+staff_id.Text+"";
   
                        conn.Open();

                        MySqlCommand comm1 = new MySqlCommand(selectquery, conn);
                        MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                        DataTable dt1 = new DataTable();
                        adp1.Fill(dt1);

                        MySqlCommand comm2 = new MySqlCommand(selectquery2, conn);
                        MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                        DataTable dt2 = new DataTable();
                        adp2.Fill(dt2);
                        /*
                        MySqlCommand commStartSelect = new MySqlCommand(stquery, conn);
                        MySqlDataAdapter adps = new MySqlDataAdapter(commStartSelect);
                        DataTable dtst = new DataTable();
                        adps.Fill(dtst);

                        MySqlCommand commEndSelect = new MySqlCommand(etquery, conn);
                        MySqlDataAdapter adpe = new MySqlDataAdapter(commEndSelect);
                        DataTable dtet = new DataTable();
                        adpe.Fill(dtet);
                        */
                        conn.Close();

                        if (dt1.Rows.Count > 0)
                        {
                            MessageBox.Show("The selected employee is already assigned" , "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (dt2.Rows.Count > 0)
                        {
                            MessageBox.Show("Conflicting with an Existing Schedule" , "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        /*
                        else if (dtst.Rows.Count > 0 || dtet.Rows.Count > 0)
                        {
                            MessageBox.Show("Time in Conflict with another schedule!", "Conflict Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        */
                        else
                        {

                            string query0003 = "INSERT INTO dc_sched(staff_id,sched_start, sched_end, sched_date," +
                                " start_time, end_time, shour, sminute, sday, ehour, eminute, eday, status) VALUES('"
                                + selected_user_id + "','" + sched_start + "', '" + sched_end + "', '" + date.Text + "','"
                                + start_time + "','" + end_time + "','" + sHour.Text + "', '" + sMin.Text + "','" + sday.Text + "', '" + eHour.Text + "','" + eMin.Text + "','" +
                                eday.Text + "','" + act_box.Text + "' )";
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

        private void button2_Click(object sender, EventArgs e)
        {
            CalendarVer2 a = new CalendarVer2();
            a.Show();
            a.previousform = this;
        }
        private int selected_sched_id = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //selected_user_id2 = int.Parse(sched_grid.Rows[e.RowIndex].Cells["sched_id"].Value.ToString());
                
                //date_box1.Text = sched_grid.Rows[e.RowIndex].Cells["date_time"].Value.ToString();
                //act_box1.Text = sched_grid.Rows[e.RowIndex].Cells["activity"].Value.ToString();
                
                
                selected_sched_id = int.Parse(sched_grid.Rows[e.RowIndex].Cells["sched_id"].Value.ToString());
               
                
                act_box.Text = sched_grid.Rows[e.RowIndex].Cells["activity"].Value.ToString();
                

            }
           // MessageBox.Show(selected_user_id.ToString());
        }
        private int selected_user_id = -1;
        private void staff_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
                {
                    if (e.RowIndex > -1)
                    {

                        selected_user_id = int.Parse(staff_grid.Rows[e.RowIndex].Cells["staff_id"].Value.ToString());
                        staff_id.Text = staff_grid.Rows[e.RowIndex].Cells["staff_id"].Value.ToString();
                        staff_name.Text = staff_grid.Rows[e.RowIndex].Cells["lname"].Value.ToString() + ", " + staff_grid.Rows[e.RowIndex].Cells["fname"].Value.ToString();

                    }
           // MessageBox.Show(selected_user_id.ToString());
        }
        private void loadall()
        {

            string query = "select staff_id, lname, fname from staff inner join person on staff.person_id = person.person_id ";
            //string query = "select person_id, concat( lname, ', ' ,fname) AS Employee from person a WHERE person_type = 2";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            staff_grid.DataSource = dt;

            staff_grid.Columns["staff_id"].Visible = false;
            staff_grid.Columns["lname"].HeaderText = "Last Name";
            staff_grid.Columns["fname"].HeaderText = "First Name";




            
            string query1 = "select * from scheduletasks";
                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(query1, conn);
                MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);

                sched_grid.DataSource = dt1;

                conn.Close();

            sched_grid.Columns["sched_id"].Visible = false;
            sched_grid.Columns["activity"].HeaderText = "Tasks";




        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form9_Activated(object sender, EventArgs e)
        {
            loadall();
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            scheduleTasks a = new scheduleTasks();
            a.Show();
            a.previousform = this;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            scheduleTasks a = new scheduleTasks();
            a.Show();
            a.previousform = this;
        }
        private void createStaff_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Profiles a = new Profiles();
            TabControl b = new TabControl();
            a.tabc.SelectedTab = a.tabc.TabPages["tabPage3"];
            a.Show();
            a.previousform = this;

        }

        private void act_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void act_box_TextChanged(object sender, EventArgs e)
        {
        }

        private void StaffScheduler_FormClosing(object sender, FormClosingEventArgs e)
        {
            previousform.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            loadall();
        }
    }
}
