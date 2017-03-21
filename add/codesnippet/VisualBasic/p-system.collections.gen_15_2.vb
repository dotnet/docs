        ' To get the values alone, use the Values property.
        Dim ilistValues As IList(Of String) = openWith.Values
        
        ' The elements of the list are strongly typed with the
        ' type that was specified for the SortedList values.
        Console.WriteLine()
        For Each s As String In ilistValues
            Console.WriteLine("Value = {0}", s)
        Next s

        ' The Values property is an efficient way to retrieve
        ' values by index.
        Console.WriteLine(vbLf & "Indexed retrieval using the " & _
            "Values property: Values(2) = {0}", openWith.Values(2))