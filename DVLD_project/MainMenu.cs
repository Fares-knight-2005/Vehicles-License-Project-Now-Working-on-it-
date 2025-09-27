using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_project.UsersForms;

namespace DVLD_project
{
    public partial class Main_Menu : Form
    {
        Login frm;
        public Main_Menu(Login frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form3();
            form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsersList frm = new frmUsersList();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUsersInfo frm = new frmShowUsersInfo(clsGlobal._user.Id);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal._user.Id);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal._user = null;

            frm.Show();
            this.Close();
        }
    }
}
