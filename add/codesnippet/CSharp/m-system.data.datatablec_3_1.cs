    private void GetIndexes()
    {
        // Get the DataSet of a DataGrid.
        DataSet thisDataSet = (DataSet)DataGrid1.DataSource;

        // Get the DataTableCollection through the Tables property.
        DataTableCollection tables = thisDataSet.Tables;

        // Get the index of each table in the collection.
        foreach (DataTable table in tables)
            System.Diagnostics.Debug.WriteLine(tables.IndexOf(table));
    }