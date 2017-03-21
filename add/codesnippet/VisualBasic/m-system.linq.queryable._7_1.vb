        Dim grades() As Integer = {59, 82, 70, 56, 92, 98, 85}

        ' Sort the grades in descending order and
        ' get all except the first three.
        Dim lowerGrades = grades.AsQueryable() _
            .OrderByDescending(Function(g) g) _
            .Skip(3)

        Dim output As New System.Text.StringBuilder
        output.AppendLine("All grades except the top three are:")
        For Each grade As Integer In lowerGrades
            output.AppendLine(grade)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' All grades except the top three are:
        ' 82
        ' 70
        ' 59
        ' 56
