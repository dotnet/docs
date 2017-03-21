            ' Create a list of integers.
            Dim ages As New List(Of Integer)(New Integer() _
                                         {21, 46, 46, 55, 17, 21, 55, 55})

            ' Select the unique numbers in the List.
            Dim distinctAges As IEnumerable(Of Integer) = ages.Distinct()

            Dim output As New System.Text.StringBuilder("Distinct ages:" & vbCrLf)
            For Each age As Integer In distinctAges
                output.AppendLine(age)
            Next

            ' Display the output.
            MsgBox(output.ToString)

            ' This code produces the following output:
            '
            ' Distinct ages:
            ' 21
            ' 46
            ' 55
            ' 17
