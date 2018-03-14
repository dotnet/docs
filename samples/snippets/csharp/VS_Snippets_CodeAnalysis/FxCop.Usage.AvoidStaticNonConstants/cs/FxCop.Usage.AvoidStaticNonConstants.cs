//<Snippet1>
using System;

namespace UsageLibrary
{
   public class SomeStaticFields
   {
      // Violates rule: AvoidNonConstantStatic;
      // the field is public and not a literal.
      static public DateTime publicField = DateTime.Now;

      // Satisfies rule: AvoidNonConstantStatic.
      public static readonly DateTime literalField = DateTime.Now;

      // Satisfies rule: NonConstantFieldsShouldNotBeVisible;
      // the field is private.
      static DateTime privateField = DateTime.Now;
   }
}
//</Snippet1>
