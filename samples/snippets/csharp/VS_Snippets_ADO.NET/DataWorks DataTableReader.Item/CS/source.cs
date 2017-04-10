using System;
using System.Data;
class DataTableReaderPrintCol
{
    [STAThread]
    static void Main()
    {
    }
    // <Snippet1>
    private static void DisplayItems(DataTableReader reader)
    {
        int rowNumber = 0;
        while (reader.Read())
        {
            Console.WriteLine("Row " + rowNumber);
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);
            }
            rowNumber++;
        }
    }
    // </Snippet1>
}

