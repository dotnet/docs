        ' To get the keys alone, use the Keys property.
        Dim keyColl As _
            Dictionary(Of String, String).KeyCollection = _
            openWith.Keys
        
        ' The elements of the KeyCollection are strongly typed
        ' with the type that was specified for dictionary keys.
        Console.WriteLine()
        For Each s As String In  keyColl
            Console.WriteLine("Key = {0}", s)
        Next s