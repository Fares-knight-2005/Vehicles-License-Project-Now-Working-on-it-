using System;
using System.Data;
using System.Data.SqlClient;

namespace LocalDrivingLicenseApplicationsDataLayer
{
    public class Class1
    {
        private static string connectionString = "Server = .;Database = DVLD;User Id = sa; Password = 123456;";
        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert into LocalDrivingLicenseApplications(ApplicationID ,LicenseClassID ) " +
                "values(@ApplicationID ,@LicenseClassID ); select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


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


        public static bool UpdateLocalDrivingLicenseApplication(int id, int ApplicationID, int LicenseClassID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update LocalDrivingLicenseApplications set ApplicationID=@ApplicationID ,LicenseClassID=@LicenseClassID " +
                "where LocalDrivingLicenseApplicationID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


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


        public static bool DeleteLocalDrivingLicenseApplication(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @ID";
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


        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from LocalDrivingLicenseApplications";
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


        public static bool IsLocalDrivingLicenseApplicationExistByApplicationID(int ApplicationID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LocalDrivingLicenseApplications where ApplicationID = @ApplicationID";
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
        public static bool IsLocalDrivingLicenseApplicationExistByLicenseClassID(int LicenseClassID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LocalDrivingLicenseApplications where LicenseClassID = @LicenseClassID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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
        public static bool FindLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(ref int ApplicationID, ref int LicenseClassID, ref int LocalDrivingLicenseApplicationID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }


        public static bool IsLocalDrivingLicenseApplicationExistByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
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
