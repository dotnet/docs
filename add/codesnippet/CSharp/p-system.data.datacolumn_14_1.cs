    private void PrintDataType(DataTable table)
    {
        // Get the DataColumnCollection from a DataTable in a DataSet.
        DataColumnCollection columns = table.Columns;

        // Print the column's data type.
        Console.WriteLine(columns["id"].DataType);
    }