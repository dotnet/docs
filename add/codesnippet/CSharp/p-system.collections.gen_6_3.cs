        // The indexer throws an exception if the requested key is
        // not in the dictionary.
        try
        {
            Console.WriteLine("For key = \"tif\", value = {0}.", 
                openWith["tif"]);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("Key = \"tif\" is not found.");
        }