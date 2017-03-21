    private void AddTables()
    {
        // Presuming a DataGrid is displaying more than one table, 
        // get its DataSet.
        DataSet thisDataSet = (DataSet)DataGrid1.DataSource;

        for (int i = 0; i < 3; i++)
            thisDataSet.Tables.Add();
        Console.WriteLine(thisDataSet.Tables.Count.ToString() 
            + " tables");
        foreach (DataTable table in thisDataSet.Tables)
            Console.WriteLine(table.TableName);
    }