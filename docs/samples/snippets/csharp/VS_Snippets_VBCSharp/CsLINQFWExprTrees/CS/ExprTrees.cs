using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Expr
{
    static class Expr
    {
        static void Main(string[] args)
        {
            Example1();
            Example2();
            Example3();
            Example4();
            Example5();

            Console.ReadKey();
        }

        static void Example1()
        {
            // <Snippet1>

            // Add the following using directive to your code file:
            // using System.Linq.Expressions;

            // Create an expression tree.
            Expression<Func<int, bool>> exprTree = num => num < 5;

            // Decompose the expression tree.
            ParameterExpression param = (ParameterExpression)exprTree.Parameters[0];
            BinaryExpression operation = (BinaryExpression)exprTree.Body;
            ParameterExpression left = (ParameterExpression)operation.Left;
            ConstantExpression right = (ConstantExpression)operation.Right;

            Console.WriteLine("Decomposed expression: {0} => {1} {2} {3}",
                              param.Name, left.Name, operation.NodeType, right.Value);

            // This code produces the following output:
  
            // Decomposed expression: num => num LessThan 5            
            // </Snippet1>

        }

        static void Example2()
        {
            // <Snippet2>

            // Add the following using directive to your code file:
            // using System.Linq.Expressions;

            // Manually build the expression tree for 
            // the lambda expression num => num < 5.
            ParameterExpression numParam = Expression.Parameter(typeof(int), "num");
            ConstantExpression five = Expression.Constant(5, typeof(int));
            BinaryExpression numLessThanFive = Expression.LessThan(numParam, five);
            Expression<Func<int, bool>> lambda1 =
                Expression.Lambda<Func<int, bool>>(
                    numLessThanFive,
                    new ParameterExpression[] { numParam });

            // </Snippet2>

        }

        static void Example3()
        {
            //<Snippet3>
            Expression<Func<int, bool>> lambda = num => num < 5;
            //</Snippet3>

        }

        static void Example4()
        {
            //<Snippet4>
            // Creating a parameter expression.
            ParameterExpression value = Expression.Parameter(typeof(int), "value");

            // Creating an expression to hold a local variable. 
            ParameterExpression result = Expression.Parameter(typeof(int), "result");

            // Creating a label to jump to from a loop.
            LabelTarget label = Expression.Label(typeof(int));

            // Creating a method body.
            BlockExpression block = Expression.Block(
                // Adding a local variable.
                new[] { result },
                // Assigning a constant to a local variable: result = 1
                Expression.Assign(result, Expression.Constant(1)),
                // Adding a loop.
                    Expression.Loop(
                // Adding a conditional block into the loop.
                       Expression.IfThenElse(
                // Condition: value > 1
                           Expression.GreaterThan(value, Expression.Constant(1)),
                // If true: result *= value --
                           Expression.MultiplyAssign(result,
                               Expression.PostDecrementAssign(value)),
                // If false, exit the loop and go to the label.
                           Expression.Break(label, result)
                       ),
                // Label to jump to.
                   label
                )
            );

            // Compile and execute an expression tree.
            int factorial = Expression.Lambda<Func<int, int>>(block, value).Compile()(5);

            Console.WriteLine(factorial);
            // Prints 120.
            //</Snippet4>
        }

        public static void Example5()
        {
            //<Snippet5>
            // Creating an expression tree.
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
            //</Snippet5>
        }
    }
}
