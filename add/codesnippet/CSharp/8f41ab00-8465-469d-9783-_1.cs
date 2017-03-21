            // Add the following directive to your file:
            // using System.Linq.Expressions;  
            public class SampleClass
            {
                public int AddIntegers(int arg1, int arg2)
                {
                    return arg1 + arg2;
                }
            }

            static public void TestCall()
            {
                // This expression represents a call to an instance method that has two arguments.
                // The first argument is an expression that creates a new object of the specified type.
                Expression callExpr = Expression.Call(
                    Expression.New(typeof(SampleClass)),
                    typeof(SampleClass).GetMethod("AddIntegers", new Type[] { typeof(int), typeof(int) }),
                    Expression.Constant(1),
                    Expression.Constant(2)
                    );

                // Print out the expression.
                Console.WriteLine(callExpr.ToString());

                // The following statement first creates an expression tree,
                // then compiles it, and then executes it.
                Console.WriteLine(Expression.Lambda<Func<int>>(callExpr).Compile()());

                // This code example produces the following output:
                //
                // new SampleClass().AddIntegers(1, 2)
                // 3
            }