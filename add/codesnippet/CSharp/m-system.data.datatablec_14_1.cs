    private void TestForTableName()
    {
        // Get the DataSet of a DataGrid.
        DataSet thisDataSet = (DataSet)DataGrid1.DataSource;

        // Get the DataTableCollection through the Tables property.
        DataTableCollection tablesCol = thisDataSet.Tables;

        // Check if the named table exists.
        if (tablesCol.Contains("Suppliers")) 
            Console.WriteLine("Table named Suppliers exists");
    }