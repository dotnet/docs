//<Snippet1>
using System;
using System.Globalization;

namespace Samples
{
    public static class TestClass
    {
        // This method violates the rule.
        public static string GetSomething(int first, int second)
        {
            return first.ToString(CultureInfo.InvariantCulture);
        }

        // This method satisfies the rule.
        public static string GetSomethingElse(int first)
        {
            return first.ToString(CultureInfo.InvariantCulture);
        }
    }
}
//</Snippet1>
