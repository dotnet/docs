using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace NextResultCS
{
    class Program
    {
        static void Main()
        {
            string s = GetConnectionString();
            SqlConnection c = new SqlConnection(s);
            RetrieveMultipleResults(c);
            Console.ReadLine();
        }
        // <Snippet1>
        static void RetrieveMultipleResults(SqlConnection connection)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand(
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
        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file.
            return "Data Source=(local);Initial Catalog=Northwind;"
                + "Integrated Security=SSPI";
        }
    }
}
