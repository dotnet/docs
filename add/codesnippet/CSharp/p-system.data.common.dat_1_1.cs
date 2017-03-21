    public void CreateTableMappings() 
    {
        DataTableMappingCollection mappings = 
            new DataTableMappingCollection();
        mappings.Add("Categories","DataCategories");
        mappings.Add("Orders","DataOrders");
        mappings.Add("Products","DataProducts");
        string message = "TableMappings:\n";
        for(int i=0;i < mappings.Count;i++)
        {
            message += i.ToString() + " " 
                + mappings[i].ToString() + "\n";
        }
        Console.WriteLine(message);
    }