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
    public partial class ProductList : Form
    {

        MySqlConnection conn;
        public Form previousform;
        string dateFormat = "yyyy-MM-dd";
        public ProductList()
        {
            InitializeComponent();
            MainMenu f2 = new MainMenu();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd =root ;");

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        public static string passingtext;

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Product Name")
            {
                textBox1.Text = "";
            }
        }
        private int selected_user_id;
        private int recipelist = 0;
        private void loadall()
        {
            autoExpireLog();
            exp_date.Value = Convert.ToDateTime(currdate);
            string query = "select * from product ;";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["prodid"].HeaderText = "Item ID";
            dataGridView1.Columns["prodname"].HeaderText = "Product Name";
            dataGridView1.Columns["prodquant"].HeaderText = "Quantity";
            dataGridView1.Columns["description"].HeaderText = "Description";
            dataGridView1.Columns["category"].HeaderText = "Category";
            dataGridView1.Columns["produnit"].HeaderText = "Unit of Measure";
            dataGridView1.Columns["restock_val"].HeaderText = "Re-Stock Threshold";
            

            dataGridView2.DataSource = dt;
            dataGridView2.Columns["prodid"].HeaderText = "Item ID";
            dataGridView2.Columns["prodname"].HeaderText = "Product name";
            dataGridView2.Columns["prodquant"].HeaderText = "Current Stock";
            dataGridView2.Columns["description"].Visible = false;
            dataGridView2.Columns["category"].HeaderText = "Category";
            dataGridView2.Columns["produnit"].Visible = false;
            dataGridView2.Columns["restock_val"].HeaderText = "Re-Stock Value";
            

            dataGridView3.DataSource = dt;
            dataGridView3.Columns["prodid"].HeaderText = "Item ID";
            dataGridView3.Columns["prodname"].HeaderText = "Product Name";
            dataGridView3.Columns["prodquant"].HeaderText = "Current Stock";
            dataGridView3.Columns["description"].HeaderText = "Description";
            dataGridView3.Columns["category"].HeaderText = "Category";
            dataGridView3.Columns["produnit"].Visible = false;
            dataGridView3.Columns["restock_val"].HeaderText = "Re-Stock Value";
           

            string stck_in = "select date_added, product.prodname , stock_in.exp_date, add_quant from stock_in " +
                "JOIN product where stock_in.prod_id = product.prodid";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(stck_in,conn);
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            conn.Close();
            DataTable stck_in_tbl = new DataTable();
            adap.Fill(stck_in_tbl);

            stck_in_Grid.DataSource = stck_in_tbl;
            stck_in_Grid.Columns["date_added"].HeaderText = "Stock In Date";
            stck_in_Grid.Columns["date_added"].DefaultCellStyle.Format = dateFormat;
            stck_in_Grid.Columns["prodname"].HeaderText = "Product Name";
            stck_in_Grid.Columns["exp_date"].HeaderText = "Expiry Date";
            stck_in_Grid.Columns["exp_date"].DefaultCellStyle.Format = dateFormat;
            stck_in_Grid.Columns["add_quant"].HeaderText = "Added Quantity";




            string expire_check = "SELECT date_added, a.prod_id, b.prodname, b.category , a.exp_date, add_quant" +
                " from stock_in a JOIN product b where a.prod_id = b.prodid AND a.exp_date = curdate() AND a.status =  0 ";
            conn.Open();
            MySqlCommand chk_cmd = new MySqlCommand(expire_check, conn);
            MySqlDataAdapter adpter = new MySqlDataAdapter(chk_cmd);
            conn.Close();
            DataTable dta = new DataTable();
            adpter.Fill(dta);
            
            foreach (DataRow dr in dta.Rows)
            {
                int prod_id = Convert.ToInt32(dr["prod_id"]);
                DateTime exp_date = Convert.ToDateTime(dr["exp_date"]);
                string prod_name = dr["prodname"] + "";
                string cat = dr["category"] + "";
                int prodquant = Convert.ToInt32(dr["add_quant"]) ;
                
                if(prodquant > 0)
                {
                    string rmv = "UPDATE product SET prodquant = prodquant - "+prodquant+ " WHERE prodid = " + prod_id + ";" +
                        "UPDATE stock_in SET status = 1 WHERE stock_in.prod_id = " + prod_id + "; ";
                    string qry = "insert into stock_out(prod_id, date,prodname,category," +
                        "prod_quant, status) Values ('" + prod_id + "','" + exp_date.Date.ToString("yyyy/MM/dd") + "','" + prod_name + "'," +
                        "'" + cat + "'," + prodquant + ", 'Expired') ";
                    conn.Open();
                    MySqlCommand cmnd = new MySqlCommand(qry, conn);
                    MySqlCommand rmv_comm = new MySqlCommand(rmv, conn);
                    rmv_comm.ExecuteNonQuery();
                    cmnd.ExecuteNonQuery();
                    conn.Close();

                }
                    if (dta.Rows.Count > 0)
                    {
                        MessageBox.Show(dta.Rows.Count + " item(s) expired and have automatically stocked out");                      
                        /*TabControl b = new TabControl();
                        b.SelectedTab = b.TabPages["tabPage3"];
                        b.Show();*/
                    }
                
             
            }
            

            string query1 = "select * from stock_out ; ";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            dataGridView4.DataSource = dt1;
            dataGridView4.Columns["stockout_id"].Visible = false;
            dataGridView4.Columns["prod_id"].HeaderText = "Product Code";
            dataGridView4.Columns["prodname"].HeaderText = "Product Name";
            dataGridView4.Columns["date"].HeaderText = "Stock Out Date";
            dataGridView4.Columns["date"].DefaultCellStyle.Format = dateFormat;
            dataGridView4.Columns["category"].HeaderText = "Category";
            dataGridView4.Columns["prod_quant"].HeaderText = "Quantity";
            dataGridView4.Columns["status"].HeaderText = "Status";


            string query2 = "select * from recipe_list ; ";
            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(query2, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);

            dataGridView5.DataSource = dt2;
            dataGridView5.Columns["recipe_id"].HeaderText = "Recipe ID";
            dataGridView5.Columns["recipe_name"].HeaderText = "Recipe Name";
            dataGridView5.Columns["recipe_desc"].HeaderText = "Description";
            dataGridView5.Columns["recipe_cat"].HeaderText = "Recipe Category";
            dataGridView5.Columns["recipe_cost"].HeaderText = "Selling Price";
            dataGridView5.Columns["recipe_unit"].HeaderText = "Unit";

            string query3 = "SELECT product.prodid, product.prodname, recipe_item_list.prod_quant " +
                "FROM recipe_list " +
                "JOIN recipe_item_list " +
                "ON recipe_list.recipe_id = recipe_item_list.recipe_id " +
                "JOIN product" +
                " ON product.prodid = recipe_item_list.prod_id" +
                " WHERE recipe_list.recipe_id = " + recipelist + " ";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);

            dataGridView6.DataSource = dt3;
            //dataGridView6.Columns["recipe_id"].Visible = false;
            //dataGridView6.Columns["recipe_code"].Visible = false;
            //dataGridView6.Columns["prod_id"].HeaderText = "Product Code";
            dataGridView6.Columns["prodid"].HeaderText = "Product ID";
            dataGridView6.Columns["prodname"].HeaderText = "Ingredient";
            dataGridView6.Columns["prod_quant"].HeaderText = "Quantity";
            //dataGridView6.Columns["recipe_name"].Visible = false;
            // dataGridView6.Columns["recipe_cat"].Visible = false;
            // dataGridView6.Columns["recipe_desc"].Visible = false;




        }
        private void loadfsix()
        {
            string query3 = "SELECT product.prodid, product.prodname, recipe_item_list.prod_quant " +
                "FROM recipe_list " +
                "JOIN recipe_item_list " +
                "ON recipe_list.recipe_id = recipe_item_list.recipe_id " +
                "JOIN product" +
                " ON product.prodid = recipe_item_list.prod_id" +
                " WHERE recipe_list.recipe_id = " + recipelist+" ";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);

            dataGridView6.DataSource = dt3;
            dataGridView6.Columns["prodid"].HeaderText = "Product ID";
            dataGridView6.Columns["prodname"].HeaderText = "Ingredient";
            dataGridView6.Columns["prod_quant"].HeaderText = "Quantity";

        }
        string currdate = DateTime.Now.Date.ToString("yyyy-MM-dd");
        public void autoExpireLog()
        {
            

            string findExpire = "select *, p.prodname, p.category from stock_in s INNER JOIN " +
                "product p ON s.prod_id = p.prodid where exp_date <= '" + currdate + "' AND status = 0 ";
            conn.Open();
            MySqlCommand comz = new MySqlCommand(findExpire, conn);
            MySqlDataAdapter adap = new MySqlDataAdapter(comz);
            conn.Close();
            DataTable dt = new DataTable();
            adap.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                int expiredStocks = Convert.ToInt32(dr["add_quant"]);
                int stockIn_id = Convert.ToInt32(dr["stockIn_id"]);
                int stockIn_prodId = Convert.ToInt32(dr["prod_id"]);
                string prodName = dr["prodname"] + "";
                string prodCat = dr["category"] + "";
                string subractExpireDate = "update product set prodquant = prodquant - " + expiredStocks +
                    " WHERE prodid = " + stockIn_prodId + "  ";
                string addLogToStockOut = "insert into stock_out(prod_id,date,prodname,category,prod_quant,status)" +
                    " VALUES(" + stockIn_prodId + ", '" + currdate + "','" + prodName + "','"+prodCat+"'," + expiredStocks + ", 'Expired')";
                string updateStockInStatus = "update stock_in set status = 1 where stockIn_id = '"+stockIn_id+"'";
                conn.Open();
                MySqlCommand runSubractExpireDate = new MySqlCommand(subractExpireDate, conn);
                MySqlCommand runAddLogToStockOut = new MySqlCommand(addLogToStockOut, conn);
                MySqlCommand runUpdateStockInStatus = new MySqlCommand(updateStockInStatus, conn);
                runSubractExpireDate.ExecuteNonQuery();
                runAddLogToStockOut.ExecuteNonQuery();
                runUpdateStockInStatus.ExecuteNonQuery();
                conn.Close();              
                
            }
            if(dt.Rows.Count >= 1)
            {
                MessageBox.Show(dt.Rows.Count + " Items have expired. Please Check Stock Out log");
                loadall();
            }
            
        }
        private void textBox2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                textBox1.Text = "Product Name";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

 

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ReadOnly = true;
            if (e.RowIndex > -1)
            {

                selected_user_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["prodid"].Value.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["prodname"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["description"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["prodquant"].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["produnit"].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["category"].Value.ToString();
                id.Text = dataGridView1.Rows[e.RowIndex].Cells["prodid"].Value.ToString();
                textBox22.Text = dataGridView1.Rows[e.RowIndex].Cells["restock_val"].Value.ToString();
            }
            string query1 = "SELECT COUNT(prodname) from product where prodid = '"+selected_user_id+"'  ";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataReader rdr = comm1.ExecuteReader();
            conn.Close();


            conn.Open();
            label39.Text = comm1.ExecuteScalar().ToString();
            conn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string query1 = "SELECT COUNT(prodname) from product where prodname = '" + textBox1.Text + "'  ";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataReader rdr = comm1.ExecuteReader();
            conn.Close();


            conn.Open();
            label39.Text = comm1.ExecuteScalar().ToString();
            conn.Close();
            
            if (textBox22.Text == "")
            {
                textBox22.Text = Convert.ToString(0);
            }else if(textBox3.Text == "")
            {
                textBox3.Text = Convert.ToString(0);
            }

            if (Convert.ToInt32(label39.Text) == 0 || Convert.ToInt32(label39.Text) < 0 )         
            {
                string query = "INSERT INTO product(prodname,description,category,prodquant,produnit,restock_val) " +
                                "VALUES('" + textBox1.Text + "','" + textBox4.Text + "', '" + comboBox2.Text + "', 0 , '" + comboBox1.Text + "', '" + textBox22.Text + "' )";
                conn.Open();

                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                loadall();
            }else
            {
                button3.PerformClick();
            }

            
        }
       
        private void Form5_Load(object sender, EventArgs e)
        {
            loadall();
            Disable_text();
            dateTimePicker1.Value = DateTime.Now.Date;
            //dateTimePicker2.Value = DateTime.Now.Date.AddDays(1);
            dateTimePicker2.Value = DateTime.Now.Date;
        }
        private void Disable_text()
        {
            textBox7.Enabled = false;
            textBox6.Enabled = false;
            comboBox3.Enabled = false;
            textBox5.Enabled = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string query = "UPDATE product SET prodname = '" + textBox1.Text + "', description = '"
                + textBox4.Text + "', category = '" + comboBox2.Text + "', prodquant = '" + textBox3.Text + "', produnit = '" + comboBox1.Text + "', restock_val = '" + textBox22.Text + "' WHERE prodid = " + selected_user_id + "  ";
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            loadall();
            RESET();
        }
        private void RESET()
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            button2.Enabled = true;
            textBox22.Clear();


            id.Clear();
            loadall();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RESET();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to delete this item", "Point of Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (iExit == DialogResult.Yes)
            {
                string query = "DELETE FROM product WHERE prodid = '" + selected_user_id + "' ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                loadall();
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.ForeColor = Color.Black;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.ReadOnly = true;
            if (e.RowIndex > -1)
            {

                selected_user_id = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["prodid"].Value.ToString());
                textBox12.Text = dataGridView3.Rows[e.RowIndex].Cells["prodname"].Value.ToString();
                textBox13.Text = dataGridView3.Rows[e.RowIndex].Cells["prodquant"].Value.ToString();
                comboBox4.Text = dataGridView3.Rows[e.RowIndex].Cells["category"].Value.ToString();
                textBox8.Text = dataGridView3.Rows[e.RowIndex].Cells["prodid"].Value.ToString();
            }
            button15.Enabled = false;
            button13.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (id.Text == "")
            {
                loadall();
            }
            else
            {


                string query = "Select * FROM product WHERE prodid = '" + id.Text + "' ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
            }

            }

        private void button10_Click(object sender, EventArgs e)
        {
            if(exp_date.Value <= Convert.ToDateTime(currdate))
            {
                MessageBox.Show("Invalid Expiry Date, Product already expired");
                return;
            }
            if(textBox10.Text == "")
            {
                MessageBox.Show("Please input Valid Number");
            }
            else if(Convert.ToInt32(textBox10.Text) < 0)
            {
                MessageBox.Show("Please input Valid Number");
            }
            else
            {
               
                string addStock = "INSERT INTO stock_in(date_added, prod_id, exp_date, add_quant)" +
                    "values( CURRENT_TIMESTAMP, '"+textBox6.Text+"', '"+ exp_date.Value.Date.ToString("yyyy/MM/dd") + "', '"+textBox10.Text+"'); ";
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand(addStock, conn);
                cmd1.ExecuteNonQuery();
                conn.Close();

                string query = "UPDATE product SET prodquant = prodquant + " + textBox10.Text + " WHERE prodid = " + selected_user_id + "  ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                loadall();
                MessageBox.Show("Stocked in Product ID: " + textBox6.Text+ " by " + textBox10.Text );
            }
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.ReadOnly = true;
            if (e.RowIndex > -1)
            {

                selected_user_id = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["prodid"].Value.ToString());
                textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells["description"].Value.ToString();
                textBox7.Text = dataGridView2.Rows[e.RowIndex].Cells["prodquant"].Value.ToString();
                comboBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["category"].Value.ToString();
                textBox6.Text = dataGridView2.Rows[e.RowIndex].Cells["prodid"].Value.ToString();
            }
        }
        public void DisplayLowQuantityItems()
        {
            string query = "Select prodname from product where prodquant <= restock_val ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataReader reader = comm.ExecuteReader();
            StringBuilder productNames = new StringBuilder();
            while (reader.Read())
            {
                productNames.Append(reader["prodname"].ToString() + Environment.NewLine);
            }
            conn.Close();
            MessageBox.Show("Following Product(s) need to restock: \n" + productNames);
        }


        private void tabPage2_Click(object sender, EventArgs e)
        {
            //loadall();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = "Select * FROM product WHERE prodid = '" + textBox9.Text + "' ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView2.DataSource = dt;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }


        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox12.Text == "" || comboBox4.Text == "" || textBox13.Text == "" || comboBox5.Text == "")
            {
                MessageBox.Show("Please Fill up the form to stock out", "Point of Sale", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (Convert.ToInt32(textBox11.Text) < 0)
            {
                MessageBox.Show("Please input Valid Number");
            }
            else
            {
                int current_stock = Convert.ToInt32(textBox13.Text), prod_quant = Convert.ToInt32(textBox11.Text);
                if (current_stock >= prod_quant)
                {
                    string query = "UPDATE product SET prodquant = prodquant - " + textBox11.Text + " WHERE prodid = " + selected_user_id + "  ";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.ExecuteNonQuery();

                    string query1 = "INSERT INTO stock_out(prod_id,date,prodname,category,prod_quant,status) " +
                        "VALUES('" + textBox8.Text + "',CURRENT_DATE, '" + textBox12.Text + "' ,'" + comboBox4.Text + "', '" + textBox11.Text + "', '" + comboBox5.Text + "')";
                    MySqlCommand comm1 = new MySqlCommand(query1, conn);
                    comm1.ExecuteNonQuery();
                    conn.Close();
                    loadall();
                    DisplayLowQuantityItems();
                }
                else
                {
                    MessageBox.Show("Insuffecient Stocks, Please re-stock");
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to delete this stock out info", "Point of Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (iExit == DialogResult.Yes)
            {
                string query = "DELETE FROM stock_out WHERE stockout_id = '" + selected_user_id + "' ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                loadall();
            }
        }

        private void dataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView4.ReadOnly = true;
            if (e.RowIndex > -1)
            {

                selected_user_id = int.Parse(dataGridView4.Rows[e.RowIndex].Cells["stockout_id"].Value.ToString());
                //textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["prodname"].Value.ToString();
                //textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["prodprice"].Value.ToString();
                textBox12.Text = dataGridView4.Rows[e.RowIndex].Cells["prodname"].Value.ToString();

                //comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["produnit"].Value.ToString();
                comboBox4.Text = dataGridView4.Rows[e.RowIndex].Cells["category"].Value.ToString();
                textBox8.Text = dataGridView4.Rows[e.RowIndex].Cells["prod_id"].Value.ToString();
                comboBox5.Text = dataGridView4.Rows[e.RowIndex].Cells["status"].Value.ToString();
                textBox11.Text = dataGridView4.Rows[e.RowIndex].Cells["prod_quant"].Value.ToString();
                textBox13.Clear();

            }
            button13.Enabled = false;
            button15.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "Select * FROM product WHERE prodid = '" + textBox14.Text + "' ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView3.DataSource = dt;

            string query1 = "Select * FROM stock_out WHERE prod_id = '" + textBox14.Text + "' ";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            dataGridView4.DataSource = dt1;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            loadall();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (comboBox6.Text == "Item Name" || comboBox6.Text == "")
            {
                string query = "Select * FROM product WHERE prodname LIKE '%" + textBox21.Text + "%' ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView6.DataSource = dt;

            } else if (comboBox6.Text == "Item Category")
            {
                string query = "Select * FROM product WHERE category LIKE '%" + textBox21.Text + "%' ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView6.DataSource = dt;
            }

        }

        private void button21_Click(object sender, EventArgs e)
        {
            loadall();
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            DisplayLowQuantityItems();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                
                selected_user_id = int.Parse(dataGridView6.Rows[e.RowIndex].Cells["prodid"].Value.ToString());
                textBox19.Text = dataGridView6.Rows[e.RowIndex].Cells["prodid"].Value.ToString();
                textBox20.Text = dataGridView6.Rows[e.RowIndex].Cells["prodname"].Value.ToString();
                //textBox18.Text = dataGridView6.Rows[e.RowIndex].Cells["prod_quant"].Value.ToString();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string query1 = "SELECT COUNT(recipe_name) from recipe_list where recipe_name = '"+ textBox16.Text +"'  ";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataReader rdr = comm1.ExecuteReader();
            conn.Close();


            conn.Open();
            label36.Text = comm1.ExecuteScalar().ToString();
            conn.Close();

            if(Convert.ToInt32(label36.Text) == 0)
            {
                if (textBox23.Text == "")
                {
                    MessageBox.Show("Please input recipe cost");

                }
                else
                {
                    string query = " insert into recipe_list(recipe_name, recipe_desc, recipe_cat, recipe_cost,recipe_unit) values('" + textBox16.Text + "' , '" + textBox17.Text + "', '" + comboBox7.Text + "' ,'" + textBox23.Text + "' , '" + comboBox8.Text + "')";
                    conn.Open();


                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadall();
                }
            }
            else
            {
                MessageBox.Show("RECIPE ALREADY EXIST");
            }
            
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                textBox15.Text = dataGridView5.Rows[e.RowIndex].Cells["recipe_id"].Value.ToString();
                textBox16.Text = dataGridView5.Rows[e.RowIndex].Cells["recipe_name"].Value.ToString();
                comboBox7.Text = dataGridView5.Rows[e.RowIndex].Cells["recipe_cat"].Value.ToString();
               // textBox20.Text = dataGridView5.Rows[e.RowIndex].Cells["prod_name"].Value.ToString();
                comboBox8.Text = dataGridView5.Rows[e.RowIndex].Cells["recipe_unit"].Value.ToString();
                textBox17.Text = dataGridView5.Rows[e.RowIndex].Cells["recipe_desc"].Value.ToString();
                textBox23.Text = dataGridView5.Rows[e.RowIndex].Cells["recipe_cost"].Value.ToString();
                recipelist = int.Parse(dataGridView5.Rows[e.RowIndex].Cells["recipe_id"].Value.ToString());

            }
            //MessageBox.Show(Convert.ToString(recipelist));
            loadfsix();
        }
        public String prdcode { get; set; }
        
        public String dsc { get; set; }
        public String qnt { get; set; }
        public String unt { get; set; }
        private void button18_Click(object sender, EventArgs e)
        {
            loadall();
            button16.Enabled = true;

        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (textBox23.Text == "")
            {
                MessageBox.Show("Input price");
                textBox23.Text = Convert.ToString(0);
            }
            string query = "UPDATE recipe_list SET recipe_name = '" + textBox16.Text + "', recipe_desc = '" + textBox17.Text + "', recipe_cat = '"
               + comboBox7.Text + "', recipe_cost = '" + textBox23.Text + "', recipe_unit = '" + comboBox8.Text + "' WHERE recipe_id = " + recipelist + "  ";
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            loadall();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to remove this ingredient", "Point of Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (iExit == DialogResult.Yes)
            {
                string query = "DELETE FROM recipe_list WHERE recipe_id = '" + recipelist + "' ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                loadall();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string query = "Select * FROM recipe_list WHERE recipe_id = '" + textBox15.Text + "' ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView5.DataSource = dt;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            /*string query = "Select DISTINCT recipe_id, recipe_code, recipe_name, recipe_desc FROM recipe_tbl ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView5.DataSource = dt;*/
            }

            private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void button19_Click_1(object sender, EventArgs e)
        {
            passingtext = textBox15.Text;
            ingredient_list a = new ingredient_list();
            a.Show();

        }

        private void Form5_Activated(object sender, EventArgs e)
        {
            loadfsix();
            autoExpireLog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string query = "UPDATE recipe_item_list SET prod_quant = '" + textBox18.Text + "'  WHERE prod_id = " + selected_user_id + "  ";
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            loadall();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM recipe_item_list WHERE prod_id = " + selected_user_id + "  ";
            conn.Open();

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            loadall();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string query1 = "SELECT COUNT(prodname) from product where prodname = '" + textBox1.Text + "'  ";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataReader rdr = comm1.ExecuteReader();
            conn.Close();


            conn.Open();
            label39.Text = comm1.ExecuteScalar().ToString();
            conn.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'')
            {
                e.Handled = true;
            }
            string query1 = "SELECT COUNT(prodname) from product where prodname = '" + textBox1.Text + "'  ";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataReader rdr = comm1.ExecuteReader();
            conn.Close();


            conn.Open();
            label39.Text = comm1.ExecuteScalar().ToString();
            conn.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

            string query1 = "SELECT COUNT(prodname) from product where prodname = '" + textBox1.Text + "'  ";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataReader rdr = comm1.ExecuteReader();
            conn.Close();


            conn.Open();
            label39.Text = comm1.ExecuteScalar().ToString();
            conn.Close();
        }

        private void id_KeyDown(object sender, KeyEventArgs e)
        {
            if (id.Text == "")
            {
                loadall();
            }
            else
            {


                string query = "Select * FROM product WHERE prodid = '" + id.Text + "' ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void id_KeyUp(object sender, KeyEventArgs e)
        {
            if (id.Text == "")
            {
                loadall();
            }
            else
            {


                string query = "Select * FROM product WHERE prodid = '" + id.Text + "' ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string search = "select date_added, product.prodname, add_quant from stock_in " +
                                "JOIN product where stock_in.prod_id = product.prodid AND" +
                                "(date_added >= '"+dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and date_added <= '"+dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' ) AND" +
                                " stock_in.prod_id = "+textBox2.Text+" ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(search, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                stck_in_Grid.DataSource = dt;

            }
            else
            {
                string search = "select date_added, product.prodname, add_quant from stock_in " +
                                "JOIN product where stock_in.prod_id = product.prodid AND" +
                                "(date_added >= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and date_added <= '"+dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(search, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                stck_in_Grid.DataSource = dt;

            }
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            loadall();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            loadall();
        }

        private void ProductList_FormClosing(object sender, FormClosingEventArgs e)
        {
            previousform.Show();
        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (textBox24.Text != "")
            {
                string search = "select date, product.prodname, prod_quant from stock_out " +
                                "JOIN product where stock_out.prod_id = product.prodid AND" +
                                "(date >= '" + dateTimePicker4.Value.ToString("yyyy-MM-dd") + "' and date <= '" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "' ) AND" +
                                " stock_out.prod_id = " + textBox24.Text + " ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(search, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView4.DataSource = dt;

            }
            else
            {
                string search = "select date, product.prodname, prod_quant from stock_out " +
                                "JOIN product where stock_out.prod_id = product.prodid AND" +
                                "(date >= '" + dateTimePicker4.Value.ToString("yyyy-MM-dd") + "' and date <= '" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "')";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(search, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView4.DataSource = dt;

            }
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }
    }
        
}

