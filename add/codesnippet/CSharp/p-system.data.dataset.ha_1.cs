    private void CheckForErrors()
    {
        if(!DataSet1.HasErrors)
        {
            DataSet1.Merge(DataSet2);
        }
        else
        {
            PrintRowErrs(DataSet1);
        }
    }
 
    private void PrintRowErrs(DataSet dataSet)
    {
        foreach(DataTable table in dataSet.Tables)
        {
            foreach(DataRow row in table.Rows)
            {
                if(row.HasErrors)
                {
                    Console.WriteLine(row.RowError);
                }
            }
        }
    }