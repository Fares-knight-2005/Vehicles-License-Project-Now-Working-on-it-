using System;
using System.Data;
using System.Data.SqlClient;

namespace LicenseClassesDataLayer
{
    public class Class1
    {
        private static string connectionString = "Server = .;Database = DVLD;User Id = sa; Password = 123456;";
        public static int AddNewLicenseClass(string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, Double ClassFees)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert into LicenseClasses(ClassName ,ClassDescription ,MinimumAllowedAge ,DefaultValidityLength ,ClassFees ) " +
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


        public static bool UpdateLicenseClass(int id, string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, Double ClassFees)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update LicenseClasses set ClassName=@ClassName ,ClassDescription=@ClassDescription ,MinimumAllowedAge=@MinimumAllowedAge ,DefaultValidityLength=@DefaultValidityLength ,ClassFees=@ClassFees " +
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


        public static bool DeleteLicenseClass(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From LicenseClasses Where LicenseClassID = @ID";
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


        public static DataTable GetAllLicenseClasses()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from LicenseClasses";
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


        public static bool IsLicenseClassExistByClassName(string ClassName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LicenseClasses where ClassName = @ClassName";
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
        public static bool IsLicenseClassExistByClassDescription(string ClassDescription)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LicenseClasses where ClassDescription = @ClassDescription";
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
        public static bool IsLicenseClassExistByMinimumAllowedAge(byte MinimumAllowedAge)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LicenseClasses where MinimumAllowedAge = @MinimumAllowedAge";
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
        public static bool IsLicenseClassExistByDefaultValidityLength(byte DefaultValidityLength)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LicenseClasses where DefaultValidityLength = @DefaultValidityLength";
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
        public static bool IsLicenseClassExistByClassFees(Double ClassFees)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LicenseClasses where ClassFees = @ClassFees";
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
        public static bool FindLicenseClassByLicenseClassID(ref string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref Double ClassFees, ref int LicenseClassID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from LicenseClasses where LicenseClassID = @LicenseClassID";
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
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (Double)reader["ClassFees"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }


        public static bool IsLicenseClassExistByLicenseClassID(int LicenseClassID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from LicenseClasses where LicenseClassID = @LicenseClassID";
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
