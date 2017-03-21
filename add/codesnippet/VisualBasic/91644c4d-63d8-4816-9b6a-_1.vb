        Dim fruits() As String = _
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

        ' Get the single string in the array whose length is greater
        ' than 10, or else the default value for type string (null).
        Dim fruit1 As String = _
            fruits.AsQueryable().SingleOrDefault(Function(fruit) fruit.Length > 10)
        ' Display the result.
        MsgBox("First Query: " & fruit1)

        ' Get the single string in the array whose length is greater
        ' than 15, or else the default value for type string (null).
        Dim fruit2 As String = _
            fruits.AsQueryable().SingleOrDefault(Function(fruit) fruit.Length > 15)
        MsgBox("Second Query: " & _
            IIf(String.IsNullOrEmpty(fruit2), "No such string!", fruit2))

        ' This code produces the following output:

        ' First Query: passionfruit
        ' Second Query: No such string!
