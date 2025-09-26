using System;
using System.Data;
using System.Data.SqlClient;

namespace TestAppointmentsDataLayer
{
    public class Class1
    {
        private static string connectionString = "Server = .;Database = DVLD;User Id = sa; Password = 123456;";
        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, Double PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert into TestAppointments(TestTypeID ,LocalDrivingLicenseApplicationID ,AppointmentDate ,PaidFees ,CreatedByUserID ,IsLocked ) " +
                "values(@TestTypeID ,@LocalDrivingLicenseApplicationID ,@AppointmentDate ,@PaidFees ,@CreatedByUserID ,@IsLocked ); select Scope_Identity();";
            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);


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


        public static bool UpdateTestAppointment(int id, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, Double PaidFees, int CreatedByUserID, bool IsLocked)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Update TestAppointments set TestTypeID=@TestTypeID ,LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID ,AppointmentDate=@AppointmentDate ,PaidFees=@PaidFees ,CreatedByUserID=@CreatedByUserID ,IsLocked=@IsLocked " +
                "where TestAppointmentID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);


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


        public static bool DeleteTestAppointment(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete From TestAppointments Where TestAppointmentID = @ID";
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


        public static DataTable GetAllTestAppointments()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from TestAppointments";
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


        public static bool IsTestAppointmentExistByTestTypeID(int TestTypeID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from TestAppointments where TestTypeID = @TestTypeID";
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
        public static bool IsTestAppointmentExistByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
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
        public static bool IsTestAppointmentExistByAppointmentDate(DateTime AppointmentDate)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from TestAppointments where AppointmentDate = @AppointmentDate";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
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
        public static bool IsTestAppointmentExistByPaidFees(Double PaidFees)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from TestAppointments where PaidFees = @PaidFees";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
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
        public static bool IsTestAppointmentExistByCreatedByUserID(int CreatedByUserID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from TestAppointments where CreatedByUserID = @CreatedByUserID";
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
        public static bool IsTestAppointmentExistByIsLocked(bool IsLocked)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from TestAppointments where IsLocked = @IsLocked";
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
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
        public static bool FindTestAppointmentByTestAppointmentID(ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref Double PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int TestAppointmentID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Select * from TestAppointments where TestAppointmentID = @TestAppointmentID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;


                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (Double)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];


                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return isFound;
        }


        public static bool IsTestAppointmentExistByTestAppointmentID(int TestAppointmentID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string Query = "Select found = 1 from TestAppointments where TestAppointmentID = @TestAppointmentID";
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
    }
}
