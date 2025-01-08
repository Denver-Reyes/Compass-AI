namespace Compass_AI
{
    partial class frmLeaderboard
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLeaderboard));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lvlReports = new Label();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            lblName = new Label();
            lblScore = new Label();
            lblRanking = new Label();
            btnReturnLB = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lvlReports
            // 
            lvlReports.AutoSize = true;
            lvlReports.Font = new Font("Segoe UI", 20F);
            lvlReports.ForeColor = Color.FromArgb(40, 90, 114);
            lvlReports.Location = new Point(23, 27);
            lvlReports.Name = "lvlReports";
            lvlReports.Size = new Size(168, 37);
            lvlReports.TabIndex = 1;
            lvlReports.Text = "Leaderboard";
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(lblRanking);
            guna2Panel1.Controls.Add(lblScore);
            guna2Panel1.Controls.Add(lblName);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Location = new Point(74, 93);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(979, 66);
            guna2Panel1.TabIndex = 2;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 20F);
            lblName.ForeColor = Color.FromArgb(40, 90, 114);
            lblName.Location = new Point(115, 14);
            lblName.Name = "lblName";
            lblName.Size = new Size(88, 37);
            lblName.TabIndex = 3;
            lblName.Text = "Name";
            lblName.Click += lblName_Click;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 20F);
            lblScore.ForeColor = Color.FromArgb(40, 90, 114);
            lblScore.Location = new Point(852, 14);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(82, 37);
            lblScore.TabIndex = 4;
            lblScore.Text = "Score";
            // 
            // lblRanking
            // 
            lblRanking.AutoSize = true;
            lblRanking.Font = new Font("Segoe UI", 20F);
            lblRanking.ForeColor = Color.FromArgb(40, 90, 114);
            lblRanking.Location = new Point(21, 14);
            lblRanking.Name = "lblRanking";
            lblRanking.Size = new Size(75, 37);
            lblRanking.TabIndex = 5;
            lblRanking.Text = "Rank";
            // 
            // btnReturnLB
            // 
            btnReturnLB.BackColor = Color.DimGray;
            btnReturnLB.BorderRadius = 1;
            btnReturnLB.BorderThickness = 2;
            btnReturnLB.CustomizableEdges = customizableEdges7;
            btnReturnLB.DisabledState.BorderColor = Color.DarkGray;
            btnReturnLB.DisabledState.CustomBorderColor = Color.DarkGray;
            btnReturnLB.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnReturnLB.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnReturnLB.FillColor = Color.Transparent;
            btnReturnLB.Font = new Font("Segoe UI", 9F);
            btnReturnLB.ForeColor = Color.White;
            btnReturnLB.Image = (Image)resources.GetObject("btnReturnLB.Image");
            btnReturnLB.ImageSize = new Size(27, 27);
            btnReturnLB.Location = new Point(1084, 12);
            btnReturnLB.Name = "btnReturnLB";
            btnReturnLB.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnReturnLB.Size = new Size(45, 45);
            btnReturnLB.TabIndex = 3;
            // 
            // frmLeaderboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1144, 684);
            Controls.Add(btnReturnLB);
            Controls.Add(guna2Panel1);
            Controls.Add(lvlReports);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmLeaderboard";
            Text = "Leaderboard";
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lvlReports;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label lblScore;
        private Label lblName;
        private Label lblRanking;
        private Guna.UI2.WinForms.Guna2Button btnReturnLB;
    }
}