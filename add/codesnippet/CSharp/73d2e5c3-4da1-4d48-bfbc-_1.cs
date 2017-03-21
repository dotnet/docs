        // Add the following directive to your file:
        // using System.Linq.Expressions;  

        class TestFieldClass
        {
            int sample = 40;
        }

        static void TestField()
        {       
            TestFieldClass obj = new TestFieldClass();
          
            // This expression represents accessing a field.
            // For static fields, the first parameter must be null.
            Expression fieldExpr = Expression.Field(
                Expression.Constant(obj),
                "sample"
            );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Console.WriteLine(Expression.Lambda<Func<int>>(fieldExpr).Compile()());
        }

        // This code example produces the following output:
        //
        // 40