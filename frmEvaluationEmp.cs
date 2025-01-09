using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compass_AI
{
    public partial class frmEvaluationEmp : Form
    {
        public frmEvaluationEmp()
        {
            InitializeComponent();
        }

        private void frmEvaluationEmp_Load(object sender, EventArgs e)
        {
            ResetButtonColors();
        }
        private void ResetButtonColors()
        {
            // Reset all buttons to default color
            btnYesEval.FillColor = Color.CadetBlue;
            btnNoEval.FillColor = Color.CadetBlue;
            btnNAEval.FillColor = Color.CadetBlue;
        }
        private void btnYesEval_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnYesEval.FillColor = Color.Red;
        }

        private void btnNoEval_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnNoEval.FillColor = Color.Red;
        }

        private void btnNAEval_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnNAEval.FillColor = Color.Red;
        }
    }
}
