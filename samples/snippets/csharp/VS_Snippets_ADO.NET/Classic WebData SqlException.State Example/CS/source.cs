// <Snippet1>
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

    public static void ShowSqlException(string connectionString)
    {
        string queryString = "EXECUTE NonExistantStoredProcedure";
        StringBuilder errorMessages = new StringBuilder();
        
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
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "Error Number: " + ex.Errors[i].Number + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
            }
        }
    }

    static private string GetConnectionString()
    {
        // To avoid storing the connection string in your code, 
        // you can retrieve it from a configuration file.
        return "Data Source=(local);Initial Catalog=AdventureWorks;"
            + "Integrated Security=SSPI";
    }
}
// </Snippet1>