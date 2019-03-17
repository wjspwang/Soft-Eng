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
    public partial class Form2 : Form
    {
        MySqlConnection conn;
        public Form previousform;

        string clinic_name;
        public Form2(string clinic_name)
        {
            this.clinic_name = clinic_name;
        }
        public Form2()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");
        }
        

        private void Form2_Load(object sender, EventArgs e)
        {
            if(clinic_name != null)
            {
                clinic_text.Text = clinic_name;
                date.Value = DateTime.Now.Date;
                loadall();
            }
            else
            {
                date.Value = DateTime.Now.Date;
                loadall();
            }

            
        }

        void loadall()
        {
            lever = true;
            string qry = "select * from Dog where owner_type = 1";
            string qry2 = "select * from dog_clinic";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(qry, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            MySqlCommand comm2 = new MySqlCommand(qry2, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);

            conn.Close();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            adp.Fill(dt);
            adp2.Fill(dt2);

            dog_grid.DataSource = dt;
            clinic_grid.DataSource = dt2;
            //DOG GRID
            dog_grid.Columns["owner_type"].Visible = false;
            dog_grid.Columns["dog_id"].Visible = false;
            dog_grid.Columns["dog_name"].HeaderText = "Pet Name";
            dog_grid.Columns["dog_breed"].HeaderText = "Breed";
            //CLINIC GRID
            clinic_grid.Columns["clinic_id"].Visible = false;
            clinic_grid.Columns["clinic_name"].HeaderText = "Clinic";
            clinic_grid.Columns["clinic_address"].HeaderText = "Address";
            clinic_grid.Columns["clinic_contact"].HeaderText = "Contact number";




        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousform.Show();
        }
        bool lever;
        private int selected_dog_id;
                private void staff_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
                {
                    if (e.RowIndex > -1)
                    {


                        selected_dog_id = int.Parse(dog_grid.Rows[e.RowIndex].Cells["dog_id"].Value.ToString());
                        dog_id.Text = dog_grid.Rows[e.RowIndex].Cells["dog_id"].Value.ToString();
                        dog_name.Text = dog_grid.Rows[e.RowIndex].Cells["dog_name"].Value.ToString();
                        dog_breed.Text = dog_grid.Rows[e.RowIndex].Cells["dog_breed"].Value.ToString();


                    }
            string slct_dog = "select dogsched_date, dogstart_time, dogend_time, c.clinic_name, dog_vaccination, dog_status from dc_dogsched inner join dog_clinic c ON dc_dogsched.clinic_id = c.clinic_id where dog_id = " + selected_dog_id+ " order by dogsched_date desc ";
            conn.Open();
            MySqlCommand com = new MySqlCommand(slct_dog, conn);

            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            DataTable tb = new DataTable();
            adp.Fill(tb);

            clinic_grid.DataSource = tb;
            conn.Close();
            lever = false;

                }
        private int select_clinic_id;
           
            private void clinic_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            if (lever == false)
            {
                return;
            }
            else
            {
                if (e.RowIndex > -1)
                {


                    select_clinic_id = int.Parse(clinic_grid.Rows[e.RowIndex].Cells["clinic_id"].Value.ToString());
                    clinic_text.Text = clinic_grid.Rows[e.RowIndex].Cells["clinic_name"].Value.ToString();



                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 a = new Form3();
            a.Show();
            a.previousform = this;
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            loadall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime cur_date = DateTime.Now;
            TimeSpan cur_time = DateTime.Now.TimeOfDay;
            DateTime input_Date = Convert.ToDateTime(date.Text);

            int taken = 0;
            if (comboBox1.Text == "Taken")
            {
                taken = 1;
            }
            else
            {
                taken = 0;
            }

            if (clinic_text.Text == "" || clinic_text.Text == null) 
            {
                MessageBox.Show("");
            }
            if (selected_dog_id == -1)
            {
                MessageBox.Show("Invalid Staff ID");
            }
            else if (dog_name.Text == "" || dog_name.Text == null)
            {
                MessageBox.Show("Invalid Staff Name");
            }
            else if (date.Text == "" || date.Text == null)
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
                int sHour_int = Convert.ToInt32(sHour.Text);
                int eHour_int = Convert.ToInt32(eHour.Text);
                int sMin_int = Convert.ToInt32(sMin.Text);
                int eMin_int = Convert.ToInt32(eMin.Text);


                if (sHour_int >= eHour_int &&
                    sMin_int >= eMin_int && sHour.Text != "12" && sday.Text == eday.Text)
                {
                    MessageBox.Show("Invalid Time", "Invalid Start/End Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (vacc_Text.Text == "" || vacc_Text.Text == null)
                {
                    MessageBox.Show("Invalid Medication");
                }
                else if (comboBox1.Text == "" || comboBox1.Text == null)
                {
                    MessageBox.Show("Invalid Status");
                }
                else
                {
                    string start_time = sHour.Text + ":" + sMin.Text + " " + sday.Text;
                    string end_time = eHour.Text + ":" + eMin.Text + " " + eday.Text;

                    TimeSpan start_time1 = Convert.ToDateTime(start_time).TimeOfDay;
                    TimeSpan end_time1 = Convert.ToDateTime(end_time).TimeOfDay;

                    string sched_start = date.Text + " " + start_time1;
                    string sched_end = date.Text + " " + end_time1;

                    if (input_Date.Date == cur_date.Date && start_time1 < cur_time && taken == 0 || input_Date.Date > cur_date.Date && start_time1 < cur_time && taken == 1)
                    {
                        MessageBox.Show("Invalid Date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string selectquery = "select * from dc_dogsched where dog_id = '" + dog_id.Text + "' AND dogsched_date = '" + date.Text + "' AND dogstart_time = '" + start_time + "' AND dogend_time = '" + end_time + "' ";
                        string selectquery2 = "SELECT * FROM dc_dogsched WHERE  ((dogsched_start <= '" + sched_start + "'  AND dogsched_end >= '" + sched_start + "' )" +
                        "OR(dogsched_start <= '" + sched_end + "'  AND dogsched_end >= '" + sched_end + "'))" +
                        "AND dog_id = " + dog_id.Text + "";
                        string duplicates = "select * from dc_dogsched where dog_id = " + selected_dog_id + " " +
                            "AND clinic_id = " + select_clinic_id + " AND dogstart_time = '" + start_time + "' AND dogend_time = '" + end_time + "'" +
                            "AND dog_vaccination = '"+vacc_Text.Text+"' ";
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

                        MySqlCommand commdup = new MySqlCommand(duplicates, conn);
                        MySqlDataAdapter adpdup = new MySqlDataAdapter(commdup);
                        DataTable dtdup = new DataTable();
                        adpdup.Fill(dtdup);
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
                        else if(dtdup.Rows.Count > 0)
                        {
                            MessageBox.Show("Duplicated Entry", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            string query0003 = "INSERT INTO dc_dogsched(dog_id,clinic_id,dogsched_start, dogsched_end, dogsched_date," +
                                " dogstart_time, dogend_time, dog_shour, dog_smin, dog_sday, dog_ehour, dog_emin, dog_eday, dog_status, dog_vaccination) VALUES('"
                                + selected_dog_id + "','"+select_clinic_id+"','" + sched_start + "', '" + sched_end + "', '" + date.Text + "','"
                                + start_time + "','" + end_time + "','" + sHour.Text + "', '" + sMin.Text + "','" + sday.Text + "', '" + eHour.Text + "','" + eMin.Text + "','" +
                                eday.Text + "','" + comboBox1.Text + "', '"+vacc_Text.Text+"' )";
                            conn.Open();

                            MySqlCommand comm4 = new MySqlCommand(query0003, conn);
                            comm4.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Schedule Successfully Appointed");
                            loadall();

                        }
                    }
                }
            }
        }

        private void createStaff_Click(object sender, EventArgs e)
        {
          //  this.Hide();
            Profiles a = new Profiles();
            TabControl b = new TabControl();
            a.tabc.SelectedTab = a.tabc.TabPages["tabPage2"];
            a.Show();
            a.previousform = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dogMedSched a = new dogMedSched();
            a.Show();
            a.previousform = this;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            previousform.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadall();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadall();
        }
    }


}
        