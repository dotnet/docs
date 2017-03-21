            ' Create an array of strings.
            Dim fruits() As String =
            {"grape", "passionfruit", "banana", "mango",
             "orange", "raspberry", "apple", "blueberry"}

            ' Sort the strings first by their length and then 
            ' alphabetically by passing the identity function.
            Dim query As IEnumerable(Of String) =
            fruits _
            .OrderBy(Function(fruit) fruit.Length) _
            .ThenBy(Function(fruit) fruit)

            ' Display the results.
            Dim output As New System.Text.StringBuilder
            For Each fruit As String In query
                output.AppendLine(fruit)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' apple
            ' grape
            ' mango
            ' banana
            ' orange
            ' blueberry
            ' raspberry
            ' passionfruit
