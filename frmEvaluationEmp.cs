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
            ResetButtonColors();
            btnYesEval.FillColor = Color.Red;
        }

        private void btnNoEval_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnNoEval.FillColor = Color.Red;
        }

        private void btnNAEval_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnNAEval.FillColor = Color.Red;
        }

        private void LoadQuestions(string employee, string task)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT questionText 
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
                            string questionText = reader["questionText"].ToString();

                            // Create a new Panel for the question
                            Panel questionPanel = new Panel
                            {
                                Size = new Size(991, 66), // Adjust width/height as needed
                                BackColor = Color.White,
                                BorderStyle = BorderStyle.FixedSingle,
                                Location = new Point(71, yPosition)
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
                                TextAlign = ContentAlignment.MiddleLeft // Ensure text is vertically aligned
                            };


                            // Create the "Yes", "No", and "N/A" radio buttons
                            RadioButton rbtnYes = new RadioButton
                            {
                                Text = "",
                                AutoSize = true,
                                Location = new Point(722, 24),
                               
                            };

                            RadioButton rbtnNo = new RadioButton
                            {
                                Text = "",
                                AutoSize = true,
                                Location = new Point(834, 24),
                                
                            };

                            RadioButton rbtnNA = new RadioButton
                            {
                                Text = "",
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



    }



}




