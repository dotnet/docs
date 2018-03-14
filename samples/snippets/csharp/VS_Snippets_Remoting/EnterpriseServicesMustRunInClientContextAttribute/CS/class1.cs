// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// <snippet1>
[MustRunInClientContext]
public class MustRunInClientContextAttribute_Ctor : ServicedComponent
{
}
// </snippet1>

// <snippet2>
[MustRunInClientContext(false)]
public class MustRunInClientContextAttribute_Ctor_Bool : ServicedComponent
{
}
// </snippet2>

// <snippet3>
[MustRunInClientContext(false)]
public class MustRunInClientContextAttribute_Value : ServicedComponent
{
    public void ValueExample()
    {
        // Get the MustRunInClientContextAttribute applied to the class.
        MustRunInClientContextAttribute attribute =
            (MustRunInClientContextAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(MustRunInClientContextAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("MustRunInClientContextAttribute.Value: {0}",
            attribute.Value);
    }
}
// </snippet3>

// </snippet0>

/*
// Test client.
public class MustRunInClientContextAttribute_Example
{
    public static void Main()
    {
        // Create a new instance of each example class.
        MustRunInClientContextAttribute_Value valueExample =
            new MustRunInClientContextAttribute_Value();

        // Demonstrate the MustRunInClientContextAttribute properties.
        valueExample.ValueExample();
    }
}
*/