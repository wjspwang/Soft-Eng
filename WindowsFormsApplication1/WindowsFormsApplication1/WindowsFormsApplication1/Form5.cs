using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");
        }
        MySqlConnection conn;
        public Form previousform;
        private int selected_user_id;
        public int custID { get; set; }
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

        private void Form5_Load(object sender, EventArgs e)
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
        }

        private void button1_Click(object sender, EventArgs e)
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
                string query = "select * from person where person_type = 1 where lname = '" + textBox2.Text + "' && fname ='"+textBox1.Text+"'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == null || textBox3.Text == "" || Regex.IsMatch(textBox3.Text, @"^[a-zA-Z]+$"))
            {
                return;
            }
            else
            {
                PlayhouseManagement previousform = new PlayhouseManagement();
                previousform.selected_user_id = Convert.ToInt32(textBox3.Text);
                previousform.firstname = textBox2.Text;
                previousform.lastname = textBox1.Text;
                 Form4 form4 = new Form4();
                form4.selected_user_id = Convert.ToInt32(textBox3.Text);
                MessageBox.Show(previousform.selected_user_id + " " + previousform.firstname + " " + previousform.lastname + " was selected.");
                previousform.Show();
                this.Hide();
            }
            

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^0-9]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousform.Show();
        }
    }
}
