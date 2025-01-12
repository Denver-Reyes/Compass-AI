﻿using System;
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
    public partial class frmLogin : Form
    {
        // Replace with your actual connection string
        private string connectionString = "Server=sql12.freesqldatabase.com;Database=sql12755997;Uid=sql12755997;Pwd=S6vGcYJmU8;";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Optional: Handle text changed event if needed
        }

        private void picbxCOMPASSAILogo_Click(object sender, EventArgs e)
        {
            // Optional: Add functionality for logo click if needed
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                string query = "SELECT COUNT(*) FROM tbl_users WHERE username = @username AND password = @password";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Use parameterized queries to prevent SQL injection
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        // Open the main form
                        frmMain mainForm = new frmMain();
                        mainForm.Show();

                        //close the login form
                        this.Hide();


                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is closed
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
