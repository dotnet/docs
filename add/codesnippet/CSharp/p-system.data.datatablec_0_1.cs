    private void GetTableByName()
    {
        // Presuming a DataGrid is displaying more than one table, get its DataSet.
        DataSet thisDataSet = (DataSet)DataGrid1.DataSource;

        // Get the DataTableCollection.
        DataTableCollection tablesCollection = thisDataSet.Tables;

        // Get a specific table by name.
        DataTable table = tablesCollection["Suppliers"];
        Console.WriteLine(table.TableName);
    }