        // To get the values alone, use the Values property.
        ICollection icoll = openWith.Values;

        // The elements of the collection are strongly typed
        // with the type that was specified for dictionary values,
        // even though the ICollection interface is not strongly
        // typed.
        Console.WriteLine();
        foreach( string s in icoll )
        {
            Console.WriteLine("Value = {0}", s);
        }