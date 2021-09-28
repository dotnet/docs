﻿using System;
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
            HasRows(c);
            Console.ReadLine();
        }
        // <Snippet1>
        static void HasRows(SqlConnection connection)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT CategoryID, CategoryName FROM Categories;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                            reader.GetString(1));
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
        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file.
            return "Data Source=(local);Initial Catalog=Northwind;"
                + "Integrated Security=SSPI";
        }
    }
}
