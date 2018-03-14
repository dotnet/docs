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
                "Server=(local);" +
                "Integrated Security=true";
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(connectString);
            Console.WriteLine("Original: " + builder.ConnectionString);
            Console.WriteLine("AttachDBFileName={0}", builder.AttachDBFilename);

            builder.AttachDBFilename = @"C:\MyDatabase.mdf";
            Console.WriteLine("Modified: " + builder.ConnectionString);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                // Now use the open connection.
                Console.WriteLine("Database = " + connection.Database);
            }
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

