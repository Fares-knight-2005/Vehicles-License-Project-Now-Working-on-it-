using System;
using System.Data;
using System.Data.SqlClient;

namespace LicensesDataLayer
{
    public class Class1
    {
        private static string connectionString = "Server = .;Database = DVLD;User Id = sa; Password = 123456;";
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, Double PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert into Licenses(ApplicationID ,DriverID ,LicenseClass ,IssueDate ,ExpirationDate ,Notes ,PaidFees ,IsActive ,IssueReason ,CreatedByUserID ) " +
                "values(@ApplicationID ,@DriverID ,@LicenseClass ,@IssueDate ,@ExpirationDate ,@Notes ,@PaidFees ,@IsActive ,@IssueReason ,@CreatedByUserID ); select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (Notes != null)
                cmd.Parameters.AddWithValue("@Notes", Notes);
            else
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


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


        public static bool UpdateLicense(int id, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, Double PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update Licenses set ApplicationID=@ApplicationID ,DriverID=@DriverID ,LicenseClass=@LicenseClass ,IssueDate=@IssueDate ,ExpirationDate=@ExpirationDate ,Notes=@Notes ,PaidFees=@PaidFees ,IsActive=@IsActive ,IssueReason=@IssueReason ,CreatedByUserID=@CreatedByUserID " +
                "where LicenseID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (Notes != null)
                cmd.Parameters.AddWithValue("@Notes", Notes);
            else
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


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


        public static bool DeleteLicense(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From Licenses Where LicenseID = @ID";
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


        public static DataTable GetAllLicenses()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from Licenses";
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


        public static bool IsLicenseExistByApplicationID(int ApplicationID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Licenses where ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
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
        public static bool IsLicenseExistByDriverID(int DriverID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Licenses where DriverID = @DriverID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@DriverID", DriverID);
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
        public static bool IsLicenseExistByLicenseClass(int LicenseClass)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Licenses where LicenseClass = @LicenseClass";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
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
        public static bool IsLicenseExistByIssueDate(DateTime IssueDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Licenses where IssueDate = @IssueDate";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
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
        public static bool IsLicenseExistByExpirationDate(DateTime ExpirationDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Licenses where ExpirationDate = @ExpirationDate";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
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
        public static bool IsLicenseExistByNotes(string Notes)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Licenses where Notes = @Notes";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@Notes", Notes);
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
        public static bool IsLicenseExistByPaidFees(Double PaidFees)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Licenses where PaidFees = @PaidFees";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
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
        public static bool IsLicenseExistByIsActive(bool IsActive)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Licenses where IsActive = @IsActive";
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
        public static bool IsLicenseExistByIssueReason(int IssueReason)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Licenses where IssueReason = @IssueReason";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
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
        public static bool IsLicenseExistByCreatedByUserID(int CreatedByUserID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Licenses where CreatedByUserID = @CreatedByUserID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
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
        public static bool FindLicenseByLicenseID(ref int ApplicationID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref Double PaidFees, ref bool IsActive, ref int IssueReason, ref int CreatedByUserID, ref int LicenseID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from Licenses where LicenseID = @LicenseID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes = reader[" Notes"] != DBNull.Value ? (string)reader["Notes"] : null;
                    PaidFees = (Double)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (int)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }


        public static bool IsLicenseExistByLicenseID(int LicenseID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Licenses where LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
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
