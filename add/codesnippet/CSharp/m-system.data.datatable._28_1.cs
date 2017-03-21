    private void PrintToString(DataSet dataSet)
    {
        foreach(DataTable table in dataSet.Tables)
        {
            Console.WriteLine(table.ToString());
        }
    }