using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "(local)";
        builder.IntegratedSecurity = true;
        builder.InitialCatalog = "AdventureWorks";

        // The connection does not allow multiple active result sets
        // by default, so this line of code explicitly
        // enables this feature. Note that this feature is 
        // only available when programming against SQL Server 2005
        // or later.
        builder.MultipleActiveResultSets = true;

        Console.WriteLine(builder.ConnectionString);
        Console.WriteLine();

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
}
// </Snippet1>

