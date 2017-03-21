        // To get the values alone, use the Values property.
        ICollection<String^>^ icoll = openWith->Values;

        // The elements of the ValueCollection are strongly typed
        // with the type that was specified for dictionary values.
        Console::WriteLine();
        for each( String^ s in icoll )
        {
            Console::WriteLine("Value = {0}", s);
        }