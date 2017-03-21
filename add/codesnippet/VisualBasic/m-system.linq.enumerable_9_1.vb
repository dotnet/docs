            ' Generate a sequence of integers from 1 to 10 
            ' and project their squares.
            Dim squares As IEnumerable(Of Integer) =
            Enumerable.Range(1, 10).Select(Function(x) x * x)

            Dim output As New System.Text.StringBuilder
            For Each num As Integer In squares
                output.AppendLine(num)
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
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
