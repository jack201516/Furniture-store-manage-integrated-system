using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class Form16 : Form
    {
        private string _materialId;
       
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public Form16(string materialId)
        {
            InitializeComponent();
            _materialId = materialId;
        }



        private void Form16_Load(object sender, EventArgs e)
        {
            LoadMaterialDetails();
        }



        private void LoadMaterialDetails()
        {
            string sql = "SELECT MaterialID, Name FROM material WHERE MaterialID = @id";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                     
                        cmd.Parameters.AddWithValue("@id", _materialId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                               
                                lblMaterialID.Text = reader["MaterialID"].ToString();
                                lblName.Text = reader["Name"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("找不到該材料的資料。");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取資料失敗: " + ex.Message);
                }
            }
        }
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            // 檢查輸入是否為數字
            if (!int.TryParse(textBox1.Text, out int qty))
            {
                MessageBox.Show("請輸入正確的數量 (數字)。");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string selectSql = "SELECT MoID FROM morder ORDER BY MoID DESC LIMIT 1";
                    string newMoID = "Mo00001"; 

                    using (MySqlCommand cmd = new MySqlCommand(selectSql, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string lastId = result.ToString(); 
                            int number = int.Parse(lastId.Substring(2)) + 1;
                            newMoID = "Mo" + number.ToString("D5"); 
                        }
                    }

                    // 2. 插入新資料到 morder
                    string insertSql = "INSERT INTO morder (MoID, MaterialID, Qty,state) VALUES (@moid, @mid, @qty,'waiting')";
                    using (MySqlCommand cmd = new MySqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@moid", newMoID);
                        cmd.Parameters.AddWithValue("@mid", lblMaterialID.Text);
                        cmd.Parameters.AddWithValue("@qty", qty);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("成功建立訂單！ID: " + newMoID);

                        Form4 form4 = (Form4)Application.OpenForms["Form4"];
                        if (form4 != null)
                        {
                            form4.Show();
                            form4.BringToFront(); // 讓視窗顯示在最上層
                        }
                        else
                        {
                            // 如果 Form4 沒開啟過，則新建一個
                            Form4 newForm4 = new Form4("UserID_Here"); // 若有參數需傳入
                            newForm4.Show();
                        }

                        // 2. 關閉當前視窗
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("新增失敗: " + ex.Message);
                }
            }
        }

    }
}