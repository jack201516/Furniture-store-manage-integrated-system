
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class F19 : Form
    {
        private string _moId; // 修改變數名稱以符合需求 (原本是 materialId)
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        // 修改建構函式，傳入 MoID
        public F19(string moId)
        {
            InitializeComponent();
            _moId = moId;
        }

        private void F19_Load(object sender, EventArgs e)
        {
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            // 使用 JOIN 連結 morder 與 material 資料表
            string sql = @"SELECT m.MoID, m.MaterialID, m.Qty, m.state, mat.Name 
                           FROM morder m 
                           LEFT JOIN material mat ON m.MaterialID = mat.MaterialID 
                           WHERE m.MoID = @moId";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@moId", _moId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                lblMoID.Text = reader["MoID"].ToString();
                                lblMaterialID.Text = reader["MaterialID"].ToString();
                                lblQty.Text = reader["Qty"].ToString();
                                lblState.Text = reader["state"] == DBNull.Value ? "N/A" : reader["state"].ToString();
                                lblName.Text = reader["Name"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("找不到該訂單的詳細資料。");
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
        private void btnApprove_Click(object sender, EventArgs e)
        {
            // 執行 SQL Update 語法
            string updateSql = "UPDATE morder SET state = 'approve' WHERE MoID = @moId";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@moId", _moId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("訂單已成功核准！");
                            // 更新介面上顯示的狀態
                            lblState.Text = "approve";
                        }
                        else
                        {
                            MessageBox.Show("更新失敗，未找到對應的訂單。");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("更新資料庫時發生錯誤: " + ex.Message);
                }
            }
        }

    }
}