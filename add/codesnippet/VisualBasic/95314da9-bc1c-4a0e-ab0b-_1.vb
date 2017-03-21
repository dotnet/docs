        Dim fruits() As String = _
            {"grape", "passionfruit", "banana", "mango", _
             "orange", "raspberry", "apple", "blueberry"}

        ' Sort the strings first by their length and then 
        ' alphabetically by passing the identity selector function.
        Dim query = fruits.AsQueryable() _
            .OrderBy(Function(fruit) fruit.Length).ThenBy(Function(fruit) fruit)

        ' Display the results.
        Dim output As New System.Text.StringBuilder
        For Each fruit As String In query
            output.AppendLine(fruit)
        Next
        MsgBox(output.ToString())

        'This code produces the following output:

        'apple
        'grape
        'mango
        'banana
        'orange
        'blueberry
        'raspberry
        'passionfruit
