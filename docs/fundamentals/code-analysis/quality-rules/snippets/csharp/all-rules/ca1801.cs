using System.Globalization;

namespace ca1801
{
    public static class TestClass
    {
        //<snippet1>
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
        //</snippet1>
    }
}
