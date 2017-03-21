            ' Create an array of integers that represent grades.
            Dim grades() As Integer = {59, 82, 70, 56, 92, 98, 85}

            ' Sort the numbers in descending order and
            ' get all but the first (largest) three numbers.
            Dim lowerGrades As IEnumerable(Of Integer) =
            grades _
            .OrderByDescending(Function(g) g) _
            .Skip(3)

            ' Display the results.
            Dim output As New System.Text.StringBuilder("All grades except the top three are:" & vbCrLf)
            For Each grade As Integer In lowerGrades
                output.AppendLine(grade)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' All grades except the top three are:
            ' 82
            ' 70
            ' 59
            ' 56
