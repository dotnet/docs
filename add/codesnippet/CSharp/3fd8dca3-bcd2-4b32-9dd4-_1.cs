    public void FindDataTableMapping() 
    {
        // ...
        // create mappings and mapping
        // ...
        if (mappings.Contains("Categories")) 
        {
            mapping = DataTableMappingCollection.GetTableMappingBySchemaAction
                (mappings, "Categories", "", MissingMappingAction.Ignore);
        }
    }