using System;
using System.Data;
// <Snippet1>
// You may need to set a reference to the System.Data.OracleClient
// assembly before running this example.
using System.Data.OracleClient;

class Program
{
    static void Main()
    {
        OracleConnectionStringBuilder builder =
            new OracleConnectionStringBuilder();
        builder.DataSource = "OracleSample";
        builder.IntegratedSecurity = true;
        Console.WriteLine("Initial connection string: " +
            builder.ConnectionString);

        Console.WriteLine("Before call to Clear, count = " + builder.Count);
        builder.Clear();
        Console.WriteLine("After call to Clear, count = " + builder.Count);
        Console.WriteLine("Cleared connection string: " +
            builder.ConnectionString);
        Console.WriteLine();

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
}
// </Snippet1>

