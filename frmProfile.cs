using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography; // Import for SHA256
using System.Text;

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
            bool isUpdated = false; // Track if an update occurs

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Retrieve current password hash from the database
                    string oldPasswordHash = string.Empty;
                    string query = "SELECT password FROM tblusers WHERE username = @username";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        oldPasswordHash = command.ExecuteScalar()?.ToString();
                    }

                    // Prepare the update query dynamically
                    List<string> updateFields = new List<string>();
                    MySqlCommand updateCommand = new MySqlCommand();
                    updateCommand.Connection = connection;

                    if (!string.IsNullOrWhiteSpace(txtbxDisplayName.Text))
                    {
                        updateFields.Add("displayname = @displayname");
                        updateCommand.Parameters.AddWithValue("@displayname", txtbxDisplayName.Text);
                        isUpdated = true;
                    }

                    if (!string.IsNullOrWhiteSpace(txtbxUsername.Text))
                    {
                        updateFields.Add("username = @newUsername");
                        updateCommand.Parameters.AddWithValue("@newUsername", txtbxUsername.Text);
                        isUpdated = true;
                    }

                    if (!string.IsNullOrWhiteSpace(txtbxPassword.Text))
                    {
                        // Validate password fields
                        if (string.IsNullOrWhiteSpace(txtbxRetypeNewPassConfirmation.Text) || string.IsNullOrWhiteSpace(txtbxTypeOldPassConfirmation.Text))
                        {
                            MessageBox.Show("Please enter both old and new passwords.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Check if new passwords match
                        if (txtbxPassword.Text != txtbxRetypeNewPassConfirmation.Text)
                        {
                            MessageBox.Show("New password and confirmation do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Hash old password input and compare it with stored hash
                        string enteredOldPasswordHash = HashPassword(txtbxTypeOldPassConfirmation.Text);
                        if (enteredOldPasswordHash != oldPasswordHash)
                        {
                            MessageBox.Show("Incorrect old password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Hash new password before storing it
                        string newPasswordHash = HashPassword(txtbxPassword.Text);
                        updateFields.Add("password = @password");
                        updateCommand.Parameters.AddWithValue("@password", newPasswordHash);
                        isUpdated = true;
                    }

                    if (!isUpdated)
                    {
                        MessageBox.Show("No changes detected. Please modify at least one field.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Execute the update query
                    string updateQuery = $"UPDATE tblusers SET {string.Join(", ", updateFields)} WHERE username = @username";
                    updateCommand.CommandText = updateQuery;
                    updateCommand.Parameters.AddWithValue("@username", username);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh profile data
                        displayProfile();

                        // Reset confirmation panel
                        pnlConfirmationEdits.Visible = false;
                        pnlConfirmationEdits.Location = new System.Drawing.Point(24, 378);

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
                    else
                    {
                        MessageBox.Show("No updates made to the database.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower(); // Convert to lowercase hex
            }
        }


        private void frmProfile_Load_1(object sender, EventArgs e)
        {

        }
    }
}