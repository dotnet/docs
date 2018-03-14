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
        // Set up a connection string for a text file.
        builder["Driver"] = "Microsoft Text Driver (*.txt; *.csv)";
        builder["dbq"] = "C:\\TextFilesFolder";
        builder["Extension"] = "asc,csv,tab,txt";

        // Overwrite the existing value for the dbq value, 
        // because it already exists within the collection.
        builder["dbq"] = "D:\\";

        Console.WriteLine(builder.ConnectionString);
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
}
// </Snippet1>

