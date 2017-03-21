    private void AddAutoIncrementColumn()
    {
        DataColumn column = new DataColumn();
        column.DataType = System.Type.GetType("System.Int32");
        column.AutoIncrement = true;
        column.AutoIncrementSeed = 1000;
        column.AutoIncrementStep = 10;

        // Add the column to a new DataTable.
        DataTable table = new DataTable("table");
        table.Columns.Add(column);
    }