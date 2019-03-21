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
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class scheduleTasks : Form
    {
        MySqlConnection conn;
        public Form previousform;
        public scheduleTasks()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");
        }

        private void scheduling_Load(object sender, EventArgs e)
        {
            loadall();
        }
        private void loadall()
        {
            string qry = "select * from scheduletasks";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(qry, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["sched_id"].Visible = false;
            dataGridView1.Columns["activity"].HeaderText = "Tasks";
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(comboBox1.Text == "")
            {
                MessageBox.Show("Invalid input","Invalid input",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            string query = "INSERT INTO scheduletasks( activity) " +
                                "VALUES('" + comboBox1.Text + "' )";
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Task Added");
            List<string> dropdwn = new List<string>();
            dropdwn.Add(comboBox1.Text);
            loadall();
        }
        private int selected_task_id;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            if (e.RowIndex > -1)
            {
                selected_task_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["sched_id"].Value.ToString());
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["activity"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE scheduletasks SET activity =  '" 
                               + comboBox1.Text + "' WHERE sched_id = "+ selected_task_id;
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Task Updated");
            loadall();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM scheduletasks WHERE sched_id = " + selected_task_id;
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Task Removed");
            loadall();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
    }
}
