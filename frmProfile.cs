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
            //popup message to type the current password to confirm the changes
            //popup message if password is incorrect or if the transaction is successful
            //save the changes to the database
        }
    }
}