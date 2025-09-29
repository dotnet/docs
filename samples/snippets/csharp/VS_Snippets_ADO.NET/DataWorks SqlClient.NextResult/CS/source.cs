using System;
using System.Data.SqlClient;

namespace NextResultCS;

static class Program
{
    static void Main()
    {
        var s = GetConnectionString();
        SqlConnection c = new(s);
        RetrieveMultipleResults(c);
        Console.ReadLine();
    }
    // <Snippet1>
    static void RetrieveMultipleResults(SqlConnection connection)
    {
        using (connection)
        {
            SqlCommand command = new(
              "SELECT CategoryID, CategoryName FROM dbo.Categories;" +
              "SELECT EmployeeID, LastName FROM dbo.Employees",
              connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.HasRows)
            {
                Console.WriteLine($"\t{reader.GetName(0)}\t{reader.GetName(1)}");

                while (reader.Read())
                {
                    Console.WriteLine($"\t{reader.GetInt32(0)}\t{reader.GetString(1)}");
                }
                reader.NextResult();
            }
        }
    }
    // </Snippet1>
    static string GetConnectionString() =>
        throw new NotImplementedException();
}
