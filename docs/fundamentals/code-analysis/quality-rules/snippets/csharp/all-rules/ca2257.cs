using System.Runtime.InteropServices;

namespace ca2257
{
    //<snippet1>
    [DynamicInterfaceCastableImplementation]
    interface IExample
    {
        // This method violates the rule.
        void BadMethod();

        // This method satisfies the rule.
        static void GoodMethod()
        {
            // ...
        }
    }
    //</snippet1>
}
