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

namespace DVLD_project.People_Forms
{
    public partial class ctrUserIfoWithFilter : UserControl
    {

        public event Action<int> onPersonLoaded;
        protected virtual void personLoaded(int personId)
        {
            Action<int> handler = onPersonLoaded;
            if(handler != null)
            {
                handler(personId);
            }
        }
        public ctrUserIfoWithFilter()
        {
            InitializeComponent();
        }

        public void Work(int ID)
        {
           personCardControl1.Work(ID);
        }

        public bool btnaddNewVisabelity { get { return picbAddNewPeron.Visible; } set { picbAddNewPeron.Visible = value; } }
        public bool FilterEnabled { get { return grbFilter.Enabled; } set {  grbFilter.Enabled = value; } }
        public ctrUserIfoWithFilter(string NationalNo)
        {
            InitializeComponent();
            cmbSearch.SelectedIndex = 1;
            txtSearch.Text = NationalNo;
            Find();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void Find()
        {
            if(cmbSearch.SelectedIndex == 1)
               personCardControl1.Work(txtSearch.Text);
            else
            {
                if (!(txtSearch.Text == string.Empty))
                {
                    Handling.ValidatOnlyNumbersAllawed(txtSearch , errorProvider1);
                    personCardControl1.Work(int.Parse(txtSearch.Text));
                }
            }

            if(onPersonLoaded != null && FilterEnabled)
            {
                onPersonLoaded(getPerson().ID); 
            }
        }

        private void picbAddNewPeron_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.DataBack += LoadAddedPersonInfo;
            frm.ShowDialog();
        }

        public void LoadAddedPersonInfo(object sender , int id)
        {
            cmbSearch.SelectedIndex = 0;
            txtSearch.Text = id.ToString();
            Find();
        }

        public Person getPerson()
        {
            return personCardControl1.GetPerson;
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.Focus();
        }

        private void ctrUserIfoWithFilter_Load(object sender, EventArgs e)
        {
            cmbSearch.SelectedIndex = 0;
            txtSearch.Focus();
        }

        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtSearch.Text))
            {
                errorProvider1.SetError(txtSearch, "nothing to search about ?");
            }
            else
            { 
                if(cmbSearch.SelectedIndex == 0)
                    Handling.ValidatOnlyNumbersAllawed(txtSearch , errorProvider1 );
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                pictureBox1_Click(sender, e);
            }
        }
    }
}