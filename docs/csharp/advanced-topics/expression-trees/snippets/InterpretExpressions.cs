using System.Linq.Expressions;
public static class InterpretExpressions
{
    public static void ParseExpression()
    {
        // <ParseExpression>
        // Add the following using directive to your code file:
        // using System.Linq.Expressions;

        // Create an expression tree.
        Expression<Func<int, bool>> exprTree = num => num < 5;

        // Decompose the expression tree.
        ParameterExpression param = (ParameterExpression)exprTree.Parameters[0];
        BinaryExpression operation = (BinaryExpression)exprTree.Body;
        ParameterExpression left = (ParameterExpression)operation.Left;
        ConstantExpression right = (ConstantExpression)operation.Right;

        Console.WriteLine($"Decomposed expression: {param.Name} => {left.Name} {operation.NodeType} {right.Value}");

        // This code produces the following output:

        // Decomposed expression: num => num LessThan 5
        // </ParseExpression>
    }

    public static void VisitConstantExpression()
    {
        // <VisitConstant>
        var constant = Expression.Constant(24, typeof(int));

        Console.WriteLine($"This is a/an {constant.NodeType} expression type");
        Console.WriteLine($"The type of the constant value is {constant.Type}");
        Console.WriteLine($"The value of the constant value is {constant.Value}");
        // </VisitConstant>
    }

    public static void VisitAddition()
    {
        // <VisitAddition>
        Expression<Func<int, int, int>> addition = (a, b) => a + b;

        Console.WriteLine($"This expression is a {addition.NodeType} expression type");
        Console.WriteLine($"The name of the lambda is {((addition.Name == null) ? "<null>" : addition.Name)}");
        Console.WriteLine($"The return type is {addition.ReturnType.ToString()}");
        Console.WriteLine($"The expression has {addition.Parameters.Count} arguments. They are:");
        foreach (var argumentExpression in addition.Parameters)
        {
            Console.WriteLine($"\tParameter Type: {argumentExpression.Type.ToString()}, Name: {argumentExpression.Name}");
        }

        var additionBody = (BinaryExpression)addition.Body;
        Console.WriteLine($"The body is a {additionBody.NodeType} expression");
        Console.WriteLine($"The left side is a {additionBody.Left.NodeType} expression");
        var left = (ParameterExpression)additionBody.Left;
        Console.WriteLine($"\tParameter Type: {left.Type.ToString()}, Name: {left.Name}");
        Console.WriteLine($"The right side is a {additionBody.Right.NodeType} expression");
        var right = (ParameterExpression)additionBody.Right;
        Console.WriteLine($"\tParameter Type: {right.Type.ToString()}, Name: {right.Name}");
        // </VisitAddition>
    }

    public static void AdditionExamples()
    {
        // <NoParens>
        Expression<Func<int>> sum = () => 1 + 2 + 3 + 4;
        // </NoParens>

        var visitor = new Visitors.LambdaVisitor(sum);
        visitor.Visit("Sum: ");


        // <ParensPermutations> 
        Expression<Func<int>> sum1 = () => 1 + (2 + (3 + 4));
        Expression<Func<int>> sum2 = () => ((1 + 2) + 3) + 4;

        Expression<Func<int>> sum3 = () => (1 + 2) + (3 + 4);
        Expression<Func<int>> sum4 = () => 1 + ((2 + 3) + 4);
        Expression<Func<int>> sum5 = () => (1 + (2 + 3)) + 4;
        // </ParensPermutations>
    }

    public static void VariableAddition()
    { 
        // <VariableAddition>
        Expression<Func<int, int>> sum = (a) => 1 + a + 3 + 4;
        // </VariableAddition>

        var visitor = new Visitors.LambdaVisitor(sum);
        visitor.Visit("Sum Variable: ");
    }

    public static void VariableParensAddition()
    {
        // <VariableParensAddition>
        Expression<Func<int, int, int>> sum3 = (a, b) => (1 + a) + (3 + b);
        // </VariableParensAddition>

        var visitor = new Visitors.LambdaVisitor(sum3 );
        visitor.Visit("Sum Parens Variable: ");
    }

    public static void FactorialVisitor()
    {
        // <FactorialVisitor>
        Expression<Func<int, int>> factorial = (n) =>
            n == 0 ?
            1 :
            Enumerable.Range(1, n).Aggregate((product, factor) => product * factor);
        // </FactorialVisitor>

        Visitors2.LambdaVisitor visitor = new Visitors2.LambdaVisitor(factorial);
        visitor.Visit("Factorial: ");

    }
}
