    private void GetTableNames(DataSet dataSet)
    {
        // Print each table's TableName.
        foreach(DataTable table in dataSet.Tables)
        {
            Console.WriteLine(table.TableName);
        }
    }