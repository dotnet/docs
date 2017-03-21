            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            ' Get the single item in the array whose length is > 10.
            Dim fruit1 As String =
            fruits.SingleOrDefault(Function(fruit) fruit.Length > 10)

            ' Display the result.
            MsgBox("First array: " & fruit1)