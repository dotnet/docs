using System;
using System.Data;
// <Snippet1>
// You may need to set a reference to the System.Data.OracleClient
// assembly before you can run this sample.
using System.Data.OracleClient;

class Program
{
    static void Main()
    {
        OracleConnectionStringBuilder builder = 
            new OracleConnectionStringBuilder();
        builder["Data Source"] = "localhost";
        builder["integrated security"] = true;
        builder["Unicode"] = true;

        // Overwrite the existing value for the Data Source value.
        builder["Data Source"] = "NewOracleDemo";

        Console.WriteLine(builder.ConnectionString);
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
}
// </Snippet1>

