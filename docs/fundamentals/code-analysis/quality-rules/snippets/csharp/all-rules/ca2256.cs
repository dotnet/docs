using System.Runtime.InteropServices;

namespace ca2256
{
    //<snippet1>
    interface IParent
    {
        void ParentMethod();
    }

    // This interface violates the rule.
    [DynamicInterfaceCastableImplementation]
    interface IBadChild : IParent
    {
        static void ChildMethod()
        {
            // ...
        }
    }

    // This interface satisfies the rule.
    [DynamicInterfaceCastableImplementation]
    interface IGoodChild : IParent
    {
        static void ChildMethod()
        {
            // ...
        }

        void IParent.ParentMethod()
        {
            // ...
        }
    }
    //</snippet1>
}
