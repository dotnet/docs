        ' Create an array of strings to sort.
        Dim fruits() As String = _
            {"apricot", "orange", "banana", "mango", "apple", "grape", "strawberry"}

        ' Sort the strings first by their length and then alphabetically by passing the identity selector function.
        Dim sortedFruits1 As IOrderedEnumerable(Of String) = _
            fruits.OrderBy(Function(ByVal fruit) fruit.Length).ThenBy(Function(ByVal fruit) fruit)

        Dim output As New System.Text.StringBuilder
        ' Output the resulting sequence of strings.
        For Each fruit As String In sortedFruits1
            output.AppendLine(fruit)
        Next

        ' Display the results.
        MsgBox(output.ToString())

        ' This code produces the following output:
        '
        ' apple
        ' grape
        ' mango
        ' banana
        ' orange
        ' apricot
        ' strawberry
