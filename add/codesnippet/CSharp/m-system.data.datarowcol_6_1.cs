    private void FindInMultiPKey(DataTable table)
    {
        // Create an array for the key values to find.
        object[]findTheseVals = new object[3];

        // Set the values of the keys to find.
        findTheseVals[0] = "John";
        findTheseVals[1] = "Smith";
        findTheseVals[2] = "5 Main St.";

        DataRow foundRow = table.Rows.Find(findTheseVals);
        // Display column 1 of the found row.
        if(foundRow != null)
            Console.WriteLine(foundRow[1]);
    }