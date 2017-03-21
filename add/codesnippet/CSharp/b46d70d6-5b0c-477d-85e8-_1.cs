    public void CreateDataTable() 
    {
        // ...
        // create dataSet and mapping
        // ...
        DataTable table = mapping.GetDataTableBySchemaAction
            (dataSet, MissingSchemaAction.Ignore);
    }