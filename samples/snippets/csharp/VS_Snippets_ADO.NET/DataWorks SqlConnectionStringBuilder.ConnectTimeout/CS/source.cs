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
                "Server=(local);Initial Catalog=AdventureWorks;" +
                "Integrated Security=true";
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(connectString);
            Console.WriteLine("Original: " + builder.ConnectionString);
            Console.WriteLine("ConnectTimeout={0}",
                builder.ConnectTimeout);
            builder.ConnectTimeout = 100;
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

