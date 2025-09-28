using System;
using System.Data;
using System.Data.SqlClient;

namespace ApplicationTypesDataLayer
{
    public class ClsApplicationTypeData
    {
        private static string connectionString = "Server = .;Database = DVLD;User Id = sa; Password = 123456;";
        public static int AddNewApplicationType(string ApplicationTypeTitle, Double ApplicationFees)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert into ApplicationTypes(ApplicationTypeTitle ,ApplicationFees ) " +
                "values(@ApplicationTypeTitle ,@ApplicationFees ); select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            cmd.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);


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
        public static bool UpdateApplicationType(int id, string ApplicationTypeTitle, Double ApplicationFees)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update ApplicationTypes set ApplicationTypeTitle=@ApplicationTypeTitle ,ApplicationFees=@ApplicationFees " +
                "where ApplicationTypeID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            cmd.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);


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
        public static bool DeleteApplicationType(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From ApplicationTypes Where ApplicationTypeID = @ID";
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
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from ApplicationTypes";
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
        public static bool IsApplicationTypeExistByApplicationTypeTitle(string ApplicationTypeTitle)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from ApplicationTypes where ApplicationTypeTitle = @ApplicationTypeTitle";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
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
        public static bool IsApplicationTypeExistByApplicationFees(Double ApplicationFees)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from ApplicationTypes where ApplicationFees = @ApplicationFees";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
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
        public static bool FindApplicationTypeByApplicationTypeID(ref string ApplicationTypeTitle, ref double ApplicationFees, ref int ApplicationTypeID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from ApplicationTypes where ApplicationTypeID = @ApplicationTypeID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees =  Convert.ToDouble(reader["ApplicationFees"]);


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }
        public static bool IsApplicationTypeExistByApplicationTypeID(int ApplicationTypeID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from ApplicationTypes where ApplicationTypeID = @ApplicationTypeID";
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
    }
}
