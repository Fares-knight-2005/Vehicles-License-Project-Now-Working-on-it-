using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersBusnesLayer;

namespace DVLD_project.UsersForms
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword(int UserId)
        {
            InitializeComponent();
            ctrUserCard1.Work(UserId);
        }
        private User user;
        string newPassword;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool checkAll()
        {
            bool ok = true;
            if(txtCurpa.Text != (user = ctrUserCard1.getUser()).Password)
            {
                ok = false;
                errorProvider1.SetError(txtCurpa, "Wrong Password");
            }
            if (txtPassword.Text != txtConfirm.Text)
            {
                ok = false;
                errorProvider1.SetError(txtConfirm, "Not The Same :(");
            }
            else
            {
                newPassword = txtConfirm.Text;
            }
            ok = Handling.ValidatRecoaierdTextBoxes(txtCurpa, errorProvider1) &&
                Handling.ValidatRecoaierdTextBoxes(txtPassword, errorProvider1);
                return ok;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkAll())
            {
                user.Password = newPassword;
                if(user.Save())
                {
                    MessageBox.Show("Password Saved Successfuly" , "Congrats" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Password wasn't Saved :(", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
