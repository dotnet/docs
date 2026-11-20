// <SqlClient>
using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING")
            ?? throw new InvalidOperationException("Set the SQL_CONNECTION_STRING environment variable.");

        const string queryString =
            "SELECT ProductID, UnitPrice, ProductName FROM dbo.Products "
            + "WHERE UnitPrice > @pricePoint ORDER BY UnitPrice DESC;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(queryString, connection))
        {
            command.Parameters.Add("@pricePoint", SqlDbType.Money).Value = 5m;
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}\t{reader.GetDecimal(1)}\t{reader.GetString(2)}");
                }
            }
        }
    }
}
// </SqlClient>
