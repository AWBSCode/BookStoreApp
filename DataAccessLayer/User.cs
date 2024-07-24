using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace DataAccessLayer
{
    public class clsUser : clsPerson
    {
        public int UserID { get; set; }

        clsUser(int userID, int personId, string name, string phone, string email, string password)
            : base(personId, name, phone, email, password )
        {
            UserID = userID;
        }

        clsUser()
        {
            UserID = -1;
        }

        
        static protected DataTable GetAllUsers()
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"SELECT        Users.UserID, Users.PersonID, Persons.Name, Persons.Phone, Persons.Password, Persons.email
            FROM            Persons INNER JOIN
                                     Users ON Persons.PersonID = Users.PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            DataTable usersTable = new DataTable();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    usersTable.Load(reader);
                }

                reader.Close();

            } catch (Exception ex)
            {

            } finally
            {
                connection.Close();
            }

            return usersTable;
        }

        static protected clsUser FindUserByID(int ID)
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"SELECT        Users.UserID, Persons.*
            FROM            Persons INNER JOIN
                                     Users ON Persons.PersonID = Users.PersonID
						            WHERE Users.UserID=@ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            clsUser FoundUser = new clsUser();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    FoundUser.UserID = ID;
                    FoundUser.PersonId = (int)reader["PersonID"];
                    FoundUser.Name = (string)reader["Name"];
                    FoundUser.Phone = (string)reader["Phone"];
                    FoundUser.Password = (string)reader["Password"];
                    FoundUser.Email = (string)reader["Email"];

                }
                reader.Close();

            } catch (Exception ex)
            {

            } finally
            {
                connection.Close();
            }

            return FoundUser;
        }

        static private bool DeleteUserRecord(int UserID)
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"DELETE FROM [dbo].[Users]
              WHERE UserID = @ID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", UserID);
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

        static protected bool DeleteUserByID(int UserID)
        {
            int PersonID = FindUserByID(UserID).PersonId;
            return DeleteUserRecord(UserID) && DeletePerson(PersonID);
        } 

        protected bool DeleteUser()
        {
            return DeleteUserByID(UserID);
        }

        protected bool UpdateUser(clsUser User)
        {
            clsPerson person = (clsPerson)User;
            if (person.PersonId == PersonId)
            {
                return person.SavePerson();
            }

           return false;
        }

        /*


        static private bool UpdatePerson(int PersonID, string Name, string Email, string Phone, string  Password)
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
            command.Parameters.AddWithValue("@ID", PersonID);

            bool isUpdated = false;

            try
            {
                connection.Open();
                int rows = (int)command.ExecuteNonQuery();

                if (rows > 0)
                {
                    isUpdated = true;
                } else
                {
                    isUpdated = false;
                }

            } catch(Exception ex)
            {
                isUpdated = false;
            } finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        
        */
    }
}
