            ' Create an array of integers.
            Dim amounts() As Integer =
            {5000, 2500, 9000, 8000, 6500, 4000, 1500, 5500}

            ' Skip items in the array whose value is greater than
            ' the item's index times 1000; get the remaining items.
            Dim query As IEnumerable(Of Integer) =
            amounts.SkipWhile(Function(amount, index) _
                                  amount > index * 1000)

            ' Output the results.
            Dim output As New System.Text.StringBuilder
            For Each amount As Integer In query
                output.AppendLine(amount)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' 4000
            ' 1500
            ' 5500
