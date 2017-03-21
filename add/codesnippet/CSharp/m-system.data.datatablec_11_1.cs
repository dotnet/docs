    private void GetIndexes()
    {
        // Get the DataSet of a DataGrid.
        DataSet thisDataSet = (DataSet)DataGrid1.DataSource;

        // Get the DataTableCollection through the Tables property.
        DataTableCollection tables = thisDataSet.Tables;

        // Get the index of the table named "Authors", if it exists.
        if (tables.Contains("Authors"))
            System.Diagnostics.Debug.WriteLine(tables.IndexOf("Authors"));
    }