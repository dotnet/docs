using System;
using System.Data;
using System.Data.Common;

static class Program
{
    static void Main()
    {
        DataTable dt = GetProviderFactoryClasses();
        Console.ReadLine();
    }
    // <Snippet1>
    // This example assumes a reference to System.Data.Common.
    static DataTable GetProviderFactoryClasses()
    {
        // Retrieve the installed providers and factories.
        DataTable table = DbProviderFactories.GetFactoryClasses();

        // Display each row and column value.
        foreach (DataRow row in table.Rows)
        {
            foreach (DataColumn column in table.Columns)
            {
                Console.WriteLine(row[column]);
            }
        }
        return table;
    }
    // </Snippet1>
}
