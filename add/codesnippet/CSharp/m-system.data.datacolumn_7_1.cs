    private void TestAndRemove(DataColumn colToRemove)
    {
        DataColumnCollection columns; 
        // Get the DataColumnCollection from a DataTable in a DataSet.
        columns = DataSet1.Tables["Orders"].Columns;
 
        if(columns.Contains(colToRemove.ColumnName))
        {
            columns.Remove(colToRemove);
        }
    }