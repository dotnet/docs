using System;

namespace ca1820
{
    //<snippet1>
    public class StringTester
    {
        string s1 = "test";

        public void EqualsTest()
        {
            // Violates rule: TestForEmptyStringsUsingStringLength.
            if (s1 == "")
            {
                Console.WriteLine("s1 equals empty string.");
            }
        }

        // Use for .NET Framework 1.0 and 1.1.
        public void LengthTest()
        {
            // Satisfies rule: TestForEmptyStringsUsingStringLength.
            if (s1 != null && s1.Length == 0)
            {
                Console.WriteLine("s1.Length == 0.");
            }
        }

        // Use for .NET Framework 2.0.
        public void NullOrEmptyTest()
        {
            // Satisfies rule: TestForEmptyStringsUsingStringLength.
            if (!String.IsNullOrEmpty(s1))
            {
                Console.WriteLine("s1 != null and s1.Length != 0.");
            }
        }
    }
    //</snippet1>
}
