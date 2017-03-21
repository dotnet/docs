    private void AddNullAllowedColumn()
    {
        DataColumn column;
        column = new DataColumn("classID", 
            System.Type.GetType("System.Int32"));
        column.AllowDBNull = true;

        // Add the column to a new DataTable.
        DataTable table;
        table = new DataTable();
        table.Columns.Add(column);
    }