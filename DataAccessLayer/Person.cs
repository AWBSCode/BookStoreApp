using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer
{
    static public class clsPerson
    {
      
        static public bool DeletePerson(int PersonId)
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"DELETE FROM [dbo].[Persons]
            WHERE PersonID = @ID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", PersonId);
            bool isDeleted = false;

            try
            {
                connection.Open();
                int rows = (int)command.ExecuteNonQuery();

                if (rows > 0)
                {
                    isDeleted = true;
                }
                else
                {
                    isDeleted = false;
                }

            }
            catch (Exception ex)
            {
                isDeleted = false;
            }
            finally
            {
                connection.Close();
            }

            return isDeleted;
        }

        static public bool UpdatePesron(int PersonId, string Name, string Phone, string Password, string Email)
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"
            UPDATE [dbo].[Persons]
               SET [Name] = @Name
                  ,[Phone] = @Phone
                  ,[Password] = @Password
                  ,[email] = @Email
             WHERE PersonID=@ID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@ID", PersonId);

            /*bool isUpdated = false;

            try
            {
                connection.Open();
                int rows = (int)command.ExecuteNonQuery();

                if (rows > 0)
                {
                    isUpdated = true;
                }
                else
                {
                    isUpdated = false;
                }

            }
            catch (Exception ex)
            {
                isUpdated = false;
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;*/

            return CrudHelper.UpdateHelper(connection, command);
        }

        static public int AddNewPerson(string Name, string Phone, string Password, string Email)
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

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Email", Email);

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


            }
            catch (Exception ex)
            {

            }

            return id;
        }
        
        static public int GetPersonID(int ID, string query)
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            int PersonID = 0;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int FoundID))
                {
                    PersonID = FoundID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }
    }
}
