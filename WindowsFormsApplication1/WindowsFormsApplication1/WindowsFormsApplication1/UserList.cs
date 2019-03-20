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
    public partial class UserList : Form
    {
       
        MySqlConnection conn;
        public Form previousform;
        public UserList()
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
        private void admin_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loadall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex > -1)
            {
                textBox1.ForeColor = Color.Black;
                textBox2.ForeColor = Color.Black;
                textBox3.ForeColor = Color.Black;
                textBox4.ForeColor = Color.Black;

                selected_user_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["user_id"].Value.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["fname"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["lname"].Value.ToString();
                //dateTimePicker1.Value = DateTime.ParseExact(dataGridView1.Rows[e.RowIndex].Cells["bdate"].Value.ToString(), "yyyy/MM/dd");
                //comboBox1.Text = maa;
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString();
                //comboBox2.Text = us;
                id.Text = dataGridView1.Rows[e.RowIndex].Cells["user_id"].Value.ToString();
            }
        }
        private int selected_user_id;
        private void loadall()
        {
            
            string query = "select * from tbl_users";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["user_id"].Visible = false;
            dataGridView1.Columns["fname"].HeaderText = "Firstname";
            dataGridView1.Columns["lname"].HeaderText = "Lastname";
            dataGridView1.Columns["user_id"].Visible = false;
            dataGridView1.Columns["bdate"].HeaderText = "Birthday";
            dataGridView1.Columns["gender"].HeaderText = "Gender";
            dataGridView1.Columns["username"].HeaderText = "Username";
            dataGridView1.Columns["password"].HeaderText = "Password";
            dataGridView1.Columns["user_type"].HeaderText = "User Type";
           
        }

        public int utype;
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" ||
                textBox3.Text == "" || textBox4.Text == "" ||
                comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("There are missing fields","Invalid Details",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            int gen=1;
            if (comboBox1.Text == "Male")
            {
                gen = 0;
            }
            else
                gen = 1;


            
            if (comboBox2.Text == "Staff")
            {
                utype = 0;
            }
            else if(comboBox2.Text=="Owner")
            {
                utype = 1;
            }

            string checker = "select * from tbl_users where username = '" + textBox4.Text + "'";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(checker, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            MessageBox.Show(checker + "\n ROW COUNT = " + dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Username already exists", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                string query = "INSERT INTO tbl_users(fname,lname,bdate,gender,username,password,user_type) " +
                                "VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" +
                                dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', " + gen + ", '" +
                                textBox4.Text + "', '" + textBox3.Text + "', '" + comboBox2.Text + "')";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                loadall();
            }

            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            loadall();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void admin_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Firstname")
            {
                textBox1.ForeColor = Color.Black;
                textBox1.Text = "";
            }
            if (textBox2.Text == "")
            {
                textBox2.ForeColor = SystemColors.ButtonShadow;
                textBox2.Text = "Lastname";
            }
            if (textBox4.Text == "")
            {
                textBox4.ForeColor = SystemColors.ButtonShadow;
                textBox4.Text = "username";
            }
            if (textBox3.Text == "")
            {
                textBox3.ForeColor = SystemColors.ButtonShadow;
                textBox3.Text = "password";
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = SystemColors.ButtonShadow;
                textBox1.Text = "Firstname";
            }
            if (textBox2.Text == "Lastname")
            {
                textBox2.ForeColor = Color.Black;
                textBox2.Text = "";
            }
            if (textBox4.Text == "")
            {
                textBox4.ForeColor = SystemColors.ButtonShadow;
                textBox4.Text = "username";
            }
            if (textBox3.Text == "")
            {
                textBox3.ForeColor = SystemColors.ButtonShadow;
                textBox3.Text = "password";
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = SystemColors.ButtonShadow;
                textBox1.Text = "Firstname";
            }
            if (textBox2.Text == "")
            {
                textBox2.ForeColor = SystemColors.ButtonShadow;
                textBox2.Text = "Lastname";
            }
            if (textBox4.Text == "username")
            {
                textBox4.ForeColor = Color.Black;
                textBox4.Text = "";
            }
            if (textBox3.Text == "")
            {
                textBox3.ForeColor = SystemColors.ButtonShadow;
                textBox3.Text = "password";
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = SystemColors.ButtonShadow;
                textBox1.Text = "Firstname";
            }
            if (textBox2.Text == "")
            {
                textBox2.ForeColor = SystemColors.ButtonShadow;
                textBox2.Text = "Lastname";
            }
            if (textBox4.Text == "")
            {
                textBox4.ForeColor = SystemColors.ButtonShadow;
                textBox4.Text = "username";
            }
            if (textBox3.Text == "password")
            {
                textBox3.ForeColor = Color.Black;
                textBox3.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.ForeColor = Color.Black;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textBox2.ForeColor = Color.Black;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //textBox4.ForeColor = Color.Black;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           // textBox3.ForeColor = Color.Black;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.ResetText();
            textBox4.Clear();
            textBox3.Clear();
            id.Clear();
            comboBox2.ResetText();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query2 = "";
            string query = "select username from tbl_users where username='" + textBox4 + "' ";
            conn.Open();
            MySqlCommand con = new MySqlCommand(query, conn);
            MySqlDataAdapter user = new MySqlDataAdapter(con);
            conn.Close();
            DataTable dt = new DataTable();
            user.Fill(dt);

            if (textBox1.Text == "" || textBox2.Text == "" )
            {
                MessageBox.Show("Please input required field.");
            }
            else
            {
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Username already exist, try another username", "BOX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    query2 += " UPDATE tbl_users set fname ='" + textBox1.Text + "',lname ='" + textBox2.Text + "',username ='" + textBox4.Text + "',password ='" + textBox3.Text + "',gender ='" + comboBox1.Text + "',user_type='"+comboBox2.Text+"',bdate='"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"' where user_id = '" + id.Text + "'";
                }
                executeQuery(query2);

            }
        }

        private void UserList_FormClosing(object sender, FormClosingEventArgs e)
        {
            previousform.Show();
        }

        private void UserList_Activated(object sender, EventArgs e)
        {

              
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(selected_user_id == 0)
            {
                MessageBox.Show("Select a User first before performing an action", "Missing User Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult ConfirmDelete;
            ConfirmDelete = MessageBox.Show("Confirm Delete User ?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (ConfirmDelete == DialogResult.OK)
            {
                string query1 = "DELETE FROM tbl_users where user_id = '" + selected_user_id + "'  ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query1, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Deleted");
                loadall();
                
            }
            
            
        }
    }
}


/*this.close;
  previousform.Show();
 
     */