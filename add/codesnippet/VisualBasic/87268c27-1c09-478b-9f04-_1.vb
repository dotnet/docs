        Dim fruits() As String = _
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

        ' Get the only string in the array whose length is greater than 10.
        Dim result As String = _
            fruits.AsQueryable().Single(Function(fruit) fruit.Length > 10)

        ' Display the result.
        MsgBox("First Query: " & result)

        Try
            ' Try to get the only string in the array
            ' whose length is greater than 15.
            Dim fruit2 As String = fruits.AsQueryable().Single(Function(fruit) fruit.Length > 15)
            MsgBox("Second Query: " + fruit2)
        Catch
            Dim text As String = "Second Query: The collection does not contain "
            text = text & "exactly one element whose length is greater than 15."
            MsgBox(text)
        End Try

        ' This code produces the following output:

        ' First Query: passionfruit
        ' Second Query: The collection does not contain exactly one 
        '   element whose length is greater than 15.
