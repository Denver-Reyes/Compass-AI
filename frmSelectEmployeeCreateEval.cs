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
            radioButtonStates.Clear(); // Clear previous selection states

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
                            string username = reader["username"].ToString();
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
                                Text = employeeName,
                                AutoSize = lblEmployeeName.AutoSize,
                                Font = lblEmployeeName.Font,
                                ForeColor = lblEmployeeName.ForeColor,
                                Location = lblEmployeeName.Location,
                                Tag = username // Store username in Tag
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

                            // Initialize selection state as false (not selected)
                            radioButtonStates[rbtnSelectEmpClone] = false;

                            // Toggle selection when clicked
                            rbtnSelectEmpClone.Click += (s, ev) =>
                            {
                                RadioButton clickedRadio = (RadioButton)s;

                                // Toggle selection state
                                radioButtonStates[clickedRadio] = !radioButtonStates[clickedRadio];

                                // Apply new state (Checked or Unchecked)
                                clickedRadio.Checked = radioButtonStates[clickedRadio];
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
            List<string> selectedEmployees = new List<string>();

            // Loop through all panels in pnlList
            foreach (Control panel in pnlList.Controls)
            {
                if (panel is Panel employeePanel)
                {
                    // Find the RadioButton and Label inside the panel
                    RadioButton radioButton = employeePanel.Controls.OfType<RadioButton>().FirstOrDefault();
                    Label lblEmployee = employeePanel.Controls.OfType<Label>().FirstOrDefault();

                    if (radioButton != null && radioButton.Checked && lblEmployee != null)
                    {
                        // Retrieve username from lblEmployee.Tag
                        string username = lblEmployee.Tag.ToString();
                        selectedEmployees.Add(username);
                    }
                }
            }

            if (selectedEmployees.Count == 0)
            {
                MessageBox.Show("Please select at least one employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pass the list of selected employees to frmCreateEval
            frmCreateEval frmCreateEval = new frmCreateEval(selectedEmployees);
            frmCreateEval.MdiParent = this.MdiParent;
            frmCreateEval.Show();
            frmCreateEval.Dock = DockStyle.Fill;
        }




    }
}
