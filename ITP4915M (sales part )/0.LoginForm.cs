using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP4915M__sales_part__
{
    public partial class LoginForm : Form
    {
        string connString = "server=localhost;database=plfc;uid=root;pwd=;";

        public LoginForm()
        {
            InitializeComponent();
            LoadBackgroundImage();
        }

        private void LoadBackgroundImage()
        {
            try
            {
                string bgPath = Application.StartupPath + "\\photo.jpg";
                if (File.Exists(bgPath))
                {
                    this.BackgroundImage = Image.FromFile(bgPath);
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            catch { }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text;
            string password = txtPassword.Text;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT department FROM user WHERE userID = @uid AND password = @pwd";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@uid", userID);
                    cmd.Parameters.AddWithValue("@pwd", password);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string department = result.ToString();
                        this.Hide();

                        switch (department.ToLower())
                        {
                            case "sales":
                                new MainMenuForm(userID, "sales").Show();
                                break;
                            case "design":
                                new _2(userID).Show();
                                break;
                            case "production":
                                new Form2(userID).Show();
                                break;
                            case "whouse":
                                new Form6(userID).Show();
                                break;
                            case "shipping":
                                new Form9(userID).Show();
                                break;
                            default:
                                MessageBox.Show("Department not found.");
                                this.Show();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid UserID or Password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}