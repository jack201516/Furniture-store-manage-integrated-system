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

namespace ITP4915M__sales_part__
{
    public partial class _4 : Form
    {
        private string connectionString = "server=localhost;database=plfc;uid=root;pwd=;";

        public _4()
        {
            InitializeComponent();
        }

        private void _4_Load(object sender, EventArgs e)
        {
            LoadComplaints();
            SetupButtons();
        }

        private void SetupButtons()
        {
            btnOrderList.Click += (s, ev) => NavigateToForm(new Form6());
            button3.Click += (s, ev) => NavigateToForm(new Form8());
            button2.Click += (s, ev) => NavigateToForm(this);
            button1.Click += (s, ev) => { this.Close(); Application.OpenForms[0]?.Show(); };
            btnSearch.Click += BtnSearch_Click;
            btnViewDetail.Click += BtnViewDetail_Click;
        }

        private void LoadComplaints(string searchText = "")
        {
            string sql = @"SELECT c.ComplaintID, c.CustomerID, c.OrderID, 
                                  c.ComplaintContent, c.States, c.Handling,
                                  cu.Name AS CustomerName
                           FROM complaint c
                           JOIN customer cu ON c.CustomerID = cu.CustomerID";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        adapter.SelectCommand.CommandText += " WHERE c.ComplaintID LIKE @search OR c.OrderID LIKE @search OR cu.Name LIKE @search";
                        adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + searchText + "%");
                    }

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvOrderList.DataSource = dt;
                }
            }
            dgvOrderList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadComplaints(txtSearch.Text);
        }

        private void BtnViewDetail_Click(object sender, EventArgs e)
        {
            if (dgvOrderList.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dgvOrderList.SelectedRows[0].DataBoundItem;
                string complaintId = row["ComplaintID"].ToString();
                string content = row["ComplaintContent"].ToString();
                string status = row["States"].ToString();

                DialogResult result = MessageBox.Show(
                    $"Complaint: {content}\n\nStatus: {status}\n\nSelect handling method:",
                    "Process Complaint",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                string handling = "";

                if (result == DialogResult.Yes)
                {
                    handling = "Return";
                }
                else if (result == DialogResult.No)
                {
                    handling = "Replace";
                }
                else
                {
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string updateSql = "UPDATE complaint SET States = 'Processed', Handling = @handling WHERE ComplaintID = @cid";
                    using (MySqlCommand cmd = new MySqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@handling", handling);
                        cmd.Parameters.AddWithValue("@cid", complaintId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Complaint processed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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