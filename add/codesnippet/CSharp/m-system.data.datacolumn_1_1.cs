    private void PrintColumns(DataTable table)
    {
        // Print the default string of each column in a collection.
        foreach(DataColumn column in table.Columns)
        {
            Console.WriteLine(column.ToString());
        }
    }