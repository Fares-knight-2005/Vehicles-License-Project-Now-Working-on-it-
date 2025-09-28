using System;
using System.Data;
using System.Data.SqlClient;

namespace TestTypesDataLayer
{
    public class Class1
    {
        private static string connectionString = "Server = .;Database = DVLD;User Id = sa; Password = 123456;";
        public static int AddNewTestType(string TestTypeTitle, string TestTypeDescription, Double TestTypeFees)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert into TestTypes(TestTypeTitle ,TestTypeDescription ,TestTypeFees ) " +
                "values(@TestTypeTitle ,@TestTypeDescription ,@TestTypeFees ); select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            cmd.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            cmd.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);


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


        public static bool UpdateTestType(int id, string TestTypeTitle, string TestTypeDescription, Double TestTypeFees)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update TestTypes set TestTypeTitle=@TestTypeTitle ,TestTypeDescription=@TestTypeDescription ,TestTypeFees=@TestTypeFees " +
                "where TestTypeID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            cmd.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            cmd.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);


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


        public static bool DeleteTestType(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From TestTypes Where TestTypeID = @ID";
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


        public static DataTable GetAllTestTypes()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from TestTypes";
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


        public static bool IsTestTypeExistByTestTypeTitle(string TestTypeTitle)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from TestTypes where TestTypeTitle = @TestTypeTitle";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
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
        public static bool IsTestTypeExistByTestTypeDescription(string TestTypeDescription)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from TestTypes where TestTypeDescription = @TestTypeDescription";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
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
        public static bool IsTestTypeExistByTestTypeFees(Double TestTypeFees)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from TestTypes where TestTypeFees = @TestTypeFees";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
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
        public static bool FindTestTypeByTestTypeID(ref string TestTypeTitle, ref string TestTypeDescription, ref Double TestTypeFees, int TestTypeID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from TestTypes where TestTypeID = @TestTypeID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFees = Convert.ToDouble(reader["TestTypeFees"]);


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }


        public static bool IsTestTypeExistByTestTypeID(int TestTypeID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from TestTypes where TestTypeID = @TestTypeID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
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
