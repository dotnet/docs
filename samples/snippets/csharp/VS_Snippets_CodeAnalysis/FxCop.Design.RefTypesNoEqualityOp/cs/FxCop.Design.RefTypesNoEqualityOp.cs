//<Snippet1>
using System;

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
//</Snippet1>
