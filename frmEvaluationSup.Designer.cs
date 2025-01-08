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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvaluationSup));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnReturnEvalSup = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // btnReturnEvalSup
            // 
            btnReturnEvalSup.BackColor = Color.DimGray;
            btnReturnEvalSup.BorderRadius = 1;
            btnReturnEvalSup.BorderThickness = 2;
            btnReturnEvalSup.CustomizableEdges = customizableEdges3;
            btnReturnEvalSup.DisabledState.BorderColor = Color.DarkGray;
            btnReturnEvalSup.DisabledState.CustomBorderColor = Color.DarkGray;
            btnReturnEvalSup.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnReturnEvalSup.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnReturnEvalSup.FillColor = Color.Transparent;
            btnReturnEvalSup.Font = new Font("Segoe UI", 9F);
            btnReturnEvalSup.ForeColor = Color.White;
            btnReturnEvalSup.Image = (Image)resources.GetObject("btnReturnEvalSup.Image");
            btnReturnEvalSup.ImageSize = new Size(27, 27);
            btnReturnEvalSup.Location = new Point(1084, 12);
            btnReturnEvalSup.Name = "btnReturnEvalSup";
            btnReturnEvalSup.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnReturnEvalSup.Size = new Size(45, 45);
            btnReturnEvalSup.TabIndex = 4;
            // 
            // frmEvaluationSup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 723);
            Controls.Add(btnReturnEvalSup);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmEvaluationSup";
            Text = "Evaluation";
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnReturnEvalSup;
    }
}