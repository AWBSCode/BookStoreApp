using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace DataAccessLayer
{
    public class clsUser 
    {
        static public DataTable GetAllUsers()
        {
            string query = @"SELECT        Users.UserID, Users.PersonID, Persons.Name, Persons.Phone, Persons.Password, Persons.email
            FROM            Persons INNER JOIN
                                     Users ON Persons.PersonID = Users.PersonID";
            
            return CrudHelper.GetAllHelper(query);
        }

        static public void FindUserByID(int UserID, ref int PersonID, ref string Name, ref string Phone, ref string Password, ref string Email)
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"SELECT        Users.UserID, Persons.*
            FROM            Persons INNER JOIN
                                     Users ON Persons.PersonID = Users.PersonID
						            WHERE Users.UserID=@ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", UserID);
            

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    Name = (string)reader["Name"];
                    Phone = (string)reader["Phone"];
                    Password = (string)reader["Password"];
                    Email = (string)reader["Email"];

                }
                reader.Close();

            } catch (Exception ex)
            {

            } finally
            {
                connection.Close();
            }

            
        }

        // can be extracted to cls person
        static public int FindPersonIDFromUserID(int UserID)
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"SELECT PersonID from Users
						            WHERE UserID=@ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", UserID);
            int PersonID = 0;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int FoundID))
                {
                    PersonID = FoundID;
                }

            } catch(Exception ex)
            {

            } finally
            {
                connection.Close();
            }

            return PersonID;
        }

        static private bool DeleteUserRecord(int UserID)
        {
            string query = @"DELETE FROM [dbo].[Users]
              WHERE UserID = @ID";
            return CrudHelper.DeleteHelper(UserID, query);
        }

        static public bool DeleteUserByID(int UserID)
        {
            int PersonId = FindPersonIDFromUserID(UserID);
            return DeleteUserRecord(UserID) && clsPerson.DeletePerson(PersonId);
        }

       static public bool UpdateUser(int userID, string Name, string Phone, string Password, string Email)
       {
            int PersonId = FindPersonIDFromUserID(userID); 
            return clsPerson.UpdatePesron(PersonId, Name, Phone, Password, Email);
       }

        
    }
}
