using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class Form10 : Form
    {
        string currentUser;
        string currentOrderId;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        // 新增這個建構函式來接收參數
        public Form10(string userId, string orderId)
        {
            InitializeComponent();
            currentUser = userId;
            currentOrderId = orderId;
            LoadOrderDetails();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 這裡可以放表單載入時的其他初始化邏輯
        }

        private void LoadOrderDetails()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                // 1. Existing order detail query
                string sqlOrder = @"SELECT o.OrderID, o.CustomerID, o.dDATA, c.Address 
                            FROM `order` o
                            LEFT JOIN customer c ON o.CustomerID = c.CustomerID 
                            WHERE o.OrderID = @oid";

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
                            txtAddress.Text = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : "無地址資訊";
                        }
                    }
                }

                // 2. Updated: Include GoodsID using LEFT JOIN
                // We join orderitem with goods on the oitemID column
                string sqlItems = @"SELECT oi.oitemID, oi.pid, oi.qty, g.GoodsID 
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
            _2 orderList = new _2(currentUser);
            orderList.Show();
            this.Close();
        }
        private void btnGoToLogin_Click(object sender, EventArgs e)
        {
            // 假設你的登入頁面類別名稱是 LoginForm
            LoginForm loginForm = new LoginForm();
            loginForm.Show(); // 顯示登入頁面
            this.Close();    // 關閉當前的 Form1
        }
        private void btnBack1_Click(object sender, EventArgs e)
        {
            // 實例化 Form9，並傳入當前的 currentUser (保持使用者狀態)
            Form9 form9 = new Form9(currentUser);

            // 顯示 Form9
            form9.Show();

            // 關閉當前的 Form10
            this.Close();
        }
        private void btnMarkDone_Click(object sender, EventArgs e)
        {
            // 詢問使用者確認
            DialogResult result = MessageBox.Show("確定要將此訂單標記為完成嗎？", "確認更新", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connString))
                    {
                        conn.Open();

                        // 更新 order 表中的 States 欄位
                        string sqlUpdate = "UPDATE `order` SET States = 'Done' WHERE OrderID = @oid";

                        using (MySqlCommand cmd = new MySqlCommand(sqlUpdate, conn))
                        {
                            cmd.Parameters.AddWithValue("@oid", currentOrderId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("訂單狀態已更新為 Done!");
                                // 重新載入資料以更新 UI 顯示
                                LoadOrderDetails();
                            }
                            else
                            {
                                MessageBox.Show("更新失敗，找不到對應的訂單。");
                            }
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