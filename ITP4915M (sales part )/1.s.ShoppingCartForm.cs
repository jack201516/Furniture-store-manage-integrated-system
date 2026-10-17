using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class ShoppingCartForm : Form
    {
        string currentUser;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";
        public static DataTable cartTable;

        public ShoppingCartForm(string user)
        {
            InitializeComponent();
           
            if (cartTable == null)
            {
                cartTable = new DataTable();
                cartTable.Columns.Add("ProductID");
                cartTable.Columns.Add("ProductName");
                cartTable.Columns.Add("QTY");
                cartTable.Columns.Add("Note");
            }
        }

        private void ShoppingCartForm_Load(object sender, EventArgs e)
        {
            LoadCart();
            SetupButtons();
            LoadCustomerInfo();
        }

        public static void AddToCart(string pid, int qty, string note)
        {
            if (cartTable == null)
            {
                cartTable = new DataTable();
                cartTable.Columns.Add("ProductID");
                cartTable.Columns.Add("ProductName");
                cartTable.Columns.Add("QTY");
                cartTable.Columns.Add("Note");
            }

            DataRow row = cartTable.NewRow();
            row["ProductID"] = pid;
            row["ProductName"] = GetProductName(pid);
            row["QTY"] = qty;
            row["Note"] = note;
            cartTable.Rows.Add(row);
        }

        private static string GetProductName(string pid)
        {
            string connString = "server=localhost;database=plfc;uid=root;pwd=;";
            string sql = "SELECT ProductName FROM product WHERE ProductID = @pid";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", pid);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : pid;
                }
            }
        }

        private void LoadCart()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = cartTable;
        }

        private void LoadCustomerInfo()
        {
            
            lblOrderDate2.Text = DateTime.Now.ToShortDateString();
            dtpDispatchDate.Value = DateTime.Now.AddDays(7);
        }

        private void SetupButtons()
        {
            btnConfirmOrder.Click += BtnConfirmOrder_Click;
            btnNewOrder.Click += (s, ev) => NavigateToForm(new MainMenuForm(currentUser, "sales"));
            btnOrderList.Click += (s, ev) => NavigateToForm(new OrderListForm(currentUser));
            btnMail.Click += (s, ev) => NavigateToForm(new MailForm(currentUser));
            btnLogout.Click += (s, ev) => { this.Close(); Application.OpenForms[0]?.Show(); };

        }

        private void BtnConfirmOrder_Click(object sender, EventArgs e)
        {
            string inputCustomerId = txtCustomerID.Text.Trim();
            if (string.IsNullOrEmpty(inputCustomerId))
            {
                MessageBox.Show("請輸入客戶 ID！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cartTable == null || cartTable.Rows.Count == 0)
            {
                MessageBox.Show("購物車是空的！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string orderId = GenerateOrderId();
            string deliveryId = GenerateDeliveryId();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1. 插入 Order 表：只插入一筆「訂單總表」記錄
                    // 注意：因為您的資料庫 order 表中包含 ProductID，這表示該欄位是設計不良的。
                    // 為了不更動資料庫結構，我們取購物車的第一項作為代表值填入。
                    string insertOrderSql = @"INSERT INTO `order` (OrderID, ProductID, CustomerID, DeliveryID, States, dDATA) 
                                     VALUES (@oid, @pid, @cid, @did, 'Not done', @date)";

                    using (MySqlCommand cmd = new MySqlCommand(insertOrderSql, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@oid", orderId);
                        cmd.Parameters.AddWithValue("@pid", cartTable.Rows[0]["ProductID"].ToString());
                        cmd.Parameters.AddWithValue("@cid", inputCustomerId);
                        cmd.Parameters.AddWithValue("@did", deliveryId);
                        cmd.Parameters.AddWithValue("@date", dtpDispatchDate.Value);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. 插入 OrderItem 表：透過迴圈將購物車每一項存入明細
                    foreach (DataRow row in cartTable.Rows)
                    {
                        string note = row["Note"]?.ToString();
                        string stateValue;

                        // 邏輯：有自訂內容則為 Designing，否則為 Production
                        if (string.IsNullOrWhiteSpace(note))
                        {
                            stateValue = "Production";
                            note = null;
                        }
                        else
                        {
                            stateValue = "Designing";
                        }

                        string insertOrderItem = @"INSERT INTO orderitem (oitemID, pid, cid, qty, OrderID, state, custom) 
                                           VALUES (@oid, @pid, @cid, @qty, @orderId, @state, @custom)";

                        using (MySqlCommand cmd = new MySqlCommand(insertOrderItem, conn, trans))
                        {
                            // 為了防止 oitemID 重複，建議加上訂單ID與產品ID，若一單有相同產品則需更嚴謹命名
                            string oitemId = orderId + "_" + row["ProductID"].ToString() + "_" + Guid.NewGuid().ToString().Substring(0, 4);

                            cmd.Parameters.AddWithValue("@oid", oitemId);
                            cmd.Parameters.AddWithValue("@pid", row["ProductID"].ToString());
                            cmd.Parameters.AddWithValue("@cid", inputCustomerId);
                            cmd.Parameters.AddWithValue("@qty", row["QTY"].ToString());
                            cmd.Parameters.AddWithValue("@orderId", orderId);
                            cmd.Parameters.AddWithValue("@state", stateValue);
                            cmd.Parameters.AddWithValue("@custom", (object)note ?? DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 3. 插入 Delivery 表
                    string insertDelivery = "INSERT INTO delivery (DeliveryID, OrderID, CustomerID) VALUES (@did, @oid, @cid)";
                    using (MySqlCommand cmd = new MySqlCommand(insertDelivery, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@did", deliveryId);
                        cmd.Parameters.AddWithValue("@oid", orderId);
                        cmd.Parameters.AddWithValue("@cid", inputCustomerId);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    cartTable.Clear();
                    LoadCart();

                    MessageBox.Show("訂單建立成功！訂單編號：" + orderId);
                    MainMenuForm mainForm = new MainMenuForm(currentUser, "sales");
                    mainForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("系統發生錯誤，訂單未建立：\n" + ex.Message);
                }
            }
        }

        private string GenerateOrderId()
        {
            string sql = "SELECT MAX(OrderID) FROM `order`";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        string lastId = result.ToString();
                        int num = int.Parse(lastId.Substring(1)) + 1;
                        return "O" + num.ToString("D6");
                    }
                    return "O000001";
                }
            }
        }

        private string GenerateDeliveryId()
        {
            string sql = "SELECT MAX(DeliveryID) FROM delivery";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        string lastId = result.ToString();
                        int num = int.Parse(lastId.Substring(1)) + 1;
                        return "D" + num.ToString("D4");
                    }
                    return "D0001";
                }
            }
        }

        private void NavigateToForm(Form targetForm)
        {
            targetForm.Show();
            this.Hide();
        }
     
    }
}