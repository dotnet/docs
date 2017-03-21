            // Add the following directive to your file:
            // using System.Linq.Expressions; 

            int num = 100;

            // This expression represents a conditional operation. 
            // It evaluates the test (first expression) and
            // executes the iftrue block (second argument) if the test evaluates to true, 
            // or the iffalse block (third argument) if the test evaluates to false.
            Expression conditionExpr = Expression.Condition(
                                       Expression.Constant(num > 10),
                                       Expression.Constant("num is greater than 10"),
                                       Expression.Constant("num is smaller than 10")
                                     );

            // Print out the expression.
            Console.WriteLine(conditionExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.       
            Console.WriteLine(
                Expression.Lambda<Func<string>>(conditionExpr).Compile()());

            // This code example produces the following output:
            //
            // IIF("True", "num is greater than 10", "num is smaller than 10")
            // num is greater than 10