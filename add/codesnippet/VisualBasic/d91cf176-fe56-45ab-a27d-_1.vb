            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            ' Take strings from the array until one of
            ' the strings matches "orange".
            Dim query As IEnumerable(Of String) =
            fruits.TakeWhile(Function(fruit) _
                                 String.Compare("orange", fruit, True) <> 0)

            ' Display the results.
            Dim output As New System.Text.StringBuilder
            For Each fruit As String In query
                output.AppendLine(fruit)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' apple
            ' banana
            ' mango
