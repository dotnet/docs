    private void ProcessDeletes(DataTable table, 
        OleDbDataAdapter adapter)
    {
        DataTable changeTable = table.GetChanges(DataRowState.Deleted);

        // Check the DataTable for errors.
        if (changeTable.HasErrors)
        {
            // Insert code to resolve errors.
        }

        // After fixing errors, update the database with the DataAdapter 
        adapter.Update(changeTable);
    }