            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            public class SampleClass
            {
                public static int Increment(int arg1)
                {
                    return arg1 + 1;
                }
            }

            static public void TestCall()
            {

                //This expression represents a call to an instance method with one argument.
                Expression callExpr = Expression.Call(
                                        typeof(SampleClass).GetMethod("Increment"),
                                        Expression.Constant(2)
                                    );

                // Print out the expression.
                Console.WriteLine(callExpr.ToString());

                // The following statement first creates an expression tree,
                // then compiles it, and then executes it.
                Console.WriteLine(Expression.Lambda<Func<int>>(callExpr).Compile()());

                // This code example produces the following output:
                //
                // Increment(2)
                // 3
            }