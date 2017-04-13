using System;
using System.Data;
// <Snippet1>
using System.Data.Odbc;

class Program
{
    static void Main()
    {
        OdbcConnectionStringBuilder  builder = new OdbcConnectionStringBuilder();
        builder.Driver = "Microsoft Visual FoxPro Driver";
        builder["SourceType"] = "DBC";

        // Keys that you have provided return true.
        Console.WriteLine(builder.ContainsKey("SourceType"));

        // Comparison is case insensitive.
        Console.WriteLine(builder.ContainsKey("sourcetype"));

        // Keys added by the provider return false. This method
        // only examines keys added explicitly.
        Console.WriteLine(builder.ContainsKey("DNS"));

        // Keys that do not exist return false.
        Console.WriteLine(builder.ContainsKey("MyKey"));

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
}
// </Snippet1>

