using System;
using System.Data.SqlClient;

namespace NextResultCS;

static class Program
{
    static void Main()
    {
        var s = GetConnectionString();
        SqlConnection c = new(s);
        HasRows(c);
        Console.ReadLine();
    }
    // <Snippet1>
    static void HasRows(SqlConnection connection)
    {
        using (connection)
        {
            SqlCommand command = new(
              "SELECT CategoryID, CategoryName FROM Categories;",
              connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                        reader.GetString(1));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
        }
    }
    // </Snippet1>
    static string GetConnectionString() =>
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file.
        "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=SSPI";
}
