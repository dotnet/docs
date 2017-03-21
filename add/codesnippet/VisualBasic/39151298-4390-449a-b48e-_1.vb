        Dim range As New List(Of Integer)(New Integer() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10})

        ' Project the square of each int value.
        Dim squares As IEnumerable(Of Integer) = _
            range.AsQueryable().Select(Function(x) x * x)

        Dim output As New System.Text.StringBuilder
        For Each num As Integer In squares
            output.AppendLine(num)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' 1
        ' 4
        ' 9
        ' 16
        ' 25
        ' 36
        ' 49
        ' 64
        ' 81
        ' 100
