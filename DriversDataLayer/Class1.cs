using System;
using System.Data;
using System.Data.SqlClient;


namespace DriversDataLayer
{
    public class Class1
    {
        private static string connectionString = "Server = .;Database = DVLD;User Id = sa; Password = 123456;";
        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert into Drivers(PersonID ,CreatedByUserID ,CreatedDate ) " +
                "values(@PersonID ,@CreatedByUserID ,@CreatedDate ); select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);


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


        public static bool UpdateDriver(int id, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update Drivers set PersonID=@PersonID ,CreatedByUserID=@CreatedByUserID ,CreatedDate=@CreatedDate " +
                "where DriverID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);


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


        public static bool DeleteDriver(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From Drivers Where DriverID = @ID";
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


        public static DataTable GetAllDrivers()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from Drivers";
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


        public static bool IsDriverExistByPersonID(int PersonID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Drivers where PersonID = @PersonID";
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
        public static bool IsDriverExistByCreatedByUserID(int CreatedByUserID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Drivers where CreatedByUserID = @CreatedByUserID";
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
        public static bool IsDriverExistByCreatedDate(DateTime CreatedDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Drivers where CreatedDate = @CreatedDate";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
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
        public static bool FindDriverByDriverID(ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate, ref int DriverID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from Drivers where DriverID = @DriverID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }


        public static bool IsDriverExistByDriverID(int DriverID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Drivers where DriverID = @DriverID";
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
    }
}
