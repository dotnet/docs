    private void ClearTables()
    {
        // Get the DataSet of a DataGrid control.
        DataSet dataSet = (DataSet)DataGrid1.DataSource;
        DataTableCollection tables = dataSet.Tables;

        // Clear the collection.
        tables.Clear();
    }