    public void CreateDataTableMapping() 
    {
        // ...
        // create mappings
        // ...
        DataColumnMapping[] columns = {};
        // Copy mappings to array    
        mappings.CopyTo(columns, 0);
        DataTableMapping mapping =
            new DataTableMapping("Categories", "DataCategories", columns);    
    }