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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_project.UsersForms
{
    public partial class frmUsersList : Form
    {
        public frmUsersList()
        {
            InitializeComponent();
        }

        private void _ResetValues(DataTable t = null)
        {
            if (t == null)
            {
                dataGridView1.DataSource = User.GetAllUsers();
            }
            else
            {
                dataGridView1.DataSource = t;
            }
            dataGridView1.Columns["PersonID"].HeaderText = "Person ID";
            dataGridView1.Columns["UserID"].HeaderText = "User ID";
            dataGridView1.Columns["FullName"].HeaderText = "      Full Name      ";
            dataGridView1.Columns["FullName"].MinimumWidth = 300;
            dataGridView1.Columns["IsActive"].HeaderText = "Is Active";
            dataGridView1.Columns["UserName"].HeaderText = "User Name";
            dataGridView1.Columns["UserName"].MinimumWidth = 110;
           
            lblNumOfRecords.Text = dataGridView1.RowCount.ToString();
        }

        private void frmUsersList_Load(object sender, EventArgs e)
        {
           _ResetValues();
            cmbActive.SelectedIndex = 0;
            cmbSearch.SelectedIndex = 0;
            txtSearch.Enabled = false;
        }

        private void picbAddUser_Click(object sender, EventArgs e)
        {
            AddUpdateUser frm = new AddUpdateUser();
            frm.ShowDialog();
            _ResetValues();
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearch.SelectedIndex == 0)
                txtSearch.Enabled = false;
            else {
                int s;
                txtSearch.Enabled = true;
                if (cmbSearch.SelectedIndex == 1 || cmbSearch.SelectedIndex == 2)
                    if (!int.TryParse(txtSearch.Text, out s))
                        txtSearch.Text = "";
                if (txtSearch.Text != "")
                    FilterIt();
            }
        }

        private void FilterIt()
        {
            DataView dv = User.GetAllUsers().DefaultView;

            switch (cmbActive.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    dv.RowFilter = "IsActive = 1";
                    break;
                case 2:
                    dv.RowFilter = "IsActive = 0";
                    break;
            }
            if (cmbSearch.SelectedIndex == 1 || cmbSearch.SelectedIndex == 2)
            {
                if (!Handling.ValidatOnlyNumbersAllawed(txtSearch, errorProvider1))
                    return;
            }
            if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != string.Empty)
            {
                switch (cmbSearch.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        dv.RowFilter = "PersonID = " + txtSearch.Text;
                        break;
                    case 2:
                        dv.RowFilter = "UserID = " + txtSearch.Text;
                        break;
                    case 3:
                        dv.RowFilter = "UserName Like \'%" + txtSearch.Text + "%\'";
                        break;
                    case 4:
                        dv.RowFilter = "FullName Like \'%" + txtSearch.Text + "%\'";
                        break;
                }
            }

            _ResetValues(dv.ToTable());

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterIt();
        }

        private void cmbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
                FilterIt();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cntms_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];

                var position = dataGridView1.PointToClient(Cursor.Position);
                cntms.Show(dataGridView1, position);
            }

        }

        private void showUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUsersInfo frm = new frmShowUsersInfo((int)dataGridView1.CurrentRow.Cells["UserID"].Value);
            frm.ShowDialog();
        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateUser frm = new AddUpdateUser((int)dataGridView1.CurrentRow.Cells["UserID"].Value);
            frm.ShowDialog();
            _ResetValues();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateUser frm = new AddUpdateUser();
            frm.ShowDialog();
            _ResetValues();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dataGridView1.CurrentRow.Cells["UserID"].Value);
            frm.ShowDialog();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User p = User.Find((int)dataGridView1.CurrentRow.Cells["UserID"].Value);
            if (MessageBox.Show("Are you sure to delete this user with id = " + p.Id + " The Ibformation about it will be Lost?", "Deleteing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (User.DeleteUser(p.Id))
                {
                    MessageBox.Show("Deleted Successfuly :)", "Dleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ResetValues();
                }
                else
                    MessageBox.Show("User Wasn't Deleted \"There are other things related to it\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
