        // Use the Remove method to remove a key/value pair. No
        // exception is thrown if the wrong data type is supplied.
        Console.WriteLine("\nRemove(\"dib\")");
        openWith.Remove("dib");

        if (!openWith.Contains("dib"))
        {
            Console.WriteLine("Key \"dib\" is not found.");
        }