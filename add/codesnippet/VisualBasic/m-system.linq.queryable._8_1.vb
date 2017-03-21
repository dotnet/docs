        Dim grades() As Integer = {59, 82, 70, 56, 92, 98, 85}

        ' Sort the grades in descending order and take the first three.
        Dim topThreeGrades = _
            grades.AsQueryable().OrderByDescending(Function(grade) grade).Take(3)

        Dim output As New System.Text.StringBuilder
        output.AppendLine("The top three grades are:")
        For Each grade As Integer In topThreeGrades
            output.AppendLine(grade)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' The top three grades are:
        ' 98
        ' 92
        ' 85
