using System;
using System.Data;
using System.Data.SqlClient;


namespace DetainedLicensesDataLayer
{
    public class Class1
    {
        private static string connectionString = "Server = .;Database = DVLD;User Id = sa; Password = 123456;";
        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, Double FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert into DetainedLicenses(LicenseID ,DetainDate ,FineFees ,CreatedByUserID ,IsReleased ,ReleaseDate ,ReleasedByUserID ,ReleaseApplicationID ) " +
                "values(@LicenseID ,@DetainDate ,@FineFees ,@CreatedByUserID ,@IsReleased ,@ReleaseDate ,@ReleasedByUserID ,@ReleaseApplicationID ); select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);
            cmd.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            cmd.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            cmd.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);


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


        public static bool UpdateDetainedLicense(int id, int LicenseID, DateTime DetainDate, Double FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update DetainedLicenses set LicenseID=@LicenseID ,DetainDate=@DetainDate ,FineFees=@FineFees ,CreatedByUserID=@CreatedByUserID ,IsReleased=@IsReleased ,ReleaseDate=@ReleaseDate ,ReleasedByUserID=@ReleasedByUserID ,ReleaseApplicationID=@ReleaseApplicationID " +
                "where DetainID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);
            cmd.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            cmd.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            cmd.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);


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


        public static bool DeleteDetainedLicense(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From DetainedLicenses Where DetainID = @ID";
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


        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from DetainedLicenses";
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


        public static bool IsDetainedLicenseExistByLicenseID(int LicenseID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from DetainedLicenses where LicenseID = @LicenseID";
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
        public static bool IsDetainedLicenseExistByDetainDate(DateTime DetainDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from DetainedLicenses where DetainDate = @DetainDate";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
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
        public static bool IsDetainedLicenseExistByFineFees(Double FineFees)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from DetainedLicenses where FineFees = @FineFees";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@FineFees", FineFees);
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
        public static bool IsDetainedLicenseExistByCreatedByUserID(int CreatedByUserID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from DetainedLicenses where CreatedByUserID = @CreatedByUserID";
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
        public static bool IsDetainedLicenseExistByIsReleased(bool IsReleased)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from DetainedLicenses where IsReleased = @IsReleased";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
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
        public static bool IsDetainedLicenseExistByReleaseDate(DateTime ReleaseDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from DetainedLicenses where ReleaseDate = @ReleaseDate";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
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
        public static bool IsDetainedLicenseExistByReleasedByUserID(int ReleasedByUserID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from DetainedLicenses where ReleasedByUserID = @ReleasedByUserID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
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
        public static bool IsDetainedLicenseExistByReleaseApplicationID(int ReleaseApplicationID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from DetainedLicenses where ReleaseApplicationID = @ReleaseApplicationID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
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
        public static bool FindDetainedLicenseByDetainID(ref int LicenseID, ref DateTime DetainDate, ref Double FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID, ref int DetainID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from DetainedLicenses where DetainID = @DetainID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DetainID", DetainID);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (Double)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    ReleaseDate = (DateTime)reader["ReleaseDate"];
                    ReleasedByUserID = (int)reader["ReleasedByUserID"];
                    ReleaseApplicationID = (int)reader["ReleaseApplicationID"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }


        public static bool IsDetainedLicenseExistByDetainID(int DetainID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from DetainedLicenses where DetainID = @DetainID";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@DetainID", DetainID);
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
