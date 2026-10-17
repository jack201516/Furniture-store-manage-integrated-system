using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class Form2 : Form
    {
        string currentUser;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public Form2(string userId)
        {
            InitializeComponent();
            currentUser = userId;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadProductionOrders();
            SetupButtons();
        }

        private void LoadProductionOrders()
        {
            // 修改 SQL：從 orderitem 表開始，並過濾 state 為 'Production'
            string sql = @"SELECT oi.oitemID, oi.OrderID, p.ProductName, c.Name AS CustomerName, oi.qty, oi.state
                   FROM `orderitem` oi
                   LEFT JOIN product p ON oi.pid = p.ProductID
                   LEFT JOIN customer c ON oi.cid = c.CustomerID
                   WHERE oi.state = 'Production'";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("載入資料失敗: " + ex.Message);
                }
            }
        }

        private void SetupButtons()
        {
            btnViewDetail.Click += BtnViewDetail_Click;
            button3.Click += (s, ev) => NavigateToForm(new Form4(currentUser));
            button5.Click += btnOpenMaterialList_Click;
        }

        private void btnOpenMaterialList_Click(object sender, EventArgs e)
        {
            // 建立 material_order_list 實例，並傳入當前使用者 ID
            material_order_list molForm = new material_order_list(currentUser);

            // 使用原本的導航方法
            NavigateToForm(molForm);
        }

        private void BtnViewDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // 改為抓取 oitemID，這能確保唯一性
                string oitemId = dataGridView1.SelectedRows[0].Cells["oitemID"].Value.ToString();

                // 將 Form3 的建構子改為接收 oitemId
                NavigateToForm(new Form3(oitemId, currentUser));
            }
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
            this.Close();    // 關閉當前的 Form1
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            // 呼叫時傳入關鍵字，讓 LoadProductionOrders 處理搜尋邏輯
            LoadProductionOrders(keyword);
        }

        private void LoadProductionOrders(string keyword = "")
        {
            // 基礎 SQL：設定目標為 'Production'
            string sql = @"SELECT oi.oitemID, oi.OrderID, p.ProductName, c.Name AS CustomerName, oi.qty, oi.state
                   FROM `orderitem` oi
                   LEFT JOIN product p ON oi.pid = p.ProductID
                   LEFT JOIN customer c ON oi.cid = c.CustomerID
                   WHERE oi.state = 'Production'";

            // 如果輸入框有內容，加入搜尋條件 (使用 OR 連結 OrderID 或 oitemID)
            if (!string.IsNullOrEmpty(keyword))
            {
                sql += " AND (oi.oitemID LIKE @keyword OR oi.OrderID LIKE @keyword)";
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // 設定參數防止 SQL Injection
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
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("搜尋失敗: " + ex.Message);
                }
            }
        }

    }
}