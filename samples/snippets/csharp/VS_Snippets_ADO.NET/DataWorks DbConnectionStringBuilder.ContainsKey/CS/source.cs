using System;
using System.Data;
using System.Data.Common;

class Program
{
    // <Snippet1>
    static void Main()
    {
        DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
        builder.Add("Provider", "Provider=Microsoft.Jet.OLEDB.4.0");
        builder.Add("Data Source", "C:\\ThisExcelWorkbook.xls");
        builder.Add("Extended Properties", "Excel 8.0;HDR=Yes;IMEX=1");

        // Displays the values in the DbConnectionStringBuilder.
        Console.WriteLine("Contents of the DbConnectionStringBuilder:");
        Console.WriteLine(builder.ConnectionString);

        // Searches for a key.
        if (builder.ContainsKey("Data Source"))
        {
            Console.WriteLine("The collection contains the key \"Data Source\".");
        }
        else
        {
            Console.WriteLine("The collection does not contain the key \"Data Source\".");
        }
        Console.ReadLine();
    }
    // </Snippet1>
}
