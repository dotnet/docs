        // When you use foreach to enumerate dictionary elements,
        // the elements are retrieved as KeyValuePair objects.
        Console::WriteLine();
        for each( KeyValuePair<String^, String^> kvp in openWith )
        {
            Console::WriteLine("Key = {0}, Value = {1}",
                kvp.Key, kvp.Value);
        }