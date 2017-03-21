        // Contains can be used to test keys before inserting 
        // them.
        if (!openWith.Contains("ht"))
        {
            openWith.Add("ht", "hypertrm.exe");
            Console.WriteLine("Value added for key = \"ht\": {0}", 
                openWith["ht"]);
        }

        // IDictionary.Contains returns false if the wrong data
        // type is supplied.
        Console.WriteLine("openWith.Contains(29.7) returns {0}",
            openWith.Contains(29.7));