    public void FindDataTableMapping() 
    {
        // ...
        // create mappings and mapping
        // ...
        if (mappings.IndexOfDataSetTable("datacategories") != -1)
            mapping = mappings.GetByDataSetTable("datacategories");
    }