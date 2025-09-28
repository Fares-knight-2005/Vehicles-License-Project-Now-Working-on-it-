using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTypesBusnesLayer;

namespace DVLD_project.Test_Forms.Test_Types
{
    public partial class frmEditTestTypecs : Form
    {
        clsTestTypes Tt;
        public frmEditTestTypecs(int id)
        {
            InitializeComponent();
            fillData(id);
        }

        public void fillData(int id)
        {
            Tt = clsTestTypes.Find((clsTestTypes.enTestTypes)id);
            txtDescription.Text = Tt.Description;
            txtTitle.Text = Tt.Title;
            txtFees.Text = Tt.Fees.ToString();
            lblID.Text = ((int)Tt.ID).ToString();
        }
        private void frmEditTestTypecs_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckAll()
        {
            bool ok = Handling.ValidatRecoaierdTextBoxes(txtDescription, errorProvider1) &&
                Handling.ValidatRecoaierdTextBoxes(txtTitle, errorProvider1) &&
                Handling.ValidatRecoaierdTextBoxes(txtFees, errorProvider1) &&
                Handling.ValidatOnlyNumbersAllawed(txtFees, errorProvider1);
            return ok;
        }

        private void fillTt()
        {
            Tt.Description = txtDescription.Text;
            Tt.Title = txtTitle.Text;
            Tt.Fees = Convert.ToDouble(txtFees.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(CheckAll())
            {
                fillTt();
                if (Tt.save())
                {
                    MessageBox.Show("Saved Successfuly", "Congrats", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("An Error Ocured Wasn't Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
