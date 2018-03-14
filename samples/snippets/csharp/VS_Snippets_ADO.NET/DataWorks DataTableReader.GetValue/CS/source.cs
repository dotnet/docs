using System;
using System.Data;
class DataTableReaderPrintCol
{
    [STAThread]
    static void Main()
    {
    }
    // <Snippet1>
    private static void GetAllValues(DataTableReader reader)
    {
        // Given a DataTableReader, retrieve the value of 
        // each column, and display the name, value, and type.
        // Make sure you have called reader.Read at least once before
        // calling this procedure.

        // Loop through all the columns.
        object value = null;
        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (reader.IsDBNull(i))
            {
                value = "<NULL>";
            }
            else
            {
                value = reader.GetValue(i);
            }
            Console.WriteLine("{0}: {1} ({2})", reader.GetName(i), 
                value, reader.GetFieldType(i).Name);
        }
    }
    // </Snippet1>
}

