using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class ProductDetailForm : Form
    {
        string productId;
        string currentUser;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public ProductDetailForm(string pid, string user)
        {
            InitializeComponent();
            productId = pid;
            currentUser = user;
        }

        private void ProductDetailForm_Load(object sender, EventArgs e)
        {
            LoadProductDetails();
            SetupButtons();
            numQuantity.ValueChanged += (s, ev) => UpdateTotalPrice();
        }

        private void LoadProductDetails()
        {
            string sql = "SELECT ProductID, ProductName, Price, describle, typ FROM product WHERE ProductID = @pid";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@pid", productId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        textBox2.Text = dt.Rows[0]["ProductName"].ToString();
                        textBox1.Text = "$" + dt.Rows[0]["Price"].ToString();
                        UpdateTotalPrice();
                    }
                }
            }
        }

        private void UpdateTotalPrice()
        {
            int qty = (int)numQuantity.Value;
            decimal price = 100;
            textBox3.Text = "$" + (qty * price).ToString();
        }

        private void SetupButtons()
        {
            btnAddToCart.Click += BtnAddToCart_Click;
            btnNewOrder.Click += (s, ev) => NavigateToForm(new ShoppingCartForm(currentUser));
            btnOrderList.Click += (s, ev) => NavigateToForm(new OrderListForm(currentUser));
            btnMail.Click += (s, ev) => NavigateToForm(new MailForm(currentUser));
            btnLogout.Click += (s, ev) => { this.Close(); Application.OpenForms[0]?.Show(); };
        }

      


        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
           
            ShoppingCartForm.AddToCart(productId, (int)numQuantity.Value, txtCustomRequire.Text);
            MessageBox.Show("Added to cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            MainMenuForm mainForm = new MainMenuForm(currentUser, "sales");

            mainForm.Show();
            this.Close();
        }

        private void NavigateToForm(Form targetForm)
        {
            targetForm.Show();
            this.Hide();
        }
   
    }
}