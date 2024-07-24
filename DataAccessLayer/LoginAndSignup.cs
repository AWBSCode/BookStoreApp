using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public static class clsLoginAndSignupDataAccess
    {
        /*public static int InsertPersonAndGetID(string name, string phone, string password, string email)
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"INSERT INTO [dbo].[Persons]
           ([Name]
           ,[Phone]
           ,[Password]
           ,[email])
     VALUES
           (@Name, @Phone, @Password, @Email); select scope_identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@Email", email);

            int id = -1;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                connection.Close();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    return insertedID;
                }
                else
                {
                    return -1;
                }


            } catch (Exception ex)
            {

            }

            return id;
        }*/

        public static bool LoginUser(string Email, string Password)
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"SELECT        Persons.email, Persons.Password
                FROM            Persons INNER JOIN
                                         Users ON Persons.PersonID = Users.PersonID
			                where email=@Email and password=@Password";

            SqlCommand command = new SqlCommand(query, connection);
            bool isFound = false;

            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                } else
                {
                    isFound = false;
                }

                connection.Close();

            } catch (Exception ex)
            {

            }

            return isFound;
        }

        public static bool SignUserUp(string name, string phone, string password, string email)
        {
            clsPerson newPerson = new clsPerson(-1, name, phone, password, email);
            int PersonID = newPerson.SaveNewPersonAndGetID();
            
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"INSERT INTO [dbo].[Users]
           ([PersonID])
     VALUES
           (@PersonID)";

            SqlCommand command = new SqlCommand(query, connection);
            bool isInserted = false;

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    isInserted = true;
                }

            } catch (Exception ex)
            {

            } finally
            {
                connection.Close();
            }

            return isInserted;
        }

        public static bool LoginAdmin(string Email, string Password)
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"SELECT  Found=1
                            FROM   Admins INNER JOIN
                            Persons ON Admins.PersonID = Persons.PersonID
                            WHERE Email=@Email and Password=@Password";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Password", Password);

            bool isLogged = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    isLogged = true;
                }
                reader.Close();

            } catch (Exception ex)
            {

            } finally
            {
                connection.Close();
            }

            return isLogged;
        }

    }
}
