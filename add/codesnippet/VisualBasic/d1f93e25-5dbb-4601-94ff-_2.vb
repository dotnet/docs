            ' Get the single item in the array whose length is > 15.
            Dim fruit2 As String =
            fruits.SingleOrDefault(Function(fruit) fruit.Length > 15)

            ' Display the result.
            Dim output As String =
            IIf(String.IsNullOrEmpty(fruit2), "No single item found", fruit2)
            MsgBox("Second array: " & output)

            ' This code produces the following output:
            '
            ' First array: passionfruit
            ' Second array: No single item found
