         // Add the following directive to your file:
         // using System.Linq.Expressions;  

         class TestClass
         {
             public int sample { get; set; }
         }

         static void TestPropertyOrField()
         {
             TestClass obj = new TestClass();
             obj.sample = 40;

             // This expression represents accessing a property or field.
             // For static properties or fields, the first parameter must be null.
             Expression memberExpr = Expression.PropertyOrField(
                 Expression.Constant(obj),
                 "sample"
             );

             // The following statement first creates an expression tree,
             // then compiles it, and then runs it.
             Console.WriteLine(Expression.Lambda<Func<int>>(memberExpr).Compile()());
         }

         // This code example produces the following output:
         //
         // 40
