    public void AddDataTableMapping() 
    {
        // ...
        // create tableMappings
        // ...
        DataTableMapping mapping =
            new DataTableMapping("Categories","DataCategories");
        tableMappings.Add((Object) mapping);
        Console.WriteLine("Table {0} added to {1} table mapping collection.",
            mapping.ToString(), tableMappings.ToString());
    }