using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class Form7 : Form
    {
        string currentUser;
        string currentOrderId;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        
        public Form7 (string userId, string orderId)
        {
            InitializeComponent();
            currentUser = userId;
            currentOrderId = orderId;
            LoadOrderDetails();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadOrderDetails()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                // 1. 載入訂單基本資訊
                string sqlOrder = "SELECT OrderID, CustomerID, dDATA FROM `order` WHERE OrderID = @oid";
                using (MySqlCommand cmd = new MySqlCommand(sqlOrder, conn))
                {
                    cmd.Parameters.AddWithValue("@oid", currentOrderId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtOrderId.Text = reader["OrderID"].ToString();
                            txtCustomerId.Text = reader["CustomerID"].ToString();
                            txtDeliveryDate.Text = reader["dDATA"] != DBNull.Value ? Convert.ToDateTime(reader["dDATA"]).ToString("yyyy-MM-dd") : "";
                        }
                    }
                }


                string sqlItems = @"
    SELECT 
        oi.oitemID, 
        oi.pid, 
        oi.qty, 
        oi.state, 
        g.GoodsID 
    FROM orderitem oi
    LEFT JOIN goods g ON oi.oitemID = g.oitemID 
    WHERE oi.OrderID = @oid";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlItems, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@oid", currentOrderId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form6 orderList = new Form6(currentUser);
            orderList.Show();
            this.Close();
        }
        private void btnGoToLogin_Click(object sender, EventArgs e)
        {
            
            LoginForm loginForm = new LoginForm();
            loginForm.Show();  
            this.Close();   


    }
        private void btnGoToForm6_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();

            form6.Show();
            this.Close(); 
        }
        private void btnUpdateToShipping_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                // 1. 檢查該訂單下是否所有 item 的 state 都是 'warehouse'
                // 我們統計非 'warehouse' 的項目數量，若為 0 則代表全部皆為 'warehouse'
                string checkSql = @"SELECT COUNT(*) FROM orderitem 
                           WHERE OrderID = @oid AND state != 'warehouse'";

                using (MySqlCommand checkCmd = new MySqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@oid", currentOrderId);
                    long count = (long)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("訂單中仍有項目未完成 (非 warehouse 狀態)，無法變更為 shipping。");
                        return;
                    }
                }

                // 2. 更新訂單狀態
                string updateSql = "UPDATE `order` SET States = 'shipping' WHERE OrderID = @oid";
                using (MySqlCommand updateCmd = new MySqlCommand(updateSql, conn))
                {
                    updateCmd.Parameters.AddWithValue("@oid", currentOrderId);
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("訂單狀態已成功更新為 shipping！");
                        LoadOrderDetails(); // 重新整理畫面
                    }
                    else
                    {
                        MessageBox.Show("更新失敗。");
                    }
                }
            }
        }
    }
}