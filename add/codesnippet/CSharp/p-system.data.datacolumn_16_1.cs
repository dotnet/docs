    private void PrintColumnDetails(DataColumn column)
    {
        // Print the Ordinal, ColumnName, and 
        // DataType of the column.
        Console.WriteLine(column.Ordinal);
        Console.WriteLine(column.ColumnName);
        Console.WriteLine(column.DataType);
    }