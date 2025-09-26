using System;
using System.Data;
using System.Data.SqlClient;

namespace TestsDataLayer
{
    public class Class1
    {
        private static string connectionString = "Server = .;Database = DVLD;User Id = sa; Password = 123456;";
        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert into Tests(TestAppointmentID ,TestResult ,Notes ,CreatedByUserID ) " +
                "values(@TestAppointmentID ,@TestResult ,@Notes ,@CreatedByUserID ); select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);
            if (Notes != null)
                cmd.Parameters.AddWithValue("@Notes", Notes);
            else
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
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


        public static bool UpdateTest(int id, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update Tests set TestAppointmentID=@TestAppointmentID ,TestResult=@TestResult ,Notes=@Notes ,CreatedByUserID=@CreatedByUserID " +
                "where TestID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);
            if (Notes != null)
                cmd.Parameters.AddWithValue("@Notes", Notes);
            else
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
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


        public static bool DeleteTest(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From Tests Where TestID = @ID";
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


        public static DataTable GetAllTests()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from Tests";
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


        public static bool IsTestExistByTestAppointmentID(int TestAppointmentID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Tests where TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
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
        public static bool IsTestExistByTestResult(bool TestResult)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Tests where TestResult = @TestResult";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@TestResult", TestResult);
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
        public static bool IsTestExistByNotes(string Notes)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Tests where Notes = @Notes";
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
        public static bool IsTestExistByCreatedByUserID(int CreatedByUserID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Tests where CreatedByUserID = @CreatedByUserID";
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
        public static bool FindTestByTestID(ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID, ref int TestID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from Tests where TestID = @TestID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TestID", TestID);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    Notes = reader[" Notes"] != DBNull.Value ? (string)reader["Notes"] : null;
                    CreatedByUserID = (int)reader["CreatedByUserID"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }


        public static bool IsTestExistByTestID(int TestID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Tests where TestID = @TestID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@TestID", TestID);
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
