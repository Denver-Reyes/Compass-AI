using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient; // Ensure you add MySql.Data reference

namespace Compass_AI
{
    public partial class frmCreateEval : Form
    {
        private string connectionString = "Server=compass-ai.czaseckgg0hi.ap-southeast-2.rds.amazonaws.com;Database=DBCompassAI;Uid=admin;Pwd=rErS3S2Mnr8Wus3Bkwb0;";
        private string selectedEmployeeName; // To store the selected employee name
        private int questionNumber = 1; // Maintain a counter for question numbers
        private Guna2Button selectedButton = null;

        public frmCreateEval()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmCreateEval_Load(object sender, EventArgs e)
        {
            string query = "SELECT username FROM tblusers WHERE role = 'employee'";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            guna2GradientPanel1.Controls.Clear(); // Clear existing controls if necessary
                            int yOffset = 10; // Vertical spacing for buttons

                            while (reader.Read())
                            {
                                string employeeName = reader["username"].ToString();

                                // Create a new button for each employee
                                Guna2Button btnEmployeEvalName = new Guna2Button
                                {
                                    Text = employeeName,
                                    Size = new System.Drawing.Size(200, 40),
                                    Location = new System.Drawing.Point(10, yOffset),
                                    BorderRadius = 10,
                                    FillColor = System.Drawing.Color.LightBlue,
                                    Font = new System.Drawing.Font("Segoe UI", 10)
                                };

                                // Optional: Add a click event to each button
                                btnEmployeEvalName.Click += (s, ev) =>
                                {
                                    MessageBox.Show($"You clicked on {employeeName}'s evaluation.");
                                    selectedEmployeeName = employeeName;

                                    // Reset all button styles
                                    foreach (Control control in guna2GradientPanel1.Controls)
                                    {
                                        if (control is Guna2Button button)
                                        {
                                            button.FillColor = System.Drawing.Color.LightBlue; // Default color
                                        }
                                    }

                                        // Highlight the selected button
                                        (s as Guna2Button).FillColor = System.Drawing.Color.DeepSkyBlue;


                                };

                                // Cast sender to Guna2Button to identify which button was clicked
                                if (sender is Guna2Button btn)
                                {
                                    // Get the name of the employee from the button's Text property
                                    selectedEmployeeName = btn.Text;

                                    // Optional: Reset styles of all buttons and highlight the selected one
                                    foreach (Control control in guna2GradientPanel1.Controls)
                                    {
                                        if (control is Guna2Button button)
                                        {
                                            button.FillColor = System.Drawing.Color.LightBlue; // Default color
                                        }
                                    }
                                    btn.FillColor = System.Drawing.Color.DeepSkyBlue; // Highlight the selected button

                                    MessageBox.Show($"You have selected {selectedEmployeeName}. You can now type a question.", "Employee Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                guna2GradientPanel1.Controls.Add(btnEmployeEvalName);
                                yOffset += 50; // Increment Y position for the next button
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee names: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnQuestionSubmit_Click(object sender, EventArgs e)
        {
            // Check if an employee is selected
            if (string.IsNullOrEmpty(selectedEmployeeName))
            {
                MessageBox.Show("Please select an employee before submitting a question.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the question text
            string questionText = txtQuestion.Text.Trim();
            if (string.IsNullOrEmpty(questionText))
            {
                MessageBox.Show("Please type a question before submitting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a new button for the question
            Guna2Button btnQuestion = new Guna2Button
            {
                Text = $"Question {questionNumber}: {questionText}", // Use the auto-incremented question number
                AutoSize = false,
                Size = new System.Drawing.Size(400, 40), // Set a fixed size for the button
                Font = new System.Drawing.Font("Segoe UI", 10),
                Location = new System.Drawing.Point(10, guna2CustomGradientPanel1.Controls.Count * 50 + 10), // Adjust position dynamically
                ForeColor = System.Drawing.Color.Black,
                FillColor = System.Drawing.Color.LightBlue,
                BorderRadius = 10, // Optional rounded corners
                TextAlign = HorizontalAlignment.Left // Align the text to the left

            };

            // Increment the question number for the next question
            questionNumber++;

            // Optional: Add a click event to the button
            btnQuestion.Click += (s, ev) =>
            {
                Guna2Button clickedButton = s as Guna2Button;

                // Store the clicked button as selected
                if (selectedButton != null)
                {
                    selectedButton.FillColor = System.Drawing.Color.LightBlue; // Reset previously selected button
                }

                selectedButton = clickedButton;
                selectedButton.FillColor = System.Drawing.Color.DeepSkyBlue; // Highlight selected button
            };

            // Add the button to the panel
            guna2CustomGradientPanel1.Controls.Add(btnQuestion);

            // Handle btnEvalDelete click event
            btnEvalDelete.Click += (s, ev) =>
            {
                if (selectedButton != null)
                {
                    // Remove the selected button from the panel
                    guna2CustomGradientPanel1.Controls.Remove(selectedButton);

                    // Reset the selected button reference
                    selectedButton = null;

                    // Recalculate button positions
                    int yOffset = 10; // Initial offset for the first button
                    int questionIndex = 1; // Reset question numbering

                    foreach (Control control in guna2CustomGradientPanel1.Controls)
                    {
                        if (control is Guna2Button btn)
                        {
                            // Update button text with new question number
                            btn.Text = $"Question {questionIndex}: {btn.Text.Split(new[] { ':' }, 2)[1].Trim()}";

                            // Update button position
                            btn.Location = new Point(10, yOffset);

                            // Increment the offset and question index
                            yOffset += 50;
                            questionIndex++;
                        }
                    }

                    // Adjust question number for new additions
                    questionNumber = questionIndex;

                    MessageBox.Show("Question deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            // Clear the textbox for the next question
            txtQuestion.Clear();
        }

        private void btnEmployeEvalName_Click(object sender, EventArgs e)
        {

        }

        private void btnEvalSubmit_Click(object sender, EventArgs e)
        {
            // Ensure an employee is selected
            if (string.IsNullOrEmpty(selectedEmployeeName))
            {
                MessageBox.Show("Please select an employee before submitting the evaluation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Collect all remaining questions
            List<string> remainingQuestions = new List<string>();
            string employeeName = selectedEmployeeName; // Use the selected employee name
            string createdBy = frmLogin.Username; // Assuming `frmLogin` has a public static property `Username`

            foreach (Control control in guna2CustomGradientPanel1.Controls)
            {
                if (control is Guna2Button btn)
                {
                    // Extract the question text after "Question X: "
                    string questionText = btn.Text.Split(new[] { ':' }, 2)[1].Trim();
                    remainingQuestions.Add(questionText);
                }
            }

            // Check if there are any questions to save
            if (remainingQuestions.Count > 0)
            {
                try
                {
                    // Define the MySQL connection
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        foreach (string question in remainingQuestions)
                        {
                            string query = "INSERT INTO tblquestions (questionText, created_for, created_by, created_date) VALUES (@questionText, @createdFor, @createdBy, @createdDate)";

                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@questionText", question);
                                command.Parameters.AddWithValue("@createdFor", employeeName);
                                command.Parameters.AddWithValue("@createdBy", createdBy);
                                command.Parameters.AddWithValue("@createdDate", DateTime.Now);

                                command.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Questions submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error submitting questions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No questions to submit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }

}
