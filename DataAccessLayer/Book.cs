using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    static public class clsBook
    {
        static public DataTable GetAllBooks()
        {
            string query = @"SELECT 
                Books.BookID,
                Books.Title, 
                Books.Price, 
                Books.CountOfCopies, 
				Books.ImagePath,
                STRING_AGG(Persons.Name, ', ') AS Authors,
                AVG(Authors.Rate) AS AvgRate
                FROM 
                    Authors 
                INNER JOIN 
                    AuthorCombos ON Authors.AuthorID = AuthorCombos.AuthorID 
                INNER JOIN 
                    Books ON AuthorCombos.BookID = Books.BookID 
                INNER JOIN 
                    Persons ON Authors.PersonID = Persons.PersonID
                GROUP BY 
                    Books.ImagePath, Books.Title, Books.Price, Books.CountOfCopies, Books.BookID";
            return CrudHelper.GetAllHelper(query);
        }

        static public bool InsertBook(string Title, int Price, int CountOfCopies)
        {
            string query = @"INSERT INTO [dbo].[Books]
           ([Title]
           ,[Price]
           ,[CountOfCopies])
     VALUES
           (@title
           ,@price
           ,@copies)";

            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@title", Title);
            command.Parameters.AddWithValue("@price", Price);
            command.Parameters.AddWithValue("@copies", CountOfCopies);

            return CrudHelper.UpdateHelper(connection, command); // maybe doesn't work
        }

        static public bool FindBookByID(int BookID, ref string Title,  ref int Price, ref int CountOfCopies,  ref string authors, ref int AvgRate)
        {
            string query = @"SELECT 
                Books.BookID,
                Books.Title, 
                Books.Price, 
                Books.CountOfCopies, 
                STRING_AGG(Persons.Name, ', ') AS Authors,
                AVG(Authors.Rate) AS AvgRate
            FROM 
                Authors 
            INNER JOIN 
                AuthorCombos ON Authors.AuthorID = AuthorCombos.AuthorID 
            INNER JOIN 
                Books ON AuthorCombos.BookID = Books.BookID 
            INNER JOIN 
                Persons ON Authors.PersonID = Persons.PersonID
            WHERE
                Books.BookID = @BookID
            GROUP BY 
                Books.BookID,
                Books.Title, 
                Books.Price, 
                Books.CountOfCopies;";

            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", BookID);

            bool isFound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    isFound = true;
                    Title = (string)reader["Title"];
                    Price = (int)reader["Price"];
                    CountOfCopies = (int)reader["CountOfCopies"];
                    authors = (string)reader["Authors"];
                    AvgRate = (int)reader["AvgRate"];
                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            } catch (Exception ex)
            {
                isFound = false;
            } finally
            {
                connection.Close();
            }

            return isFound;
        }

        static public bool UpdateBook(int BookID, string Title, int Price, int CountOfCopies)
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            string query = @"UPDATE [dbo].[Books]
               SET [Title] = @Title
                  ,[Price] = @Price
                  ,[CountOfCopies] = @Copies
             WHERE BookID = @ID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Copies", CountOfCopies);
            command.Parameters.AddWithValue("@ID", BookID);

            return CrudHelper.UpdateHelper(connection, command);
        }

        static public bool ClearBookCombos(int BookID)
        {
            string query = @"DELETE FROM [dbo].[AuthorCombos]
                    WHERE BookID = @ID";
            return CrudHelper.DeleteHelper(BookID, query);
        }

        static public int GetLastBookID()
        {
            string query = @"select top 1 BookID from Books
                order by BookID desc";
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            int id = 0;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                id = (int)result;

            } catch (Exception ex)
            {

            } finally
            {
                connection.Close();
            }

            return id;
        }

        static public bool DeleteBook(int BookID) {
            string query = @"DELETE FROM [dbo].[Books]
      WHERE BookID = @ID";

            ClearBookCombos (BookID);
            return CrudHelper.DeleteHelper(BookID, query);
        }
    }
}
