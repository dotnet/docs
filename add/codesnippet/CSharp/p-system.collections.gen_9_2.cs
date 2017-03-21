        // To get the keys alone, use the Keys property.
        IList<string> ilistKeys = openWith.Keys;

        // The elements of the list are strongly typed with the 
        // type that was specified for the SortedList keys.
        Console.WriteLine();
        foreach( string s in ilistKeys )
        {
            Console.WriteLine("Key = {0}", s);
        }

        // The Keys property is an efficient way to retrieve
        // keys by index.
        Console.WriteLine("\nIndexed retrieval using the Keys " +
            "property: Keys[2] = {0}", openWith.Keys[2]);