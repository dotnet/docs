        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This statement creates an empty expression.
        Dim emptyExpr As DefaultExpression = Expression.Empty()

        ' An empty expression can be used where an expression is expected but no action is desired.
        ' For example, you can use an empty expression as the last expression in a block expression.
        ' In this case, the block expression's return value is void.
        Dim emptyBlock = Expression.Block(emptyExpr)