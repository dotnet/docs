// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// <snippet1>
[JustInTimeActivation]
public class JITAAttribute_Ctor : ServicedComponent
{
}
// </snippet1>

// <snippet2>
[JustInTimeActivation(false)]
public class JITAAttribute_Ctor_Bool : ServicedComponent
{
}
// </snippet2>

// <snippet3>
[JustInTimeActivation(false)]
public class JITAAttribute_Value : ServicedComponent
{
    public void ValueExample()
    {
        // Get the JustInTimeActivationAttribute applied to the class.
        JustInTimeActivationAttribute attribute =
            (JustInTimeActivationAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(JustInTimeActivationAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("JustInTimeActivationAttribute.Value: {0}",
            attribute.Value);
    }
}
// </snippet3>

// </snippet0>

/*
// Test client.
public class JITAAttribute_Example
{
    public static void Main()
    {
        // Create a new instance of each example class.
        JITAAttribute_Value valueExample = new JITAAttribute_Value();

        // Demonstrate the JustInTimeActivationAttribute properties.
        valueExample.ValueExample();
    }
}
*/