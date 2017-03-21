        Dim ages As List(Of Integer) = New List(Of Integer)(New Integer() {21, 46, 46, 55, 17, 21, 55, 55})

        Dim distinctAges As IEnumerable(Of Integer) = ages.AsQueryable().Distinct()

        Dim output As New System.Text.StringBuilder
        output.AppendLine("Distinct ages:")

        For Each age As Integer In distinctAges
            output.AppendLine(age)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:
        '
        ' Distinct(ages)
        ' 21
        ' 46
        ' 55
        ' 17
