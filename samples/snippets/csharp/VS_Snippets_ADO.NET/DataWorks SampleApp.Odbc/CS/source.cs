
// <Snippet1>
using System;
using System.Data.Odbc;

static class Program
{
    static void Main()
    {
        const string connectionString =
            "Driver={Microsoft Access Driver (*.mdb)};...";

        // Provide the query string with a parameter placeholder.
        const string queryString =
            "SELECT ProductID, UnitPrice, ProductName from products "
                + "WHERE UnitPrice > ? "
                + "ORDER BY UnitPrice DESC;";

        // Specify the parameter value.
        const int paramValue = 5;

        // Create and open the connection in a using block. This
        // ensures that all resources will be closed and disposed
        // when the code exits.
        using (OdbcConnection connection =
            new(connectionString))
        {
            // Create the Command and Parameter objects.
            OdbcCommand command = new(queryString, connection);
            command.Parameters.AddWithValue("@pricePoint", paramValue);

            // Open the connection in a try/catch block.
            // Create and execute the DataReader, writing the result
            // set to the console window.
            try
            {
                connection.Open();
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"\t{reader[0]}\t{reader[1]}\t{reader[2]}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
// </Snippet1>
