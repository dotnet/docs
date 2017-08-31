//<Snippet42>
using System;
//</Snippet42>
namespace N1
{
    //<Snippet36>
    [System.AttributeUsage(System.AttributeTargets.All,
                       AllowMultiple = false,
                       Inherited = true)]
    class NewAttribute : System.Attribute { }
    //</Snippet36>
}
namespace N2
{
    //<Snippet37>
    [System.AttributeUsage(System.AttributeTargets.All)]
    class NewAttribute : System.Attribute { }
    //</Snippet37>

}
namespace N3
{
    //<Snippet38>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    class NewPropertyOrFieldAttribute : Attribute { }
    //</Snippet38>
}

namespace N4
{

    //<Snippet39>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class MultiUseAttr : Attribute { }

    [MultiUseAttr]
    [MultiUseAttr]
    class Class1 { }

    [MultiUseAttr, MultiUseAttr]
    class Class2 { }
    //</Snippet39>
}

namespace N5
{
    //<Snippet40>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    class Attr1 : Attribute { }

    [Attr1]
    class BClass { }

    class DClass : BClass { }
    //</Snippet40>
}

namespace N6
{
    //<Snippet41>
    // Create some custom attributes:
    [AttributeUsage(System.AttributeTargets.Class, Inherited = false)]
    class A1 : System.Attribute { }

    [AttributeUsage(System.AttributeTargets.Class)]
    class A2 : System.Attribute { }

    [AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    class A3 : System.Attribute { }

    // Apply custom attributes to classes:
    [A1, A2]
    class BaseClass { }

    [A3, A3]
    class DerivedClass : BaseClass { }

    public class TestAttributeUsage
    {
        static void Main()
        {
            BaseClass b = new BaseClass();
            DerivedClass d = new DerivedClass();

            // Display custom attributes for each class.
            Console.WriteLine("Attributes on Base Class:");
            object[] attrs = b.GetType().GetCustomAttributes(true);
            foreach (Attribute attr in attrs)
            {
                Console.WriteLine(attr);
            }

            Console.WriteLine("Attributes on Derived Class:");
            attrs = d.GetType().GetCustomAttributes(true);
            foreach (Attribute attr in attrs)
            {
                Console.WriteLine(attr);
            }
        }
    }
    //</Snippet41>
}