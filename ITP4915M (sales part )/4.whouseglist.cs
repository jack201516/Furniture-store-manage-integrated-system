using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ITP4915M__sales_part__
{
    public partial class Form6 : Form
    {
        private string connectionString = "server=localhost;database=plfc;uid=root;pwd=;";
        private string currentUser;

        public Form6(string userId)
        {
            InitializeComponent();
            currentUser = userId;
        }

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            LoadGoodsData();
            SetupButtons();
        }

        private void SetupButtons()
        {
            
            button3.Click += (s, ev) => NavigateToForm(new Form8());
            button2.Click += (s, ev) => NavigateToForm(new _4());
            button1.Click += (s, ev) => { this.Close(); Application.OpenForms[0]?.Show(); };
            btnSearch.Click += BtnSearch_Click;
            btnViewDetail.Click += btnViewDetail_Click;
            button5.Click += btnGoToForm17_Click;
        }

        private void btnGoToForm17_Click(object sender, EventArgs e)
        {
            
            From17 form17 = new From17(currentUser);

            // 導向該表單
            form17.Show();

            // 隱藏目前頁面
            this.Hide();
        }
        private void LoadGoodsData(string searchText = "")
        {
            // 直接從 order 資料表查詢，並關聯 product 資料表
            string sql = @"SELECT o.OrderID, p.ProductName, o.States, o.dDATA 
                   FROM `order` o
                   JOIN product p ON o.ProductID = p.ProductID
                   WHERE o.States = 'Not done'";

            // 如果使用者有輸入搜尋文字，則加上 AND 搜尋條件
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                sql += " AND (o.OrderID LIKE @search OR p.ProductName LIKE @search)";
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + searchText + "%");
                    }

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvOrderList.DataSource = dt;
                }
            }

            dgvOrderList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
     



        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadGoodsData(txtSearch.Text);
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (dgvOrderList.SelectedRows.Count > 0)
            {
                string orderId = dgvOrderList.SelectedRows[0].Cells["orderID"].Value.ToString();
                // 傳遞 currentUser 與 orderId 到 
                Form7 detailForm = new Form7(currentUser, orderId);
                detailForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("請先選擇一筆訂單！");
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
    }
}