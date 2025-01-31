using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Compass_AI
{
    public partial class frmLogin : Form
    {
        // Replace with your actual connection string
        private string connectionString = "Server=compass-ai.czaseckgg0hi.ap-southeast-2.rds.amazonaws.com;Database=DBCompassAI;Uid=admin;Pwd=rErS3S2Mnr8Wus3Bkwb0;";

        // Properties to store the logged-in user's details
        public static string Username { get; set; }
        public static string UserRole { get; set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                // Query to retrieve username and role if the credentials are valid
                string query = "SELECT username, role FROM tblusers WHERE username = @username AND password = @password";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Use parameterized queries to prevent SQL injection
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve and store the username and role
                            Username = reader["username"].ToString();
                            UserRole = reader["role"].ToString();

                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Open the main form and pass the username
                            frmMain mainForm = new frmMain(Username);
                            mainForm.Show();

                            // Hide the login form
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is closed
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void picbxCOMPASSAILogo_Click(object sender, EventArgs e)
        {

        }
    }
}
