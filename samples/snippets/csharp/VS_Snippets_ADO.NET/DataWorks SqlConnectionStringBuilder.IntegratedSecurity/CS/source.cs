using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        try
        {
            string connectString =
                "Data Source=(local);User ID=ab;Password=MyPassword;" +
                "Initial Catalog=AdventureWorks";

            SqlConnectionStringBuilder builder = 
                new SqlConnectionStringBuilder(connectString);
            Console.WriteLine("Original: " + builder.ConnectionString);

            // Use the Remove method
            // in order to reset the user ID and password back to their
            // default (empty string) values. Simply setting the 
            // associated property values to an empty string won't
            // remove them from the connection string; you must
            // call the Remove method.
            builder.Remove("User ID");
            builder.Remove("Password");

            // Turn on integrated security:
            builder.IntegratedSecurity = true;

            Console.WriteLine("Modified: " + builder.ConnectionString);

            using (SqlConnection connection = 
                       new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                // Now use the open connection.
                Console.WriteLine("Database = " + connection.Database);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Press any key to finish.");
        Console.ReadLine();
    }
}
// </Snippet1>

