using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer
{
    static public class clsAuthor
    {

        static public bool InsertAuthor(string Name, string Phone, string Email, int Rate)
        {
            int personId = clsPerson.AddNewPerson(Name, Phone, "", Email);

            if (personId == -1) return false;

            string query = @"INSERT INTO [dbo].[Authors]
           ([PersonID]
           ,[Rate])
     VALUES
           (@PersonID
           ,@Rate)";

            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", personId);
            command.Parameters.AddWithValue("@Rate", Rate);

            return CrudHelper.UpdateHelper(connection, command); // may not work.
        }

        static public bool AddAuthorCombo(int BookID, int AuthorID)
        {
            string query = @"INSERT INTO [dbo].[AuthorCombos]
           ([BookID]
           ,[AuthorID])
     VALUES
           (@bookID
           ,@authorID)";

            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@bookID", BookID);
            command.Parameters.AddWithValue("@authorID", AuthorID);

            return CrudHelper.UpdateHelper(connection, command);
        }

        static private bool AuthorFinder(string query, object param, ref int personId, ref string phone, ref string name, ref int AuthorID,  ref string email, ref int rate)
        {
           
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            if (param is int)
            {
                command.Parameters.AddWithValue("@ID", (int)param);
            } else
            {
                command.Parameters.AddWithValue("@ID", (string)param);
            }

            bool isOk = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    AuthorID = (int)reader["AuthorID"];
                    name = (string)reader["Name"];
                    personId = (int)reader["PersonID"];
                    phone = (string)reader["Phone"];
                    email = (string)reader["email"];
                    rate = (int)reader["Rate"];
                    isOk = true;
                }
                else
                {
                    isOk = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isOk = false;
            }
            finally { connection.Close(); }

            return isOk;
        }

        static public bool FindAuthorByID(int authorID, ref int personId, ref string name, ref string phone, ref string email, ref int rate)
        {
            string query = @"SELECT        Authors.AuthorID, Persons.*, Authors.Rate
            FROM            Persons INNER JOIN
                                     Authors ON Persons.PersonID = Authors.PersonID
            WHERE AuthorID = @ID";

            return AuthorFinder(query, authorID, ref  personId, ref phone, ref name, ref authorID, ref email, ref rate);
        }

        static public bool FindAuthorByName(string authorName, ref int personId, ref int authorID, ref string phone, ref string email, ref int rate)
        {
            string query = @"SELECT        Authors.AuthorID, Persons.*, Authors.Rate
            FROM            Persons INNER JOIN
                                     Authors ON Persons.PersonID = Authors.PersonID
            WHERE Persons.Name = @ID";

            return AuthorFinder(query, authorName, ref personId, ref phone, ref authorName, ref authorID, ref email, ref rate);
        }

        static public List<string> GetAuthorsList()
        {
            string query = @"SELECT        Persons.Name
FROM            Authors INNER JOIN
                         Persons ON Authors.PersonID = Persons.PersonID";
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            List<string> authorsList = new List<string>();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    authorsList.Add(reader["Name"].ToString());
                }

                reader.Close();
            } catch (Exception ex) { 
                connection.Close();
            } finally
            {
                connection.Close();
            }

            return authorsList;
        } 
        
        static public DataTable GetAuthorsBookList(int ID) {
            string query = @"SELECT        AuthorCombos.BookID, Books.Title
            FROM            AuthorCombos INNER JOIN
                                     Books ON AuthorCombos.BookID = Books.BookID AND AuthorCombos.BookID = Books.BookID
            where AuthorCombos.AuthorID = @ID";
            /*SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            */

            return CrudHelper.GetAllHelper(query, ID);
        }

        static public DataTable GetAllAuthors()
        {
            string query = @"SELECT 
    Authors.AuthorID, 
    Authors.PersonID, 
    Persons.Name, 
    Persons.Phone, 
    Persons.email, 
    Authors.Rate, 
    COUNT(AuthorCombos.AuthorID) AS TotalBooks
FROM 
    Authors 
INNER JOIN
    Persons ON Authors.PersonID = Persons.PersonID
LEFT JOIN
    AuthorCombos ON Authors.AuthorID = AuthorCombos.AuthorID
GROUP BY 
    Authors.AuthorID, 
    Authors.PersonID, 
    Persons.Name, 
    Persons.Phone, 
    Persons.email, 
    Authors.Rate
";
            return CrudHelper.GetAllHelper(query);
        }

        static public bool DeleteAuthor(int AuthorID)
        {
            string query = @"
-- Step 1: Delete from AuthorCombos
DELETE FROM AuthorCombos
WHERE AuthorID = @ID;

-- Step 2: Delete books related to the author
DELETE FROM Books
WHERE BookID IN (
    SELECT BookID
    FROM AuthorCombos
    WHERE AuthorID = @ID
);

-- Step 3: Delete the author from Authors
DELETE FROM Authors
WHERE AuthorID = @ID;
";
            return CrudHelper.DeleteHelper(AuthorID, query);
        }

        static public bool UpdateAuthor(int ID, int personID, string name, string phone, string email, int rate)
        {
            bool isUpdated = clsPerson.UpdatePesron(personID, name, phone, "", email); // working
            
            if (!isUpdated) return false; // working

            // 👇 Not Working
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"UPDATE [dbo].[Authors]
           SET [PersonID] = @PersonID
              ,[Rate] = @Rate
         WHERE AuthorID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Rate", rate);
            command.Parameters.AddWithValue("@PersonID", personID);

            return CrudHelper.UpdateHelper(connection, command);
        }
    
        static public string GetLastAuthorName()
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"SELECT    top 1   Persons.Name
FROM            Authors INNER JOIN
                         Persons ON Authors.PersonID = Persons.PersonID
						 order by AuthorID desc";
            SqlCommand command = new SqlCommand(query, connection);
            string authorName = "";

            try
            {
                connection.Open();
                var result = command.ExecuteScalar();
                authorName = (string)result;
                
            } catch (Exception ex) { 
                
            } finally
            {
                connection.Close();
            }

            return authorName;
        }
    }   
}

