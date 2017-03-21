    public void ChangedMyMind() 
    {
        // ...
        // create mappings and mapping
        // ...
        if (mappings.Contains((Object) mapping))
            mappings.Remove((Object) mapping);
        else 
        {
            mappings.Add((Object) mapping);
            Console.WriteLine("Index of new mapping: " +
                mappings.IndexOf((Object) mapping));
        }
    }