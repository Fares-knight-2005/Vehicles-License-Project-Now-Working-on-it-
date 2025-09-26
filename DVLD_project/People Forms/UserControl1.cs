using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using countriesBusnesLayer;
using PeopleBusnisLayer;


namespace DVLD_project
{
    public partial class UserControl1 : UserControl
    {
        public delegate void dDataBack(object sender, int id);
        public event dDataBack DataBack;
        public Person person {  get; set; }
        public enum enMode { AddNew = 1, Update = 2}
        enMode Mode { get; set; }
        string NationalNumber;
        public UserControl1()
        {
            InitializeComponent();
            initialaiseComponents();
            Mode = enMode.AddNew;
            person = new Person();
            lblOperationToDo.Text = "Adding New Person";
        }
        public UserControl1(int ID)
        {
            InitializeComponent();
            person = Person.Find(ID);
           
            this.Load += (s, e) =>
            {
                if (person == null)
                {
                    MessageBox.Show("Sorry Couldn't Find Data With ID = " + ID  + ":(", "Wrong Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.FindForm().Close();
                }
            }; 
            NationalNumber = person.NationalNo;
            Mode = enMode.Update;
            lblOperationToDo.Text = " Updating Person";
            initialaiseComponents();
            fillData(ID);
        }
        public void initialaiseComponents()
        {

            cmpbCountries.DataSource = Country.GetCountryList();

            cmpbCountries.DisplayMember = "CountryName";
            cmpbCountries.ValueMember = "CountryId";

            setAddress("");
            setCountry("Syria");
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-120);
            setDateOfBirth(DateTime.Now.AddYears(-20));
            setEmail("");
            setFirstName("");
            setGendor(0);
            setLastName("");
            setNationalNumber("");
            setPhoneNum("");
            setSecondtName("");
            setThirdName("");
        }
        private void fillData(int ID)
        {
            lblID.Text = ID.ToString();
            setFirstName(person.FirstName);
            setSecondtName(person.SecondName);
            setThirdName(person.ThirdName);
            setLastName(person.LastName);
            setNationalNumber(person.NationalNo);
            setPhoneNum(person.PhoneNo);
            setEmail(person.Email);
            setGendor(person.Gendor);
            setDateOfBirth(person.DateOfBirth);
            setCountry(person.Country.CountryName);
            setAddress(person.Address);
            setImagePath(person.ImagePath);


            if (picbImage.ImageLocation != null)
            {
                lklRemove.Visible = true;
            }
        }
        private bool UpdatePerson()
        {
            person.FirstName = getFirstName();
            person.LastName = getLastName();
            person.SecondName = getSecondName();
            person.ThirdName = getThirdName();
            person.NationalNo = getNationalNumber();
            person.Email = getEmail();
            person.PhoneNo = getPhoneNum();
            person.Gendor = getGendor();
            person.DateOfBirth = getDateOfBirth();
            person.CountryID = Country.Find(getSelectedCountry()).CountryID; 
            person.Address = getAddress();
            person.ImagePath = getImagePath();
            return person.Save();

        }
        public void setImagePath(string imagePath)
        {
            if (imagePath != "")
            {
                picbImage.ImageLocation = imagePath;
            }
        }
        public string getImagePath()
        {
            return (picbImage.ImageLocation == null ? "" : picbImage.ImageLocation);
        }
        public void setFirstName(string firstName)
        {
            txtFirstName.Text = firstName;
        }
        public string getFirstName()
        {
            return (string)txtFirstName.Text;
        }
        public void setSecondtName(string SecondName)
        {
            txtSecondName.Text = SecondName;
        }
        public string getSecondName()
        {
            return (string)txtSecondName.Text;
        }
        public void setThirdName(string thirdName)
        {
            txtThirdName.Text = thirdName;
        }
        public string getThirdName()
        {
            return (string)txtThirdName.Text;
        }
        public void setLastName(string LastName)
        {
            txtLastName.Text = LastName;
        }
        public string getLastName()
        {
            return (string)txtLastName.Text;
        }
        public void setNationalNumber(string NationalNumber)
        {
            txtNationalNumber.Text = NationalNumber;
        }
        public string getNationalNumber()
        {
            return (string)txtNationalNumber.Text;
        }
        public void setEmail(string Email)
        {
            txtEmail.Text = Email;
        }
        public string getEmail()
        {
            return (string)txtEmail.Text;
        }
        public void setAddress(string Address)
        {
            txtAddress.Text = Address;
        }
        public string getAddress()
        {
            return (string)txtAddress.Text;
        }
        public void setPhoneNum(string PhoneNum)
        {
            txtPhoneNum.Text = PhoneNum;
        }
        public string getPhoneNum()
        {
            return (string)txtPhoneNum.Text;
        }
        public Button GetSaveButton()
        {
            return btnSave;
        }
        public Button GetCancelButton()
        {
            return btnClose;
        }
        public void setCountry(string Country)
        {
            cmpbCountries.Text = Country;
        }
        public void setCountry(int Index)
        {
            cmpbCountries.SelectedIndex = Index;
        }
        public string getSelectedCountry()
        {
            return Country.Find(cmpbCountries.Text).CountryName;
        }
        public void setDateOfBirth(DateTime dateTime)
        {
            dtpDateOfBirth.Value = dateTime;
        }
        public DateTime getDateOfBirth() 
        {
            return (DateTime)dtpDateOfBirth.Value;
        }
        public void setGendor(byte gendor) // 1 Female  And 0 Male
        {
            if (gendor == 1)
            {
                rdbFemale.Select();
            }
            else rdbMale.Select();
        }
        public byte getGendor()
        {
            if(rdbFemale.Checked == true)
            {
                return 1;
            }
            else return 0;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFemale.Checked == true)
            {
                picbImage.Image = Properties.Resources.person_girl;
            }
            else
            {
                picbImage.Image = Properties.Resources.person_boy__1_;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        private void Sve()
        {
            string Mesg = "";
            if (Mode == enMode.AddNew)
            {
                Mesg = "Person Added Successfuly :)";
            }
            else
            {
                Mesg = "Person Updated Successfuly :)";
            }
            MessageBox.Show(Mesg, "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private bool CheckImage()
        {
            if(person.ImagePath != picbImage.ImageLocation)
            {
                if(person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(person.ImagePath);
                    }
                    catch { }
                }
                if(picbImage.ImageLocation != null)
                {
                    string toCopy = picbImage.ImageLocation.ToString();
                    if(Handling.CopyImageToProjectImagesFolder(ref toCopy))
                    {
                        picbImage.ImageLocation = toCopy;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }
        private bool checkEveryThing()  
        {
            errorProvider1.Clear();
            bool r;
            r = (Handling.ValidatRecoaierdTextBoxes(txtFirstName , errorProvider1) && Handling.ValidatRecoaierdTextBoxes(txtLastName, errorProvider1) &&
                Handling.ValidatRecoaierdTextBoxes(txtNationalNumber, errorProvider1) && Handling.ValidatRecoaierdTextBoxes(txtAddress, errorProvider1)
                && Handling.ValidatRecoaierdTextBoxes(txtPhoneNum, errorProvider1));

            if(!r) return false;

            if (!Handling.ValidatingEmail(txtEmail , errorProvider1))
                return false;

            if(!Handling.ValidatOnlyNumbersAllawed(txtPhoneNum , errorProvider1))
            {
                return false;
            }

            if (txtNationalNumber.Text != NationalNumber)
            {
                if (Person.Find(txtNationalNumber.Text) != null)
                {
                    errorProvider1.SetError(txtNationalNumber, "Already Exist");
                    return false;
                }
            }
            r = CheckImage();
            return r;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkEveryThing())
            {
                if (UpdatePerson())
                {
                    Sve();
                    DataBack?.Invoke(this, person.ID);
                    btnClose_Click(sender, e);
                }
                else MessageBox.Show("Data Wasn,t Saved Successfuly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lklSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                picbImage.Load(selectedFilePath);
                lklRemove.Visible = true;
            }
        }

        private void lklRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            picbImage.ImageLocation = null;
            picbImage.Image = null;
            person.ImagePath = "";
            if (rdbMale.Checked)
            {
                setGendor(1);
                setGendor(0);
            }
            else { setGendor(0); setGendor(1); }
            lklRemove.Visible=false;
        }

        private void cmpbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}