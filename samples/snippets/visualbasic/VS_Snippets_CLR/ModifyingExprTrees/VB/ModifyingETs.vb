Imports System.Linq.Expressions

Module ModifyingExprTrees
    Sub Main()
        ' <Snippet3>
        Dim expr As Expression(Of Func(Of String, Boolean)) = _
            Function(name) name.Length > 10 AndAlso name.StartsWith("G")

        Console.WriteLine(expr)

        Dim modifier As New AndAlsoModifier()
        Dim modifiedExpr = modifier.Modify(CType(expr, Expression))

        Console.WriteLine(modifiedExpr)

        ' This code produces the following output:
        ' name => ((name.Length > 10) && name.StartsWith("G"))
        ' name => ((name.Length > 10) || name.StartsWith("G"))

        ' </Snippet3>

        Console.ReadLine()
    End Sub
End Module
