            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            ' Get the single item in the array whose length is greater than 10.
            Dim result As String =
            fruits.Single(Function(fruit) fruit.Length > 10)

            ' Display the result.
            MsgBox("First query: " & result)