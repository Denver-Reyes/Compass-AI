using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Ensure you have the MySQL.Data package installed

namespace Compass_AI
{
    public partial class frmEvaluationSup : Form
    {
        public static string UserRole { get; set; }

        public static string UserName { get; set; }


        private string connectionString = "Server=compass-ai.czaseckgg0hi.ap-southeast-2.rds.amazonaws.com;Database=DBCompassAI;Uid=admin;Pwd=rErS3S2Mnr8Wus3Bkwb0;";

        public frmEvaluationSup(string role)
        {
            InitializeComponent();
            UserRole = frmLogin.UserRole;
            UserName = frmLogin.Username;

        }

        private void frmEvaluationSup_Load(object sender, EventArgs e)
        {
            if (UserRole == "employee")
            {
                pnlEmployee.Location = new Point(119, 67); // Set the panel's location
                pnlEmployee.Visible = true;              // Make the panel visible
                LoadTasksForEmployee();                  // Load tasks for the logged-in employee
            }
            else
            {
                pnlEmployee.Visible = false;             // Hide the panel for non-employees
            }

            LoadEmployeeData();
        }

        private void LoadTasksForEmployee()
        {
            cmbTaskGivenEmployee.Items.Clear(); // Clear any existing items
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to get tasks for the logged-in employee
                    string query = @"
                        SELECT DISTINCT questionSet 
                        FROM tblquestions 
                        WHERE created_for = @username";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", UserName);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbTaskGivenEmployee.Items.Add(reader["questionSet"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tasks for employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEmployeeData()
        {
            cmbEmployeeEval.Items.Clear(); // Clear existing items
            Dictionary<string, string> employeeData = new Dictionary<string, string>(); // Store displayname -> username mapping

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to get username and displayname for employees under the logged-in supervisor
                    string query = "SELECT username, displayname FROM tblusers WHERE role = 'employee' AND underby = @supervisor";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@supervisor", UserName); // Use the logged-in supervisor's username

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string username = reader["username"].ToString();
                                string displayname = reader["displayname"].ToString();

                                // Store in dictionary
                                employeeData[displayname] = username;

                                // Add only displayname to ComboBox
                                cmbEmployeeEval.Items.Add(displayname);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Store dictionary in the ComboBox Tag for later retrieval
            cmbEmployeeEval.Tag = employeeData;
        }


        private void cmbEmployeeEval_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDisplayName = cmbEmployeeEval.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedDisplayName)) return;

            // Retrieve the actual username from the dictionary stored in the ComboBox Tag
            var employeeData = cmbEmployeeEval.Tag as Dictionary<string, string>;
            string selectedUsername = employeeData.ContainsKey(selectedDisplayName) ? employeeData[selectedDisplayName] : null;

            if (selectedUsername == null)
            {
                MessageBox.Show("Error retrieving user data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadTaskData(selectedUsername);
        }


        private void LoadTaskData(string employeeName)
        {

            cmbTaskGiven.Items.Clear(); // Clear previous items
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to get questionSet corresponding to the selected employee
                    string query = @"
                        SELECT DISTINCT questionSet 
                        FROM tblquestions 
                        WHERE created_for = @employeeName";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@employeeName", employeeName);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbTaskGiven.Items.Add(reader["questionSet"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading task data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (UserRole == "supervisor")
            {
                string selectedDisplayName = cmbEmployeeEval.SelectedItem?.ToString();
                string selectedTask = cmbTaskGiven.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedDisplayName) || string.IsNullOrEmpty(selectedTask))
                {
                    MessageBox.Show("Please select both an employee and a task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Retrieve actual username from dictionary stored in cmbEmployeeEval.Tag
                var employeeData = cmbEmployeeEval.Tag as Dictionary<string, string>;
                string selectedUsername = employeeData.ContainsKey(selectedDisplayName) ? employeeData[selectedDisplayName] : null;

                if (selectedUsername == null)
                {
                    MessageBox.Show("Error retrieving username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Pass the correct `username`
                frmEvaluationEmp frmEvaluationEmp = new frmEvaluationEmp(selectedUsername, selectedTask);
                frmEvaluationEmp.MdiParent = this.MdiParent; // Maintain the MDI structure
                frmEvaluationEmp.Show();
                frmEvaluationEmp.Dock = DockStyle.Fill;
            }
        }


        private void pnlEmployee_Paint(object sender, PaintEventArgs e)
        {
        }

        
    }
}