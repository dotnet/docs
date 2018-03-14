using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        SqlConnectionStringBuilder builder = 
            new SqlConnectionStringBuilder(GetConnectionString());

        // Loop through each of the values, displaying the contents.
        foreach (object value in builder.Values)
            Console.WriteLine(value);

        Console.WriteLine("Press any key to continue.");
        Console.ReadLine();
    }

    private static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file. 
        return "Data Source=(local);Integrated Security=SSPI;" +
            "Initial Catalog=AdventureWorks; Asynchronous Processing=true";
    }
}
// </Snippet1>

