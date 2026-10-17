using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class Form1 : Form
    {
        string currentUser;
        string currentOrderId;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public Form1(string userId, string orderId)
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

                
                string sqlQuery = @"
            SELECT o.OrderID, o.CustomerID, o.dDATA, oi.oitemID, oi.custom 
            FROM `order` o
            JOIN `orderitem` oi ON o.OrderID = oi.OrderID
            WHERE o.OrderID = @oid";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@oid", currentOrderId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        if (reader.Read())
                        {
                            txtOrderId.Text = reader["OrderID"].ToString();
                            txtCustomerId.Text = reader["CustomerID"].ToString();
                            txtDeliveryDate.Text = reader["dDATA"] != DBNull.Value ? Convert.ToDateTime(reader["dDATA"]).ToString("yyyy-MM-dd") : "";

                            // 新增顯示 orderitem 相關欄位
                            textBox1.Text = reader["oitemID"].ToString();
                            txtCustomInfo.Text = reader["custom"]?.ToString();
                        }
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _2 orderList = new _2(currentUser);
            orderList.Show();
            this.Close();
        }
        private void btnGoToLogin_Click(object sender, EventArgs e)
        {
            
            LoginForm loginForm = new LoginForm();
            loginForm.Show(); 
            this.Close();    
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            // 檢查是否有選中的 oitemID，這裡假設你將 oitemID 存儲在一個變數中
            // 如果你是使用 DataGridView，這裡應該改為獲取當前選中行的 oitemID
            string oitemIDToUpdate = textBox1.Text;

            if (string.IsNullOrEmpty(oitemIDToUpdate))
            {
                MessageBox.Show("無法識別當前的項目 ID。");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                   
                    string sqlUpdate = "UPDATE `orderitem` SET `state` = 'Production' WHERE `oitemID` = @oitemID";

                    using (MySqlCommand cmd = new MySqlCommand(sqlUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@oitemID", oitemIDToUpdate);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("訂單狀態已成功更新為 Production！");
                            
                            LoadOrderDetails();
                            _2 orderList = new _2(currentUser);
                            orderList.Show();

                            
                            this.Close();
                        
                    }
                        else
                        {
                            MessageBox.Show("更新失敗，未找到對應的訂單項目。");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("發生錯誤: " + ex.Message);
                }
            }
        }
    }
}