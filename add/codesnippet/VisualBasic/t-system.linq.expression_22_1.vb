        Dim tree As String = "maple"

        Dim addMethod As System.Reflection.MethodInfo = _
            Type.GetType("System.Collections.Generic.Dictionary`2[System.Int32, System.String]").GetMethod("Add")

        ' Create an ElementInit that represents calling
        ' Dictionary(Of Integer, String).Add(tree.Length, tree).
        Dim elementInit As System.Linq.Expressions.ElementInit = _
            System.Linq.Expressions.Expression.ElementInit( _
                addMethod, _
                System.Linq.Expressions.Expression.Constant(tree.Length), _
                System.Linq.Expressions.Expression.Constant(tree))

        Console.WriteLine(elementInit.ToString())

        ' This code produces the following output:
        '
        ' Void Add(Int32, System.String)(5,"maple")