    private void GetRowsByFilter()
    {
        DataTable table = DataSet1.Tables["Orders"];
        // Presuming the DataTable has a column named Date.
        string expression;
        expression = "Date > #1/1/00#";
        DataRow[] foundRows;

        // Use the Select method to find all rows matching the filter.
        foundRows = table.Select(expression);

        // Print column 0 of each returned row.
        for(int i = 0; i < foundRows.Length; i ++)
        {
            Console.WriteLine(foundRows[i][0]);
        }
    }