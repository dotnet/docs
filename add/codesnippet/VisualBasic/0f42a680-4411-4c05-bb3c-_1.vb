        Dim numbers() As Integer = {0, 30, 20, 15, 90, 85, 40, 75}

        ' Get all the numbers that are less than or equal to
        ' the product of their index in the array and 10.
        Dim query = numbers.AsQueryable() _
            .Where(Function(number, index) number <= index * 10)

        ' Display the results.
        Dim output As New System.Text.StringBuilder
        For Each number As Integer In query
            output.AppendLine(number)
        Next
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' 0
        ' 20
        ' 15
        ' 40
