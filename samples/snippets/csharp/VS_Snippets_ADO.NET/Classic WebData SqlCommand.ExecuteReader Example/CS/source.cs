

using System;
using System.Data;
using System.Data.SqlClient;



class Program
{
    static void Main()
    {
        string str = "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=SSPI";
        string qs = "SELECT OrderID, CustomerID FROM dbo.Orders;";
        CreateCommand(qs, str);
    }
    // <Snippet1>
    private static void CreateCommand(string queryString,
        string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand(queryString, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}", reader[0]));
            }
        }
    }
    // </Snippet1>
}

