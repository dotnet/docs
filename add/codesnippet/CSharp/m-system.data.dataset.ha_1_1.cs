    private void UpdateDataSet(DataSet dataSet)
    {
        // Check for changes with the HasChanges method first.
        if(!dataSet.HasChanges(DataRowState.Modified)) return;

        // Create temporary DataSet variable and
        // GetChanges for modified rows only.
        DataSet tempDataSet = 
            dataSet.GetChanges(DataRowState.Modified);

        // Check the DataSet for errors.
        if(tempDataSet.HasErrors)
        {
            // Insert code to resolve errors.
        }
        // After fixing errors, update the data source with  
        // the DataAdapter used to create the DataSet.
        adapter.Update(tempDataSet);
    }