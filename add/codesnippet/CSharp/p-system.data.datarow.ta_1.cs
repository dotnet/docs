    private void GetTable(DataRow row)
    {
        // Get the DataTable of a DataRow
        DataTable table = row.Table;

        // Print the DataType of each column in the table.
        foreach(DataColumn column in table.Columns)
        {
            Console.WriteLine(column.DataType);
        }
    }