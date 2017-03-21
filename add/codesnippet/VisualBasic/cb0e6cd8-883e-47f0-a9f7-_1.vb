        Dim fruits() As String = _
            {"apple", "passionfruit", "banana", "mango", _
             "orange", "blueberry", "grape", "strawberry"}

        ' Take strings from the array until a string whose length
        ' is less than its index in the array is found.
        Dim query = fruits.AsQueryable() _
            .TakeWhile(Function(fruit, index) fruit.Length >= index)

        ' Display the results.
        Dim output As New System.Text.StringBuilder
        For Each fruit As String In query
            output.AppendLine(fruit)
        Next
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' apple
        ' passionfruit
        ' banana
        ' mango
        ' orange
        ' blueberry
