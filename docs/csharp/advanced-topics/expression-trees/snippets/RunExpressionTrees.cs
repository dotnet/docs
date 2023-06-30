using System.Linq.Expressions;

public static class RunExpressionTrees
{
    public static void ConvertToDelegate()
    {
        // <ConvertToDelegate>
        Expression<Func<int>> add = () => 1 + 2;
        var func = add.Compile(); // Create Delegate
        var answer = func(); // Invoke Delegate
        Console.WriteLine(answer);
        // </ConvertToDelegate>
    }

    public static void CreateExpressionTree()
    {
        // <CreateExpressionTree>
        Expression<Func<int, bool>> expr = num => num < 5;

        // Compiling the expression tree into a delegate.
        Func<int, bool> result = expr.Compile();

        // Invoking the delegate and writing the result to the console.
        Console.WriteLine(result(4));

        // Prints True.

        // You can also use simplified syntax
        // to compile and run an expression tree.
        // The following line can replace two previous statements.
        Console.WriteLine(expr.Compile()(4));

        // Also prints True.
        // </CreateExpressionTree>
    }

    public static void BuildExpressionTree()
    {
        // <ConvertToFund>
        // The expression tree to execute.
        BinaryExpression be = Expression.Power(Expression.Constant(2d), Expression.Constant(3d));

        // Create a lambda expression.
        Expression<Func<double>> le = Expression.Lambda<Func<double>>(be);

        // Compile the lambda expression.
        Func<double> compiledExpression = le.Compile();

        // Execute the lambda expression.
        double result = compiledExpression();

        // Display the result.
        Console.WriteLine(result);

        // This code produces the following output:
        // 8
        // </ConvertToFund>
    }

    // <CreateBoundFunc>
    private static Func<int, int> CreateBoundFunc()
    {
        var constant = 5; // constant is captured by the expression tree
        Expression<Func<int, int>> expression = (b) => constant + b;
        var rVal = expression.Compile();
        return rVal;
    }
    // </CreateBoundFunc>

    // <CreateBoundResource>
    private static Func<int, int> CreateBoundResource()
    {
        using (var constant = new Resource()) // constant is captured by the expression tree
        {
            Expression<Func<int, int>> expression = (b) => constant.Argument + b;
            var rVal = expression.Compile();
            return rVal;
        }
    }
    // </CreateBoundResource>
}

// <ResourceClass>
public class Resource : IDisposable
{
    private bool _isDisposed = false;
    public int Argument
    {
        get
        {
            if (!_isDisposed)
                return 5;
            else throw new ObjectDisposedException("Resource");
        }
    }

    public void Dispose()
    {
        _isDisposed = true;
    }
}
// </ResourceClass>
