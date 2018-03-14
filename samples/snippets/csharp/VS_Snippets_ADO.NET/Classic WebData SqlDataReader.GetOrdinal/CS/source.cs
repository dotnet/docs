
using System;
using System.Data;
using System.Data.SqlClient;


class Program
{
    static void Main()
    {
        string str = "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=SSPI";
        ReadGetOrdinal(str);
    }

    // <Snippet1>
    private static void ReadGetOrdinal(string connectionString)
    {
        string queryString = "SELECT DISTINCT CustomerID FROM dbo.Orders;";
        using (SqlConnection connection =
                   new SqlConnection(connectionString))
        {
            SqlCommand command =
                new SqlCommand(queryString, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            // Call GetOrdinal and assign value to variable.
            int customerID = reader.GetOrdinal("CustomerID");

            // Use variable with GetString inside of loop.
            while (reader.Read())
            {
                Console.WriteLine("CustomerID={0}", reader.GetString(customerID));
            }

            // Call Close when done reading.
            reader.Close();
        }
    }
    // </Snippet1>

}
