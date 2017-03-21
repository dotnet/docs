        // When you use foreach to enumerate dictionary elements
        // with the IDictionary interface, the elements are retrieved
        // as DictionaryEntry objects instead of KeyValuePair objects.
        Console.WriteLine();
        foreach( DictionaryEntry de in openWith )
        {
            Console.WriteLine("Key = {0}, Value = {1}", 
                de.Key, de.Value);
        }