        Dim tree1 As String = "maple"
        Dim tree2 As String = "oak"

        Dim addMethod As System.Reflection.MethodInfo = _
            Type.GetType("System.Collections.Generic.Dictionary`2[System.Int32, System.String]").GetMethod("Add")

        ' Create two ElementInit objects that represent the
        ' two key-value pairs to add to the Dictionary.
        Dim elementInit1 As System.Linq.Expressions.ElementInit = _
            System.Linq.Expressions.Expression.ElementInit( _
                addMethod, _
                System.Linq.Expressions.Expression.Constant(tree1.Length), _
                System.Linq.Expressions.Expression.Constant(tree1))
        Dim elementInit2 As System.Linq.Expressions.ElementInit = _
            System.Linq.Expressions.Expression.ElementInit( _
                addMethod, _
                System.Linq.Expressions.Expression.Constant(tree2.Length), _
                System.Linq.Expressions.Expression.Constant(tree2))

        ' Create a NewExpression that represents constructing
        ' a new instance of Dictionary(Of Integer, String).
        Dim newDictionaryExpression As System.Linq.Expressions.NewExpression = _
            System.Linq.Expressions.Expression.[New](Type.GetType("System.Collections.Generic.Dictionary`2[System.Int32, System.String]"))

        ' Create a ListInitExpression that represents initializing
        ' a new Dictionary(Of T) instance with two key-value pairs.
        Dim listInitExpression As System.Linq.Expressions.ListInitExpression = _
            System.Linq.Expressions.Expression.ListInit( _
                newDictionaryExpression, _
                elementInit1, _
                elementInit2)

        Console.WriteLine(listInitExpression.ToString())

        ' This code produces the following output:
        '
        ' new Dictionary`2() {Void Add(Int32, System.String)(5,"maple"),
        ' Void Add(Int32, System.String)(3,"oak")