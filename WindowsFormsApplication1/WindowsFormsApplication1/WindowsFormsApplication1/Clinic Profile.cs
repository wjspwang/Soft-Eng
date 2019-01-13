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
    public partial class Form3 : Form
    {
        MySqlConnection conn;
        public Form previousform;
        public Form3()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root;");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            loadall();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string clinic_name = textBox1.Text.Replace("'", "''");
            if(textBox1.Text == "")
            {
                MessageBox.Show("Please input a valid clinic name", "Invalid Clinic Name", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            else if(textBox2.Text == "" || textBox3.Text  == "")
            {
                //MessageBox.Show("Missing Fields", "There are fields needed to be inputted, proceed ?", MessageBoxButtons.OKCancel);
                if(MessageBox.Show("There are fields you haven't filled, proceed ?", "Missing Fields", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    string ifExist = "select * from dog_clinic where clinic_name = '"+clinic_name+"' AND clinic_address = '"+textBox2.Text+"' AND clinic_contact = '"+textBox3.Text+"' ";
                    conn.Open();
                    MySqlCommand a = new MySqlCommand(ifExist, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(a);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    conn.Close();

                    if(dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("The clinic already exists in your list", "Clinic already exists", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                    string addClinic = "insert into dog_clinic(clinic_name,clinic_address,clinic_contact) VALUES('" + clinic_name + "','" + textBox2.Text + "','" + textBox3.Text + "' )";
                                        conn.Open();
                                        MySqlCommand comm = new MySqlCommand(addClinic, conn);
                                        comm.ExecuteNonQuery();
                                        conn.Close();
                                        MessageBox.Show("Clinic Added");
                                        this.Close();
                    }

                    
                    
                }
                else
                {
                    return;
                }
            }
            else
            {
                string ifExist = "select * from dog_clinic where clinic_name = '" + clinic_name + "' AND clinic_address = '" + textBox2.Text + "' AND clinic_contact = '" + textBox3.Text + "' ";
                conn.Open();
                MySqlCommand a = new MySqlCommand(ifExist, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(a);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                conn.Close();

                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("The clinic already exists in your list", "Clinic already exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string addClinic = "insert into dog_clinic(clinic_name,clinic_address,clinic_contact) VALUES('" + clinic_name + "','" + textBox2.Text + "','" + textBox3.Text + "' )";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(addClinic, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Clinic Added");
                    this.Close();
                }
            }
            

        }
        int selected_clinic_id;
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                string upd = "update dog_clinic set clinic_name ='"+textBox1.Text.Replace("'", "''") + "', clinic_address = '"+textBox2.Text.Replace("'", "''") + "' , clinic_contact = '"+textBox3.Text+"' where clinic_id = '" + selected_clinic_id +"' ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(upd, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                loadall();
                MessageBox.Show("Clinic Updated");
            }
            else if(textBox2.Text == "" || textBox3.Text == "")
            {
                //MessageBox.Show("Missing Fields", "There are fields needed to be inputted, proceed ?", MessageBoxButtons.OKCancel);
                if (MessageBox.Show("There are fields you haven't filled, proceed ?", "Missing Fields", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    string upd = "update dog_clinic set clinic_name ='" + textBox1.Text.Replace("'", "''") + "', clinic_address = '" + textBox2.Text.Replace("'", "''") + "' , clinic_contact = '" + textBox3.Text + "' where clinic_id = '" + selected_clinic_id + "' ";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(upd, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadall();
                    MessageBox.Show("Clinic Updated");

                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please input fields", "Invalid Data Provided", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void loadall()
        {
            string qry = "select * from dog_clinic";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(qry, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            DataTable dt = new DataTable(); 
            conn.Close();

            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["clinic_id"].Visible = false;
            dataGridView1.Columns["clinic_name"].HeaderText = "Clinic Name";
            dataGridView1.Columns["clinic_address"].HeaderText = "Address";
            dataGridView1.Columns["clinic_contact"].HeaderText = "Contact Number";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string qry = "delete from dog_clinic where clinic_id = "+selected_clinic_id+"";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(qry, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Are you sure ?", "Deleting "+textBox1.Text+"", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            loadall();
            MessageBox.Show(textBox1.Text + " has been deleted");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                selected_clinic_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["clinic_id"].Value.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["clinic_name"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["clinic_address"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["clinic_contact"].Value.ToString();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string search = "select * from dog_clinic where clinic_name like '%"+
                textBox1.Text+"%' AND clinic_address like '%"+
                textBox2.Text+"%' AND clinic_contact like '%"+textBox3.Text+"%'  ";

            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                string qry = "select * from dog_clinic";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(qry, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                conn.Close();

                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["clinic_id"].Visible = false;
                dataGridView1.Columns["clinic_name"].HeaderText = "Clinic Name";
                dataGridView1.Columns["clinic_address"].HeaderText = "Address";
                dataGridView1.Columns["clinic_contact"].HeaderText = "Contact Number";
                MessageBox.Show(dt.Rows.Count + " Clinics Found");
            }
            else
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand(search, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                conn.Close();

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["clinic_id"].Visible = false;
                dataGridView1.Columns["clinic_name"].HeaderText = "Clinic Name";
                dataGridView1.Columns["clinic_address"].HeaderText = "Address";
                dataGridView1.Columns["clinic_contact"].HeaderText = "Contact Number";
                MessageBox.Show(dt.Rows.Count + " Clinics Found");
            }
        }
    }
}
