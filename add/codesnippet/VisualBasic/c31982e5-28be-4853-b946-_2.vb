            ' Create an empty List.
            Dim numbers As New List(Of Integer)()

            Dim output As New System.Text.StringBuilder
            ' Iterate through the items in the List, calling DefaultIfEmpty().
            For Each number As Integer In numbers.DefaultIfEmpty()
                output.AppendLine(number)
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' 0
