    private void CheckForErrors(DataSet dataSet) 
    {
        // Invoke GetChanges on the DataSet to create a reduced set.
        DataSet thisDataSet = dataSet.GetChanges();

        // Check each table's HasErrors property.
        foreach(DataTable table in thisDataSet.Tables) 
        {
            // If HasErrors is true, reconcile errors.
            if(table.HasErrors) 
            {
                // Insert code to reconcile errors.
            }
        }
    }