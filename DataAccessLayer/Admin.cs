using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public static class clsAdmin
    {
        public enum enPermissions
        {
            None = 0,
            users=1,
            admins=2,
            books=4,
        }

        // find admin
        // can be extracted to cls person
        public static void FindAdmin(int AdminId, ref int PersonID, ref string Name, ref string Phone, ref string Password, ref string Email, ref int Perms)
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"SELECT        Admins.AdminID, Admins.PersonID, Persons.Name, Persons.Phone, Persons.Password, Persons.email, Admins.PermissionCode
            FROM            Admins INNER JOIN
                                     Persons ON Admins.PersonID = Persons.PersonID
			            where Admins.AdminID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", AdminId);


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
                    Perms = (int)reader["PermissionCode"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

        }

        // get admin personId from id
        // can be extracted to cls person
        public static int GetPersonIdFromAdminID(int adminID)
        {
            /*SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"SELECT PersonID from Admins
						            WHERE AdminID=@ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", adminID);
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
            }*/
            string query = @"SELECT PersonID from Admins
						            WHERE AdminID=@ID";
            return clsPerson.GetPersonID(adminID, query) ;
        }

        // insert admin
        public static bool InsertNewAdmin(string Name, string Phone, string Password, string Email, int PersmissionCode)
        {
            int personId = clsPerson.AddNewPerson(Name, Phone, Password, Email);
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"INSERT INTO [dbo].[Admins]
           ([PersonID]
           ,[PermissionCode])
     VALUES
           (@PersonID
           ,@PermissionCode)";

            SqlCommand command = new SqlCommand(query, connection);
            bool isInserted = false;

            command.Parameters.AddWithValue("@PersonID", personId);
            command.Parameters.AddWithValue("@PermissionCode", PersmissionCode);

            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    isInserted = true;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return isInserted;
        }

        // delete admin
        private static bool DeleteAdminRecord(int ID)
        {
            string query = @"DELETE FROM [dbo].[Admins]
                WHERE AdminID=@ID";
            return CrudHelper.DeleteHelper(ID, query);
        }

        public static bool DeleteAdmin(int ID)
        {
            int personId = GetPersonIdFromAdminID(ID);
            bool isRecordDeleted = DeleteAdminRecord(ID);
            bool isPersonDeleted = clsPerson.DeletePerson(personId);
            return isRecordDeleted && isPersonDeleted;
        }

        // update admin
        public static bool UpdateAdmin(int AdminID, string Name, string Phone, string Password, string Email, int Permissions)
        {
            int personId = GetPersonIdFromAdminID(AdminID);
            bool isPersonUpdated = clsPerson.UpdatePesron(personId, Name, Phone, Password, Email);

            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"UPDATE [dbo].[Admins]
                   SET [PersonID] = @PersonID
                      ,[PermissionCode] = @Permissions
                 WHERE AdminID=@AdminID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", personId);
            command.Parameters.AddWithValue("@Permissions", Permissions);
            command.Parameters.AddWithValue("@AdminID", AdminID);

            bool isRecordUpdated = CrudHelper.UpdateHelper(connection, command);

            return isPersonUpdated && isRecordUpdated;
        }

        // show all admins.
        public static DataTable GetAllAdmins()
        {
            string query = @"SELECT        Admins.AdminID, Admins.PersonID, Persons.Name, Persons.Phone, Persons.Password, Persons.email, Admins.PermissionCode
FROM            Admins INNER JOIN
                         Persons ON Admins.PersonID = Persons.PersonID";
            return CrudHelper.GetAllHelper(query);
        }

        // check permissions
        public static bool HasPermissionFor(int PersmissionCode, enPermissions Perm)
        {
            if (PersmissionCode == -1) return true;

            int result = (int)Perm & PersmissionCode;

            return result == (int)Perm;
        }

        public static int CreatePermissionCode(bool users, bool books, bool admins)
        {
            int code = 0;

            if (users) code += (int)enPermissions.users;
            if (admins) code += (int)enPermissions.admins;
            if (books) code += (int)enPermissions.books;

            return code;
        }
    }
}
