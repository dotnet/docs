using System;
using System.Data;
class DataTableReaderPrintCol
{
    [STAThread]
    static void Main()
    {
    }
    // <Snippet1>
    private static object GetValueByName(
        DataTableReader reader, string columnName)
    {
        // Consider when to use a procedure like this one carefully:
        // if you're going to retrieve information from a column
        // in a loop, it would be better to retrieve the column
        // ordinal once, store the value, and use the methods
        // of the DataTableReader class directly. 
        object columnValue;

        try
        {
            int columnOrdinal = reader.GetOrdinal(columnName);
            columnValue = reader.GetValue(columnOrdinal);
        }
        catch (ArgumentException ex)
        {
            // Throw all other errors back out to the caller.
            columnValue = null;
        }
        return columnValue;
    }

    // </Snippet1>
}

