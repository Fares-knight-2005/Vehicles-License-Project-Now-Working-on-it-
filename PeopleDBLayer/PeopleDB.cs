using System;
using System.Data;
using System.Data.SqlClient;

namespace PeopleDBLayer
{
    public class PeopleDB
    {
        static string connectionString = "server=.;Database=DVLD;User Id = sa; Password = 123456;";

        public static int addNewPerson(string nationalNo, string firstName, string secondName, string thirdName,
            string lastName, DateTime dateOfBirth, byte gendor, string address, string phoneNo, string email, int countryID,
            string imagePath)
        {
            int id = -1;
            SqlConnection con = new SqlConnection(connectionString);

            string query = "insert into People (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth" +
                ",Gendor,Address,Phone,Email,NationalityCountryID,ImagePath) " +
                "values (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth" +
                ",@Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath); select scope_Identity();";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@NationalNo", nationalNo);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@SecondName", secondName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", gendor);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Phone", phoneNo);
            cmd.Parameters.AddWithValue("@NationalityCountryID", countryID);

            if (thirdName != null)
                cmd.Parameters.AddWithValue("@ThirdName", thirdName);
            else cmd.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            if (email != null)
                cmd.Parameters.AddWithValue("@Email", email);
            else cmd.Parameters.AddWithValue("@Email", DBNull.Value);

            if (imagePath != null)
                cmd.Parameters.AddWithValue("@ImagePath", imagePath);
            else cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            try
            {
                con.Open();
                object Readed = cmd.ExecuteScalar();

                if (Readed != null && int.TryParse(Readed.ToString(), out int NewID))
                {
                    id = NewID;
                }
            }
            catch (Exception ex) { }
            finally { con.Close(); }

            return id;
        }

        public static bool FindPersonByID(int id, ref string nationalNo, ref string firstName, ref string secondName, ref string thirdName,
            ref string lastName, ref DateTime dateOfBirth, ref byte gendor, ref string address, ref string phoneNo, ref string email, ref int countryID,
            ref string imagePath)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from People where PersonID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            bool isFound = false;

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    nationalNo = (string)reader["NationalNo"];
                    firstName = (string)reader["FirstName"];
                    secondName = (string)reader["SecondName"];
                    lastName = (string)reader["LastName"];
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    gendor = (byte)reader["Gendor"];
                    address = (string)reader["Address"];
                    phoneNo = (string)reader["Phone"];
                    countryID = (int)reader["NationalityCountryID"];

                    // Handle nullable fields
                    thirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : null;
                    email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : null;
                    imagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null;
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

            return isFound;
        }

        public static bool UpdatePerson(int id, string nationalNo, string firstName, string secondName, string thirdName,
            string lastName, DateTime dateOfBirth, byte gendor, string address, string phoneNo, string email, int countryID,
            string imagePath)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update People set NationalNo=@NationalNo, FirstName=@FirstName, SecondName=@SecondName, " +
                "ThirdName=@ThirdName, LastName=@LastName, DateOfBirth=@DateOfBirth, Gendor=@Gendor, Address=@Address, " +
                "Phone=@Phone, Email=@Email, NationalityCountryID=@NationalityCountryID, ImagePath=@ImagePath " +
                "where PersonID=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@NationalNo", nationalNo);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@SecondName", secondName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", gendor);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Phone", phoneNo);
            cmd.Parameters.AddWithValue("@NationalityCountryID", countryID);

            if (thirdName != null)
                cmd.Parameters.AddWithValue("@ThirdName", thirdName);
            else
                cmd.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            if (email != null)
                cmd.Parameters.AddWithValue("@Email", email);
            else
                cmd.Parameters.AddWithValue("@Email", DBNull.Value);

            if (imagePath != null)
                cmd.Parameters.AddWithValue("@ImagePath", imagePath);
            else
                cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            int effectedRows = 0;

            try
            {
                conn.Open();
                effectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }
            return (effectedRows > 0);
        }

        public static bool DeletePerson(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From People Where PersonID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ID", id);

            bool IsDeleted = false;

            try
            {
                conn.Open();
                int numberOfEffectedRows = cmd.ExecuteNonQuery();

                if (numberOfEffectedRows > 0)
                    IsDeleted = true;
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

            return IsDeleted;
        }

        public static DataTable GetAllPeople()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select People.PersonID , People.NationalNo , People.FirstName , People.SecondName , People.ThirdName\r\n" +
                ", People.LastName , People.Phone , People.Gendor , case when People.Gendor = 0 then 'Male' Else 'Female' \r\n" +
                "End as GendorName , People.Address , People.Email , People.DateOfBirth , People.NationalityCountryID\r\n" +
                ", Countries.CountryName , People.ImagePath from People INNER JOIN Countries on People.NationalityCountryID = Countries.CountryID\r\norder by People.FirstName;";
            SqlCommand command = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return dataTable;
        }

        public static bool IsPersonExist(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from People where PersonID = @ID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ID", id);

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

        public static bool FindPersonByNationalNo(string nationalNo, ref int id, ref string firstName, ref string secondName,
            ref string thirdName, ref string lastName, ref DateTime dateOfBirth, ref byte gendor, ref string address,
            ref string phoneNo, ref string email, ref int countryID, ref string imagePath)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from People where NationalNo = @NationalNo";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@NationalNo", nationalNo);
            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    id = (int)reader["PersonID"];
                    firstName = (string)reader["FirstName"];
                    secondName = (string)reader["SecondName"];
                    lastName = (string)reader["LastName"];
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    gendor = (byte)reader["Gendor"];
                    address = (string)reader["Address"];
                    phoneNo = (string)reader["Phone"];
                    countryID = (int)reader["NationalityCountryID"];

                    // Handle nullable fields
                    thirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : null;
                    email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : null;
                    imagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null;
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;
        }

        public static bool IsPersonExistByNationalNo(string nationalNo)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "select Found = 1 from People where NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@NationalNo", nationalNo);

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
    }
}