    private void PrintAllErrs(DataSet dataSet)
    {
        DataRow[] rowsInError; 
      
        foreach(DataTable table in dataSet.Tables)
        {
            // Test if the table has errors. If not, skip it.
            if(table.HasErrors)
            {
                // Get an array of all rows with errors.
                rowsInError = table.GetErrors();
                // Print the error of each column in each row.
                for(int i = 0; i < rowsInError.Length; i++)
                {
                    foreach(DataColumn column in table.Columns)
                    {
                        Console.WriteLine(column.ColumnName + " " + 
                            rowsInError[i].GetColumnError(column));
                    }
                    // Clear the row errors
                    rowsInError[i].ClearErrors();
                }
            }
        }
    }