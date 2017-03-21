
    private void ClearColumnsCollection(DataTable table)
    {
        DataColumnCollection columns;
        // Get the DataColumnCollection from a 
        // DataTable in a DataSet.
        columns = table.Columns;
        columns.Clear();
    }