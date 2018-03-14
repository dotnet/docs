using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(
            "Network Address=(local);Integrated Security=SSPI;" +
            "Initial Catalog=AdventureWorks");

        // Display the connection string, which should now 
        // contain the "Data Source" key, as opposed to the 
        // supplied "Network Address".
        Console.WriteLine(builder.ConnectionString);

        // Retrieve the DataSource property.
        Console.WriteLine("DataSource = " + builder.DataSource);

        Console.WriteLine("Press any key to continue.");
        Console.ReadLine();
    }
}
// </Snippet1>

