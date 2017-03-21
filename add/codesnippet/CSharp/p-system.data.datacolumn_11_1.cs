    private void PrintColumnNamesByIndex(DataTable table)
    {
        // Get the DataColumnCollection from a DataTable in a DataSet.
        DataColumnCollection columns = table.Columns;

        // Print each column's name using the Index.
        for (int i = 0 ;i <columns.Count ;i++)
            Console.WriteLine(columns[i]);
    }