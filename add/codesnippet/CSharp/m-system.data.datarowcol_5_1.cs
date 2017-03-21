    private void AddRow(DataTable table)
    {
        // Create an array with three elements.
        object[] rowVals = new object[3];
        DataRowCollection rowCollection = table.Rows;
        rowVals[0] = "hello";
        rowVals[1] = "world";
        rowVals[2] = "two";

        // Add and return the new row.
        DataRow row = rowCollection.Add(rowVals);
    }