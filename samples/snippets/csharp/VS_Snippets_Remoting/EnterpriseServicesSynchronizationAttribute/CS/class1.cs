// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// <snippet1>
// This is equivalent to [Synchronization(SynchronizationOption.Required)].
[Synchronization]
public class SynchronizationAttribute_Ctor : ServicedComponent
{
}
// </snippet1>

// <snippet2>
[Synchronization(SynchronizationOption.Disabled)]
public class SynchronizationAttribute_Ctor_SynchronizationOption : ServicedComponent
{
}
// </snippet2>

// <snippet3>
[Synchronization(SynchronizationOption.RequiresNew)]
public class SynchronizationAttribute_Value : ServicedComponent
{
    public void ValueExample()
    {
        // Get the SynchronizationAttribute applied to the class.
        SynchronizationAttribute attribute =
            (SynchronizationAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(SynchronizationAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("SynchronizationAttribute.Value: {0}",
            attribute.Value);
    }
}
// </snippet3>

// </snippet0>

/*
// Test client.
public class SynchronizationAttribute_Example
{
    public static void Main()
    {
        // Create a new instance of each example class.
        SynchronizationAttribute_Value valueExample =
            new SynchronizationAttribute_Value();

        // Demonstrate the SynchronizationAttribute properties.
        valueExample.ValueExample();
    }
}
*/
