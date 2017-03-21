        Dim amounts() As Integer = {5000, 2500, 9000, 8000, _
                            6500, 4000, 1500, 5500}

        ' Skip over amounts in the array until the first amount
        ' that is less than or equal to the product of its
        ' index in the array and 1000. Take the remaining items.
        Dim query = amounts.AsQueryable() _
            .SkipWhile(Function(amount, index) amount > index * 1000)

        Dim output As New System.Text.StringBuilder
        For Each amount As Integer In query
            output.AppendLine(amount)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' 4000
        ' 1500
        ' 5500
