        // To get the keys alone, use the Keys property.
        Dictionary<String^, String^>::KeyCollection^ keyColl =
            openWith->Keys;

        // The elements of the KeyCollection are strongly typed
        // with the type that was specified for dictionary keys.
        Console::WriteLine();
        for each( String^ s in keyColl )
        {
            Console::WriteLine("Key = {0}", s);
        }