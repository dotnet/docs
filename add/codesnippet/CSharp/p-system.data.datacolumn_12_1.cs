    private void AddColumn(DataTable table)
    {
        // Add a DataColumn to the collection and set its properties.
        // The constructor sets the ColumnName of the column.
        DataColumn column = table.Columns.Add("Total");
        column.DataType = System.Type.GetType("System.Decimal");
        column.ReadOnly = true;
        column.Expression = "UnitPrice * Quantity";
        column.Unique = false;
    }