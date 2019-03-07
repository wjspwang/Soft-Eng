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
    public partial class salesReport : Form
    {
        MySqlConnection conn;
        public Form previousform;
        public salesReport()
        {
            InitializeComponent();
            MainMenu f2 = new MainMenu();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd = root;");
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            loadall();
        }
        public void loadall()
        {
            DateTime currdate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            fromdate.Value = currdate;
            todate.Value = currdate;
            string query = " select invoice_id, recipe_list.recipe_name, recipe_list.recipe_cat, recipe_list.recipe_cost," +
                " recipe_list.recipe_unit, dot, sales_tbl.sale_item_quant, total_price from sales_tbl INNER JOIN recipe_list WHERE sales_tbl.recipe_id = recipe_list.recipe_id";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            
            
            dataGridView1.Columns["invoice_id"].HeaderText = "Invoice No.";
            dataGridView1.Columns["recipe_name"].HeaderText = "Item Sold";
            dataGridView1.Columns["recipe_cat"].HeaderText = "Item Category";
            dataGridView1.Columns["recipe_cost"].HeaderText = "Item Cost";
            dataGridView1.Columns["recipe_unit"].HeaderText = "Unit of Measure";
            dataGridView1.Columns["dot"].HeaderText = "Purchase Date";
            dataGridView1.Columns["sale_item_quant"].HeaderText = "Quantity Sold";
            dataGridView1.Columns["total_price"].HeaderText = "Total Price";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void fromdate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = " select invoice_id, recipe_list.recipe_name, recipe_list.recipe_cat, recipe_list.recipe_cost,"+
                 "recipe_list.recipe_unit, dot, sales_tbl.sale_item_quant, total_price from sales_tbl INNER JOIN recipe_list WHERE sales_tbl.recipe_id = recipe_list.recipe_id "+
                 "AND dot >= '"+ fromdate.Text +"' AND dot <= '"+ todate.Text +"'; ";
            //MessageBox.Show(fromdate.Text + " " + todate.Text);
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;

            dataGridView1.Columns["dot"].HeaderText = "Purchase Date";
            dataGridView1.Columns["invoice_id"].HeaderText = "Invoice No.";
            dataGridView1.Columns["recipe_name"].HeaderText = "Item Sold";
            dataGridView1.Columns["recipe_cat"].HeaderText = "Item Category";
            dataGridView1.Columns["recipe_cost"].HeaderText = "Item Cost";
            dataGridView1.Columns["recipe_unit"].HeaderText = "Unit of Measure";
            dataGridView1.Columns["sale_item_quant"].HeaderText = "Quantity Sold";
            dataGridView1.Columns["total_price"].HeaderText = "Total Price";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadall();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox1.Text == null)
            {
                return;
            }
            string query = " select invoice_id, recipe_list.recipe_name, recipe_list.recipe_cat, recipe_list.recipe_cost," +
                 "recipe_list.recipe_unit, dot, sales_tbl.sale_item_quant, total_price from sales_tbl INNER JOIN recipe_list WHERE sales_tbl.recipe_id = recipe_list.recipe_id " +
                 "AND invoice_id = "+textBox1.Text+" ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;

            dataGridView1.Columns["dot"].HeaderText = "Purchase Date";
            dataGridView1.Columns["invoice_id"].HeaderText = "Invoice No.";
            dataGridView1.Columns["recipe_name"].HeaderText = "Item Sold";
            dataGridView1.Columns["recipe_cat"].HeaderText = "Item Category";
            dataGridView1.Columns["recipe_cost"].HeaderText = "Item Cost";
            dataGridView1.Columns["recipe_unit"].HeaderText = "Unit of Measure";
            dataGridView1.Columns["sale_item_quant"].HeaderText = "Quantity Sold";
            dataGridView1.Columns["total_price"].HeaderText = "Total Price";
        }

        private void salesReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            previousform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            dt = dataGridView1.DataSource as DataTable;
            //MessageBox.Show(dataGridView1.DataSource + "");
            ds.Tables.Add(dt);
            Form4 f = new Form4(ds,"sales");
            f.Show();
        }
    }
}
