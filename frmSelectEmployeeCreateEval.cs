using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic; // Required for List

namespace Compass_AI
{
    public partial class frmSelectEmployeeCreateEval : Form
    {
        private string connectionString = "Server=compass-ai.czaseckgg0hi.ap-southeast-2.rds.amazonaws.com;Database=DBCompassAI;Uid=admin;Pwd=rErS3S2Mnr8Wus3Bkwb0;";
        private Dictionary<RadioButton, bool> radioButtonStates = new Dictionary<RadioButton, bool>(); // Stores toggle state
        private string selectedEmployeeUsername;

        public frmSelectEmployeeCreateEval()
        {
            InitializeComponent();
        }

        private void frmSelectEmployeeCreateEval_Load(object sender, EventArgs e)
        {
            LoadEmployeePanels();
        }

        private void LoadEmployeePanels()
        {
            pnlList.Controls.Clear(); // Clear previous dynamically generated panels

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT username, displayname, position FROM tblusers WHERE role = 'employee' AND underby = @supervisor";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@supervisor", frmLogin.Username); // Show only employees under this supervisor

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int yPosition = 10; // Start inside pnlList

                        while (reader.Read())
                        {
                            string username = reader["username"].ToString(); // Store username
                            string employeeName = reader["displayname"].ToString();
                            string employeePosition = reader["position"].ToString();

                            // Create a new Panel for each employee
                            Panel employeePanel = new Panel
                            {
                                Size = lblEmployeeName.Parent.Size,
                                BackColor = lblEmployeeName.Parent.BackColor,
                                Location = new Point(10, yPosition)
                            };

                            // Clone Employee Name Label
                            Label lblEmployeeNameClone = new Label
                            {
                                Text = employeeName, // Display Name
                                AutoSize = lblEmployeeName.AutoSize,
                                Font = lblEmployeeName.Font,
                                ForeColor = lblEmployeeName.ForeColor,
                                Location = lblEmployeeName.Location,
                                Tag = username // Store username in the Tag property
                            };

                            // Clone Position Label
                            Label lblPositionClone = new Label
                            {
                                Text = employeePosition,
                                AutoSize = lblPosition.AutoSize,
                                Font = lblPosition.Font,
                                ForeColor = lblPosition.ForeColor,
                                Location = lblPosition.Location
                            };

                            // Clone Select Employee RadioButton
                            RadioButton rbtnSelectEmpClone = new RadioButton
                            {
                                AutoSize = rbtnSelectEmp.AutoSize,
                                Font = rbtnSelectEmp.Font,
                                ForeColor = rbtnSelectEmp.ForeColor,
                                Location = rbtnSelectEmp.Location
                            };

                            // Store selected employee when radio button is clicked
                            rbtnSelectEmpClone.Click += (s, ev) =>
                            {
                                // Retrieve the username from the label's Tag
                                selectedEmployeeUsername = lblEmployeeNameClone.Tag.ToString();
                            };

                            // Add controls to the employee panel
                            employeePanel.Controls.Add(lblEmployeeNameClone);
                            employeePanel.Controls.Add(lblPositionClone);
                            employeePanel.Controls.Add(rbtnSelectEmpClone);

                            pnlList.Controls.Add(employeePanel); // Add the panel to pnlList

                            yPosition += employeePanel.Height + 10;
                        }
                    }
                }
            }
        }


        private void btnConfirmSelectedEmp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedEmployeeUsername))
            {
                MessageBox.Show("Please select an employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pass the username (stored in Tag) to frmCreateEval
            frmCreateEval frmCreateEval = new frmCreateEval(selectedEmployeeUsername);
            frmCreateEval.MdiParent = this.MdiParent;
            frmCreateEval.Show();
            frmCreateEval.Dock = DockStyle.Fill;
        }



    }
}
