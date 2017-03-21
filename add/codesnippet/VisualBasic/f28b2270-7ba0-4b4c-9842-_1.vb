            ' Create an array of integers that represent grades.
            Dim grades() As Integer = {59, 82, 70, 56, 92, 98, 85}

            ' Sort the grades in descending order and
            ' get all grades greater less than 80.
            Dim lowerGrades As IEnumerable(Of Integer) =
            grades _
            .OrderByDescending(Function(grade) grade) _
            .SkipWhile(Function(grade) grade >= 80)

            ' Display the results.
            Dim output As New System.Text.StringBuilder("All grades below 80:" & vbCrLf)
            For Each grade As Integer In lowerGrades
                output.AppendLine(grade)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' All grades below 80:
            ' 70
            ' 59
            ' 56
