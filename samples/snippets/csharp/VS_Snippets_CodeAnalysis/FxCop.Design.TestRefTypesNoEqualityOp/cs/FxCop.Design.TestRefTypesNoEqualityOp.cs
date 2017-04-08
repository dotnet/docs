//<Snippet1>
using System;

namespace DesignLibrary
{
    public class ReferenceTypeEquality
    {
       public static void Main()
       {
          MyReferenceType a = new MyReferenceType(2,2);
          MyReferenceType b = new MyReferenceType(2,2);
          MyReferenceType c = a;
         
          Console.WriteLine("a = new {0} and b = new {1} are equal? {2}", a,b, a.Equals(b)? "Yes":"No");
          Console.WriteLine("c and a are equal? {0}", c.Equals(a)? "Yes":"No");
          Console.WriteLine("b and a are == ? {0}", b == a ? "Yes":"No");
          Console.WriteLine("c and a are == ? {0}", c == a ? "Yes":"No");     
       }
    }
}
//</Snippet1>
namespace DesignLibrary
{
   public class MyReferenceType
   {
      private int a, b;
      public MyReferenceType (int a, int b)
      {
         this.a = a;
         this.b = b;
      }

      public override string ToString()
      {
         return String.Format("({0},{1})", a, b);
      }
   }
}
