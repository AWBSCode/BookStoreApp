using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer
{
    static internal class CrudHelper
    {
        static public bool DeleteHelper(int ID, string query)
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
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

        static public DataTable GetAllHelper(string query, int ID=-1)
        {
            SqlConnection connection = new SqlConnection(setupConnection.ConnectionString);
            
            SqlCommand command = new SqlCommand(query, connection);

            if (ID != -1)
            {
                command.Parameters.AddWithValue("@ID", ID);
            }

            DataTable data = new DataTable();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    data.Load(reader);
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

            return data;
        }

        static public bool UpdateHelper(SqlConnection connection, SqlCommand command)
        {
            
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
    }
}
