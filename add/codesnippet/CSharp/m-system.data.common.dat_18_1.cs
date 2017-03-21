
    public void RemoveDataColumnMapping() 
    {
        // ...
        // create columnMappings
        // ...
        if (columnMappings.Contains("Picture"))
            columnMappings.RemoveAt("Picture");
    }