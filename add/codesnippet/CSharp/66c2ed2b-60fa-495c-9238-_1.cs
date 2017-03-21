    public void FindDataColumnMapping() 
    {
        // ...
        // create mappings and mapping
        // ...
        if (mappings.Contains("Description"))
            mapping = DataColumnMappingCollection.GetColumnMappingBySchemaAction
                (mappings, "Description", MissingMappingAction.Ignore);
    }