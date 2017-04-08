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
            string connectString = "Server=(local);Initial Catalog=AdventureWorks;" + 
                "Integrated Security=true";
            SqlConnectionStringBuilder builder = 
                new SqlConnectionStringBuilder(connectString);
            Console.WriteLine("Original: " + builder.ConnectionString);
            Console.WriteLine("ApplicationName={0}",
                builder.ApplicationName);

            builder.ApplicationName = "My Application";
            Console.WriteLine("Modified: " + builder.ConnectionString);

            Console.WriteLine("Press any key to finish.");
            Console.ReadLine();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
// </Snippet1>

