    private void GetTable(DataColumn column)
    {
        // Get the Table of the column.
        DataTable table = column.Table;
        Console.WriteLine("columns count: " + table.Columns.Count);
        Console.WriteLine("rows count: " + table.Rows.Count);
    }