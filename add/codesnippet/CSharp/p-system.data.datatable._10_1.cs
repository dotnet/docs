    private DataSet GetDataSetFromTable()
    {
        DataTable table;
 
        // Check to see if the DataGrid's DataSource
        // is a DataTable.
        if( dataGrid1.DataSource is DataTable)
        {
            table = (DataTable) dataGrid1.DataSource;
            // Return the DataTable's DataSet
            return table.DataSet;
        }
        else
        {
            return null;
        }
    }