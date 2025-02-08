using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace Compass_AI
{
    public partial class frmCreateEval : Form
    {
        private string selectedEmployeeUsername; // Stores the selected employee's username
        private int questionNumber = 1; // Tracks the question numbering
        private Guna2Button selectedButton; // Tracks the selected question for deletion

        private string connectionString = "Server=compass-ai.czaseckgg0hi.ap-southeast-2.rds.amazonaws.com;Database=DBCompassAI;Uid=admin;Pwd=rErS3S2Mnr8Wus3Bkwb0;";

        private List<string> selectedEmployees;

        public frmCreateEval(List<string> employees)
        {
            InitializeComponent();
            selectedEmployees = employees;
        }

        private void frmCreateEval_Load(object sender, EventArgs e)
        {
            
        }

        private void btnQuestionSubmit_Click(object sender, EventArgs e)
        {
            // Ensure at least one employee is selected
            if (selectedEmployees == null || selectedEmployees.Count == 0)
            {
                MessageBox.Show("Please select at least one employee before submitting a question.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string questionText = txtQuestion.Text.Trim();
            if (string.IsNullOrEmpty(questionText))
            {
                MessageBox.Show("Please type a question before submitting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Measure text and set button size dynamically
            Size textSize = TextRenderer.MeasureText($"Question {questionNumber}: {questionText}", new Font("Segoe UI", 10));
            int minWidth = 400;
            int buttonWidth = Math.Max(minWidth, textSize.Width + 20);

            // Create a new button for the question
            Guna2Button btnQuestion = new Guna2Button
            {
                Text = $"Question {questionNumber}: {questionText}",
                AutoSize = false,
                Size = new Size(buttonWidth, 40),
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, guna2CustomGradientPanel1.Controls.Count * 50 + 10),
                ForeColor = Color.Black,
                FillColor = Color.LightBlue,
                BorderRadius = 10,
                TextAlign = HorizontalAlignment.Left
            };

            questionNumber++;

            // Highlight the selected button when clicked
            btnQuestion.Click += (s, ev) =>
            {
                if (selectedButton != null)
                {
                    selectedButton.FillColor = Color.LightBlue;
                }
                selectedButton = btnQuestion;
                selectedButton.FillColor = Color.DeepSkyBlue;
            };

            guna2CustomGradientPanel1.Controls.Add(btnQuestion);
            txtQuestion.Clear();
        }


        private void btnEvalDelete_Click(object sender, EventArgs e)
        {
            if (selectedButton != null)
            {
                guna2CustomGradientPanel1.Controls.Remove(selectedButton);
                selectedButton = null;

                // Recalculate button positions
                int yOffset = 10;
                int questionIndex = 1;

                foreach (Control control in guna2CustomGradientPanel1.Controls)
                {
                    if (control is Guna2Button btn)
                    {
                        btn.Text = $"Question {questionIndex}: {btn.Text.Split(new[] { ':' }, 2)[1].Trim()}";
                        btn.Location = new Point(10, yOffset);
                        yOffset += 50;
                        questionIndex++;
                    }
                }

                questionNumber = questionIndex;
                MessageBox.Show("Question deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEvalSubmit_Click(object sender, EventArgs e)
        {
            if (selectedEmployees == null || selectedEmployees.Count == 0)
            {
                MessageBox.Show("No employees selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuestionSet.Text))
            {
                MessageBox.Show("Please provide a valid question set name before submitting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> remainingQuestions = new List<string>();
            string createdBy = frmLogin.Username;
            string questionSet = txtQuestionSet.Text.Trim();

            foreach (Control control in guna2CustomGradientPanel1.Controls)
            {
                if (control is Guna2Button btn)
                {
                    string questionText = btn.Text.Split(new[] { ':' }, 2)[1].Trim();
                    remainingQuestions.Add(questionText);
                }
            }

            if (remainingQuestions.Count > 0)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        foreach (string question in remainingQuestions)
                        {
                            foreach (string employee in selectedEmployees) // Save for each selected employee
                            {
                                string query = "INSERT INTO tblquestions (questionText, questionSet, created_for, created_by, created_date) VALUES (@questionText, @questionSet, @createdFor, @createdBy, @createdDate)";

                                using (MySqlCommand command = new MySqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@questionText", question);
                                    command.Parameters.AddWithValue("@questionSet", questionSet);
                                    command.Parameters.AddWithValue("@createdFor", employee); // Store username instead of displayname
                                    command.Parameters.AddWithValue("@createdBy", createdBy);
                                    command.Parameters.AddWithValue("@createdDate", DateTime.Now);

                                    command.ExecuteNonQuery();
                                }
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
