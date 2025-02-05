using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Compass_AI
{
    public partial class frmLeaderboard : Form
    {
        private string connectionString = "Server=compass-ai.czaseckgg0hi.ap-southeast-2.rds.amazonaws.com;Database=DBCompassAI;Uid=admin;Pwd=rErS3S2Mnr8Wus3Bkwb0;";

        public frmLeaderboard()
        {
            InitializeComponent();
        }

        private void frmLeaderboard_Load(object sender, EventArgs e)
        {
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT username, userscore FROM tblusers ORDER BY userscore DESC LIMIT 100"; // Top 100 rankings

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int rank = 1;
                        int yOffset = lblpanelclone.Bottom - 65; // Adjust based on last static panel position

                        while (reader.Read())
                        {
                            string playerName = reader["username"].ToString();
                            int playerScore = reader["userscore"] == DBNull.Value ? 0 : Convert.ToInt32(reader["userscore"]);

                            if (rank == 1)
                            {
                                lblName1.Text = playerName;
                                lblScore1.Text = playerScore.ToString();
                                lblScore1.Location = new Point(880, 14); // Adjust based on last static label position
                            }
                            else if (rank == 2)
                            {
                                lblName2.Text = playerName;
                                lblScore2.Text = playerScore.ToString();
                                lblScore2.Location = new Point(880, 14); // Adjust based on last static label position
                            }
                            else if (rank == 3)
                            {
                                lblName3.Text = playerName;
                                lblScore3.Text = playerScore.ToString();
                                lblScore3.Location = new Point(880, 14); // Adjust based on last static label position
                            }
                            else
                            {
                                // Clone the panel dynamically
                                Panel lblpanelcloneNew = new Panel
                                {
                                    Size = lblpanelclone.Size,        // Copy size
                                    BackColor = lblpanelclone.BackColor,  // Copy background color
                                    Location = new Point(lblpanelclone.Location.X, yOffset) // Position below the last panel
                                };

                                // Custom border settings
                                lblpanelcloneNew.Paint += (sender, e) =>
                                {
                                    // Set up the pen for the border (color = CadetBlue, solid)
                                    using (Pen pen = new Pen(Color.CadetBlue, 2))
                                    {
                                        // Set the pen's dash style to solid
                                        pen.DashStyle = DashStyle.Solid;

                                        // Draw a rectangle with rounded corners (border radius = 5)
                                        int radius = 5; // Border radius
                                        Rectangle panelRect = new Rectangle(0, 0, lblpanelcloneNew.Width - 1, lblpanelcloneNew.Height - 1);

                                        // Create a GraphicsPath to draw the rounded rectangle
                                        GraphicsPath path = new GraphicsPath();
                                        path.AddArc(panelRect.X, panelRect.Y, radius, radius, 180, 90); // Top-left corner
                                        path.AddArc(panelRect.Right - radius, panelRect.Y, radius, radius, 270, 90); // Top-right corner
                                        path.AddArc(panelRect.Right - radius, panelRect.Bottom - radius, radius, radius, 0, 90); // Bottom-right corner
                                        path.AddArc(panelRect.X, panelRect.Bottom - radius, radius, radius, 90, 90); // Bottom-left corner
                                        path.CloseAllFigures();

                                        // Draw the rounded rectangle border
                                        e.Graphics.DrawPath(pen, path);
                                    }
                                };

                                // Rank number label
                                Label lblrankno = new Label
                                {
                                    Text = $"{rank}.",
                                    AutoSize = true,
                                    Font = lblName1.Font,
                                    ForeColor = lblName1.ForeColor,
                                    Location = new Point(45, 14),
                                    TextAlign = ContentAlignment.MiddleCenter // Align text to the left of the label
                                };

                                // Clone name label
                                Label lblnameclone = new Label
                                {
                                    Text = playerName,
                                    AutoSize = true,
                                    Font = lblName1.Font,
                                    ForeColor = lblName1.ForeColor,
                                    Location = new Point(115, 14),
                                };

                                // Clone score label
                                Label lblscoreclone = new Label
                                {
                                    Text = playerScore.ToString(),
                                    AutoSize = true,
                                    Font = lblScore1.Font,
                                    ForeColor = lblScore1.ForeColor,
                                    Location = new Point(880, 14),
                                    TextAlign = ContentAlignment.MiddleCenter // Align text to the right
                                };

                                // Add labels to the new panel
                                lblpanelcloneNew.Controls.Add(lblrankno);
                                lblpanelcloneNew.Controls.Add(lblnameclone);
                                lblpanelcloneNew.Controls.Add(lblscoreclone);

                                // Add the new panel to the form
                                this.Controls.Add(lblpanelcloneNew);

                                // Increase Y offset for the next entry
                                yOffset += lblpanelcloneNew.Height + 5;
                            }

                            rank++;
                        }
                    }
                }
            }
        }
    }
}
