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
                    Console.WriteLine($"{reader.GetInt32(0)}\t{reader.GetString(1)}");
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
        throw new NotImplementedException();
}
