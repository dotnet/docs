    private void RemoveTables()
    {
        // Set the name of the table to test for and remove.
        string name = "Suppliers";

        // Presuming a DataGrid is displaying more than one table, get its DataSet.
        DataSet thisDataSet = (DataSet)DataGrid1.DataSource;
        DataTableCollection tablesCol = thisDataSet.Tables;
        if (tablesCol.Contains(name) && tablesCol.CanRemove(tablesCol[name])) 
            tablesCol.Remove(name);
    }