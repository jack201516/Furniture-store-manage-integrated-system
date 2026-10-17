using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class MailForm : Form
    {
        string currentUser;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public MailForm(string userId)
        {
            InitializeComponent();
            currentUser = userId;

            LoadComplaints();
            SetupButtons();
        }

        private void MailForm_Load(object sender, EventArgs e)
        {
            LoadComplaints();
            SetupButtons();
        }

        private void LoadComplaints(string searchText = "")
        {
            // 基礎 SQL
            string sql = @"SELECT ComplaintID, OrderID, ComplaintContent, States, Handling
                   FROM complaint 
                   WHERE 1=1"; // 使用 1=1 方便後續接 AND 條件

            // 如果有輸入搜尋文字，則增加篩選條件
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                sql += " AND (ComplaintID LIKE @search OR OrderID LIKE @search)";
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    // 如果有搜尋字串，綁定參數 (使用 % 進行模糊查詢)
                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void SetupButtons()
        {
            button1.Click += (s, ev) => NavigateToForm(new Form11(currentUser));

            // 更新搜尋按鈕點擊事件
            btnSearch.Click += (s, ev) =>
            {
                LoadComplaints(txtSearch.Text.Trim());
            };

            btnNewOrder.Click += (s, ev) => NavigateToForm(new ShoppingCartForm(currentUser));
            btnOrderList.Click += (s, ev) => NavigateToForm(new OrderListForm(currentUser));
            btnMail.Click += (s, ev) => NavigateToForm(this);
            btnLogout.Click += (s, ev) => { this.Close(); Application.OpenForms[0]?.Show(); };
        }

        private void NavigateToForm(Form targetForm)
        {
            targetForm.Show();
            this.Hide();
        }

    }
}