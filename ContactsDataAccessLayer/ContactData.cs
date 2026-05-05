using System;
using System.Data;
using System.Data.SqlClient;

namespace ContactsDataAccessLayer
{
    public class clsContactsDataAccess
    {

        public static bool GetContactInfoById(int ContactID,ref string FirstName,ref string LastName
            ,ref string Email ,ref string Phone,ref string Address,ref DateTime DateOfBirth
            ,ref int CountryID,ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "Select * From Contacts Where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(Query,Connection);

            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    FirstName = (string)Reader["FirstName"];
                    LastName = (string)Reader["LastName"];
                    Email = (string)Reader["Email"];
                    Phone = (string)Reader["Phone"];
                    Address = (string)Reader["Address"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    CountryID = (int)Reader["CountryID"];

                    //Handling Nullable Col
                    if (Reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)Reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                    IsFound = false;
                }
                Reader.Close();
            }
            catch(Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound; 
        }

        public static int AddNewContact(string FirstName, string LastName,string Email
            ,string Phone,string Address,DateTime DateOfBirth,int CountryID,string ImagePath)
        {
            int ContactId = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Insert Into Contacts (FirstName,LastName,Email,Phone,Address,DateOfBirth
                           ,CountryID,ImagePath) Values (@FirstName,@LastName,@Email,@Phone,@Address
                           ,@DateOfBirth ,@CountryID,@ImagePath) Select Scope_Identity(); ";

            SqlCommand command = new SqlCommand(Query,connection);

            command.Parameters.AddWithValue("@FirstName",FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath",System.DBNull.Value);
            }

                try
                {
                    connection.Open();

                    object Result = command.ExecuteScalar();

                    if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    {
                        ContactId = InsertedID;
                    }

                }
                catch(Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            return ContactId;

        }

        public static bool UpdateContact(int ContactID,string FirstName,string LastName,string Email,
            string Phone,string Address,DateTime DateOfBirth,int CountryID , string ImagePath)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update Contacts
                           Set FirstName = @FirstName,
                           LastName = @LastName,
                           Email = @Email,
                           Phone = @Phone,
                           Address = @Address,
                           DateOfBirth = @DateOfBirth,
                           CountryID = @CountryID,
                           ImagePath = @ImagePath
                           Where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(Query,connection);

            command.Parameters.AddWithValue("@ContactID", ContactID);
            command.Parameters.AddWithValue("@FirstName",FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();

                }
                catch(Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
                finally
                {

                    connection.Close();
                }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllContacts()
        {
            DataTable Dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "Select * From Contacts";

            SqlCommand command = new SqlCommand(Query,connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {

                    Dt.Load(reader);

                }

                reader.Close();
            }
            catch(Exception ex)
            {
                //Console.WriteLine("Error :" + ex.Message);   
            }
            finally
            {
                connection.Close();
            }

            return Dt;
        }
        
        public static bool DeleteContact(int ContactID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "Delete Contacts Where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(Query,connection);

            command.Parameters.AddWithValue("@ContactID",ContactID);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                //Console.WriteLine("Error " + ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);
        }


        public static bool IsContactExist(int ContactID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "Select Found=1 From Contacts Where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(Query,connection);

            command.Parameters.AddWithValue("@ContactID",ContactID);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                
                IsFound = Reader.HasRows;

                Reader.Close();
            }
             catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
                IsFound = false;

            }
            finally
            {
                connection.Close();
                
            }
            return IsFound;
        }

    }

}
