    public void FindDataColumnMapping() 
    {
        // ...
        // create columnMappings
        // ...
        if (!columnMappings.Contains("Description"))
            Console.WriteLine("Error: no such table in collection.");
        else
        {
            Console.WriteLine("Name {0}", 
                columnMappings["Description"].ToString());
            Console.WriteLine("Index: {0}", 
                columnMappings.IndexOf("Description").ToString());
        }
    }