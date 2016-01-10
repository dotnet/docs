using System;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreeSamples
{
    public class ExpressionTreeClassesSampleOne : Sample
    {
        public override string Name { get; } = "Expression Tree Classes, Sample 1";
        
        public override void Run()
        {
            Expression<Func<int, int>> addFive = (num) => num + 5;

            if (addFive.NodeType == ExpressionType.Lambda)
            {
                var lambdaExp = addFive as LambdaExpression;
                var arg = lambdaExp.Parameters.First();
                if (arg.NodeType == ExpressionType.Parameter)
                {
                    var parameter = arg as ParameterExpression;
                    Console.WriteLine(parameter.Name);
                    Console.WriteLine(parameter.Type.ToString());
                }
            }
        }
    }
}
