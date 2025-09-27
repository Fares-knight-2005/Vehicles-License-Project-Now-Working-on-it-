using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleBusnisLayer;
using countriesBusnesLayer;
using UsersBusnesLayer;
namespace DVLD_project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private bool CheckAll()
        {
            bool ok;
            ok = Handling.ValidatRecoaierdTextBoxes(txtBUserName , errorProvider1) && 
                Handling.ValidatRecoaierdTextBoxes(txtBPassword , errorProvider1);
            if (!ok) { return false; }

            if ((clsGlobal._user = User.Find(txtBUserName.Text, txtBPassword.Text)) != null)
            {
                errorProvider1.SetError(txtBPassword, null);
                errorProvider1.SetError(txtBUserName, null);
                return true;
            }
            errorProvider1.SetError(txtBUserName, "User or Password is not right");
            errorProvider1.SetError(txtBPassword, "User or Password is not right");
            return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckAll())
            {
                if (clsGlobal._user.IsActive) {
                    if (chkBRememberMe.Checked) 
                    {
                        if (!clsGlobal.RememberUsernameAndPassword(clsGlobal._user.UserName, clsGlobal._user.Password))
                            return;
                    }
                    this.Hide();
                    Form form = new Main_Menu(this);
                    form.ShowDialog();
                }
                else
                {
                    clsGlobal._user = null;
                    MessageBox.Show("Your Account is not Active Please Contact Your Admin" , "Not Activated" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBUserName.Focus();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";
            if(clsGlobal.GetStoredCredential(ref UserName , ref Password))
            {
                txtBUserName.Text = UserName;
                txtBPassword.Text = Password;
                chkBRememberMe.Checked = true;
            }
            else
            {
                return;
            }
        }
    }
}
