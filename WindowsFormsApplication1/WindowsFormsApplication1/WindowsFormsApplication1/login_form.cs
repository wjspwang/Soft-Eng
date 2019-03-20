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
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        public Form1 previousform;
        public static string user = "";
        public static string id="";
        public Form1()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; Database=pawesome_db; uid=root; Pwd=root ;");
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (btnuser.Text == "username")
            {
                btnuser.Text = "";
            }
            if(btnpass.Text == ""){
                btnpass.Text = "****";
            }

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
           if(btnpass.Text == "****")
            {
                btnpass.Text = "";
            }
           if(btnuser.Text== "")
            {
                btnuser.Text = "username";
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int utype;
        string utype_text;
        private void btnok_Click(object sender, EventArgs e)
        {
            user = btnuser.Text;
            String pass = btnpass.Text;
            String query = "SELECT * FROM tbl_users" + " WHERE username = '" + user + "' AND password = '" + pass + "'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                
                user = dt.Rows[0]["fname"].ToString() + " " + dt.Rows[0][2].ToString();
                id = dt.Rows[0]["user_id"].ToString();
                utype_text = dt.Rows[0]["user_type"].ToString();
                if(utype_text == "Staff")
                {
                    utype = 0;
                    //MessageBox.Show("utype = " + utype);
                }
                else if(utype_text == "Owner")
                {
                    utype = 1;
                   // MessageBox.Show("utype = " + utype );
                }
                else
                {
                    MessageBox.Show("Invalid User Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                MessageBox.Show("Welcome " + user, "Good Day!" ,MessageBoxButtons.OK,MessageBoxIcon.Information);
                MainMenu f = new MainMenu(utype);
                this.Hide();
                f.Show();
                f.previousform = this;
            }
            else MessageBox.Show("Wrong username or password", "Please Check Username/Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnpass.Text = "";
        }

        private void btnuser_TextChanged(object sender, EventArgs e)
        {
            btnuser.ForeColor = Color.Black;
        }

        private void btnpass_TextChanged(object sender, EventArgs e)
        {
            btnpass.ForeColor = Color.Black;
        }

        private void btnuser_ForeColorChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
