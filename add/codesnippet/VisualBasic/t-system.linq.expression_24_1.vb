        Dim largeSumTest As System.Linq.Expressions.Expression(Of System.Func(Of Integer, Integer, Boolean)) = _
            Function(num1, num2) (num1 + num2) > 1000

        ' Create an InvocationExpression that represents applying
        ' the arguments '539' and '281' to the lambda expression 'largeSumTest'.
        Dim invocationExpression As System.Linq.Expressions.InvocationExpression = _
            System.Linq.Expressions.Expression.Invoke( _
                largeSumTest, _
                System.Linq.Expressions.Expression.Constant(539), _
                System.Linq.Expressions.Expression.Constant(281))

        Console.WriteLine(invocationExpression.ToString())

        ' This code produces the following output:
        '
        ' Invoke((num1, num2) => ((num1 + num2) > 1000),539,281)