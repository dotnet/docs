        ' To get the keys alone, use the Keys property.
        Dim ilistKeys As IList(Of String) = openWith.Keys
        
        ' The elements of the list are strongly typed with the
        ' type that was specified for the SortedList keys.
        Console.WriteLine()
        For Each s As String In ilistKeys 
            Console.WriteLine("Key = {0}", s)
        Next s

        ' The Keys property is an efficient way to retrieve
        ' keys by index.
        Console.WriteLine(vbLf & "Indexed retrieval using the " & _
            "Keys property: Keys(2) = {0}", openWith.Keys(2))