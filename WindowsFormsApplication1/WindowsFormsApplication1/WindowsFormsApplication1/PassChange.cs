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
    public partial class PassChange : Form
    {
        MySqlConnection conn;
        public Form previousform;
        public PassChange()
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
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Npass = newp.Text;
            string Cpass = retype.Text;
            string query = "";
            Form1 a = new Form1();
            if (Cpass == Npass)
            {
                query = "UPDATE tbl_users SET password='" + Cpass + "' WHERE user_id=" +Form1.id  + "";     
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Password changed.", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else MessageBox.Show("Password do not match!", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string us = user.Text;
            
            string query = "";
            Form1 a = new Form1();
            
                query = "UPDATE tbl_users SET username='" + us + "' WHERE user_id=" + Form1.id + "";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Password changed.", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);

            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PassChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            previousform.Show();
        }
    }
}
