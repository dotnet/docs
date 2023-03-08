using System.Linq.Expressions;

namespace ExpressionTreeExample;
public static class TranslateExpressions
{
    // <ReplaceNode>
    private static Expression ReplaceNodes(Expression original)
    {
        if (original.NodeType == ExpressionType.Constant)
        {
            return Expression.Multiply(original, Expression.Constant(10));
        }
        else if (original.NodeType == ExpressionType.Add)
        {
            var binaryExpression = (BinaryExpression)original;
            return Expression.Add(
                ReplaceNodes(binaryExpression.Left),
                ReplaceNodes(binaryExpression.Right));
        }
        return original;
    }
    // </ReplaceNode>

    public static void TranslateNode()
    {
        // <TranslateNode>
        var one = Expression.Constant(1, typeof(int));
        var two = Expression.Constant(2, typeof(int));
        var addition = Expression.Add(one, two);
        var sum = ReplaceNodes(addition);
        var executableFunc = Expression.Lambda(sum);

        var func = (Func<int>)executableFunc.Compile();
        var answer = func();
        Console.WriteLine(answer);
        // </TranslateNode>
    }

    public static void TraverseAndCreate()
    {
        // <TraverseAndCreateNode>
        var one = Expression.Constant(1, typeof(int));
        var two = Expression.Constant(2, typeof(int));
        var three = Expression.Constant(3, typeof(int));
        var four = Expression.Constant(4, typeof(int));
        var addition = Expression.Add(one, two);
        var add2 = Expression.Add(three, four);
        var sum = Expression.Add(addition, add2);

        // Declare the delegate, so you can call it
        // from itself recursively:
        Func<Expression, int> aggregate = null!;
        // Aggregate, return constants, or the sum of the left and right operand.
        // Major simplification: Assume every binary expression is an addition.
        aggregate = (exp) =>
            exp.NodeType == ExpressionType.Constant ?
            (int)((ConstantExpression)exp).Value :
            aggregate(((BinaryExpression)exp).Left) + aggregate(((BinaryExpression)exp).Right);

        var theSum = aggregate(sum);
        Console.WriteLine(theSum);
        // </TraverseAndCreateNode>

        Aggregate(sum);

        // <sum1Expression>
        Expression<Func<int>> sum1 = () => 1 + (2 + (3 + 4));
        // </sum1Expression>
        Console.WriteLine();
        Console.WriteLine("sum1 aggregate");
        Aggregate(sum);
    }

    // <Aggregate>
    private static int Aggregate(Expression exp)
    {
        if (exp.NodeType == ExpressionType.Constant)
        {
            var constantExp = (ConstantExpression)exp;
            Console.Error.WriteLine($"Found Constant: {constantExp.Value}");
            if (constantExp.Value is int value)
            {
                return value;
            }
            else
            {
                return 0;
            }
        }
        else if (exp.NodeType == ExpressionType.Add)
        {
            var addExp = (BinaryExpression)exp;
            Console.Error.WriteLine("Found Addition Expression");
            Console.Error.WriteLine("Computing Left node");
            var leftOperand = Aggregate(addExp.Left);
            Console.Error.WriteLine($"Left is: {leftOperand}");
            Console.Error.WriteLine("Computing Right node");
            var rightOperand = Aggregate(addExp.Right);
            Console.Error.WriteLine($"Right is: {rightOperand}");
            var sum = leftOperand + rightOperand;
            Console.Error.WriteLine($"Computed sum: {sum}");
            return sum;
        }
        else throw new NotSupportedException("Haven't written this yet");
    }
    // </Aggregate>


    public static void ModifyExpression()
    {
        // <ModifyExpression>
        Expression<Func<string, bool>> expr = name => name.Length > 10 && name.StartsWith("G");
        Console.WriteLine(expr);

        AndAlsoModifier treeModifier = new AndAlsoModifier();
        Expression modifiedExpr = treeModifier.Modify((Expression)expr);

        Console.WriteLine(modifiedExpr);

        /*  This code produces the following output:

            name => ((name.Length > 10) && name.StartsWith("G"))
            name => ((name.Length > 10) || name.StartsWith("G"))
        */
        // </ModifyExpression>
    }
}

// <AndAlsoModifier>
public class AndAlsoModifier : ExpressionVisitor
{
    public Expression Modify(Expression expression)
    {
        return Visit(expression);
    }

    protected override Expression VisitBinary(BinaryExpression b)
    {
        if (b.NodeType == ExpressionType.AndAlso)
        {
            Expression left = this.Visit(b.Left);
            Expression right = this.Visit(b.Right);

            // Make this binary expression an OrElse operation instead of an AndAlso operation.
            return Expression.MakeBinary(ExpressionType.OrElse, left, right, b.IsLiftedToNull, b.Method);
        }

        return base.VisitBinary(b);
    }
}
// </AndAlsoModifier>
