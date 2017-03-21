        ' To get the values alone, use the Values property.
        Dim icoll As ICollection = openWith.Values
        
        ' The elements of the collection are strongly typed
        ' with the type that was specified for dictionary values,
        ' even though the ICollection interface is not strongly
        ' typed.
        Console.WriteLine()
        For Each s As String In  icoll
            Console.WriteLine("Value = {0}", s)
        Next s