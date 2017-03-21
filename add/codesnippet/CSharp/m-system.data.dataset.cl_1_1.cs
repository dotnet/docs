    private void ClearDataSet(DataSet dataSet)
    {
        // To test, print the number rows in each table.
        foreach(DataTable table in dataSet.Tables)
        {
            Console.WriteLine(table.TableName + "Rows.Count = " 
                + table.Rows.Count.ToString());
        }
        // Clear all rows of each table.
        dataSet.Clear();

        // Print the number of rows again.
        foreach(DataTable table in dataSet.Tables)
        {
            Console.WriteLine(table.TableName + "Rows.Count = "  
                + table.Rows.Count.ToString());
        }
    }