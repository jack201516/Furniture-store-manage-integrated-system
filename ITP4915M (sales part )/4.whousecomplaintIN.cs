using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class Form12 : Form
    {
        string currentUser;
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public Form12(string userId)
        {
            InitializeComponent();
            currentUser = userId;
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            LoadComplaints();
            SetupButtons();
        }

        private void LoadComplaints()
        {
            string sql = @"SELECT c.ComplaintID, c.OrderID, c.CustomerID, c.ComplaintContent, c.States
                           FROM complaint c
                           WHERE c.States = 'wait to deal'";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void SetupButtons()
        {
            button4.Click += (s, ev) => NavigateToForm(new _4());
            button5.Click += BtnProcess_Click;
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string complaintId = dataGridView1.SelectedRows[0].Cells["ComplaintID"].Value.ToString();
                string handling = "Processed by warehouse";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string sql = "UPDATE complaint SET States = 'Processed', Handling = @handling WHERE ComplaintID = @cid";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@handling", handling);
                        cmd.Parameters.AddWithValue("@cid", complaintId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Complaint processed!");
                LoadComplaints();
            }
        }

        private void NavigateToForm(Form targetForm)
        {
            targetForm.Show();
            this.Hide();
        }
    }
}