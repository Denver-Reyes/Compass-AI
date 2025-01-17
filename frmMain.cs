namespace Compass_AI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ResetButtonColors();
            CloseAllForms();
        }
        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ResetButtonColors()
        {
            btnEvaluation.FillColor = Color.Transparent;
            btnLeaderboard.FillColor = Color.Transparent;
            btnCreateEval.FillColor = Color.Transparent;
            btnReports.FillColor = Color.Transparent;
        }

        private void CloseAllForms()
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }
        private void btnEvaluation_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            ResetButtonColors();
            btnEvaluation.FillColor = Color.CadetBlue;
            frmEvaluationEmp frmEvaluationEmp = new frmEvaluationEmp();
            frmEvaluationEmp.MdiParent = frmMain.ActiveForm;
            frmEvaluationEmp.Show();
            frmEvaluationEmp.Dock = DockStyle.Fill;
            frmEvaluationEmp.WindowState = FormWindowState.Maximized;
        }

        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            ResetButtonColors();
            btnLeaderboard.FillColor = Color.CadetBlue;
            frmLeaderboard frmLeaderboard = new frmLeaderboard();
            frmLeaderboard.MdiParent = frmMain.ActiveForm;
            frmLeaderboard.Show();
            frmLeaderboard.Dock = DockStyle.Fill;
            frmLeaderboard.WindowState = FormWindowState.Maximized;
        }

        private void btnCreateEval_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            ResetButtonColors();
            btnCreateEval.FillColor = Color.CadetBlue;
            frmCreateEval frmCreateEval = new frmCreateEval();
            frmCreateEval.MdiParent = frmMain.ActiveForm;
            frmCreateEval.Show();
            frmCreateEval.Dock = DockStyle.Fill;
            frmCreateEval.WindowState = FormWindowState.Maximized;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            ResetButtonColors();
            btnReports.FillColor = Color.CadetBlue;
            frmReports frmReports = new frmReports();
            frmReports.MdiParent = frmMain.ActiveForm;
            frmReports.Show();
            frmReports.Dock = DockStyle.Fill;
            frmReports.WindowState = FormWindowState.Maximized;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            //close the login form
            this.Close();
        }
    }
}
