using System;
using System.Data;
using System.Data.SqlClient;

namespace ApplicationDataLayer
{
    public class Class1
    {
        private static string connectionString = "Server = .;Database = DVLD;User Id = sa; Password = 123456;";
        public static int AddNewApplication(int ApplicationPersonID, DateTime ApplicatinDate, int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate, Double paidFees, int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert into Applications(ApplicationPersonID ,ApplicatinDate ,ApplicationTypeID ,ApplicationStatus ,LastStatusDate ,paidFees ,CreatedByUserID ) " +
                "values(@ApplicationPersonID ,@ApplicatinDate ,@ApplicationTypeID ,@ApplicationStatus ,@LastStatusDate ,@paidFees ,@CreatedByUserID ); select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
            cmd.Parameters.AddWithValue("@ApplicatinDate", ApplicatinDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@paidFees", paidFees);
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


        public static bool UpdateApplication(int id, int ApplicationPersonID, DateTime ApplicatinDate, int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate, Double paidFees, int CreatedByUserID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update Applications set ApplicationPersonID=@ApplicationPersonID ,ApplicatinDate=@ApplicatinDate ,ApplicationTypeID=@ApplicationTypeID ,ApplicationStatus=@ApplicationStatus ,LastStatusDate=@LastStatusDate ,paidFees=@paidFees ,CreatedByUserID=@CreatedByUserID " +
                "where ApplicationID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
            cmd.Parameters.AddWithValue("@ApplicatinDate", ApplicatinDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@paidFees", paidFees);
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


        public static bool DeleteApplication(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From Applications Where ApplicationID = @ID";
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


        public static DataTable GetAllApplications()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from Applications";
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


        public static bool IsApplicationExistByApplicationPersonID(int ApplicationPersonID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Applications where ApplicationPersonID = @ApplicationPersonID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
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
        public static bool IsApplicationExistByApplicatinDate(DateTime ApplicatinDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Applications where ApplicatinDate = @ApplicatinDate";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ApplicatinDate", ApplicatinDate);
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
        public static bool IsApplicationExistByApplicationTypeID(int ApplicationTypeID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Applications where ApplicationTypeID = @ApplicationTypeID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
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
        public static bool IsApplicationExistByApplicationStatus(int ApplicationStatus)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Applications where ApplicationStatus = @ApplicationStatus";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
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
        public static bool IsApplicationExistByLastStatusDate(DateTime LastStatusDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Applications where LastStatusDate = @LastStatusDate";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
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
        public static bool IsApplicationExistBypaidFees(Double paidFees)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Applications where paidFees = @paidFees";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@paidFees", paidFees);
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
        public static bool IsApplicationExistByCreatedByUserID(int CreatedByUserID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Applications where CreatedByUserID = @CreatedByUserID";
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
        public static bool FindApplicationByApplicationID(ref int ApplicationPersonID, ref DateTime ApplicatinDate, ref int ApplicationTypeID, ref int ApplicationStatus, ref DateTime LastStatusDate, ref Double paidFees, ref int CreatedByUserID, ref int ApplicationID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from Applications where ApplicationID = @ApplicationID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    ApplicationPersonID = (int)reader["ApplicationPersonID"];
                    ApplicatinDate = (DateTime)reader["ApplicatinDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (int)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    paidFees = (Double)reader["paidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }


        public static bool IsApplicationExistByApplicationID(int ApplicationID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Applications where ApplicationID = @ApplicationID";
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
    }
}
