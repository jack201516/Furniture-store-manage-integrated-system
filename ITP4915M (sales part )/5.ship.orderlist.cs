using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class Form9 : Form
    {
        string currentUser;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public Form9(string userId)
        {
            InitializeComponent();
            currentUser = userId;

            // 確保 Form 載入事件已綁定
            this.Load += new EventHandler(Form9_Load);
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                
                string sql = @"SELECT o.OrderID, p.ProductName, c.Name AS CustomerName, o.States, o.dDATA as DeliveryDate
                       FROM `order` o
                       LEFT JOIN product p ON o.ProductID = p.ProductID
                       LEFT JOIN customer c ON o.CustomerID = c.CustomerID
                       WHERE o.States = 'shipping'";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // 檢查資料是否成功載入
                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                        else
                        {
                            // 若沒有符合 shipping 的資料，這裡會提示
                            MessageBox.Show("目前沒有狀態為 'shipping' 的訂單資料。");
                            dataGridView1.DataSource = null;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("資料庫連線錯誤: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生未預期的錯誤: " + ex.Message);
            }
        }


        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string orderId = dataGridView1.SelectedRows[0].Cells["OrderID"].Value.ToString();
                Form10 detailForm = new Form10(currentUser, orderId);
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
        private void btnBack_Click(object sender, EventArgs e)
        {
           
            Form9 form9 = new Form9(currentUser);

            
            form9.Show();

           
            this.Close();
        }
        private void btnGoToForm2_Click(object sender, EventArgs e)
        {
           
            F2 form2 = new F2(currentUser);

            // 2. 顯示 Form2
            form2.Show();

            // 3. 隱藏當前視窗 (或是使用 this.Close() 如果你想關閉 Form9)
            this.Hide();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchId = textBox1.Text.Trim(); // 取得搜尋內容並去除空白

            if (string.IsNullOrEmpty(searchId))
            {
                // 如果搜尋框為空，恢復顯示原本的 shipping 清單
                LoadOrders();
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    // 修改 SQL 以包含搜尋條件 (使用 LIKE 可以增加搜尋彈性，或改用 = 精確匹配)
                    string sql = @"SELECT o.OrderID, p.ProductName, c.Name AS CustomerName, o.States, o.dDATA as DeliveryDate
                           FROM `order` o
                           LEFT JOIN product p ON o.ProductID = p.ProductID
                           LEFT JOIN customer c ON o.CustomerID = c.CustomerID
                           WHERE o.OrderID LIKE @oid";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // 使用 % 讓搜尋更方便，例如輸入 O00000 即可找到相關訂單
                        cmd.Parameters.AddWithValue("@oid", "%" + searchId + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dt;
                            }
                            else
                            {
                                MessageBox.Show("找不到符合該 OrderID 的訂單。");
                                dataGridView1.DataSource = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("搜尋過程中發生錯誤: " + ex.Message);
            }
        }
    }
}