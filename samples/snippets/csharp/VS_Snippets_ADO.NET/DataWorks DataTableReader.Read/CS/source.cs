using System;
using System.Data;
class DataTableReaderPrintCol
{
    [STAThread]
    static void Main()
    {
    }
    // <Snippet1>
    private static void PrintColumns(DataTableReader reader)
    {
        // Loop through all the rows in the DataTableReader
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write("{0} ", reader[i]);
            }
            Console.WriteLine();
        }
    }
    // </Snippet1>
}

