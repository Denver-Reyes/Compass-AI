using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Compass_AI
{
    public partial class frmEvaluationEmp : Form
    {
        private string selectedEmployee;
        private string selectedTask;
        private string connectionString = "Server=compass-ai.czaseckgg0hi.ap-southeast-2.rds.amazonaws.com;Database=DBCompassAI;Uid=admin;Pwd=rErS3S2Mnr8Wus3Bkwb0;";

        // Constructor to receive selected employee and task
        public frmEvaluationEmp(string employee, string task)
        {
            InitializeComponent();
            selectedEmployee = employee;
            selectedTask = task;
        }

        private void frmEvaluationEmp_Load(object sender, EventArgs e)
        {
            ResetButtonColors();
            // Now that we have the selected employee and task, load the questions
            LoadQuestions(selectedEmployee, selectedTask);
        }

        private void ResetButtonColors()
        {
            // Reset all buttons to default color
            btnYesEval.FillColor = Color.CadetBlue;
            btnNoEval.FillColor = Color.CadetBlue;
            btnNAEval.FillColor = Color.CadetBlue;
        }

        private void btnYesEval_Click(object sender, EventArgs e)
        {
            Text = "Yes";
            ResetButtonColors();
            btnYesEval.FillColor = Color.Red;
        }

        private void btnNoEval_Click(object sender, EventArgs e)
        {
            Text = "No";
            ResetButtonColors();
            btnNoEval.FillColor = Color.Red;
        }

        private void btnNAEval_Click(object sender, EventArgs e)
        {
            Text = "N/A";
            ResetButtonColors();
            btnNAEval.FillColor = Color.Red;
        }

        private void LoadQuestions(string employee, string task)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                SELECT questionID, questionText 
                FROM tblquestions 
                WHERE created_for = @employee AND questionSet = @task";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@employee", employee);
                    command.Parameters.AddWithValue("@task", task);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int questionNumber = 1;
                        int yPosition = 72; // Starting Y position for the first question

                        while (reader.Read())
                        {
                            string questionID = reader["questionID"].ToString(); // Get the questionID
                            string questionText = reader["questionText"].ToString();

                            // Create a new Panel for the question
                            Panel questionPanel = new Panel
                            {
                                Size = new Size(991, 66), // Adjust width/height as needed
                                BackColor = Color.White,
                                BorderStyle = BorderStyle.FixedSingle,
                                Location = new Point(71, yPosition),
                                Tag = questionID // Set the Tag to the questionID
                            };

                            // Create the "Q#" label
                            Label lblQueNoClone = new Label
                            {
                                Text = $"Q{questionNumber}",
                                AutoSize = true,
                                Font = lblQueNo.Font,
                                ForeColor = lblQueNo.ForeColor,
                                Location = new Point(18, 15) // Align to the left inside the panel
                            };

                            // Create the "Questionnaire" label
                            Label lblQuestionClone = new Label
                            {
                                Text = questionText,
                                AutoSize = false,
                                Font = lblQuestionnaire.Font, // Copy font from lblQuestionnaire
                                ForeColor = lblQuestionnaire.ForeColor, // Copy color from lblQuestionnaire
                                Location = new Point(81, 14), // Position after "Q#"
                                Width = 400, // Adjust width to ensure proper spacing
                                Height = lblQuestionnaire.Height, // Use the height from lblQuestionnaire
                                TextAlign = ContentAlignment.MiddleLeft, // Ensure text is vertically aligned
                                Tag = questionID // Set the Tag to the questionID
                            };

                            // Create the "Yes", "No", and "N/A" radio buttons
                            RadioButton rbtnYes = new RadioButton
                            {
                                Text = "Yes",
                                AutoSize = true,
                                Location = new Point(722, 24),
                            };

                            RadioButton rbtnNo = new RadioButton
                            {
                                Text = "No",
                                AutoSize = true,
                                Location = new Point(834, 24),
                            };

                            RadioButton rbtnNA = new RadioButton
                            {
                                Text = "N/A",
                                AutoSize = true,
                                Location = new Point(937, 24),
                            };

                            // Add controls to the question panel
                            questionPanel.Controls.Add(lblQueNoClone);
                            questionPanel.Controls.Add(lblQuestionClone);
                            questionPanel.Controls.Add(rbtnYes);
                            questionPanel.Controls.Add(rbtnNo);
                            questionPanel.Controls.Add(rbtnNA);

                            // Add the question panel to the main form
                            this.Controls.Add(questionPanel);

                            // Adjust the Y position for the next question
                            yPosition += questionPanel.Height + 10;

                            questionNumber++;
                        }
                    }
                }
            }
        }
        private void btnSubmitEvalEmp_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                bool hasEntriesToSubmit = false; // Flag to check if any entries are processed

                foreach (Control control in this.Controls)
                {
                    if (control is Panel questionPanel)
                    {
                        string questionID = null;

                        // Retrieve the questionID from the Panel's Tag
                        if (questionPanel.Tag != null)
                        {
                            questionID = questionPanel.Tag.ToString();
                        }
                        else
                        {
                            continue; // Skip this question if there's no questionID
                        }

                        // Retrieve the selected radio button
                        string answer = null;
                        foreach (Control questionControl in questionPanel.Controls)
                        {
                            if (questionControl is RadioButton radioButton && radioButton.Checked)
                            {
                                answer = radioButton.Text; // Get the answer (Yes, No, N/A)
                                break;
                            }
                        }

                        if (answer != null)
                        {
                            hasEntriesToSubmit = true; // At least one entry is being processed

                            // Prepare the insert query
                            string insertQuery = @"
                        INSERT INTO tblresults (answer, role, answeredBy, questionID, answeredDate) 
                        VALUES (@answer, @role, @answeredBy, @questionID, @answeredDate)";

                            using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                            {
                                // Assign parameters for the query
                                command.Parameters.AddWithValue("@answer", answer);
                                command.Parameters.AddWithValue("@role", frmLogin.UserRole); // Replace with the appropriate role logic
                                command.Parameters.AddWithValue("@answeredBy", frmLogin.Username); // Replace with the logged-in user's username
                                command.Parameters.AddWithValue("@questionID", questionID);
                                command.Parameters.AddWithValue("@answeredDate", DateTime.Now);

                                // Execute the insert query
                                try
                                {
                                    command.ExecuteNonQuery();
                                }
                                catch (MySqlException ex)
                                {
                                    MessageBox.Show($"Database error: {ex.Message}");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error: {ex.Message}");
                                }
                            }
                        }
                    }
                }

                if (hasEntriesToSubmit)
                {
                    MessageBox.Show("Evaluation submitted successfully!");
                }
                else
                {
                    MessageBox.Show("No valid entries were submitted. Please complete the evaluation.");
                }
            }

            // Navigate back to frmMain, passing the required parameter (username)
            frmMain mainForm = new frmMain(frmLogin.Username); // Pass the username to the frmMain constructor
            mainForm.Show();
            this.Close();
        }



    }
}