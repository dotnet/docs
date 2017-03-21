            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "passionfruit", "banana", "mango",
             "orange", "blueberry", "grape", "strawberry"}

            ' Take strings from the array until one
            ' of the string's lengths is greater than or
            ' equal to the string item's index in the array.
            Dim query As IEnumerable(Of String) =
            fruits.TakeWhile(Function(fruit, index) _
                                 fruit.Length >= index)

            ' Display the results.
            Dim output As New System.Text.StringBuilder
            For Each fruit As String In query
                output.AppendLine(fruit)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' apple
            ' passionfruit
            ' banana
            ' mango
            ' orange
            ' blueberry
