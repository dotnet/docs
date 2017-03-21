            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents a call to an instance method without arguments.
            Expression callExpr = Expression.Call(
                Expression.Constant("sample string"), typeof(String).GetMethod("ToUpper", new Type[] { }));

            // Print out the expression.
            Console.WriteLine(callExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.  
            Console.WriteLine(Expression.Lambda<Func<String>>(callExpr).Compile()());

            // This code example produces the following output:
            //
            // "sample string".ToUpper
            // SAMPLE STRING
