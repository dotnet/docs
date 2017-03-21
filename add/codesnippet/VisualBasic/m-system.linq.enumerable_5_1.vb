            ' Create an array of strings.
            Dim fruits() As String = {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            Try
                ' Count the number of items in the array.
                Dim numberOfFruits As Integer = fruits.Count()
                ' Display the output.
                MsgBox("There are " & numberOfFruits & " fruits in the collection.")
            Catch e As OverflowException
                MsgBox("The count is too large to store as an Int32. Try using LongCount() instead.")
            End Try

            ' This code produces the following output:
            '
            ' There are 6 fruits in the collection.
