using System;
using System.Data;
using System.Data.SqlClient;

static class Program
{
    static void Main()
    {
        // Supply any valid Document ID value.
        // The value 7 is supplied for demonstration purposes.
        GetSalesByCategory("Data Source=(local);Initial Catalog=Northwind;Integrated Security=true;", "Confections");
        Console.ReadLine();
    }
    // <Snippet1>
    static void GetSalesByCategory(string connectionString,
        string categoryName)
    {
        using (SqlConnection connection = new(connectionString))
        {
            // Create the command and set its properties.
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SalesByCategory",
                CommandType = CommandType.StoredProcedure
            };

            // Add the input parameter and set its properties.
            SqlParameter parameter = new()
            {
                ParameterName = "@CategoryName",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = categoryName
            };

            // Add the parameter to the Parameters collection.
            command.Parameters.Add(parameter);

            // Open the connection and execute the reader.
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
        }
    }
    // </Snippet1>
}
