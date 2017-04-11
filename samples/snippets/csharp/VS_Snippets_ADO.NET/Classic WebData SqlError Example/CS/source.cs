using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

class Program
{
    static void Main()
    {
        string s = GetConnectionString();
        ShowSqlException(s);
        Console.ReadLine();
    }
    // <Snippet1>
    public static void ShowSqlException(string connectionString)
    {
        string queryString = "EXECUTE NonExistantStoredProcedure";
        
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                DisplaySqlErrors(ex);
            }
        }
    }

    private static void DisplaySqlErrors(SqlException exception)
    {
        for (int i = 0; i < exception.Errors.Count; i++)
        {
            Console.WriteLine("Index #" + i + "\n" +
                "Error: " + exception.Errors[i].ToString() + "\n");
        }
        Console.ReadLine();
    }
    // </Snippet1>


    static private string GetConnectionString()
    {
        // To avoid storing the connection string in your code, 
        // you can retrieve it from a configuration file.
        return "Data Source=(local);Initial Catalog=AdventureWorks;"
            + "Integrated Security=SSPI";
    }
}
