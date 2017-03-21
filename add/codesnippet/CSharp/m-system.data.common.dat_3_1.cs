    public void AddDataTableMapping() 
    {
        // ...
        // create mappings
        // ...
        DataTableMapping mapping =
            new DataTableMapping("Categories","DataCategories");
        mappings.Add((Object) mapping);
        Console.WriteLine("Table " + mapping.ToString() + " added to " +
            "table mapping collection " + mappings.ToString());
    }