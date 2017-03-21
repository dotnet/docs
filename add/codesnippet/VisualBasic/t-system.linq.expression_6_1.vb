        ' Create a NewExpression that represents constructing
        ' a new instance of Dictionary(Of Integer, String).
        Dim newDictionaryExpression As System.Linq.Expressions.NewExpression = _
            System.Linq.Expressions.Expression.[New]( _
                Type.GetType("System.Collections.Generic.Dictionary`2[System.Int32, System.String]"))

        Console.WriteLine(newDictionaryExpression.ToString())

        ' This code produces the following output:
        '
        ' new Dictionary`2()