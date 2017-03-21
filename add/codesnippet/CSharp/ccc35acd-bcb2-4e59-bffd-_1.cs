        // Add the following directive to your file:
        // using System.Linq.Expressions;  

         class TestPropertyClass
         {
             public int sample {get; set;}
         }

         static void TestProperty()
         {
             TestPropertyClass obj = new TestPropertyClass();
             obj.sample = 40;

             // This expression represents accessing a property.
             // For static fields, the first parameter must be null.
             Expression propertyExpr = Expression.Property(
                 Expression.Constant(obj),
                 "sample"
             );

             // The following statement first creates an expression tree,
             // then compiles it, and then runs it.
             Console.WriteLine(Expression.Lambda<Func<int>>(propertyExpr).Compile()());            
         }

         // This code example produces the following output:
         //
         // 40
