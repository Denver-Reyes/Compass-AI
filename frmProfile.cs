using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Compass_AI
{
    public partial class frmProfile : Form
    {
        private string connectionString = "Server=compass-ai.czaseckgg0hi.ap-southeast-2.rds.amazonaws.com;Database=DBCompassAI;Uid=admin;Pwd=rErS3S2Mnr8Wus3Bkwb0;";
        private string username;

        public frmProfile(string username)
        {
            InitializeComponent();
            this.username = username; // Set the username first
            displayProfile(); // Call displayProfile() here to load data immediately
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {

        }

        // Function to fetch and display profile information
        public void displayProfile()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT username, displayname, password FROM tblusers WHERE username = @username";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Fetch values from the database
                                string fetchedUsername = reader["username"].ToString();
                                string fetchedDisplayName = reader["displayname"].ToString();
                                string fetchedPassword = reader["password"].ToString();

                                // Update labels with fetched values
                                lblUsernameHolder.Text = fetchedUsername;
                                lblDisplayNameHolder.Text = fetchedDisplayName;
                                lblPasswordHolder.Text = new string('*', fetchedPassword.Length); // Mask password with asterisks
                            }
                            else
                            {
                                MessageBox.Show("User  not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            // Set the lblUsernameHolder, lblDisplayNameHolder, and lblPasswordHolder to invisible
            lblUsernameHolder.Visible = false;
            lblDisplayNameHolder.Visible = false;
            lblPasswordHolder.Visible = false;

            // Set the textboxes to visible
            txtbxDisplayName.Visible = true;
            txtbxUsername.Visible = true;
            txtbxPassword.Visible = true; // Assuming you have a textbox for the password

            // Set the locations of the textboxes
            txtbxDisplayName.Location = new System.Drawing.Point(27, 56);
            txtbxUsername.Location = new System.Drawing.Point(27, 132);
            txtbxPassword.Location = new System.Drawing.Point(27, 205);

            // Set the text inside the textboxes to the current values of the login info
            txtbxDisplayName.Text = lblDisplayNameHolder.Text; // Assuming lblDisplayNameHolder has the current display name
            txtbxUsername.Text = lblUsernameHolder.Text; // Assuming lblUsernameHolder has the current username

            //set change location of btnConfirmEdit and btnCancelEdits to visible
            btnConfirmEdits.Visible = true;
            btnConfirmEdits.Location = new System.Drawing.Point(351, 283);
            btnCancelEdits.Visible = true;

            //set btnEditProfile to invisible
            btnEditProfile.Visible = false;

            //set lblDisplayName to "New Display Name: "
            lblDisplayName.Text = "New Display Name: ";
            lblUsername.Text = "New Username: ";
            lblPassword.Text = "New Password: ";
        }

        private void btnCancelEdits_Click(object sender, EventArgs e)
        {
            //Cancel the edit return back to the original state
            lblUsernameHolder.Visible = true;
            lblDisplayNameHolder.Visible = true;
            lblPasswordHolder.Visible = true;
            txtbxDisplayName.Visible = false;
            txtbxUsername.Visible = false;
            txtbxPassword.Visible = false;
            btnEditProfile.Visible = true;
            btnCancelEdits.Visible = false;
            btnConfirmEdits.Location = new System.Drawing.Point(95, 283);
            btnConfirmEdits.Visible = false;
            lblDisplayName.Text = "Display Name: ";
            lblUsername.Text = "Username: ";
            lblPassword.Text = "Password: ";

        }

        private void btnConfirmEdits_Click(object sender, EventArgs e)
        {
            //pnlConfirmationEdits.Visible = true and set location to 419, 195
            pnlConfirmationEdits.Visible = true;
            pnlConfirmationEdits.Location = new System.Drawing.Point(419, 195);
        }

        private void btnConfirmationNo_Click(object sender, EventArgs e)
        {
            pnlConfirmationEdits.Visible = false;
            pnlConfirmationEdits.Location = new System.Drawing.Point(24, 378);
        }

        private void btnConfirmationYes_Click(object sender, EventArgs e)
        {
            //compare txtbxRetypeNewPassConfirmation value with txtbxPassword value
            //compare txtbxTypeOldPassConfirmation to old password from database
            //if both are correct update the database with the new values
            //pop up confirmation message box that the data has been updated
            //set pnlConfirmationEdits.Visible = false; if the data is saved in the database
            //set pnlConfirmationEdits.Location = new System.Drawing.Point(24, 378); if the data is saved in the database
            //else show error message

            string oldPasswordFromDb = string.Empty;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT password FROM tblusers WHERE username = @username";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        oldPasswordFromDb = command.ExecuteScalar()?.ToString(); // Get the old password
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving old password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit if there's an error
                }
            }

            // Compare the new password and confirmation password
            if (txtbxPassword.Text != txtbxRetypeNewPassConfirmation.Text)
            {
                MessageBox.Show("The new password and confirmation password do not match.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit if passwords do not match
            }
            else
            {
                MessageBox.Show("The new password and confirmation password match.", "Password Match", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Compare the old password
            if (txtbxTypeOldPassConfirmation.Text != oldPasswordFromDb)
            {
                MessageBox.Show("The old password is incorrect.", "Old Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit if the old password does not match
            }
            else
            {
                MessageBox.Show("The old password is correct.", "Old Password Match", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // If both comparisons are correct, you can proceed to update the database
            // (This part will be implemented in the next steps)
        }
    }
}