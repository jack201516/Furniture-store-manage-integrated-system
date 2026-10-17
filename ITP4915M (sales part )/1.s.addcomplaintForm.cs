using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ITP4915M__sales_part__
{
    public partial class Form11 : Form
    {
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";
        string currentUser;

        public Form11()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            SetupTopMenuButtons();
        }

        public Form11(string userId)
        {
            InitializeComponent();
            currentUser = userId;
            txtSearch.Text = currentUser;
            comboBox1.SelectedIndex = 0;
            button1.Click += button1_Click;
            SetupTopMenuButtons();
        }

        private void SetupTopMenuButtons()
        {
            btnLogout.Click += (s, ev) =>
            {
                this.Close();
                Application.OpenForms[0]?.Show();
            };
            btnOrderList.Click += (s, ev) => NavigateToForm(new OrderListForm(currentUser));
            btnNewOrder.Click += (s, ev) => NavigateToForm(new ShoppingCartForm(currentUser));
            btnMail.Click += (s, ev) => NavigateToForm(new MailForm(currentUser));
        }
        private void Form11_Load(object sender, EventArgs e)
        {
        }

        private void NavigateToForm(Form targetForm)
        {
            targetForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please fill Customer ID and Order ID!");
                return;
            }

            string newComplaintId = GenerateComplaintId();

            string query = @"INSERT INTO complaint (
                                ComplaintID, CustomerID, OrderID, ComplaintContent, oitemID, States, Handling) 
                            VALUES (
                                @CompId, @CusId, @OrdId, @content, '1', 'wait to deal', @handling)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@CompId", newComplaintId);
                    cmd.Parameters.AddWithValue("@CusId", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@OrdId", textBox1.Text);
                    cmd.Parameters.AddWithValue("@content", textBox4.Text);
                    cmd.Parameters.AddWithValue("@handling", comboBox1.SelectedItem.ToString());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Complaint submitted successfully!");
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private string GenerateComplaintId()
        {
            string sql = "SELECT MAX(ComplaintID) FROM complaint";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        string lastId = result.ToString();
                        int num = int.Parse(lastId.Substring(2)) + 1;
                        return "CI" + num.ToString("D4");
                    }
                    return "CI0001";
                }
            }
        }

        private void ClearForm()
        {
            textBox1.Clear();
            textBox4.Clear();
            txtSearch.Clear();
            comboBox1.SelectedIndex = 0;
        }
        private void btnGoToLogin_Click(object sender, EventArgs e)
        {

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}