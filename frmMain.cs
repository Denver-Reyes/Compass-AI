using System;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Compass_AI
{
    public partial class frmMain : Form
    {
        private string connectionString = "Server=compass-ai.czaseckgg0hi.ap-southeast-2.rds.amazonaws.com;Database=DBCompassAI;Uid=admin;Pwd=rErS3S2Mnr8Wus3Bkwb0;";
        private string userRole;
        private string loggedInUsername;

        public frmMain(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
        }

        // RoleManager class to fetch user role
        public class RoleManager
        {
            private readonly string connectionString;

            public RoleManager(string connectionString)
            {
                this.connectionString = connectionString;
            }

            public string GetUserRole(string username)
            {
                string role = null;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT role FROM tblusers WHERE username = @Username";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Username", username);

                            object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                role = result.ToString();
                            }
                            else
                            {
                                throw new Exception("User not found or role not assigned.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error retrieving role: {ex.Message}");
                    }
                }

                return role;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Fetch the user role (example: "employee", "admin", "supervisor")
            RoleManager roleManager = new RoleManager(connectionString);
            userRole = roleManager.GetUserRole(loggedInUsername);

            if (string.IsNullOrEmpty(userRole))
            {
                MessageBox.Show("User role could not be determined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Adjust UI based on role
            AdjustUIBasedOnRole(userRole);
        }

        // Adjust UI visibility based on user role
        private void AdjustUIBasedOnRole(string role)
        {
            switch (role.ToLower())
            {
                case "employee":
                    btnCreateEval.Visible = false;
                    btnReports.Visible = false;
                    break;

                case "supervisor":
                    btnReports.Visible = false;
                    break;

                case "admin":
                    // Admin sees everything; no changes needed
                    break;

                default:
                    MessageBox.Show("Unknown role type. Please check user settings.");
                    break;
            }
        }

        // Close all child forms
        private void CloseAllForms()
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }

        // Reset button colors
        private void ResetButtonColors()
        {
            btnEvaluation.FillColor = Color.Transparent;
            btnLeaderboard.FillColor = Color.Transparent;
            btnCreateEval.FillColor = Color.Transparent;
            btnReports.FillColor = Color.Transparent;
            btnProfile.FillColor = Color.Transparent;
        }

        // Button click handlers for opening child forms
        private void btnEvaluation_Click(object sender, EventArgs e)
        {
            CloseAllForms();  // Close any currently opened forms
            ResetButtonColors();  // Reset button colors
            btnEvaluation.FillColor = Color.CadetBlue;  // Highlight this button

            // Now, we instantiate and show frmEvaluationSup, passing the necessary parameters
            frmEvaluationSup frmEvaluationSup = new frmEvaluationSup(loggedInUsername);  // Assuming username is passed to this form
            frmEvaluationSup.MdiParent = this;  // MDI parent is frmMain
            frmEvaluationSup.Show();
            frmEvaluationSup.Dock = DockStyle.Fill;
        }


        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            ResetButtonColors();
            btnLeaderboard.FillColor = Color.CadetBlue;

            frmLeaderboard frmLeaderboard = new frmLeaderboard();
            frmLeaderboard.MdiParent = this;
            frmLeaderboard.Show();
            frmLeaderboard.Dock = DockStyle.Fill;
        }

        private void btnCreateEval_Click(object sender, EventArgs e)
        {
            if (userRole == "employee")
            {
                MessageBox.Show("Access denied.");
                return;
            }

            CloseAllForms();
            ResetButtonColors();
            btnCreateEval.FillColor = Color.CadetBlue;

            frmSelectEmployeeCreateEval frmSelectEmployeeCreateEval = new frmSelectEmployeeCreateEval();
            frmSelectEmployeeCreateEval.MdiParent = this;
            frmSelectEmployeeCreateEval.Show();
            frmSelectEmployeeCreateEval.Dock = DockStyle.Fill;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            if (userRole == "employee")
            {
                MessageBox.Show("Access denied.");
                return;
            }

            CloseAllForms();
            ResetButtonColors();
            btnReports.FillColor = Color.CadetBlue;

            frmReports frmReports = new frmReports();
            frmReports.MdiParent = this;
            frmReports.Show();
            frmReports.Dock = DockStyle.Fill;
        }

        private void btnMainLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Close the current form (frmMain)
                this.Close();

                // Show the login form
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            ResetButtonColors();
            btnProfile.FillColor = Color.CadetBlue;

            frmProfile frmProfile = new frmProfile(frmLogin.Username);
            frmProfile.MdiParent = this;
            frmProfile.Show();
            frmProfile.Dock = DockStyle.Fill;
        }
    }
}
