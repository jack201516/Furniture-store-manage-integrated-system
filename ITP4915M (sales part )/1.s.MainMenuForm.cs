using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ITP4915M__sales_part__
{
    public partial class MainMenuForm : Form
    {
        string currentUser = "";
        string currentUserDept = "";

        public MainMenuForm(string userId, string dept)
        {
            InitializeComponent();
            currentUser = userId;
            currentUserDept = dept;

            SetupButtons();
            LoadProductsByCategory("Chair");
        }

        private void SetupButtons()
        {
            
            btnOrderList.Click += (s, ev) => NavigateToForm(new OrderListForm(currentUser));
            btnMail.Click += (s, ev) => NavigateToForm(new MailForm(currentUser));
            btnLogout.Click += (s, ev) =>
            {
                this.Close();
                Application.OpenForms[0]?.Show();
            };
            btnChair.Click += (s, ev) => LoadProductsByCategory("Chair");
            btnTable.Click += (s, ev) => LoadProductsByCategory("Table");
            btnSofas.Click += (s, ev) => LoadProductsByCategory("Sofa");
            btnBeds.Click += (s, ev) => LoadProductsByCategory("Bed");
            btnKitchen.Click += (s, ev) => LoadProductsByCategory("Kitchen");
            btnBathroom.Click += (s, ev) => LoadProductsByCategory("Bathroom");
            btnOthers.Click += (s, ev) => LoadProductsByCategory("Other");
            btnViewDetail.Click += BtnViewDetail_Click;
            btnShoppingCart.Click += (s, ev) => NavigateToForm(new ShoppingCartForm(currentUser));
        }

        private void LoadProductsByCategory(string category)
        {
            string sql = "SELECT ProductID, ProductName, Price, describle, typ FROM product WHERE typ = @cat";
            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=plfc;uid=root;pwd=;"))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@cat", category);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvProducts.DataSource = dt;
                }
            }
        }

        private void BtnViewDetail_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                string productId = dgvProducts.SelectedRows[0].Cells["ProductID"].Value.ToString();
                NavigateToForm(new ProductDetailForm(productId, currentUser));
            }
        }



        private void NavigateToForm(Form targetForm)
        {
            targetForm.Show();
            this.Hide();
        }

      


    }
}