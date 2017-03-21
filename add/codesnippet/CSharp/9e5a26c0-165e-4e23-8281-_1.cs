    public void CreateDataTableMapping() 
    {
        // ...
        // create mappings
        // ...
    
        DataColumnMapping[] columns1 = {};
        mappings.CopyTo(columns1, 0);
        DataTableMapping mapping =
            new DataTableMapping("Categories", "DataCategories", columns1);
    
        DataColumnMapping[] columns2 = {};
        mapping.ColumnMappings.CopyTo(columns2, 0);
    }