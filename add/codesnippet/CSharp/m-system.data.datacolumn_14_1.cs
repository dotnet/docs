    private void GetIndex(DataTable table)
    {
        DataColumnCollection columns = table.Columns;
        if(columns.Contains("City")) 
        {
            Console.WriteLine(columns.IndexOf("City"));
        }
    }