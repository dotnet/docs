using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlConnection1CS
{
    class Program
    {
        static void Main()
        {
            string connectionString =
                "Persist Security Info=False;Integrated Security=SSPI;database=Northwind;server=(local)";
            CreateSqlConnection(connectionString);
            Console.ReadLine();
        }
        // <Snippet1>
        private static void CreateSqlConnection(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
                Console.WriteLine("State: {0}", connection.State );
            }
        }
        // </Snippet1>
    }
}
