            ' Create an array that contains two items.
            Dim fruits2() As String = {"orange", "apple"}

            result = String.Empty

            ' Try to get the 'single' item in the array.
            Try
                result = fruits2.Single()
            Catch ex As System.InvalidOperationException
                result = "The collection does not contain exactly one element."
            End Try

            ' Display the result.
            MsgBox("Second query: " & result)

            ' This code produces the following output:
            '
            ' First query: orange
            ' Second query: The collection does not contain exactly one element.
