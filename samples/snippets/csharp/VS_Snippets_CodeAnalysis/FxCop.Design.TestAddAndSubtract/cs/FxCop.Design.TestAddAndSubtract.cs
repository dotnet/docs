//<Snippet1>
using System;

namespace DesignLibrary
{
    public class TestAddableTypes
    {
       public static void Main()
       {
          BadAddableType a = new BadAddableType(2,2);
          BadAddableType b = new BadAddableType(2,2);
          BadAddableType x = new BadAddableType(9,9);
          GoodAddableType c = new GoodAddableType(3,3);
          GoodAddableType d = new GoodAddableType(3,3);
          GoodAddableType y = new GoodAddableType(9,9);
    
          Console.WriteLine("Bad type:  {0} {1} are equal? {2}", a,b, a.Equals(b)? "Yes":"No");
          Console.WriteLine("Good type: {0} {1} are equal? {2}", c,d, c.Equals(d)? "Yes":"No");
          Console.WriteLine("Good type: {0} {1} are == ?   {2}", c,d, c==d? "Yes":"No");
          Console.WriteLine("Bad type:  {0} {1} are equal? {2}", a,x, a.Equals(x)? "Yes":"No");
          Console.WriteLine("Good type: {0} {1} are == ?   {2}", c,y, c==y? "Yes":"No");
       }
    }
}
//</Snippet1>
namespace DesignLibrary
{
   public class BadAddableType
   {
      private int a, b;
      public BadAddableType(int a, int b)
      {
         this.a = a;
         this.b = b;
      }
      // Violates rule: OverrideOperatorEqualsOnOverridingAddAndSubtract.
      public static BadAddableType operator +(BadAddableType a, BadAddableType b)
      {
         return new BadAddableType(a.a + b.a, a.b + b.b);
      }
      // Violates rule: OverrideOperatorEqualsOnOverridingAddAndSubtract.
      public static BadAddableType operator -(BadAddableType a, BadAddableType b)
      {
         return new BadAddableType(a.a - b.a, a.b - b.b);
      }
      public override string ToString()
      {
         return String.Format("{{{0},{1}}}", a, b);
      }
   }

   public class GoodAddableType
   {
      private int a, b;
      public GoodAddableType(int a, int b)
      {
         this.a = a;
         this.b = b;
      }
      // Satisfies rule: OverrideOperatorEqualsOnOverridingAddAndSubtract.
      public static bool operator ==(GoodAddableType a, GoodAddableType b)
      {
         return (a.a == b.a && a.b == b.b);
      }

      // If you implement ==, you must implement !=.
      public static bool operator !=(GoodAddableType a, GoodAddableType b)
      {
         return !(a==b);
      }

      // Equals should be consistent with operator ==.
      public override bool Equals(Object obj)
      {
         GoodAddableType good = obj as GoodAddableType;
         if (obj == null)
            return false;
         
        return this == good;
      }
      
      public override int GetHashCode() 
      { 
          return 0; 
      }

      public static GoodAddableType operator +(GoodAddableType a, GoodAddableType b)
      {
         return new GoodAddableType(a.a + b.a, a.b + b.b);
      }
     
      public static GoodAddableType operator -(GoodAddableType a, GoodAddableType b)
      {
         return new GoodAddableType(a.a - b.a, a.b - b.b);
      }
      public override string ToString()
      {
         return String.Format("{{{0},{1}}}", a, b);
      }
   }
}