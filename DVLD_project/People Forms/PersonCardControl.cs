using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using countriesBusnesLayer;
using DVLD_project.Properties;
using PeopleBusnisLayer;

namespace DVLD_project
{
    public partial class PersonCardControl : UserControl
    {
        private Person person;
        public Person GetPerson { get { if (person == null || person.ID == -1) return null; return person; } }
        public PersonCardControl()
        {
            InitializeComponent();
        }

        public void Work(int ID)
        {
            person = Person.Find(ID);
            if (person == null) { return; }
            fillData();
        }
        public void Work(string NationalNo)
        {
            person = Person.Find(NationalNo);
            fillData();
        }
        private void fillData()
        {
            lblID.Text = person.ID.ToString();
            lblName.Text = person.FullName;
            lblNationalNumber.Text = person.NationalNo;
            lblPhoneNum.Text = person.PhoneNo;
            lblEmail.Text = person.Email;
            lblGendor.Text = (person.Gendor == 0) ? "Male" : "Female";
            lblDateOfBirth.Text = person.DateOfBirth.ToString();
            lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
            lblAddress.Text = person.Address;
            lblCountry.Text = person.Country.CountryName;
       
            if (person.ImagePath != "")
            {
                picbImage.ImageLocation = person.ImagePath;
            }
            else
            {
                picbImage.Image = (person.Gendor == 0 ? Resources.person_boy__1_ : Resources.person_girl); 
            }
        }
        private void PersonCardControl_Load(object sender, EventArgs e)
        {
            if (person == null)
            {
                MessageBox.Show("Wrong: Id did Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fillData();
        }
        private void lklEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (person == null)
            {
                Form4 frm = new Form4();
                frm.DataBack += DataBack;
                frm.ShowDialog();
            }
            else
            {
                Form4 frm = new Form4(person.ID);
                frm.DataBack += (senderr, id) =>
                {
                    DataBack(senderr, id);
                };
                frm.ShowDialog();
            }
        }

        private void DataBack(object sender, int id)
        {
            person = Person.Find(id);
            fillData();
        }

        private void lblDateOfBirth_Click(object sender, EventArgs e)
        {

        }
    }
}
