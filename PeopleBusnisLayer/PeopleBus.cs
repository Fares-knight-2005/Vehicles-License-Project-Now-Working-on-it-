using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using countriesBusnesLayer;
using PeopleDBLayer;


namespace PeopleBusnisLayer
{
    public class Person
    {
        public enum Mode { AddNew = 0 , Update = 1}

        public Mode mode = Mode.AddNew;
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName {get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }
        public int ID { get; set; }


        public Country Country { get; set; }

        public Person()
        {
            mode = Mode.AddNew;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now;
            Gendor = 2;
            Address = string.Empty;
            PhoneNo = string.Empty;
            Email = string.Empty;
            CountryID = -1;
            ImagePath = string.Empty;
            ID = -1;
            Country = null;
        }

        public Person(int id ,string nationalNo, string firstName, string secondName,
                string thirdName, string lastName, DateTime dateOfBirth,
                byte gendor, string address, string phoneNo, string email,
                int countryID, string imagePath)
        {
            this.mode = Mode.Update;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gendor = gendor;
            Address = address;
            PhoneNo = phoneNo;
            Email = email;
            CountryID = countryID;
            ImagePath = imagePath;
            ID = id;
            Country = countriesBusnesLayer.Country.Find(countryID);
            FullName = FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
        }

        private static int _AddPerson(Person person)
        {
            if (person == null) return -1;
            return PeopleDBLayer.PeopleDB.addNewPerson(
                person.NationalNo,
                person.FirstName,
                person.SecondName,
                person.ThirdName,
                person.LastName,
                person.DateOfBirth,
                person.Gendor,
                person.Address,
                person.PhoneNo,
                person.Email,
                person.CountryID,
                person.ImagePath
            );
        }

        public static DataTable GetPeople()
        {
            return PeopleDBLayer.PeopleDB.GetAllPeople();
        }

        public static Person Find(string NationalNum)
        { 
            int id = 0;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            string Address = "";
            string PhoneNo = "";
            string Email = "";
            int CountryID = -1;
            string ImagePath = "";

            if(!PeopleDBLayer.PeopleDB.FindPersonByNationalNo(NationalNum, ref id, ref FirstName, ref SecondName, ref ThirdName,
                ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref PhoneNo, ref Email, ref CountryID, ref ImagePath))
                return null; 

            return new Person(id ,NationalNum, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, PhoneNo
               , Email, CountryID, ImagePath);
        }

        public static Person Find(int ID)
        {

            string NationalNo = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            string Address = "";
            string PhoneNo = "";
            string Email = "";
            int CountryID = -1;       
            string ImagePath = "";


            if(!PeopleDBLayer.PeopleDB.FindPersonByID(ID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth, ref Gendor, ref Address, ref PhoneNo, ref Email, ref CountryID, ref ImagePath))
                return null;

            return new Person(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, PhoneNo
                         , Email, CountryID, ImagePath);
        }

        private static bool _Update(Person p)
        {
            if (p == null) return false;
            return PeopleDBLayer.PeopleDB.UpdatePerson(p.ID , p.NationalNo , p.FirstName , p.SecondName , p.ThirdName , p.LastName , p.DateOfBirth
               , p.Gendor , p.Address , p.PhoneNo , p.Email , p.CountryID , p.ImagePath);
        }

        public static bool DeletePerson(int id)
        {
            return PeopleDBLayer.PeopleDB.DeletePerson(id);
        }

        public static bool isPersonExist(int id)
        {
            return PeopleDBLayer.PeopleDB.IsPersonExist(id);
        }

        public static bool isPersonExist(string NationalNum)
        {
            return PeopleDBLayer.PeopleDB.IsPersonExistByNationalNo(NationalNum);
        }

        public bool Save()
        {
            switch (mode)
            {
                case Mode.AddNew:
                    if((this.ID = _AddPerson(this)) != -1)
                    {
                        mode = Mode.Update;
                      
                        return true;
                    }
                    return false;
                   
                case Mode.Update:
                    return _Update(this);
            }
            return false;
        }
    }
}
