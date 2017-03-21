    private void AddTable()
    {
        // Presuming a DataGrid is displaying more than one table, 
        // get its DataSet.
        DataSet thisDataSet = (DataSet)DataGrid1.DataSource;

        // Use the Add method to add a new table with a given name.
        DataTable table = thisDataSet.Tables.Add("NewTable");

        // Code to add columns and rows not shown here.

        Console.WriteLine(table.TableName);
        Console.WriteLine(thisDataSet.Tables.Count.ToString());
    }