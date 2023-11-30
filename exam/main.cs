using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=myServerAddress;Database=myDataBase;UserId=myUsername;Password=myPassword;";
        string query = "drop table if exists MyTable";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                command.ExecuteNonQuery();
                Console.WriteLine("MyTable table successfully deleted");
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("SQL error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

