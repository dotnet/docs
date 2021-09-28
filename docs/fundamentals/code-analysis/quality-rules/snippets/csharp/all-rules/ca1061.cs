using System;

namespace ca1061
{
    //<snippet1>
    class BaseType
    {
        internal void MethodOne(string inputOne, object inputTwo)
        {
            Console.WriteLine("Base: {0}, {1}", inputOne, inputTwo);
        }

        internal void MethodTwo(string inputOne, string inputTwo)
        {
            Console.WriteLine("Base: {0}, {1}", inputOne, inputTwo);
        }
    }

    class DerivedType : BaseType
    {
        internal void MethodOne(string inputOne, string inputTwo)
        {
            Console.WriteLine("Derived: {0}, {1}", inputOne, inputTwo);
        }

        // This method violates the rule.
        internal void MethodTwo(string inputOne, object inputTwo)
        {
            Console.WriteLine("Derived: {0}, {1}", inputOne, inputTwo);
        }
    }

    class Test
    {
        static void Main1061()
        {
            DerivedType derived = new DerivedType();

            // Calls DerivedType.MethodOne.
            derived.MethodOne("string1", "string2");

            // Calls BaseType.MethodOne.
            derived.MethodOne("string1", (object)"string2");

            // Both of these call DerivedType.MethodTwo.
            derived.MethodTwo("string1", "string2");
            derived.MethodTwo("string1", (object)"string2");
        }
    }
    //</snippet1>
}
