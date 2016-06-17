using System;
using System.Linq.Expressions;

namespace ExpressionTreeSamples
{
    public class ExpressionTreeTranslationSampleThree : Sample
    {
        public override string Name { get; } = "Translation Expression Trees, Sample 3: Computing the sum of an addition tree with logging";
        
        public override void Run()
        {
            var one = Expression.Constant(1, typeof(int));
            var two = Expression.Constant(2, typeof(int));
            var three = Expression.Constant(3, typeof(int));
            var four = Expression.Constant(4, typeof(int));
            var addition = Expression.Add(one, two);
            var add2 = Expression.Add(three, four);
            var sum = Expression.Add(addition, add2);

            var theSum = Aggregate(sum);
            Console.WriteLine(theSum);

            sum = Expression.Add(one,
                Expression.Add(two,
                    Expression.Add(three, four)));

            Console.WriteLine("Rearranging the order of operations");
            theSum = Aggregate(sum);
            Console.WriteLine(theSum);
       }

        private static int Aggregate(Expression exp)
        {
            if (exp.NodeType == ExpressionType.Constant)
            {
                var constantExp = (ConstantExpression)exp;
                Console.WriteLine($"Found Constant: {constantExp.Value}");
                return (int)constantExp.Value;
            }
            else if (exp.NodeType == ExpressionType.Add)
            {
                var addExp = (BinaryExpression)exp;
                Console.WriteLine("Found Addition Expression");
                Console.WriteLine("Computing Left node");
                var leftOperand = Aggregate(addExp.Left);
                Console.WriteLine($"Left is: {leftOperand}");
                Console.WriteLine("Computing Right node");
                var rightOperand = Aggregate(addExp.Right);
                Console.WriteLine($"Right is: {rightOperand}");
                var sum = leftOperand + rightOperand;
                Console.WriteLine($"Computed sum: {sum}");
                return sum;

            }
            else throw new NotSupportedException("Haven't written this yet");
        }
    }
}
