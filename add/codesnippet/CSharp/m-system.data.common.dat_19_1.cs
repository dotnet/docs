    public void PushIntoArray() 
    {
        // ...
        // create DataTableMappingCollection collection mappings
        // ...
        DataTableMapping[] tables = {};
        mappings.CopyTo(tables, 0);
        mappings.Clear();
    }