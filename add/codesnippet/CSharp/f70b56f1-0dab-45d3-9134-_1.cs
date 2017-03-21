
         // Add the following directive to your file:
         // using System.Linq.Expressions;  

         class TestMemberInitClass
         {
             public int sample { get; set; }
         }

         static void MemberInit()
         {   
             // This expression creates a new TestMemberInitClass object
             // and assigns 10 to its sample property.
             Expression testExpr = Expression.MemberInit(
                 Expression.New(typeof(TestMemberInitClass)),
                 new List<MemberBinding>() {
                     Expression.Bind(typeof(TestMemberInitClass).GetMember("sample")[0], Expression.Constant(10))
                 }
             );

             // The following statement first creates an expression tree,
             // then compiles it, and then runs it.
             var test = Expression.Lambda<Func<TestMemberInitClass>>(testExpr).Compile()();
             Console.WriteLine(test.sample);
         }

         // This code example produces the following output:
         //
         // 10