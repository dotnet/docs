// <Snippet1>
using System;

public class BaseClass
{
   [ThreadStatic] public int total;
   
   [CLSCompliant(false)] public virtual uint MethodA()
   {
      return (uint) 100;
   }
}

public class DerivedClass : BaseClass
{
   public override uint MethodA()
   {
      total++;
      return 200;
   }
}

public class Example
{
   public static void Main()
   {
      Type t = typeof(DerivedClass);
      Console.WriteLine("Members of {0}:", t.FullName);
      foreach (var m in t.GetMembers())
      {
         bool hasAttribute = false;
         Console.Write("   {0}: ", m.Name);
         if (m.GetCustomAttributes(typeof(CLSCompliantAttribute), true).Length > 0) {
            Console.Write("CLSCompliant");
            hasAttribute = true;
         }
         if (m.GetCustomAttributes(typeof(ThreadStaticAttribute), true).Length > 0) {
            Console.Write("ThreadStatic");
            hasAttribute = true;
         }
         if (! hasAttribute)
            Console.Write("No attributes");

         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//       Members of DerivedClass:
//          MethodA: CLSCompliant
//          ToString: No attributes
//          Equals: No attributes
//          GetHashCode: No attributes
//          typeof: No attributes
//          .ctor: No attributes
//          total: ThreadStatic
// </Snippet1>

