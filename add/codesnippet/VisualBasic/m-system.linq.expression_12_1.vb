        ' Add the following directive to the file:
        ' Imports System.Linq.Expressions 

        ' Creating a parameter for the expression tree.
        Dim param As ParameterExpression = Expression.Parameter(GetType(Integer))

        ' Creating an expression for the method call and specifying its parameter.
        Dim methodCall As MethodCallExpression = Expression.Call(
                GetType(Console).GetMethod("WriteLine", New Type() {GetType(Integer)}),
                param
            )

        ' Compiling and invoking the methodCall expression.
        Expression.Lambda(Of Action(Of Integer))(
            methodCall,
            New ParameterExpression() {param}
        ).Compile()(10)
        ' This code example produces the following output:
        '
        ' 10