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

        // Loop through the collection of keys, displaying 
        // the key and value for each item.
        foreach (string key in builder.Keys)
            Console.WriteLine("{0}={1}", key, builder[key]);

        Console.WriteLine();
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
}
// </Snippet1>

