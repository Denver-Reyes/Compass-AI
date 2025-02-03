namespace Compass_AI
{
    partial class frmEvaluationSup
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvaluationSup));
            lblEvalSupMenu = new Label();
            btnConfirmbutton = new Guna.UI2.WinForms.Guna2Button();
            cmbEmployeeEval = new Guna.UI2.WinForms.Guna2ComboBox();
            cmbTaskGiven = new Guna.UI2.WinForms.Guna2ComboBox();
            label1 = new Label();
            pnlEmployee = new Guna.UI2.WinForms.Guna2Panel();
            cmbTaskGivenEmployee = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new Label();
            pnlEmployee.SuspendLayout();
            SuspendLayout();
            // 
            // lblEvalSupMenu
            // 
            lblEvalSupMenu.AutoSize = true;
            lblEvalSupMenu.Font = new Font("Segoe UI", 20F);
            lblEvalSupMenu.ForeColor = Color.FromArgb(40, 90, 114);
            lblEvalSupMenu.Location = new Point(175, 89);
            lblEvalSupMenu.Name = "lblEvalSupMenu";
            lblEvalSupMenu.Size = new Size(350, 37);
            lblEvalSupMenu.TabIndex = 5;
            lblEvalSupMenu.Text = "Select employee to evaluate";
            // 
            // btnConfirmbutton
            // 
            btnConfirmbutton.CustomizableEdges = customizableEdges1;
            btnConfirmbutton.DisabledState.BorderColor = Color.DarkGray;
            btnConfirmbutton.DisabledState.CustomBorderColor = Color.DarkGray;
            btnConfirmbutton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnConfirmbutton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnConfirmbutton.FillColor = Color.CadetBlue;
            btnConfirmbutton.Font = new Font("Segoe UI", 9F);
            btnConfirmbutton.ForeColor = Color.White;
            btnConfirmbutton.Location = new Point(510, 446);
            btnConfirmbutton.Name = "btnConfirmbutton";
            btnConfirmbutton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnConfirmbutton.Size = new Size(180, 45);
            btnConfirmbutton.TabIndex = 6;
            btnConfirmbutton.Text = "Confirm";
            btnConfirmbutton.Click += btnConfirm_Click;
            // 
            // cmbEmployeeEval
            // 
            cmbEmployeeEval.BackColor = Color.Transparent;
            cmbEmployeeEval.CustomizableEdges = customizableEdges3;
            cmbEmployeeEval.DrawMode = DrawMode.OwnerDrawFixed;
            cmbEmployeeEval.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployeeEval.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbEmployeeEval.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbEmployeeEval.Font = new Font("Segoe UI", 10F);
            cmbEmployeeEval.ForeColor = Color.FromArgb(68, 88, 112);
            cmbEmployeeEval.ItemHeight = 30;
            cmbEmployeeEval.Location = new Point(175, 138);
            cmbEmployeeEval.Name = "cmbEmployeeEval";
            cmbEmployeeEval.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cmbEmployeeEval.Size = new Size(331, 36);
            cmbEmployeeEval.TabIndex = 7;
            cmbEmployeeEval.SelectedIndexChanged += cmbEmployeeEval_SelectedIndexChanged;
            // 
            // cmbTaskGiven
            // 
            cmbTaskGiven.BackColor = Color.Transparent;
            cmbTaskGiven.CustomizableEdges = customizableEdges5;
            cmbTaskGiven.DrawMode = DrawMode.OwnerDrawFixed;
            cmbTaskGiven.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTaskGiven.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbTaskGiven.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbTaskGiven.Font = new Font("Segoe UI", 10F);
            cmbTaskGiven.ForeColor = Color.FromArgb(68, 88, 112);
            cmbTaskGiven.ItemHeight = 30;
            cmbTaskGiven.Location = new Point(175, 283);
            cmbTaskGiven.Name = "cmbTaskGiven";
            cmbTaskGiven.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cmbTaskGiven.Size = new Size(331, 36);
            cmbTaskGiven.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.ForeColor = Color.FromArgb(40, 90, 114);
            label1.Location = new Point(175, 234);
            label1.Name = "label1";
            label1.Size = new Size(258, 37);
            label1.TabIndex = 8;
            label1.Text = "Select the task given";
            // 
            // pnlEmployee
            // 
            pnlEmployee.Controls.Add(cmbTaskGivenEmployee);
            pnlEmployee.Controls.Add(label2);
            pnlEmployee.CustomizableEdges = customizableEdges9;
            pnlEmployee.Location = new Point(596, 75);
            pnlEmployee.Name = "pnlEmployee";
            pnlEmployee.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlEmployee.Size = new Size(465, 304);
            pnlEmployee.TabIndex = 10;
            pnlEmployee.Visible = false;
            // 
            // cmbTaskGivenEmployee
            // 
            cmbTaskGivenEmployee.BackColor = Color.Transparent;
            cmbTaskGivenEmployee.CustomizableEdges = customizableEdges7;
            cmbTaskGivenEmployee.DrawMode = DrawMode.OwnerDrawFixed;
            cmbTaskGivenEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTaskGivenEmployee.FocusedColor = Color.Empty;
            cmbTaskGivenEmployee.Font = new Font("Segoe UI", 10F);
            cmbTaskGivenEmployee.ForeColor = Color.FromArgb(68, 88, 112);
            cmbTaskGivenEmployee.ItemHeight = 30;
            cmbTaskGivenEmployee.Location = new Point(115, 134);
            cmbTaskGivenEmployee.Name = "cmbTaskGivenEmployee";
            cmbTaskGivenEmployee.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cmbTaskGivenEmployee.Size = new Size(228, 36);
            cmbTaskGivenEmployee.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F);
            label2.ForeColor = Color.FromArgb(40, 90, 114);
            label2.Location = new Point(98, 80);
            label2.Name = "label2";
            label2.Size = new Size(258, 37);
            label2.TabIndex = 11;
            label2.Text = "Select the task given";
            // 
            // frmEvaluationSup
            // 
            AcceptButton = btnConfirmbutton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(729, 511);
            Controls.Add(pnlEmployee);
            Controls.Add(cmbTaskGiven);
            Controls.Add(label1);
            Controls.Add(cmbEmployeeEval);
            Controls.Add(btnConfirmbutton);
            Controls.Add(lblEvalSupMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmEvaluationSup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Evaluation";
            Load += frmEvaluationSup_Load;
            pnlEmployee.ResumeLayout(false);
            pnlEmployee.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblEvalSupMenu;
        private Guna.UI2.WinForms.Guna2Button btnConfirmbutton;
        private Guna.UI2.WinForms.Guna2ComboBox cmbEmployeeEval;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTaskGiven;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Panel pnlEmployee;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTaskGivenEmployee;
        private Label label2;
    }
}