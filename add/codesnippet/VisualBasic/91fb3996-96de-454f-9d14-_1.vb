            ' Create an array of integers.
            Dim numbers() As Integer = {0, 30, 20, 15, 90, 85, 40, 75}

            ' Restrict the results to those numbers whose
            ' values are less than or equal to their index times 10.
            Dim query As IEnumerable(Of Integer) =
            numbers.Where(Function(number, index) number <= index * 10)

            ' Display the results.
            Dim output As New System.Text.StringBuilder
            For Each number As Integer In query
                output.AppendLine(number)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' 0
            ' 20
            ' 15
            ' 40
