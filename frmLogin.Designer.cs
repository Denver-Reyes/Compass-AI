namespace Compass_AI
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblUsername = new Label();
            txtboxUsername = new Guna.UI2.WinForms.Guna2TextBox();
            txtboxPassword = new Guna.UI2.WinForms.Guna2TextBox();
            lblPassword = new Label();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(29, 29);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // txtboxUsername
            // 
            txtboxUsername.CustomizableEdges = customizableEdges7;
            txtboxUsername.DefaultText = "";
            txtboxUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtboxUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtboxUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtboxUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtboxUsername.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtboxUsername.Font = new Font("Segoe UI", 9F);
            txtboxUsername.ForeColor = Color.Black;
            txtboxUsername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtboxUsername.Location = new Point(29, 47);
            txtboxUsername.Name = "txtboxUsername";
            txtboxUsername.PasswordChar = '\0';
            txtboxUsername.PlaceholderForeColor = Color.Black;
            txtboxUsername.PlaceholderText = "";
            txtboxUsername.SelectedText = "";
            txtboxUsername.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtboxUsername.Size = new Size(200, 36);
            txtboxUsername.TabIndex = 1;
            txtboxUsername.TextChanged += guna2TextBox1_TextChanged;
            // 
            // txtboxPassword
            // 
            txtboxPassword.CustomizableEdges = customizableEdges9;
            txtboxPassword.DefaultText = "";
            txtboxPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtboxPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtboxPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtboxPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtboxPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtboxPassword.Font = new Font("Segoe UI", 9F);
            txtboxPassword.ForeColor = Color.Black;
            txtboxPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtboxPassword.Location = new Point(29, 110);
            txtboxPassword.Name = "txtboxPassword";
            txtboxPassword.PasswordChar = '*';
            txtboxPassword.PlaceholderForeColor = Color.Black;
            txtboxPassword.PlaceholderText = "";
            txtboxPassword.SelectedText = "";
            txtboxPassword.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtboxPassword.Size = new Size(200, 36);
            txtboxPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(29, 92);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // btnLogin
            // 
            btnLogin.CustomizableEdges = customizableEdges11;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.FromArgb(128, 255, 255);
            btnLogin.Font = new Font("Segoe UI", 9F);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(107, 165);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnLogin.Size = new Size(122, 32);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogin);
            Controls.Add(txtboxPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtboxUsername);
            Controls.Add(lblUsername);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "COMPASS AI Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtboxUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtboxPassword;
        private Label lblPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
    }
}