    private void UpdateDataTable(DataTable table, 
        OleDbDataAdapter myDataAdapter)
    {
        DataTable xDataTable = table.GetChanges();

        // Check the DataTable for errors.
        if (xDataTable.HasErrors)
        {
            // Insert code to resolve errors.
        }

        // After fixing errors, update the database with the DataAdapter 
        myDataAdapter.Update(xDataTable);
    }