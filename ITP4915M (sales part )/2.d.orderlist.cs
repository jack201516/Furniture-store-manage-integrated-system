using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class _2 : Form
    {
        string currentUser;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public _2(string userId)
        {
            InitializeComponent();
            currentUser = userId;
        }

        private void _2_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            // 修改 SQL：改為從 orderitem 篩選 state = 'Designing'
            // 並透過 OrderID 關聯回 order 資料表，再關聯 product 和 customer
            string sql = @"SELECT oi.oitemID, oi.OrderID, p.ProductName, c.Name AS CustomerName, oi.qty, oi.state
                   FROM orderitem oi
                   LEFT JOIN `order` o ON oi.OrderID = o.OrderID
                   LEFT JOIN product p ON oi.pid = p.ProductID
                   LEFT JOIN customer c ON oi.cid = c.CustomerID
                   WHERE oi.state = 'Designing'";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("資料載入失敗: " + ex.Message);
                }
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string orderId = dataGridView1.SelectedRows[0].Cells["OrderID"].Value.ToString();
                // 傳遞 currentUser 與 orderId 到 Form1
                Form1 detailForm = new Form1(currentUser, orderId);
                detailForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("請先選擇一筆訂單！");
            }
        }
        private void btnGoToLogin_Click(object sender, EventArgs e)
        {
            
            LoginForm loginForm = new LoginForm();
            loginForm.Show(); 
            this.Close();    
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            LoadOrders(keyword); // 呼叫時帶入搜尋關鍵字
        }

        private void LoadOrders(string keyword = "")
        {
            // 基礎 SQL 語句
            string sql = @"SELECT oi.oitemID, oi.OrderID, p.ProductName, c.Name AS CustomerName, oi.qty, oi.state
                   FROM orderitem oi
                   LEFT JOIN `order` o ON oi.OrderID = o.OrderID
                   LEFT JOIN product p ON oi.pid = p.ProductID
                   LEFT JOIN customer c ON oi.cid = c.CustomerID
                   WHERE oi.state = 'Designing'";

            // 如果輸入框有內容，加入搜尋條件
            if (!string.IsNullOrEmpty(keyword))
            {
                sql += " AND (oi.oitemID LIKE @keyword OR oi.OrderID LIKE @keyword OR oi.cid LIKE @keyword)";
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // 使用參數化查詢防止 SQL Injection
                        if (!string.IsNullOrEmpty(keyword))
                        {
                            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("搜尋失敗: " + ex.Message);
                }
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }

}