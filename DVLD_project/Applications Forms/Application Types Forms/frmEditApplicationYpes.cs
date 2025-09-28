using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationTypesBusnesLayer;

namespace DVLD_project.Applications_Forms.Application_Types_Forms
{
    public partial class frmEditApplicationYpes : Form
    {
        public frmEditApplicationYpes(int ID)
        {
            InitializeComponent();
            fillData(ID);

        }
        clsApplicationType ap;

        private void fillData(int ID)
        {
            ap = clsApplicationType.Find(ID);
            if (ap == null) { return ; }    
            txtFees.Text = ap.Fees.ToString();
            txtTitle.Text = ap.Title.ToString();
            lblID.Text = ap.ID.ToString();
        }

        private void frmEditApplicationYpes_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkAll()
        {
            bool ok = true;

            ok = Handling.ValidatRecoaierdTextBoxes(txtFees , errorProvider1) && 
                Handling.ValidatRecoaierdTextBoxes(txtTitle , errorProvider1 ) &&
                Handling.ValidatOnlyNumbersAllawed(txtFees , errorProvider1);


            return ok;
        }

        private void fillApl()
        {
            ap.Fees = double.Parse( txtFees.Text);
            ap.Title = txtTitle.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(checkAll())
            {
                fillApl();
                if (ap.Save())
                {
                    MessageBox.Show("Application Type Saved Successfuly", "congrats", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("an Error ocured was not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
