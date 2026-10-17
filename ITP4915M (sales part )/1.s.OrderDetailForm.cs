using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class OrderDetailForm : Form
    {
        string orderId;
        string currentUser;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public OrderDetailForm(string oid, string user)
        {
            InitializeComponent();
            orderId = oid;
            currentUser = user;
        }

        private void OrderDetailForm_Load(object sender, EventArgs e)
        {
            LoadOrderDetails();
            SetupButtons();
        }

        private void LoadOrderDetails()
        {
            string sql = @"SELECT o.OrderID, o.dDATA as DeliveryDate, o.States, 
                          o.CustomerID, c.Name, c.Address
                   FROM `order` o
                   LEFT JOIN customer c ON o.CustomerID = c.CustomerID
                   WHERE o.OrderID = @oid";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@oid", orderId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                       
                        textBox1.Text = row["OrderID"].ToString();

                        
                        if (row["DeliveryDate"] != DBNull.Value)
                        {
                            dtpDeliveryDate.Value = Convert.ToDateTime(row["DeliveryDate"]);
                        }

                       
                        txtCustomerID.Text = row["CustomerID"].ToString();
                     
                        txtAddress.Text = row["Address"] != DBNull.Value ? row["Address"].ToString() : "null";

                        txtOrderDate.Text = DateTime.Now.ToShortDateString();
                    }
                    else
                    {
                        MessageBox.Show("Order information not found! Please confirm OrderID: " + orderId);
                    }
                }
            }

            string sqlItems = @"SELECT oi.oitemID, p.ProductName, oi.qty , oi.state, oi.custom
                                FROM orderitem oi
                                JOIN product p ON oi.pid = p.ProductID
                                WHERE oi.OrderID = @oid";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlItems, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@oid", orderId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvOrderItems.DataSource = dt;
                }
            }
        }

    

        private void SetupButtons()
        {
            btnBack.Click += (s, ev) => NavigateToForm(new OrderListForm(currentUser));
            btnCancelOrder.Click += BtnCancelOrder_Click;
            btnNewOrder.Click += (s, ev) => NavigateToForm(new ShoppingCartForm(currentUser));
            btnOrderList.Click += (s, ev) => NavigateToForm(new OrderListForm(currentUser));
            btnMail.Click += (s, ev) => NavigateToForm(new MailForm(currentUser));
            btnLogout.Click += (s, ev) => { this.Close(); Application.OpenForms[0]?.Show(); };
            btnEdit.Click += (s, ev) =>
            {
               
                Form15 editForm = new Form15(orderId);
                editForm.ShowDialog(); 
                LoadOrderDetails();    
            };
        }

        private void BtnCancelOrder_Click(object sender, EventArgs e)
        {
           
            DialogResult result = MessageBox.Show("Are you sure you want to cancel this order? This action cannot be reversed",
                                                  "Order Cancellation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction(); 

                try
                {
                    
                    string sqlDeleteItems = "DELETE FROM orderitem WHERE OrderID = @oid";
                    using (MySqlCommand cmd = new MySqlCommand(sqlDeleteItems, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@oid", orderId);
                        cmd.ExecuteNonQuery();
                    }

                    
                    string sqlDeleteOrder = "DELETE FROM `order` WHERE OrderID = @oid";
                    using (MySqlCommand cmd = new MySqlCommand(sqlDeleteOrder, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@oid", orderId);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit(); 
                    MessageBox.Show("The order has been successfully cancelled.");

                    
                    NavigateToForm(new OrderListForm(currentUser));
                }
                catch (Exception ex)
                {
                    trans.Rollback(); 
                    MessageBox.Show("Cancellation failed, error message:" + ex.Message);
                }
            }
        }
        private void NavigateToForm(Form targetForm)
        {
            targetForm.Show();
            this.Hide();
        }
     
    }
}