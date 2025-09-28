using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.UsersForms
{
    public partial class frmShowUsersInfo : Form
    {
        public frmShowUsersInfo(int UserId)
        {
            InitializeComponent();
            ctrUserCard1.Work(UserId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
