    private void GetRows()
    {
        // Get the DataTable of a DataSet.
        DataTable table = DataSet1.Tables["Suppliers"];
        DataRow[] rows = table.Select();

        // Print the value one column of each DataRow.
        for(int i = 0; i < rows.Length ; i++)
        {
            Console.WriteLine(rows[i]["CompanyName"]);
        }
    }