using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class Form3 : Form
    {
        string orderId;
        string currentUser;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public Form3(string oitemId, string userId)
        {
            InitializeComponent();
            orderId = oitemId;
            currentUser = userId;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadOrderDetails();
            SetupButtons();
        }

        private void LoadOrderDetails()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string sqlQuery = @"
    SELECT o.OrderID, o.CustomerID, o.dDATA, oi.oitemID, oi.custom 
    FROM `orderitem` oi
    LEFT JOIN `order` o ON o.OrderID = oi.OrderID
    WHERE oi.oitemID = @oid";

                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, conn))
                    {
                        // @oid 現在接收的是 Form2 傳來的 oitemID
                        cmd.Parameters.AddWithValue("@oid", orderId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtOrderID.Text = reader["OrderID"].ToString();
                                textBox3.Text = reader["CustomerID"].ToString();
                                textBox4.Text = reader["dDATA"] != DBNull.Value ?
                                                Convert.ToDateTime(reader["dDATA"]).ToString("yyyy-MM-dd") : "";
                                txtOrderItemID.Text = reader["oitemID"].ToString();
                                txtCustomInfo.Text = reader["custom"]?.ToString();
                            }
                            else
                            {
                             
                                MessageBox.Show("找不到對應的 oitemID: " + orderId);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取資料發生錯誤: " + ex.Message);
                }
            }
        }
        private void SetupButtons()
        {
            button4.Click += (s, ev) => NavigateToForm(new Form2(currentUser));
            button5.Click += BtnDone_Click;
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE `order` SET States = 'PendingInbound' WHERE OrderID = @oid";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@oid", orderId);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Order completed and sent to warehouse!");
            NavigateToForm(new Form2(currentUser));
        }

        private void NavigateToForm(Form targetForm)
        {
            targetForm.Show();
            this.Hide();
        }
        private void btnGoToLogin_Click(object sender, EventArgs e)
        {
            // 假設你的登入頁面類別名稱是 LoginForm
            LoginForm loginForm = new LoginForm();
            loginForm.Show(); // 顯示登入頁面
            this.Close();    
        }
        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            string newGoodsId = GenerateNewGoodsId();
            string orderId = txtOrderID.Text;
            string currentOitemID = txtOrderItemID.Text; // 確保這是從 txtOrderItemID 取得

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                // 開啟交易
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                       
                        string sqlInsert = "INSERT INTO goods (GoodsID, OrderID, oitemID) VALUES (@gid, @oid, @oiid)";
                        using (MySqlCommand cmd = new MySqlCommand(sqlInsert, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@gid", newGoodsId);
                            cmd.Parameters.AddWithValue("@oid", orderId);
                            cmd.Parameters.AddWithValue("@oiid", currentOitemID);
                            cmd.ExecuteNonQuery();
                        }

                      
                        string sqlUpdate = "UPDATE `orderitem` SET `state` = 'warehouse' WHERE `oitemID` = @oiid";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, conn, trans))
                        {
                            cmdUpdate.Parameters.AddWithValue("@oiid", currentOitemID);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        
                        trans.Commit();
                        MessageBox.Show("訂單已完成，商品已新增並更新狀態為 warehouse！");

                        Form5 nextForm = new Form5(currentUser);
                        nextForm.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        
                        trans.Rollback();
                        MessageBox.Show("處理過程中發生錯誤，系統已復原：\n" + ex.Message);
                    }
                }
            }
        }

        // 用來生成 G00000X 格式的輔助方法
        private string GenerateNewGoodsId()
        {
            string lastId = "G000000"; // 預設初始值
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT GoodsID FROM goods ORDER BY GoodsID DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null) lastId = result.ToString();
            }

            // 提取數字部分並加 1
            int number = int.Parse(lastId.Substring(1)) + 1;
            return "G" + number.ToString("D6"); // 確保格式為 G000001
        }
    }
}