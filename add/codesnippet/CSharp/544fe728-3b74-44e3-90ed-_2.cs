        // The Item property is another name for the indexer, so you 
        // can omit its name when accessing elements. 
        Console.WriteLine("For key = \"rtf\", value = {0}.", 
            openWith["rtf"]);

        // The indexer can be used to change the value associated
        // with a key.
        openWith["rtf"] = "winword.exe";
        Console.WriteLine("For key = \"rtf\", value = {0}.", 
            openWith["rtf"]);

        // If a key does not exist, setting the indexer for that key
        // adds a new key/value pair.
        openWith["doc"] = "winword.exe";

        // The indexer returns null if the key is of the wrong data 
        // type.
        Console.WriteLine("The indexer returns null" 
            + " if the key is of the wrong type:");
        Console.WriteLine("For key = 2, value = {0}.", 
            openWith[2]);

        // The indexer throws an exception when setting a value
        // if the key is of the wrong data type.
        try
        {
            openWith[2] = "This does not get added.";
        }
        catch (ArgumentException)
        {
            Console.WriteLine("A key of the wrong type was specified" 
                + " when assigning to the indexer.");
        }