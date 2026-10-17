using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class Form4 : Form
    {
        string currentUser;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public Form4(string userId)
        {
            InitializeComponent();
            currentUser = userId;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadMaterialRequests();
            SetupButtons();
        }

        private void LoadMaterialRequests()
        {
            string sql = "SELECT MaterialID, Name, QTY FROM material";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetupButtons()
        {
            button3.Click += (s, ev) => NavigateToForm(this);
        }

        private void NavigateToForm(Form targetForm)
        {
            targetForm.Show();
            this.Hide();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
           
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                string selectedMaterialId = dataGridView1.SelectedRows[0].Cells["MaterialID"].Value.ToString();

              
                Form16 detailForm = new Form16(selectedMaterialId);

               
                detailForm.Show();

               
            }
            else
            {
                MessageBox.Show("請先選擇一個材料項目。");
            }
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