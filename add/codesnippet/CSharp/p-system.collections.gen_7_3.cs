        // When a program often has to try keys that turn out not to
        // be in the dictionary, TryGetValue can be a more efficient 
        // way to retrieve values.
        string value = "";
        if (openWith.TryGetValue("tif", out value))
        {
            Console.WriteLine("For key = \"tif\", value = {0}.", value);
        }
        else
        {
            Console.WriteLine("Key = \"tif\" is not found.");
        }