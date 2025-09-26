using System;
using System.Data;
using System.Data.SqlClient;


namespace LicenseClassesDBLayer
{
    public class Class1
    {
        private static string connectionString = "Server = .;Database = DVLD;User Id = sa; Password = 123456;";
        public static int AddNewLicenseClasse(string ClassName, string ClassDescription, byte MinimumAllowedAge, int DefaultValidityLength, Double ClassFees)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert into LiceneseClasses(ClassName ,ClassDescription ,MinimumAllowedAge ,DefaultValidityLength ,ClassFees ) " +
                "values(@ClassName ,@ClassDescription ,@MinimumAllowedAge ,@DefaultValidityLength ,@ClassFees ); select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@ClassName", ClassName);
            cmd.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            cmd.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            cmd.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            cmd.Parameters.AddWithValue("@ClassFees", ClassFees);


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


        public static bool UpdateLicenseClasse(int id, string ClassName, string ClassDescription, byte MinimumAllowedAge, int DefaultValidityLength, Double ClassFees)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update LiceneseClasses set ClassName=@ClassName ,ClassDescription=@ClassDescription ,MinimumAllowedAge=@MinimumAllowedAge ,DefaultValidityLength=@DefaultValidityLength ,ClassFees=@ClassFees " +
                "where LicenseClassID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.Parameters.AddWithValue("@ClassName", ClassName);
            cmd.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            cmd.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            cmd.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            cmd.Parameters.AddWithValue("@ClassFees", ClassFees);


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


        public static bool DeleteLicenseClasse(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From LiceneseClasses Where LicenseClassID = @ID";
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


        public static DataTable GetAllLiceneseClasses()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from LiceneseClasses";
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


        public static bool FindLicenseClasseByClassName(ref string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge, ref int DefaultValidityLength, ref Double ClassFees, ref int LicenseClassID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from LiceneseClasses where ClassName = @ClassName";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ClassName", ClassName);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (int)reader["DefaultValidityLength"];
                    ClassFees = (Double)reader["ClassFees"];
                    LicenseClassID = (int)reader["LicenseClassID"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }


        public static bool IsLicenseClasseExistByClassName(string ClassName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LiceneseClasses where ClassName = @ClassName";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ClassName", ClassName);
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
        public static bool IsLicenseClasseExistByClassDescription(string ClassDescription)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LiceneseClasses where ClassDescription = @ClassDescription";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
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
        public static bool IsLicenseClasseExistByMinimumAllowedAge(byte MinimumAllowedAge)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LiceneseClasses where MinimumAllowedAge = @MinimumAllowedAge";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
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
        public static bool IsLicenseClasseExistByDefaultValidityLength(int DefaultValidityLength)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LiceneseClasses where DefaultValidityLength = @DefaultValidityLength";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
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
        public static bool IsLicenseClasseExistByClassFees(Double ClassFees)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LiceneseClasses where ClassFees = @ClassFees";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);
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
        public static bool FindLicenseClasseByLicenseClassID(ref string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge, ref int DefaultValidityLength, ref Double ClassFees, ref int LicenseClassID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from LiceneseClasses where LicenseClassID = @LicenseClassID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (int)reader["DefaultValidityLength"];
                    ClassFees = (Double)reader["ClassFees"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }


        public static bool IsLicenseClasseExistByLicenseClassID(int LicenseClassID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LiceneseClasses where LicenseClassID = @LicenseClassID";
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
    }
}
