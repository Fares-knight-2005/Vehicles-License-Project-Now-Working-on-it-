using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Configuration;

namespace UsersDataLayer
{
    public class clsUsersData
    {
        private static string connectionString = "Server = .;Database = DVLD;User Id = sa; Password = 123456;";

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert into Users(PersonID ,UserName ,Password ,IsActive ) " +
                "values(@PersonID ,@UserName ,@Password ,@IsActive ); select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);


            try
            {
                con.Open();

                object Readed = cmd.ExecuteScalar();

                if (Readed != null && int.TryParse(Readed.ToString(), out int NewID))
                {
                    ID = NewID;
                }
            }

            catch (Exception ex) { }

            finally { con.Close(); }
            return ID;
        }
        public static bool UpdateUser(int id, int PersonID, string UserName, string Password, bool IsActive)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update Users set PersonID=@PersonID ,UserName=@UserName ,Password=@Password ,IsActive=@IsActive " +
                "where UserID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);


            int effectedRows = 0;
            try
            {
                conn.Open();
                effectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return (effectedRows > 0);
        }
        public static bool DeleteUser(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From Users Where UserID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            bool IsDeleted = false;
            try
            {
                conn.Open();
                int numberOfEffectedRows = cmd.ExecuteNonQuery();
                if (numberOfEffectedRows > 0) IsDeleted = true;
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return IsDeleted;
        }
        public static DataTable GetAllUsers()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select Users.UserID , Users.PersonID , FullName = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName ," +
                "Users.UserName , Users.IsActive From Users Inner Join People on Users.PersonID = People.PersonID;";
            SqlCommand command = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) dataTable.Load(reader);
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return dataTable;
        }
        public static bool FindUserByPersonID(ref int PersonID, ref string UserName, ref string Password, ref bool IsActive, ref int UserID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from Users where PersonID = @PersonID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                    UserID = (int)reader["UserID"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }
        public static bool IsUserExistByPersonID(int PersonID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Users where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            bool isFound = false;
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return isFound;
        }
        public static bool IsUserExistByUserName(string UserName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Users where UserName = @UserName";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@UserName", UserName);
            bool isFound = false;
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return isFound;
        }
        public static bool IsUserExistByPassword(string Password)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Users where Password = @Password";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@Password", Password);
            bool isFound = false;
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return isFound;
        }
        public static bool IsUserExistByIsActive(bool IsActive)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Users where IsActive = @IsActive";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            bool isFound = false;
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return isFound;
        }
        public static bool FindUserByUserID(ref int PersonID, ref string UserName, ref string Password, ref bool IsActive, ref int UserID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from Users where UserID = @UserID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }
        public static bool IsUserExistByUserID(int UserID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Users where UserID = @UserID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@UserID", UserID);
            bool isFound = false;
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return isFound;
        }
        public static bool FindUserByUserNameAndUserPassword(ref string UserName, ref string Password, ref int PersonID, ref bool IsActive, ref int UserID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from Users where UserName = @UserName And Password = @Password;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password" , Password);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    UserID   = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }
        public static bool ChangePassword(int UserID , string NewPassword)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string qery = @"Update Users set Password = @Password where UserID = @UserID;";
            SqlCommand cmd = new SqlCommand(qery, conn);
            cmd.Parameters.AddWithValue("@UserID" , UserID);
            cmd.Parameters.AddWithValue ("Password" , NewPassword);
            int effectedRows = 0;
            try
            {
                conn.Open();
                effectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return (effectedRows > 0);
        }
    }
}
