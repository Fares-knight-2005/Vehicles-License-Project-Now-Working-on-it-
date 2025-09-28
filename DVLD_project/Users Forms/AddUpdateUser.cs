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
using UsersBusnesLayer;
namespace DVLD_project.UsersForms
{
    public partial class AddUpdateUser : Form
    {

        enum EnMode { AddNew , Update}
        EnMode Mode;
        User user;

        public AddUpdateUser()
        {
            InitializeComponent();
            Mode = EnMode.AddNew;
            lblMode.Text = "Add New User";
            user = new User();
        }
        public AddUpdateUser(int ID)
        {
            InitializeComponent();
            ctrUserIfoWithFilter1.FilterEnabled = false;
            user = UsersBusnesLayer.User.Find(ID);
            if (user == null) { return; } 
            Mode = EnMode.Update;
            lblMode.Text = "Update User";
            fillData();
        }

        private void HadPersonInfo(int obj)
        {
         
        }

        public void fillData()
        {
            ctrUserIfoWithFilter1.Work(user.PersonId);
            lblUserID.Text = user.Id.ToString();
            txtUserName.Text = user.UserName;
            txtPassword.Text = user.Password;
            txtConfirm.Text = user.Password;
            ckbActive.Checked = user.IsActive;
        }

        private bool CheckAll()
        {
            bool ok = true;
            ok = (Handling.ValidatRecoaierdTextBoxes(txtUserName, errorProvider1) &&
             Handling.ValidatRecoaierdTextBoxes(txtPassword, errorProvider1) && Handling.ValidatRecoaierdTextBoxes(txtConfirm, errorProvider1));
            
            if (UsersBusnesLayer.User.isUserExist(txtUserName.Text) && txtUserName.Text != user.UserName)
            {
                errorProvider1.SetError(txtUserName, "This User Already Exist");
                ok = false;
            }
            if(txtPassword.Text != txtConfirm.Text)
            {
                errorProvider1.SetError(txtConfirm, "Not The Same Password :(");
                ok = false;
            }
            return ok;
        }
        private void picbImage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To add a new user you should eather to \n1: Choose a person to make it user. or\n2: Add new person first from the \"Edit person\" Link.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            user.Person = ctrUserIfoWithFilter1.getPerson();
            if (user.Person == null)
            {
                errorProvider1.SetError(ctrUserIfoWithFilter1, "this Can't be Empty");
                MessageBox.Show("Please Choose a person or Add One", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Mode == EnMode.AddNew && UsersBusnesLayer.User.FindByPersonId(user.Person.ID) != null)
            {
                errorProvider1.SetError(ctrUserIfoWithFilter1, "this Person Already User");
                MessageBox.Show("This Person Is Already User ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                user.PersonId = user.Person.ID;
                groupBox1.Enabled = true;
                tabControl1.SelectedIndex = 1;
                tabPersonInfo.Enabled = false;
            }
        }

        private void FillUser()
        {
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.IsActive = ckbActive.Checked;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if(CheckAll())
            {
                FillUser();
                if(user.Save())
                {
                    MessageBox.Show("User Saved Successfuly" , "Congrats" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                    btnClose.PerformClick();
                }
                else
                {
                    MessageBox.Show("User Info Are Not Completed :(" , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                }
            }
        }

        private void AddUpdateUser_Load(object sender, EventArgs e)
        {

            ctrUserIfoWithFilter1.onPersonLoaded += HadPersonInfo;
            groupBox1.Enabled = false;
        }

        private void ctrUserIfoWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
