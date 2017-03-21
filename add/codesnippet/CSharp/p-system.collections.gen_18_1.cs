        // To get the keys alone, use the Keys property.
        icoll = openWith.Keys;

        // The elements of the ValueCollection are strongly typed
        // with the type that was specified for dictionary values.
        Console.WriteLine();
        foreach( string s in icoll )
        {
            Console.WriteLine("Key = {0}", s);
        }