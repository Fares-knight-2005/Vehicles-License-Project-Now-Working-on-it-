using System;
using System.Data;
using System.Data.SqlClient;


namespace InternationalLicensesDataLayer
{
    public class Class1
    {
        private static string connectionString = "Server = .;Database = DVLD;User Id = sa; Password = 123456;";
        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert into InternationalLicenses(ApplicationID ,DriverID ,IssuedUsingLocalLicenseID ,IssueDate ,ExpirationDate ,IsActive ,CreatedByUserID ) " +
                "values(@ApplicationID ,@DriverID ,@IssuedUsingLocalLicenseID ,@IssueDate ,@ExpirationDate ,@IsActive ,@CreatedByUserID ); select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
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


        public static bool UpdateInternationalLicense(int id, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update InternationalLicenses set ApplicationID=@ApplicationID ,DriverID=@DriverID ,IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID ,IssueDate=@IssueDate ,ExpirationDate=@ExpirationDate ,IsActive=@IsActive ,CreatedByUserID=@CreatedByUserID " +
                "where InternationalLicenseID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
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


        public static bool DeleteInternationalLicense(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From InternationalLicenses Where InternationalLicenseID = @ID";
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


        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from InternationalLicenses";
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


        public static bool IsInternationalLicenseExistByApplicationID(int ApplicationID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from InternationalLicenses where ApplicationID = @ApplicationID";
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
        public static bool IsInternationalLicenseExistByDriverID(int DriverID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from InternationalLicenses where DriverID = @DriverID";
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
        public static bool IsInternationalLicenseExistByIssuedUsingLocalLicenseID(int IssuedUsingLocalLicenseID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from InternationalLicenses where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
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
        public static bool IsInternationalLicenseExistByIssueDate(DateTime IssueDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from InternationalLicenses where IssueDate = @IssueDate";
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
        public static bool IsInternationalLicenseExistByExpirationDate(DateTime ExpirationDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from InternationalLicenses where ExpirationDate = @ExpirationDate";
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
        public static bool IsInternationalLicenseExistByIsActive(bool IsActive)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from InternationalLicenses where IsActive = @IsActive";
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
        public static bool IsInternationalLicenseExistByCreatedByUserID(int CreatedByUserID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from InternationalLicenses where CreatedByUserID = @CreatedByUserID";
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
        public static bool FindInternationalLicenseByInternationalLicenseID(ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID, ref int InternationalLicenseID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from InternationalLicenses where InternationalLicenseID = @InternationalLicenseID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
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
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }


        public static bool IsInternationalLicenseExistByInternationalLicenseID(int InternationalLicenseID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from InternationalLicenses where InternationalLicenseID = @InternationalLicenseID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
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
