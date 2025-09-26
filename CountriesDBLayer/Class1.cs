using System;
using System.Data;
using System.Data.SqlClient;

namespace CountriesDBLayer
{
    public class Class1
    {
        private static string connectionString = "Server = .;Database = DVLD;User Id = sa; Password = 123456;";
        public static int AddNewCountry(string CountryName)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert into Countries(CountryName ) " +
                "values(@CountryName ); select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@CountryName", CountryName);


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


        public static bool UpdateCountry(int id, string CountryName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update Countries set CountryName=@CountryName " +
                "where CountryID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.Parameters.AddWithValue("@CountryName", CountryName);


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


        public static bool DeleteCountry(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From Countries Where CountryID = @ID";
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


        public static DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from Countries";
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


        public static bool FindCountryByCountryName(string CountryName, ref int CountryID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from Countries where CountryName = @CountryName";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CountryName", CountryName);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    CountryID = (int)reader["CountryID"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }


        public static bool IsCountryExistByCountryName(string CountryName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Countries where CountryName = @CountryName";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@CountryName", CountryName);
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
        public static bool FindCountryByCountryID(ref string CountryName, int CountryID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from Countries where CountryID = @CountryID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CountryID", CountryID);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    CountryName = (string)reader["CountryName"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }


        public static bool IsCountryExistByCountryID(int CountryID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from Countries where CountryID = @CountryID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@CountryID", CountryID);
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
