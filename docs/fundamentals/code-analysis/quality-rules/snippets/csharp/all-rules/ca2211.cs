using System;

namespace ca2211
{
    //<snippet1>
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
    //</snippet1>
}
