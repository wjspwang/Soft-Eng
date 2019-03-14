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
    public partial class PoS : Form
    {

        MySqlConnection conn;
        public Form previousform;
        public PoS()
        {
            InitializeComponent();
            MainMenu f2 = new MainMenu();
            conn = new MySqlConnection("server=localhost;Database=pawesome_db;uid=root; Pwd = root;");
        }
        double Total;
        public int invoice = 1;
        float price;
        int quant;
        float pos_total;
        float percent;
        private void connectionState()
        {
            if (conn.State != ConnectionState.Open)
            {

                conn.Open();

            }
            else
            {
            }

        }
        private void current_invoice()
        {
            string query = "select count(invoice_id) from sales_tbl";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            invoice_ui.Text = Convert.ToString(Convert.ToInt32(dt.Rows[0]["count(invoice_id)"]) + 1);

        }




        private void Form8_Load(object sender, EventArgs e)
        {
            loadall();
            textBox5.Text = Convert.ToString(0);
            textBox7.Text = Convert.ToString(0);
            textBox13.Text = Convert.ToString(0);

            float.TryParse(textBox5.Text, out price);
            int.TryParse(textBox7.Text, out quant);

            textBox6.Text = Convert.ToString(price * quant);


        }
        private void loadall()
        {
            current_invoice();
            updateOrderCount();
            textBox14.Text = Convert.ToString(invoice_ui.Text);
            string query = " select * from order_line where invoice_id = " + invoice_ui.Text + " ;";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;

            dataGridView1.Columns["order_line_id"].Visible = false;
            dataGridView1.Columns["date_time"].HeaderText = "Date of Transaction";
            dataGridView1.Columns["invoice_id"].HeaderText = "Invoice #";
            dataGridView1.Columns["prod_id"].HeaderText = "Item Code";
            dataGridView1.Columns["prodname"].HeaderText = "Item Name";
            dataGridView1.Columns["category"].HeaderText = "Category";
            dataGridView1.Columns["prod_unit"].HeaderText = "Unit of Measure";
            dataGridView1.Columns["prod_quant"].HeaderText = "Product Quantity";
            dataGridView1.Columns["prod_price"].HeaderText = "Product Price";
            dataGridView1.Columns["total"].HeaderText = "Total Price";


            string query1 = "select * from recipe_list";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            dataGridView2.DataSource = dt1;

            dataGridView2.DataSource = dt1;
            dataGridView2.Columns["recipe_id"].Visible = false;
            dataGridView2.Columns["recipe_name"].HeaderText = "Dish Name";
            dataGridView2.Columns["recipe_desc"].HeaderText = "Description";
            dataGridView2.Columns["recipe_cat"].HeaderText = "Category";
            dataGridView2.Columns["recipe_cost"].HeaderText = "Selling Price";
            dataGridView2.Columns["recipe_unit"].HeaderText = "Unit";


            string query3 = " SELECT COUNT(prod_id) FROM order_line where invoice_id = " + invoice_ui.Text + "";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query3, conn);
            MySqlDataReader rdr = comm3.ExecuteReader();
            conn.Close();

            conn.Open();
            textBox2.Text = comm3.ExecuteScalar().ToString();
            conn.Close();

            string query4 = "SELECT SUM(total) FROM order_line Where invoice_id = " + invoice_ui.Text + ";";
            conn.Open();
            MySqlCommand comm4 = new MySqlCommand(query4, conn);
            MySqlDataReader rdr1 = comm4.ExecuteReader();
            conn.Close();

            conn.Open();
            textBox10.Text = comm4.ExecuteScalar().ToString();
            conn.Close();


            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProductList a = new ProductList();
            a.Show();
            a.previousform = this;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }
        private int selected_user_id;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ReadOnly = true;
            if (e.RowIndex > -1)
            {
                selected_user_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["order_line_id"].Value.ToString());



            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                string query = "select * from order_line where date_time >= '" + fromdate.Value.ToString("yyyy-MM-dd") + "' and date_time <= '" + todate.Value.ToString("yyyy-MM-dd") + "' ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            else
            {
                string query1 = "select * from order_line where invoice_id = '" + textBox1.Text + "' AND date_time >= '" + fromdate.Value.ToString("yyyy-MM-dd") + "' and date_time <= '" + todate.Value.ToString("yyyy-MM-dd") + "' ";
                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(query1, conn);
                MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                conn.Close();
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);

                dataGridView1.DataSource = dt1;
            }

        }
        private int selected_user_id1;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //lowStocks();
            if (e.RowIndex > -1)
            {

                selected_user_id1 = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["recipe_id"].Value.ToString());
                textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["recipe_name"].Value.ToString();
                textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells["recipe_cost"].Value.ToString();
                //textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells["description"].Value.ToString();
                //textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells["recipe_cost"].Value.ToString();
                textBox9.Text = dataGridView2.Rows[e.RowIndex].Cells["recipe_unit"].Value.ToString();
                textBox8.Text = dataGridView2.Rows[e.RowIndex].Cells["recipe_cat"].Value.ToString();
                textBox16.Text = dataGridView2.Rows[e.RowIndex].Cells["recipe_id"].Value.ToString();
            }
            textBox7.Text = Convert.ToString(0);
            string query = "select a.prodname, a.prodquant, b.prod_quant from product a, recipe_item_list b, recipe_list c where c.recipe_id = " + selected_user_id1 + " AND c.recipe_id = b.recipe_id AND a.prodid = b.prod_id ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView3.DataSource = dt;
            dataGridView3.Columns["prodname"].HeaderText = "Ingredient";
            dataGridView3.Columns["prod_quant"].HeaderText = "Consumption";
            dataGridView3.Columns["prodquant"].HeaderText = "Stocks";

            updateOrderCount();

        }
        private void lowStocks()
        {
            string query = "select count(prodname) from product a, recipe_item_list b, recipe_list c where c.recipe_id = " + selected_user_id1 + " AND prodquant <= restock_val AND prodquant > 0 AND c.recipe_id = b.recipe_id AND a.prodid = b.prod_id";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query, conn);
            MySqlDataReader rdr = comm3.ExecuteReader();
            conn.Close();

            conn.Open();
            lowstock.Text = comm3.ExecuteScalar().ToString();
            conn.Close();





        }
        private void noStock()
        {
            string query = "select count(prodname) from product a, recipe_item_list b, recipe_list c where c.recipe_id = " + selected_user_id1 + " AND prodquant <= 0 AND c.recipe_id = b.recipe_id AND a.prodid = b.prod_id";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query, conn);
            MySqlDataReader rdr = comm3.ExecuteReader();
            conn.Close();

            conn.Open();
            label33.Text = comm3.ExecuteScalar().ToString();
            conn.Close();
        }
        private void updateOrderCount()
        {
            string query5 = "SELECT COUNT(prod_id) FROM order_line WHERE prod_id = " + selected_user_id1 + " AND invoice_id = " + invoice_ui.Text + "";
            conn.Open();
            MySqlCommand comm5 = new MySqlCommand(query5, conn);
            MySqlDataReader rdr2 = comm5.ExecuteReader();
            conn.Close();

            conn.Open();
            label13.Text = comm5.ExecuteScalar().ToString();
            conn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int recipe_id = selected_user_id1;
            int multiplier = Convert.ToInt32(textBox7.Text);
            string querya = "select * from recipe_item_list where recipe_id = " + recipe_id;
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(querya, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                int quantity = Convert.ToInt32(dr["prod_quant"] + "") * multiplier;
                string id = dr["prod_id"] + "";
                string queryb = "select * from product where prodid = " + id;
                conn.Open();
                MySqlCommand comm2 = new MySqlCommand(queryb, conn);
                MySqlDataAdapter adp1 = new MySqlDataAdapter(comm2);
                conn.Close();
                DataTable dt2 = new DataTable();
                adp1.Fill(dt2);

                foreach (DataRow dr2 in dt2.Rows)
                {
                    int total_prod = Convert.ToInt32(dr2["prodquant"]);
                    if (quantity > total_prod)
                    {

                        MessageBox.Show("Insufficient Ingredients");
                        return;
                    }
                }

            }
            if (Convert.ToInt32(textBox7.Text) == 0)
            {
                MessageBox.Show("Please Fill Up Quantity Required Field", "Point of Sale", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Total = Convert.ToDouble(textBox5.Text) * Convert.ToDouble(textBox7.Text);
                textBox6.Text = Convert.ToString(Total);
                if (Convert.ToInt32(label33.Text) > 0)
                {
                    string query2 = "select prodname from product a, recipe_item_list b, recipe_list c where c.recipe_id = " + selected_user_id1 + " AND prodquant <= restock_val AND c.recipe_id = b.recipe_id AND a.prodid = b.prod_id ";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query2, conn);
                    MySqlDataReader reader = comm.ExecuteReader();
                    StringBuilder productNames = new StringBuilder();
                    while (reader.Read())
                    {
                        productNames.Append(reader["prodname"].ToString() + Environment.NewLine);
                    }
                    conn.Close();
                    MessageBox.Show("Out of Stocks", "Please Re-Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show("Following Products need to restock: " + productNames, "Out of ingredients", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (Convert.ToInt32(lowstock.Text) > 0)
                {
                    string query2 = "select prodname from product a, recipe_item_list b, recipe_list c where c.recipe_id = " + selected_user_id1 + " AND prodquant <= restock_val AND c.recipe_id = b.recipe_id AND a.prodid = b.prod_id ";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query2, conn);
                    MySqlDataReader reader = comm.ExecuteReader();
                    StringBuilder productNames = new StringBuilder();
                    while (reader.Read())
                    {
                        productNames.Append(reader["prodname"].ToString() + Environment.NewLine);
                    }
                    conn.Close();
                    MessageBox.Show("Warning Low Stocks", "Low Stocks", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show("Following Products need to restock: " + productNames, "Out of ingredients", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return;
                }
                if (Convert.ToInt32(label13.Text) == 0)
                {
                    MessageBox.Show("ITEM ADDED TO THE ORDER");
                    string query = "INSERT INTO order_line(date_time, invoice_id, prod_id, prodname, category, prod_unit, prod_quant, prod_price, total) VALUES(CURRENT_DATE, '" + invoice_ui.Text + "', '" + textBox16.Text + "', '" + textBox3.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox7.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "');";
                    conn.Open();

                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("ITEM ADDED TO THE ORDER");
                    loadall();
                }
                else
                {
                    string query = " update order_line set prod_quant =  prod_quant + '" + textBox7.Text + "' , total = total + '" + textBox6.Text + "' where prod_id = '" + textBox16.Text + "' ";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("ITEM UPDATED");
                    loadall();
                }



            }



            //invoice = invoice + 1;
        }






        private void add_Invoice()
        {
            /*string query1 = "select max(invoice_id) from sales_tbl";
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataReader rdr = comm1.ExecuteReader();
            conn.Close();


            conn.Open();
            tmp = (int)comm1.ExecuteScalar();
            */
            //cur_Invoice += 1 ;
            /*
            conn.Close(); */
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to delete this item", "Point of Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (iExit == DialogResult.Yes)
            {
                string query = "DELETE FROM order_line WHERE order_line_id = '" + selected_user_id + "' ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                loadall();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Total = Convert.ToDouble(textBox5.Text) * Convert.ToDouble(textBox7.Text);
            textBox6.Text = Convert.ToString(Total);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 ||
                e.KeyCode == Keys.D5 || e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 || e.KeyCode == Keys.D9 || e.KeyCode == Keys.D0)
            {
                int.TryParse(textBox5.Text, out val1);
                int.TryParse(textBox7.Text, out val2);

                textBox6.Text = Convert.ToString(val1 * val2);
            }*/

            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 ||
                e.KeyCode == Keys.D5 || e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 || e.KeyCode == Keys.D9 || e.KeyCode == Keys.Back
                || e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4
                 || e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.NumPad9)
            {
                float.TryParse(textBox5.Text, out price);
                int.TryParse(textBox7.Text, out quant);

                textBox6.Text = Convert.ToString(price * quant);
            }
        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 ||
                e.KeyCode == Keys.D5 || e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 || e.KeyCode == Keys.D9 || e.KeyCode == Keys.Back
                || e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4
                 || e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.NumPad9)
            {
                float.TryParse(textBox5.Text, out price);
                int.TryParse(textBox7.Text, out quant);

                textBox6.Text = Convert.ToString(price * quant);
            }

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 ||
                e.KeyCode == Keys.D5 || e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 || e.KeyCode == Keys.D9 || e.KeyCode == Keys.Back
                || e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4
                 || e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.NumPad9)
            {


                float.TryParse(textBox10.Text, out pos_total);
                float.TryParse(textBox11.Text, out percent);

                float rate = percent / 100;




                label17.Text = Convert.ToString(pos_total - pos_total * rate);
                double discounted = pos_total - pos_total * rate;

            }


        }

        private void textBox11_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 ||
                e.KeyCode == Keys.D5 || e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 || e.KeyCode == Keys.D9 || e.KeyCode == Keys.Back
                || e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4
                 || e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.NumPad9)
            {


                float.TryParse(textBox10.Text, out pos_total);
                float.TryParse(textBox11.Text, out percent);

                float rate = percent / 100;




                label17.Text = Convert.ToString(pos_total - pos_total * rate);
                double discounted = pos_total - pos_total * rate;

            }
        }
        float total, tendered, payable;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == Convert.ToString(0))
            {
                MessageBox.Show("Invalid Purchase");
            }
            else
            {
                
                //MessageBox.Show(tendered + "");
                if (label17.Text == Convert.ToString(0))
                {
                    label18.Text = Convert.ToString(0);
                    label27.Text = Convert.ToString(0);
                    float.TryParse(textBox13.Text, out tendered);
                        
                    /*float.TryParse(textBox10.Text, out total);
                    if (tendered <= 0 || label17.Text == "" || tendered < total)
                    {
                        MessageBox.Show("Invalid Paid Amount");
                        return;
                    }*/
                    label29.Text = Convert.ToString(tendered - total);
                    label25.Text = textBox2.Text;
                    label26.Text = textBox10.Text;
                    label28.Text = textBox13.Text;
                }
                else
                {
                    float.TryParse(label17.Text, out payable);
                    float.TryParse(textBox13.Text, out tendered);

                    /*if (tendered <= 0 || label17.Text == "" || tendered < payable)
                    {
                        MessageBox.Show("Invalid Paid Amount");
                        return;
                    }*/

                    label29.Text = Convert.ToString(tendered - payable);
                    label25.Text = textBox2.Text;
                    label26.Text = textBox10.Text;
                    label27.Text = comboBox1.Text;
                    label18.Text = label17.Text;
                    label28.Text = textBox13.Text;
                }
                if (comboBox1.Text == "")
                {
                    comboBox1.Text = Convert.ToString(0);
                }
                else if (Convert.ToInt32(comboBox1.Text) >= 100)
                {
                    MessageBox.Show("Invalid Discount Ammount", "Invalid Input", MessageBoxButtons.OK);
                }
                else if (label17.Text != Convert.ToString(0))
                {
                    if (Convert.ToDouble(textBox13.Text) < Convert.ToDouble(label17.Text))
                    {
                        MessageBox.Show("Invalid Paid Amount", "Invalid Input", MessageBoxButtons.OK);

                    }
                    else
                    {



                        if (Convert.ToDouble(label29.Text) >= 0)
                        {

                            int num = 0;
                            string query = "select count(prod_id) from order_line " +
                                "where invoice_id = " + invoice_ui.Text + "";
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            MySqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                num = Convert.ToInt32(reader["count(prod_id)"]);
                            }
                            conn.Close();

                            int[] data = new int[num];
                            for (int i = 0; i < num; i++)
                            {
                                int recipe_id = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());
                                int multiplier = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value.ToString());
                                string querya = "select * from recipe_item_list where recipe_id = " + recipe_id;
                                conn.Open();
                                MySqlCommand comm = new MySqlCommand(querya, conn);
                                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                                conn.Close();
                                DataTable dt = new DataTable();
                                adp.Fill(dt);

                                foreach (DataRow dr in dt.Rows)
                                {
                                    int quantity = Convert.ToInt32(dr["prod_quant"] + "") * multiplier;
                                    string id = dr["prod_id"] + "";
                                    
                                    string queryb = "update product p set prodquant = prodquant - " + quantity + " where prodid = " + id;

                                    conn.Open();
                                    MySqlCommand comm1 = new MySqlCommand(queryb, conn);
                                    comm1.ExecuteNonQuery();
                                    conn.Close();
                                }

                            }
                            int num0 = 0;
                            string query0 = "select count(prod_id) from order_line " +
                                "where invoice_id = " + invoice_ui.Text + "";
                            conn.Open();
                            MySqlCommand cmd0 = new MySqlCommand(query0, conn);
                            MySqlDataReader reader0 = cmd.ExecuteReader();
                            if (reader0.Read())
                            {
                                num0 = Convert.ToInt32(reader0["count(prod_id)"]);
                            }
                            conn.Close();
                            DialogResult Confirm;
                            Confirm = MessageBox.Show("Proceed with Order ?", "Verification", MessageBoxButtons.YesNo);
                            if(Confirm == DialogResult.Yes)
                            {
                                int[] data0 = new int[num0];
                                for (int i = 0; i < num0; i++)
                                {
                                    int recipe_id = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());
                                    int recipe_quant = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value.ToString());
                                    string total_price0 = Convert.ToString(dataGridView1.Rows[i].Cells[9].Value.ToString());
                                    string querya = "insert into sales_tbl(invoice_id, recipe_id, sale_item_quant, total_price)  VALUES('" + textBox14.Text + "', '" + recipe_id + "'  , '" + recipe_quant + "' , '" + total_price0 + "'  )";
                                    conn.Open();
                                    MySqlCommand comm = new MySqlCommand(querya, conn);
                                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                                    conn.Close();
                                    DataTable dt = new DataTable();
                                    adp.Fill(dt);
                                }
                                DataTable dt1 = new DataTable();
                                DataSet ds = new DataSet();

                                dt1 = dataGridView1.DataSource as DataTable;
                                ds.Tables.Add(dt1);
                                Form4 f = new Form4(ds, "receipt");
                                f.Show();

                                MessageBox.Show("Invoice Submitted, Thank you");

                                textBox2.Clear();
                                textBox10.Clear();




                                label17.Text = "0";
                                label25.Text = "0";
                                label26.Text = "0";
                                label27.Text = "0";
                                label18.Text = "0";
                                label28.Text = "0";
                                label29.Text = "0";
                                textBox13.Clear();


                                loadall();
                            }
                            else
                            {
                                return;
                            }       

                        }



                        else if (tendered <= 0 || label17.Text == "")
                        {
                            if (Convert.ToDouble(textBox13.Text) < Convert.ToDouble(textBox10.Text))
                            {
                                MessageBox.Show("Invalid Pay Amount", "Invalid Input", MessageBoxButtons.OK);
                            }
                            else
                            {

                                //string stock_query = "select recipe_item_list ";
                                if (Convert.ToDouble(label29.Text) >= 0)
                                {


                                  


                                    int num = 0;
                                    string query = "select count(prod_id) from order_line " +
                                        "where invoice_id = " + invoice_ui.Text + "";
                                    conn.Open();
                                    MySqlCommand cmd = new MySqlCommand(query, conn);
                                    MySqlDataReader reader = cmd.ExecuteReader();
                                    if (reader.Read())
                                    {
                                        num = Convert.ToInt32(reader["count(prod_id)"]);
                                    }
                                    conn.Close();


                                    // int prodid_data = 0;
                                    // int prodquant_data = 0;
                                    int[] data = new int[num];
                                    for (int i = 0; i < num; i++)
                                    {
                                        int recipe_id = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());
                                        int multiplier = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value.ToString());
                                        string querya = "select * from recipe_item_list where recipe_id = " + recipe_id;
                                        conn.Open();
                                        MySqlCommand comm = new MySqlCommand(querya, conn);
                                        MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                                        conn.Close();
                                        DataTable dt = new DataTable();
                                        adp.Fill(dt);

                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            int quantity = Convert.ToInt32(dr["prod_quant"] + "") * multiplier;
                                            string id = dr["prod_id"] + "";
                                           
                                            string queryb = "update product p set prodquant = prodquant - " + quantity + " where prodid = " + id;

                                            conn.Open();
                                            MySqlCommand comm1 = new MySqlCommand(queryb, conn);
                                            comm1.ExecuteNonQuery();
                                            conn.Close();

                                        }
                                    }

                                    string query4 = "INSERT INTO sales_tbl(invoice_id, sale_item_quant, total_price)  VALUES('" + textBox14.Text + "', '" + textBox2.Text + "' , '" + textBox10.Text + "'  )";
                                    conn.Open();
                                    
                                    MySqlCommand comm4 = new MySqlCommand(query4, conn);
                                   
                                    comm4.ExecuteNonQuery();
                                    conn.Close();
                                    MessageBox.Show("Invoice Submitted, Thank you");
                                    textBox2.Clear();
                                    textBox10.Clear();


                                    loadall();

                                    label17.Text = "0";
                                    label25.Text = "0";
                                    label26.Text = "0";
                                    label27.Text = "0";
                                    label18.Text = "0";
                                    label28.Text = "0";
                                    label29.Text = "0";
                                    textBox13.Clear();







                                }
                            }
                        }



                        /*
                        int height = dataGridView1.Height;
                        dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                        bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                        dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                        dataGridView1.Height = height;
                        //PrintPreviewDialog.ShowDialog();
                        */
                    }

                }
            }
        }
    

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            loadall();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query1 = "select * from order_line where invoice_id = '" + textBox1.Text + "'  ";
           
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            dataGridView1.DataSource = dt1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
          
            
            
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
 

            
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
 

            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            float.TryParse(textBox10.Text, out pos_total);
            float.TryParse(comboBox1.Text, out percent);

            float rate = percent / 100;




            label17.Text = Convert.ToString(pos_total - pos_total * rate);
            double discounted = pos_total - pos_total * rate;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void invoice_ui_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Activated(object sender, EventArgs e)
        {
            lowStocks();
            noStock();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void todate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void nostock_Click(object sender, EventArgs e)
        {

        }

        private void lowstock_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void PoS_FormClosing(object sender, FormClosingEventArgs e)
        {
            previousform.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
 }


