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
                Console.WriteLine("\t{0}\t{1}", reader.GetName(0),
                    reader.GetName(1));

                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}", reader.GetInt32(0),
                        reader.GetString(1));
                }
                reader.NextResult();
            }
        }
    }
    // </Snippet1>
    static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file.
        return "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=SSPI";
    }
}
