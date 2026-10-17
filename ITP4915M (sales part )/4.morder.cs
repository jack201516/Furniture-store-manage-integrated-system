
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class From17 : Form
    {
        string currentUser;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public From17(string userId)
        {
            InitializeComponent();
            currentUser = userId;
        }

        private void From17_Load(object sender, EventArgs e)
        {
            
            LoadMorderData();
            SetupButtons();
        }

        
        private void LoadMorderData(string keyword = "")
        {
          
            string sql = "SELECT * FROM `morder` WHERE state='waiting'";

           
            if (!string.IsNullOrEmpty(keyword))
            {
                
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
            btnViewDetail.Click += btnViewDetail_Click;
            btnSearch.Click += btnSearch_Click;


            button5.Click += btnOpenMaterialList_Click;
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            // 檢查是否有選取任何資料列
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // 取得所選列的 MoID (假設 MoID 在 DataGridView 的第一欄，索引為 0)
                string moId = dataGridView1.SelectedRows[0].Cells["MoID"].Value.ToString();

                // 導向 Form19 並傳入 moId
                F19 detailForm = new F19(moId);
                NavigateToForm(detailForm);
            }
            else
            {
                MessageBox.Show("請先選擇一項訂單資料。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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