        // To get the values alone, use the Values property.
        IList<string> ilistValues = openWith.Values;

        // The elements of the list are strongly typed with the 
        // type that was specified for the SorteList values.
        Console.WriteLine();
        foreach( string s in ilistValues )
        {
            Console.WriteLine("Value = {0}", s);
        }

        // The Values property is an efficient way to retrieve
        // values by index.
        Console.WriteLine("\nIndexed retrieval using the Values " +
            "property: Values[2] = {0}", openWith.Values[2]);