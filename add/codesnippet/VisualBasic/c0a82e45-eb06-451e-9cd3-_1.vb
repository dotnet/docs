            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            ' Get the number of items in the array.
            Dim count As Long = fruits.LongCount()

            ' Display the result.
            MsgBox("There are " & count & " fruits in the collection.")

            ' This code produces the following output:
            '
            ' There are 6 fruits in the collection.
