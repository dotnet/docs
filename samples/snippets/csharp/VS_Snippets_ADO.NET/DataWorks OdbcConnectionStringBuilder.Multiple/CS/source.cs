using System;
using System.Data;
// <Snippet1>
using System.Data.Odbc;

class Program
{
    static void Main()
    {
        try
        {
            // Build an empty instance, just to see
            // the contents of the keys.
            DumpBuilderContents("");

            // Create a SQL Server connection string.
            DumpBuilderContents("Driver={SQL Server};Server=(local);Database=AdventureWorks;Uid=ab;Pwd=pass@word1");

            // Create an Access connection string.
            DumpBuilderContents(@"Driver={Microsoft Access Driver (*.mdb)};Dbq=C:\info.mdb;Exclusive=1;Uid=admin;Pwd=pass@word1");

            // Create an Oracle connection string.
            DumpBuilderContents("Driver={Microsoft ODBC for Oracle};Server=OracleServer.world;Uid=Admin;Pwd=pass@word1;");

            // Create a Sybase connection string.
            DumpBuilderContents("Driver={SYBASE ASE ODBC Driver};Srvr=SomeServer;Uid=admin;Pwd=pass@word1");

            Console.WriteLine("Press any key to finish.");
            Console.ReadLine();

        }
        catch (System.ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static void DumpBuilderContents(string connectString)
    {
        OdbcConnectionStringBuilder builder =
            new OdbcConnectionStringBuilder(connectString);
        Console.WriteLine("=================");
        Console.WriteLine("Original connectString   = " + connectString);
        Console.WriteLine("builder.ConnectionString = " + builder.ConnectionString);
        foreach (string key in builder.Keys)
        {
            Console.WriteLine(key + "=" + builder[key].ToString());
        }
    }
}
// </Snippet1>

