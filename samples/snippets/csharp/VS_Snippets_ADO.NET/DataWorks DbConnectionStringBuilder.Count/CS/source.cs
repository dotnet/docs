using System;
using System.Data;
using System.Data.Common;


class Program
{
    // <Snippet1>
    static void Main()
    {
        DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
        builder.ConnectionString =
            "Data Source=(local);Initial Catalog=AdventureWorks;" +
            "Integrated Security=SSPI";

        // This should display "3" in the console window.
        Console.WriteLine("Original count: " + builder.Count);

        builder.Add("Connection Timeout", 25);

        // This should display the new connection string and
        // the number of items (4) in the console window.
        Console.WriteLine(builder.ConnectionString);
        Console.WriteLine("New count: " + builder.Count);

        Console.WriteLine();
        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();
    }
    // </Snippet1>

}
