// <Snippet1>
using System;

// Create some custom attributes:
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
class FirstAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Class)]
class SecondAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
class ThirdAttribute : Attribute { }

// Apply custom attributes to classes:
[First, Second]
class BaseClass { }

[Third, Third]
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
// </Snippet1>
