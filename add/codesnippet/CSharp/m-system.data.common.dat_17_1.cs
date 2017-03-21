    public void FindDataTableMapping() 
    {
        // ...
        // create mappings
        // ...
        if (!mappings.Contains("Categories"))
            Console.WriteLine("Error: no such table in collection");
        else
            Console.WriteLine
                ("Name: " + mappings["Categories"].ToString() + "\n"
                + "Index: " + mappings.IndexOf("Categories").ToString());
    }