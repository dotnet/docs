        ' To get the values alone, use the Values property.
        Dim valueColl _
            As SortedDictionary(Of String, String).ValueCollection = _
            openWith.Values
        
        ' The elements of the ValueCollection are strongly typed
        ' with the type that was specified for dictionary values.
        Console.WriteLine()
        For Each s As String In valueColl 
            Console.WriteLine("Value = {0}", s)
        Next s