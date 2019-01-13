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
    public partial class Profiles : Form
    {
        MySqlConnection conn;
        public Form previousform;
        public TabControl tabc;
        public Profiles()
        {
            InitializeComponent();
            MainMenu f2 = new MainMenu();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd = root;");
            tabc = tabControl1;
        }
        private void executeQuery(string q)
        {
            conn.Open();
            MySqlCommand comm = new MySqlCommand(q, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            loadall();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void contact(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }

        private void num_Click(object sender, EventArgs e)
        {
 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {


                selected_user_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["person_id"].Value.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["lname"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["fname"].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["gender"].Value.ToString();
                num.Text = dataGridView1.Rows[e.RowIndex].Cells["contact"].Value.ToString();
                id.Text = dataGridView1.Rows[e.RowIndex].Cells["person_id"].Value.ToString();
            }
        }
       
        private int selected_user_id;
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

            string query3 = "select * from dog";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);

            dataGridView2.DataSource = dt3;


            string query2 = "select staff_id, lname, fname, gender, contact from staff inner join person on staff.person_id = person.person_id";
            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(query2, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);

            dataGridView3.DataSource = dt2;

         

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            loadall();
        }
   
        private void button2_Click(object sender, EventArgs e)
        {
            string match = "select * from person where lname = '"+textBox1.Text+"' AND fname = '"+textBox2.Text+"'" +
                "AND gender = '"+comboBox1.Text+"' AND person_type = 1";
            conn.Open();
            MySqlCommand cmand = new MySqlCommand(match,conn);
            MySqlDataAdapter adpt = new MySqlDataAdapter(cmand);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Customer already exists");
            }
            else {
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Fill in the appropriate fields");
                }
                else
                {
                    string query = "INSERT INTO person(lname,fname,gender,person_type,contact) " +
                    "VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + comboBox1.Text + "', 1 , '" + num.Text + "')";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadall();
                }
            }


            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "";
            if (String.IsNullOrEmpty(id.Text)) { MessageBox.Show("Choose a user to edit or input id to edit.", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                if (String.IsNullOrEmpty(textBox1.Text)) query += ""; else query += " UPDATE person SET fname='" + textBox1.Text + "' WHERE person_id ='" + id.Text + "'; ";
                if (String.IsNullOrEmpty(textBox2.Text)) query += ""; else query += "UPDATE person SET lname='" + textBox2.Text + "' WHERE person_id='" + id.Text + "'; ";
                if (String.IsNullOrEmpty(num.Text)) query += ""; else query += "UPDATE person SET contact='" + num.Text + "' WHERE person_id='" + id.Text + "'; ";
                if (String.IsNullOrEmpty(comboBox1.Text)) query += ""; else query += "UPDATE person SET gender='" + comboBox1.Text + "' WHERE person_id='" + id.Text + "'; ";
                executeQuery(query);
            }
        }
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM person WHERE person_id = '" + selected_user_id + "'; ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            loadall();
            MessageBox.Show("Successfully Deleted");
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells["person_id"].Value.ToString());
                selected_user_id = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["staff_id"].Value.ToString());
                textBox8.Text = dataGridView3.Rows[e.RowIndex].Cells["lname"].Value.ToString();
                textBox9.Text = dataGridView3.Rows[e.RowIndex].Cells["fname"].Value.ToString();
                comboBox3.Text = dataGridView3.Rows[e.RowIndex].Cells["gender"].Value.ToString();
                textBox10.Text = dataGridView3.Rows[e.RowIndex].Cells["contact"].Value.ToString();
                textBox7.Text = dataGridView3.Rows[e.RowIndex].Cells["staff_id"].Value.ToString();
                
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {

            string match = "select * from person where lname = '" + textBox9.Text + "' AND fname = '" + textBox8.Text + "'" +
                "AND gender = '" + comboBox3.Text + "' AND person_type = 2";
            conn.Open();
            MySqlCommand cmand = new MySqlCommand(match, conn);
            MySqlDataAdapter adpt = new MySqlDataAdapter(cmand);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Staff already exists");
                return;
            }
            else
            {
                if (textBox8.Text == "" || textBox9.Text == "" || comboBox3.Text == "")
                {
                    MessageBox.Show("Fill in the appropriate fields");
                }
                else
                {
                    string query = "INSERT INTO person(lname,fname,gender,person_type,contact) " +
                "VALUES('" + textBox8.Text + "', '" + textBox9.Text + "','" + comboBox3.Text + "', 2, '" + textBox10.Text + "')";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadall();
                    
                    string query1 = "select person_id from person where person_id = (select max(person_id) from person) AND person_type = 2 ";
                    conn.Open();
                    MySqlCommand comm3 = new MySqlCommand(query1, conn);
                    MySqlDataReader rdr = comm3.ExecuteReader();
                    conn.Close();

                    conn.Open();
                    person_id.Text = comm3.ExecuteScalar().ToString();
                    conn.Close();
                    loadall();
                    string query2 = "INSERT INTO staff(person_id) " +
                        "VALUES('" + person_id.Text + "')";
                    conn.Open();
                    MySqlCommand comm2 = new MySqlCommand(query2, conn);
                    comm2.ExecuteNonQuery();
                    conn.Close();
                    loadall();
                    MessageBox.Show("Staff Added");
                }
            
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string match = "select * from dog where dog_name = '" + textBox4.Text + "' AND dog_breed = '" + textBox5.Text + "'" +
                "AND dog_owner = '"+textBox6.Text+"'";
            conn.Open();
            MySqlCommand cmand = new MySqlCommand(match, conn);
            MySqlDataAdapter adpt = new MySqlDataAdapter(cmand);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Dog already exists");
            }
            else
            {
                if (checkBox1.Checked == false)
                {
                    if (textBox4.Text == "" || textBox5.Text == "")
                    {
                        MessageBox.Show("Please fill up appropriate fields");
                    }
                    else
                    {
                        string match1 = "select * from dog where dog_name = '" + textBox4.Text + "' AND dog_breed = '" + textBox5.Text + "'" +
                        "AND owner_type = 1";
                        
                        conn.Open();
                        MySqlCommand cmand1 = new MySqlCommand(match1, conn);
                        MySqlDataAdapter adpt1 = new MySqlDataAdapter(cmand1);
                        DataTable dt1 = new DataTable();
                        adpt1.Fill(dt1);
                        conn.Close();
                        if (dt1.Rows.Count > 0)
                        {
                            MessageBox.Show("Dog already exists");
                            return; 
                        }

                        string query = "INSERT INTO dog(dog_name,dog_breed,dog_owner, owner_type) " +
                        "VALUES('" + textBox4.Text + "', '" + textBox5.Text + "', 'Mgt-Owned', 1)";
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand(query, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                        loadall();
                        MessageBox.Show("Dog Added");
                    }
                    
                }
                else
                {
                    if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                    {
                        MessageBox.Show("Please fill up appropriate fields");
                    }
                    string query = "INSERT INTO dog(dog_name,dog_breed,dog_owner,owner_type) " +
                    "VALUES('" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', 2)";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadall();
                }
            }
            
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {


                selected_user_id = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["dog_id"].Value.ToString());
                textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells["dog_name"].Value.ToString();
                textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells["dog_breed"].Value.ToString();
                textBox6.Text = dataGridView2.Rows[e.RowIndex].Cells["dog_owner"].Value.ToString();
                textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["dog_id"].Value.ToString();


            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked == false)
            {
            string query = " update dog SET dog_name = '" + textBox4.Text + "' , dog_breed = '" + textBox5.Text + "' , dog_owner = 'Mgt-Owned', owner_type = 1 where dog_id = '" + textBox3.Text + "' ";
            conn.Open();
            //MessageBox.Show(query);
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            //MessageBox.Show("ITEM UPDATED");
            loadall();
            }
            else
            {
                string query = " update dog SET dog_name = '" + textBox4.Text + "' , dog_breed = '" + textBox5.Text + "' , dog_owner = '"+textBox6.Text+"', owner_type = 2 where dog_id = '" + textBox3.Text + "' ";
                conn.Open();
                //MessageBox.Show(query);
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("ITEM UPDATED");
                loadall();
            }
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string selectPid = "select person_id from staff where staff_id = '" + selected_user_id + "'";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(selectPid, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                int person_id = Convert.ToInt32(dr["person_id"]);
                string query = "";
                if (String.IsNullOrEmpty(textBox7.Text)) { MessageBox.Show("Choose a user to edit or input id to edit.", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {
                    if (String.IsNullOrEmpty(textBox8.Text)) query += ""; else query += " UPDATE person SET fname='" + textBox8.Text + "' WHERE person_id ='" + person_id + "'; ";
                    if (String.IsNullOrEmpty(textBox9.Text)) query += ""; else query += "UPDATE person SET lname='" + textBox9.Text + "' WHERE person_id='" + person_id + "'; ";
                    if (String.IsNullOrEmpty(textBox10.Text)) query += ""; else query += "UPDATE person SET contact='" + textBox10.Text + "' WHERE person_id='" + person_id + "'; ";
                    if (String.IsNullOrEmpty(comboBox3.Text)) query += ""; else query += "UPDATE person SET gender='" + comboBox3.Text + "' WHERE person_id='" + person_id + "'; ";
                    executeQuery(query);
                    MessageBox.Show("Updated");
                }

            }

                


        }

        private void button13_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if(checkBox1.Checked == true)
            {
                textBox6.Enabled = true;
            }
            else
            {
                textBox6.Enabled = false;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string selectPid = "select person_id from staff where staff_id = '" + selected_user_id + "'";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(selectPid, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            MessageBox.Show("Row Count = " + dt.Rows.Count + "");


            string query1 = "DELETE FROM staff where staff_id = '"+selected_user_id+"'  ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query1, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            loadall();
            MessageBox.Show("Successfully Deleted");

            
            foreach (DataRow dr in dt.Rows)
            {
                
                int person_id = Convert.ToInt32(dr["person_id"]);
                MessageBox.Show(person_id + "");
                string query = "DELETE FROM person WHERE person_id = '" + person_id + "' ";
                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(query, conn);
                comm1.ExecuteNonQuery();
                conn.Close();
                loadall();
                MessageBox.Show("Successfully Deleted");

            }




        }
    }
    }

