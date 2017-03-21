    private void PrintRows(DataTable table)
    {
        // Print the CompanyName column for every row using the index.
        for(int i = 0; i < table.Rows.Count; i++)
        {
            Console.WriteLine(table.Rows[i]["CompanyName"]);
        }
    }