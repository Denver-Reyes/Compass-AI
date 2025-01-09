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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            lblUsername = new Label();
            txtboxUsername = new Guna.UI2.WinForms.Guna2TextBox();
            txtboxPassword = new Guna.UI2.WinForms.Guna2TextBox();
            lblPassword = new Label();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            picbxCOMPASSAILogo = new Guna.UI2.WinForms.Guna2PictureBox();
            lblIncorrectlogin = new Label();
            ((System.ComponentModel.ISupportInitialize)picbxCOMPASSAILogo).BeginInit();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(93, 143);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // txtboxUsername
            // 
            txtboxUsername.CustomizableEdges = customizableEdges1;
            txtboxUsername.DefaultText = "";
            txtboxUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtboxUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtboxUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtboxUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtboxUsername.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtboxUsername.Font = new Font("Segoe UI", 9F);
            txtboxUsername.ForeColor = Color.Black;
            txtboxUsername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtboxUsername.Location = new Point(93, 161);
            txtboxUsername.Name = "txtboxUsername";
            txtboxUsername.PasswordChar = '\0';
            txtboxUsername.PlaceholderForeColor = Color.Black;
            txtboxUsername.PlaceholderText = "";
            txtboxUsername.SelectedText = "";
            txtboxUsername.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtboxUsername.Size = new Size(200, 36);
            txtboxUsername.TabIndex = 1;
            txtboxUsername.TextChanged += guna2TextBox1_TextChanged;
            // 
            // txtboxPassword
            // 
            txtboxPassword.CustomizableEdges = customizableEdges3;
            txtboxPassword.DefaultText = "";
            txtboxPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtboxPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtboxPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtboxPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtboxPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtboxPassword.Font = new Font("Segoe UI", 9F);
            txtboxPassword.ForeColor = Color.Black;
            txtboxPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtboxPassword.Location = new Point(93, 224);
            txtboxPassword.Name = "txtboxPassword";
            txtboxPassword.PasswordChar = '*';
            txtboxPassword.PlaceholderForeColor = Color.Black;
            txtboxPassword.PlaceholderText = "";
            txtboxPassword.SelectedText = "";
            txtboxPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtboxPassword.Size = new Size(200, 36);
            txtboxPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(93, 206);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // btnLogin
            // 
            btnLogin.CustomizableEdges = customizableEdges5;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.CadetBlue;
            btnLogin.Font = new Font("Segoe UI", 9F);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(171, 294);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLogin.Size = new Size(122, 32);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            // 
            // picbxCOMPASSAILogo
            // 
            picbxCOMPASSAILogo.CustomizableEdges = customizableEdges7;
            picbxCOMPASSAILogo.Image = Properties.Resources.COMPASS_AI_whitebg_logo;
            picbxCOMPASSAILogo.ImageRotate = 0F;
            picbxCOMPASSAILogo.Location = new Point(392, 45);
            picbxCOMPASSAILogo.Name = "picbxCOMPASSAILogo";
            picbxCOMPASSAILogo.ShadowDecoration.CustomizableEdges = customizableEdges8;
            picbxCOMPASSAILogo.Size = new Size(350, 350);
            picbxCOMPASSAILogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picbxCOMPASSAILogo.TabIndex = 5;
            picbxCOMPASSAILogo.TabStop = false;
            picbxCOMPASSAILogo.Click += picbxCOMPASSAILogo_Click;
            // 
            // lblIncorrectlogin
            // 
            lblIncorrectlogin.AutoSize = true;
            lblIncorrectlogin.ForeColor = Color.IndianRed;
            lblIncorrectlogin.Location = new Point(93, 267);
            lblIncorrectlogin.Name = "lblIncorrectlogin";
            lblIncorrectlogin.Size = new Size(177, 15);
            lblIncorrectlogin.TabIndex = 6;
            lblIncorrectlogin.Text = "Incorrect Username or Password";
            lblIncorrectlogin.Visible = false;
            // 
            // frmLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(lblIncorrectlogin);
            Controls.Add(picbxCOMPASSAILogo);
            Controls.Add(btnLogin);
            Controls.Add(txtboxPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtboxUsername);
            Controls.Add(lblUsername);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "COMPASS AI Login";
            ((System.ComponentModel.ISupportInitialize)picbxCOMPASSAILogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtboxUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtboxPassword;
        private Label lblPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2PictureBox picbxCOMPASSAILogo;
        private Label lblIncorrectlogin;
    }
}