using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class Form15 : Form
    {
        string orderId;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public Form15()
        {
            InitializeComponent();
        }

        public Form15(string oid) : this()
        {
            orderId = oid;
            LoadOrderItems();
        }

        
        private void LoadOrderItems()
        {
            string sql = @"SELECT oi.oitemID, p.ProductName, oi.qty 
                           FROM orderitem oi
                           JOIN product p ON oi.pid = p.ProductID
                           WHERE oi.OrderID = @oid";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@oid", orderId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvOrderItems.DataSource = dt;
            }
        }

      
        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE `order` SET dDATA = @newDate WHERE OrderID = @oid";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@newDate", dtpDispatchDate.Value);
                cmd.Parameters.AddWithValue("@oid", orderId);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("訂單日期已更新！");
        }

      
        private void btnCancelItem_Click(object sender, EventArgs e)
        {
            if (dgvOrderItems.SelectedRows.Count > 0)
            {
                // 取得選取行的 oitemID
                string oitemId = dgvOrderItems.SelectedRows[0].Cells["oitemID"].Value.ToString();

                DialogResult dr = MessageBox.Show("確定要刪除此商品項目嗎？", "確認刪除", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    string sql = "DELETE FROM orderitem WHERE oitemID = @oitemId";
                    using (MySqlConnection conn = new MySqlConnection(connString))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@oitemId", oitemId);
                        cmd.ExecuteNonQuery();
                    }
                    LoadOrderItems(); // 刪除後重新載入列表
                }
            }
            else
            {
                MessageBox.Show("請先在表格中選取一行項目。");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
    }
}