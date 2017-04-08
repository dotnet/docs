

using System;
using System.Data;
using System.Data.SqlClient;


namespace SqlCommandCS
{
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
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        // </Snippet1>
    }
}
