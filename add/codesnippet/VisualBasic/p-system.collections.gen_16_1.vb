        ' To get the values alone, use the Values property.
        Dim icoll As ICollection(Of String) = openWith.Values
        
        ' The elements of the ValueCollection are strongly typed
        ' with the type that was specified for dictionary values.
        Console.WriteLine()
        For Each s As String In  icoll
            Console.WriteLine("Value = {0}", s)
        Next s