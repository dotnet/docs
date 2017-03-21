        Dim fruits As New List(Of String)(New String() _
                                {"apple", "passionfruit", "banana", "mango", _
                                 "orange", "blueberry", "grape", "strawberry"})

        ' Get all strings whose length is less than 6.
        Dim query = fruits.AsQueryable().Where(Function(fruit) fruit.Length < 6)

        ' Display the results.
        Dim output As New System.Text.StringBuilder
        For Each fruit As String In query
            output.AppendLine(fruit)
        Next
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' apple
        ' mango
        ' grape
