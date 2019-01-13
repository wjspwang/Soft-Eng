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
    public partial class ingredient_list : Form
    {
        MySqlConnection conn;
        public Form previousform;
        public ingredient_list()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            loadall();
            label6.Text = ProductList.passingtext;
        }
        private void loadall()
        {
            string query = "select * from product ; ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["prodid"].Visible = false;
            dataGridView1.Columns["prodname"].HeaderText = "Product Name";
            dataGridView1.Columns["prodquant"].HeaderText = "Quantity";
            dataGridView1.Columns["description"].HeaderText = "Description";
            dataGridView1.Columns["category"].HeaderText = "Category";
            dataGridView1.Columns["produnit"].HeaderText = "Unit of Measure";
            dataGridView1.Columns["restock_val"].Visible = false;
        }
        private int selected_user_id;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                selected_user_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["prodid"].Value.ToString());
                code.Text = dataGridView1.Rows[e.RowIndex].Cells["prodid"].Value.ToString();
                name.Text = dataGridView1.Rows[e.RowIndex].Cells["prodname"].Value.ToString();
                desc.Text = dataGridView1.Rows[e.RowIndex].Cells["description"].Value.ToString();
                //quant.Text = dataGridView1.Rows[e.RowIndex].Cells["prodquant"].Value.ToString();
                unit.Text = dataGridView1.Rows[e.RowIndex].Cells["produnit"].Value.ToString();

            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = "SELECT COUNT(prod_id) from recipe_item_list where recipe_id = '"+selected_user_id+"' ";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataReader rdr = comm1.ExecuteReader();
            conn.Close();


            conn.Open();
            label7.Text = comm1.ExecuteScalar().ToString();
            conn.Close();
            if (textBox1.Text == "" || code.Text == "")
            {
                MessageBox.Show("Please Complete the Form");
            }
            else
            {


                if (Convert.ToInt32(label7.Text) == 0)
                {
                    MessageBox.Show("ITEM ADDED");
                    string query = " insert into recipe_item_list(recipe_id, prod_id, prod_quant) values('" + label6.Text + "' , '" + code.Text + "' , '" + textBox1.Text + "')";
                    conn.Open();
                    //MessageBox.Show(textBox1.Text);
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadall();
                }
                else
                {
                    MessageBox.Show("ITEM ADDED");
                    string query = " update recipe_item_list set prod_quant =  prod_quant + '" + textBox1.Text + "' where prod_id = '" + code.Text + "' ";
                    conn.Open();
                    MessageBox.Show(textBox1.Text);
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadall();
                }

                this.Close();
            }
        }
    }
}
