    private void AddColumn(DataTable table)
    {
        // Create a new column and set its properties.
        DataColumn column = new DataColumn("column", 
            typeof(int), "", MappingType.Attribute);
        column.DataType = Type.GetType("System.String");
        column.ColumnMapping = MappingType.Element;

        // Add the column the table's columns collection.
        table.Columns.Add(column);
    }