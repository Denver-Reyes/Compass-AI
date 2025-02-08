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
    public partial class frmSelectEmployeeCreateEval : Form
    {
        public frmSelectEmployeeCreateEval()
        {
            InitializeComponent();
        }

        private void btnConfirmSelectedEmp_Click(object sender, EventArgs e)
        {
            frmCreateEval frmCreateEval = new frmCreateEval();
            frmCreateEval.MdiParent = this.MdiParent;
            frmCreateEval.Show();
            frmCreateEval.Dock = DockStyle.Fill;
        }
    }
}
