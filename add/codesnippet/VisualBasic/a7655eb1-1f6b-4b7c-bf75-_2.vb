            result = String.Empty

            ' Try to get the single item in the array whose length is > 15.
            Try
                result = fruits.Single(Function(fruit) _
                                       fruit.Length > 15)
            Catch ex As System.InvalidOperationException
                result = "There is not EXACTLY ONE element whose length is > 15."
            End Try

            ' Display the result.
            MsgBox("Second query: " & result)

            ' This code produces the following output:
            '
            ' First query: passionfruit
            ' Second query: There is not EXACTLY ONE element whose length is > 15.
