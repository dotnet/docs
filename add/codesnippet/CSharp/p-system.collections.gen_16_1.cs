        // To get the values alone, use the Values property.
        ICollection<string> icoll = openWith.Values;

        // The elements of the ValueCollection are strongly typed
        // with the type that was specified for dictionary values.
        Console.WriteLine();
        foreach( string s in icoll )
        {
            Console.WriteLine("Value = {0}", s);
        }