using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ITP4915M__sales_part__
{
    public partial class Form8 : Form
    {
        private string connectionString = "server=localhost;database=plfc;uid=root;pwd=;";

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            LoadStockData();
            SetupButtons();
        }

        private void SetupButtons()
        {
            btnOrderList.Click += (s, ev) => NavigateToForm(new Form6());
            button3.Click += (s, ev) => NavigateToForm(this);
            button4.Click += (s, ev) => NavigateToForm(new _4());
            button1.Click += (s, ev) => { this.Close(); Application.OpenForms[0]?.Show(); };
            button2.Click += BtnSearch_Click;
        }

   
private void LoadStockData(string searchText = "")
        {
            
            string sql = @"SELECT MaterialID, Name, QTY 
                   FROM material";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    
                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        cmd.CommandText += " WHERE Name LIKE @search OR MaterialID LIKE @search";
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        try
                        {
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("讀取 Material 資料失敗: " + ex.Message);
                        }
                    }
                }
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadStockData(textBox1.Text);
        }

        private void NavigateToForm(Form targetForm)
        {
            targetForm.Show();
            this.Hide();
        }
        private void btnGoToLogin_Click(object sender, EventArgs e)
        {
            
            LoginForm loginForm = new LoginForm();
            loginForm.Show(); // 顯示登入頁面
            this.Close();    // 關閉當前的 Form1
        }
    }

}