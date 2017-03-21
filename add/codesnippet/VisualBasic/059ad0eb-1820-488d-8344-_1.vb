    Class CaseInsensitiveComparer
        Implements IComparer(Of String)

        Function Compare(ByVal x As String, ByVal y As String) As Integer _
            Implements IComparer(Of String).Compare

            ' Compare values and ignore case.
            Return String.Compare(x, y, True)
        End Function
    End Class

    Sub ThenByDescendingEx1()
        Dim fruits() As String = _
            {"apPLe", "baNanA", "apple", "APple", "orange", "BAnana", "ORANGE", "apPLE"}

        ' Sort the strings first ascending by their length and 
        ' then descending by using a custom case insensitive comparer.
        Dim query = fruits.AsQueryable() _
            .OrderBy(Function(fruit) fruit.Length) _
            .ThenByDescending(Function(fruit) fruit, New CaseInsensitiveComparer())

        Dim output As New System.Text.StringBuilder
        For Each fruit As String In query
            output.AppendLine(fruit)
        Next

        ' Display the results.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:

    ' apPLe
    ' apple
    ' APple
    ' apPLE
    ' orange
    ' ORANGE
    ' baNanA
    ' BAnana
