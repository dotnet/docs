
using System;
using System.Data;
using System.Data.SqlClient;


class Program
{
    static void Main()
    {
        string str = "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=SSPI";
        ReadOrderData(str);
    }
    // <Snippet1>
    private static void ReadOrderData(string connectionString)
    {
        string queryString =
            "SELECT OrderID, CustomerID FROM dbo.Orders;";

        using (SqlConnection connection =
                   new SqlConnection(connectionString))
        {
            SqlCommand command =
                new SqlCommand(queryString, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}",
                    reader[0], reader[1]));
            }

            // Call Close when done reading.
            reader.Close();
        }
    }
    // </Snippet1>
}
