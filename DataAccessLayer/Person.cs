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
    public class clsPerson
    {
        enum enMode
        {
            AddNew,
            Update
        };

        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email {  get; set; }
        public string Password { get; set; }

        private enMode _Mode = enMode.AddNew;

        public clsPerson(int personId, string name, string phone, string email, string password)
        {
            PersonId = personId;
            Name = name;
            Phone = phone;
            Email = email;
            Password = password;

            if (personId != -1)
            {
                _Mode = enMode.Update;
            }

        }

        public clsPerson()
        {
            PersonId = -1;
        }

        static protected bool DeletePerson(int PersonId)
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

        public bool DeletePerson()
        {
            if (_Mode == enMode.AddNew)
            {
                return false;
            }

            return DeletePerson(PersonId);
        }

        private bool _Update()
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

            bool isUpdated = false;

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

            return isUpdated;
        }

        private int _AddNew()
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

        public bool SavePerson()
        {
            if (_Mode == enMode.AddNew)
            {
                return _AddNew() != -1;
            } else if (_Mode == enMode.Update)
            {
                return _Update();
            }

            return false;
        }

        public int SaveNewPersonAndGetID()
        {
            if (_Mode == enMode.AddNew)
            {
                return _AddNew();
            } else
            {
                return -1;
            }
        } 
    }
}
