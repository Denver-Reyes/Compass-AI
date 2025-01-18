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
    public partial class frmEvaluationSup : Form
    {
        private string userRole;

        public frmEvaluationSup(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void frmEvaluationSup_Load(object sender, EventArgs e)
        {
            if (userRole == "employee")
            {
                pnlEmployee.Location = new Point(119, 67); // Set the panel's location
                pnlEmployee.Visible = true;              // Make the panel visible
            }
            else
            {
                pnlEmployee.Visible = false;             // Hide the panel for non-employees
            }
        }

        private void btnConfirmbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}