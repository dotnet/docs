//<Snippet1>
using System;

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
//</Snippet1>
