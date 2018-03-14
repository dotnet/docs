using System;
using System.Data;
// <Snippet1>
using System.Data.Odbc;

class Program
{
    static void Main()
    {
        OdbcConnectionStringBuilder builder = 
            new OdbcConnectionStringBuilder();
        builder.Driver = "Microsoft Access Driver (*.mdb)";

        // Call the Add method to explicitly add key/value
        // pairs to the internal collection.
        builder.Add("Dbq", "C:\\info.mdb");
        builder.Add("Uid", "Admin");
        builder.Add("Pwd", "pass!word1");

        Console.WriteLine(builder.ConnectionString);
        Console.WriteLine();

        // Clear current values and reset known keys to their
        // default values.
        builder.Clear();

        // Pass the OdbcConnectionStringBuilder an existing 
        // connection string, and you can retrieve and
        // modify any of the elements.
        builder.ConnectionString =
            "driver={IBM DB2 ODBC DRIVER};Database=SampleDB;" +
            "hostname=SampleServerName;port=SamplePortNum;" +
            "protocol=TCPIP;uid=Admin;pwd=pass!word1";

        Console.WriteLine("protocol = " 
            + builder["protocol"].ToString());
        Console.WriteLine();

        // Modify existing items.
        builder["uid"] = "NewUser";
        builder["pwd"] = "Pass@word2";

        // Call the Remove method to remove items from 
        // the collection of key/value pairs.
        builder.Remove("port");

        // Note that calling Remove on a nonexistent item does not
        // throw an exception.
        builder.Remove("BadItem");
        Console.WriteLine(builder.ConnectionString);
        Console.WriteLine();

        // Setting the indexer adds the associated value, if 
        // necessary.
        builder["NewKey"] = "newValue";
        Console.WriteLine(builder.ConnectionString);

        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();
    }
}
// </Snippet1>

