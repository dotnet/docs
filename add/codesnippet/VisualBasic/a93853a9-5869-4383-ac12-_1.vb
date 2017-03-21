        Dim grades() As Integer = {59, 82, 70, 56, 92, 98, 85}

        ' Get all grades less than 80 by first  sorting the grades 
        ' in descending order and then taking all the grades that 
        ' occur after the first grade that is less than 80.
        Dim lowerGrades = grades.AsQueryable() _
            .OrderByDescending(Function(grade) grade) _
            .SkipWhile(Function(grade) grade >= 80)

        Dim output As New System.Text.StringBuilder
        output.AppendLine("All grades below 80:")
        For Each grade As Integer In lowerGrades
            output.AppendLine(grade)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' All grades below 80:
        ' 70
        ' 59
        ' 56
