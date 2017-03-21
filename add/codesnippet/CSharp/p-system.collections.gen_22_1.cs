        // To get the keys alone, use the Keys property.
        Dictionary<string, string>.KeyCollection keyColl =
            openWith.Keys;

        // The elements of the KeyCollection are strongly typed
        // with the type that was specified for dictionary keys.
        Console.WriteLine();
        foreach( string s in keyColl )
        {
            Console.WriteLine("Key = {0}", s);
        }