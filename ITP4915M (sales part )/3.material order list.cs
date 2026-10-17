
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class material_order_list : Form
    {
        string currentUser;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public material_order_list(string userId)
        {
            InitializeComponent();
            currentUser = userId;
        }

        private void material_order_list_Load(object sender, EventArgs e)
        {
            // 進入頁面時載入所有 morder 資料
            LoadMorderData();
            SetupButtons();
        }

        // 載入 morder 資料的方法
        private void LoadMorderData(string keyword = "")
        {
            // 基礎 SQL：從 morder 資料表讀取
            string sql = "SELECT * FROM `morder` WHERE 1=1";

            // 如果有輸入搜尋關鍵字，增加過濾條件
            if (!string.IsNullOrEmpty(keyword))
            {
                // 假設用 MoID 進行搜尋，請根據實際欄位名稱調整
                sql += " AND MoID LIKE @keyword";
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
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
                    MessageBox.Show("資料載入失敗: " + ex.Message);
                }
            }
        }

        private void SetupButtons()
        {
            // 確保 btnSearch 綁定了正確的事件
            btnSearch.Click += btnSearch_Click;

            
            button3.Click += (s, ev) => NavigateToForm(new Form4(currentUser));
            button5.Click += btnOpenMaterialList_Click;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 獲取 textBox1 的內容 (你原本代碼中似乎是 txtSearch，若改為 textBox1 請記得替換)
            string keyword = textBox1.Text.Trim();
            LoadMorderData(keyword);
        }

        // 其他原有方法...
        private void btnOpenMaterialList_Click(object sender, EventArgs e)
        {
            material_order_list molForm = new material_order_list(currentUser);
            NavigateToForm(molForm);
        }

        private void NavigateToForm(Form targetForm)
        {
            targetForm.Show();
            this.Hide();
        }
    }
}