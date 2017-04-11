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
            string connectString = "Data Source=(local);" +
                "Integrated Security=true";

            SqlConnectionStringBuilder builder = 
                new SqlConnectionStringBuilder(connectString);
            Console.WriteLine("Original: " + builder.ConnectionString);

            // Normally, you could simply set the InitialCatalog
            // property of the SqlConnectionStringBuilder object. This
            // example uses the default Item property (the C# indexer)
            // and the "Database" string, simply to demonstrate that
            // setting the value in this way results in the same
            // connection string:
            builder["Database"] = "AdventureWorks";
            Console.WriteLine("builder.InitialCatalog = " 
                + builder.InitialCatalog);
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

