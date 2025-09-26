using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project
{
    public partial class ShowPersonDetails : Form
    {
        public ShowPersonDetails(int id)
        {
            InitializeComponent();
            personCardControl2.Work(id);
            AcceptButton = btnClose;
            CancelButton = btnClose;
        }

        public ShowPersonDetails(string NationalNumber)
        {
            InitializeComponent();
            personCardControl2.Work(NationalNumber);
            AcceptButton = btnClose;
            CancelButton = btnClose;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowPersonDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
