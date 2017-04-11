using System;
using System.Data;
// <Snippet1>
using System.Data.Odbc;
class Program
{
    static void Main()
    {
        OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();

        // Call the Add method to explicitly add key/value
        // pairs to the internal collection.
        builder.Driver = "Microsoft Excel Driver (*.xls)";
        builder["Dbq"] = "C:\\Data.xls";
        builder["DriverID"] = "790";
        builder["DefaultDir"] = "C:\\";

        // Dump the contents of the "filled-in" OdbcConnectionStringBuilder
        // to the Console window:
        DumpBuilderContents(builder);

        // Clear current values and reset known keys to their
        // default values.
        builder.Clear();

        // Dump the contents of the newly emptied OdbcConnectionStringBuilder
        // to the console window.
        DumpBuilderContents(builder);

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    private static void DumpBuilderContents(OdbcConnectionStringBuilder builder)
    {
        Console.WriteLine("=================");
        Console.WriteLine("builder.ConnectionString = " + builder.ConnectionString);
        foreach (string key in builder.Keys)
        {
            Console.WriteLine(key + "=" + builder[key].ToString());
        }
    }
}
// </Snippet1>

