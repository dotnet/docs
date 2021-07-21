using System;

namespace ca1802
{
    //<snippet1>
    // This class violates the rule.
    public class UseReadOnly
    {
        static readonly int x = 3;
        static readonly double y = x + 2.1;
        static readonly string s = "readonly";

        public void Print()
        {
            Console.WriteLine(s);
        }
    }

    // This class satisfies the rule.
    public class UseConstant
    {
        const int x = 3;
        const double y = x + 2.1;
        const string s = "const";
    }
    //</snippet1>
}
