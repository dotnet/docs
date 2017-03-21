        ' To get the keys alone, use the Keys property.
        icoll = openWith.Keys
        
        ' The elements of the ValueCollection are strongly typed
        ' with the type that was specified for dictionary values.
        Console.WriteLine()
        For Each s As String In  icoll
            Console.WriteLine("Key = {0}", s)
        Next s