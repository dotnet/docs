    private void PrintValues(DataTable table)
    {
        foreach(DataRow row in table.Rows)
        {
            foreach(DataColumn column in table.Columns)
            {
                Console.WriteLine(row[column]);
            }
        }
    }