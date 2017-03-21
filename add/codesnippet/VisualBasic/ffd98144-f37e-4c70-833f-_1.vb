            ' Create an array of Integer values that represent grades.
            Dim grades() As Integer = {59, 82, 70, 56, 92, 98, 85}

            ' Get the highest three grades by first sorting
            ' them in descending order and then taking the
            ' first three values.
            Dim topThreeGrades As IEnumerable(Of Integer) =
            grades _
            .OrderByDescending(Function(grade) grade) _
            .Take(3)

            ' Display the results.
            Dim output As New System.Text.StringBuilder("The top three grades are:" & vbCrLf)
            For Each grade As Integer In topThreeGrades
                output.AppendLine(grade)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' The top three grades are:
            ' 98
            ' 92
            ' 85
