using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using UsersDataLayer;
using PeopleBusnisLayer;
using System.Data;

namespace UsersBusnesLayer
{
    public class User
    {

        private enum EnMode { AddNew, Update };

        EnMode Mode;
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public User()
        {
            Mode = EnMode.AddNew;
            Id = -1;
            UserName = "";
            Password = "";
            IsActive = false;
            PersonId = -1;
            Person = null;
        }

        public User(int id, string UserName, string Password, bool IsActive, int PersonId)
        {
            Mode = EnMode.Update;
            this.Id = id;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.PersonId = PersonId;
            Person = PeopleBusnisLayer.Person.Find(PersonId);
        }

        private static int _AddNewUser(User user)
        {
            if (user == null)
                return -1;

            return UsersDataLayer.clsUsersData.AddNewUser(user.PersonId, user.UserName, user.Password, user.IsActive);
        }
        private static bool _UpdateUser(User user)
        {
            if (user == null) return false;

            return clsUsersData.UpdateUser(user.Id, user.PersonId, user.UserName, user.Password, user.IsActive);
        }
        public bool Save()
        {
            if (Mode == EnMode.AddNew)
            {
                int num = _AddNewUser(this);
                if (num != -1) { this.Mode = EnMode.Update; return true; }
                return false;
            }
            else if (Mode == EnMode.Update)
            {
                {
                    return _UpdateUser(this);
                }
            } 
            return false;
        }
        public static User Find(int ID)
        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;
            if(clsUsersData.FindUserByUserID(ref PersonID , ref UserName , ref Password , ref IsActive , ref ID))
                return new User(ID, UserName, Password , IsActive , PersonID);
            return null;
        }
        public static User Find(string UserName , string Password)
        {
            int PersonID = -1;
            int ID = -1;
            bool IsActive = false;
            if (clsUsersData.FindUserByUserNameAndUserPassword(ref UserName, ref Password, ref PersonID, ref IsActive, ref ID))
                return new User(ID, UserName, Password, IsActive,PersonID);
            return null;
        }
        public static User FindByPersonId(int PersonId) 
        {
            string UserName = "";
            int Id = -1;
            string Password = "";
            bool IsActive = false;
            if (clsUsersData.FindUserByPersonID(ref PersonId, ref UserName, ref Password, ref IsActive, ref Id))
                return new User(Id, UserName, Password, IsActive, PersonId);
            return null;
        }
        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }
        public static bool isUserExist(int userID)
        {
            return clsUsersData.IsUserExistByUserID(userID);
        }
        public static bool isUserExistByPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistByPersonID(PersonID);
        }
        public static bool isUserExist(string UserName)
        {
            return clsUsersData.IsUserExistByUserName(UserName);
        }
    }
}
