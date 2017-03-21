    public void RemoveDataTableMapping() 
    {
        // ...
        // create mappings
        // ...
        if (mappings.Contains("Categories"))
            mappings.RemoveAt("Categories");
    }