        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions 

        ' This expression compares the values of its two arguments.
        ' Both arguments must be of the same type.
        Dim lessThanOrEqual As Expression = Expression.LessThanOrEqual(
             Expression.Constant(42),
             Expression.Constant(45)
         )

        ' Print the expression.
        Console.WriteLine(lessThanOrEqual.ToString())

        ' The following statement first creates an expression tree,
        ' then compiles it, and then executes it. 
        Console.WriteLine(
            Expression.Lambda(Of Func(Of Boolean))(lessThanOrEqual).Compile()())

        ' This code example produces the following output:
        '
        ' (42 <= 45)
        ' True