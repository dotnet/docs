        ' Create an array of strings to sort.
        Dim fruits() As String = {"apricot", "orange", "banana", "mango", "apple", "grape", "strawberry"}
        ' First sort the strings by their length.
        Dim sortedFruits2 As IOrderedEnumerable(Of String) = _
            fruits.OrderBy(Function(ByVal fruit) fruit.Length)
        ' Secondarily sort the strings alphabetically, using the default comparer.
        Dim sortedFruits3 As IOrderedEnumerable(Of String) = _
            sortedFruits2.CreateOrderedEnumerable(Of String)( _
                Function(ByVal fruit) fruit, _
                System.Collections.Generic.Comparer(Of String).Default, _
                False)

        Dim output As New System.Text.StringBuilder
        ' Output the resulting sequence of strings.
        For Each fruit As String In sortedFruits3
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
