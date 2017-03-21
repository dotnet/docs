        ' To get the keys alone, use the Keys property.
        icoll = openWith.Keys
        
        ' The elements of the collection are strongly typed
        ' with the type that was specified for dictionary keys,
        ' even though the ICollection interface is not strongly
        ' typed.
        Console.WriteLine()
        For Each s As String In  icoll
            Console.WriteLine("Key = {0}", s)
        Next s