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
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to get all employees
                    string query = "SELECT username FROM tblusers WHERE role = 'employee'";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbEmployeeEval.Items.Add(reader["username"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEmployeeEval_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEmployee = cmbEmployeeEval.SelectedItem.ToString();
            LoadTaskData(selectedEmployee);

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
            if (UserRole == "employee")
            {
                string selectedTask = cmbTaskGivenEmployee.SelectedItem?.ToString();

                // Ensure the task is selected before proceeding
                if (string.IsNullOrEmpty(selectedTask))
                {
                    MessageBox.Show("Please select a task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Open frmEvaluationEmp for the employee
                frmEvaluationEmp frmEvaluationEmp = new frmEvaluationEmp(UserName, selectedTask); // Use `username` for the logged-in employee
                frmEvaluationEmp.MdiParent = this.MdiParent; // Maintain the MDI structure
                frmEvaluationEmp.Show();
                frmEvaluationEmp.Dock = DockStyle.Fill;
            }
            else if (UserRole == "supervisor")
            {
                string selectedEmployee = cmbEmployeeEval.SelectedItem?.ToString();
                string selectedTask = cmbTaskGiven.SelectedItem?.ToString();

                // Ensure both employee and task are selected before proceeding
                if (string.IsNullOrEmpty(selectedEmployee) || string.IsNullOrEmpty(selectedTask))
                {
                    MessageBox.Show("Please select both an employee and a task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Open frmEvaluationEmp for the supervisor with the selected employee and task
                frmEvaluationEmp frmEvaluationEmp = new frmEvaluationEmp(selectedEmployee, selectedTask);
                frmEvaluationEmp.MdiParent = this.MdiParent; // Maintain the MDI structure
                frmEvaluationEmp.Show();
                frmEvaluationEmp.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("User role not recognized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlEmployee_Paint(object sender, PaintEventArgs e)
        {
        }

        
    }
}