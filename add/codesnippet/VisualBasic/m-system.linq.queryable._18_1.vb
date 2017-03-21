
        ' Create a list of objects.
        Dim words As New List(Of Object)(New Object() {"green", "blue", "violet"})

        ' Cast the objects in the list to type 'string'
        ' and project the first letter of each string.
        Dim query As IEnumerable(Of String) = _
            words.AsQueryable() _
                    .Cast(Of String)() _
                    .Select(Function(str) str.Substring(0, 1))

        For Each s As String In query
            MsgBox(s)
        Next

        ' This code produces the following output:
        '
        ' g
        ' b
        ' v
