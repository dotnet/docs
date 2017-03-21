    private void FindInPrimaryKeyColumn(DataTable table, 
        long pkValue)
    {
        // Find the number pkValue in the primary key 
        // column of the table.
        DataRow foundRow = table.Rows.Find(pkValue);

        // Print the value of column 1 of the found row.
        if(foundRow != null)
            Console.WriteLine(foundRow[1]);
    }