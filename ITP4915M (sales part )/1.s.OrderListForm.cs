using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class OrderListForm : Form
    {
        string currentUser;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public OrderListForm(string user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
           
        }

        private void LoadOrders(string searchText = "")
        {
          
            string sql = @"SELECT o.OrderID, p.ProductName, c.Name AS CustomerName, o.States, o.dDATA as DeliveryDate
                   FROM `order` o
                   LEFT JOIN product p ON o.ProductID = p.ProductID
                   LEFT JOIN customer c ON o.CustomerID = c.CustomerID";

           
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                sql += " WHERE o.OrderID = @OrderID";
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                   
                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", searchText);
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvOrderList.DataSource = dt;
                    }
                }
            }
            dgvOrderList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void BtnViewDetail_Click(object sender, EventArgs e)
        {
            if (dgvOrderList.SelectedRows.Count > 0)
            {
                string orderId = dgvOrderList.SelectedRows[0].Cells["OrderID"].Value.ToString();
                NavigateToForm(new OrderDetailForm(orderId, currentUser));
                
            }
        }

        private void btnOpenMail_Click(object sender, EventArgs e)
        {
            NavigateToForm(new MailForm(currentUser));
        }

        private void NavigateToForm(Form targetForm)
        {
            targetForm.Show();
            this.Hide();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            
            LoadOrders(searchText);
        }


    }
}