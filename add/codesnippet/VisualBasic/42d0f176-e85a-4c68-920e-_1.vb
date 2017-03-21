        Dim fruits() As String = {"apple", "banana", "mango", "orange", _
                              "passionfruit", "grape"}

        ' Take strings from the array until a string
        ' that is equal to "orange" is found.
        Dim query = fruits.AsQueryable() _
            .TakeWhile(Function(fruit) String.Compare("orange", fruit, True) <> 0)

        Dim output As New System.Text.StringBuilder
        For Each fruit As String In query
            output.AppendLine(fruit)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        'This code produces the following output:

        'apple
        'banana
        'mango
