using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// This is equivalent to [Synchronization(SynchronizationOption.Required)].
[Synchronization]
public class SynchronizationAttribute_Ctor : ServicedComponent
{
}

[Synchronization(SynchronizationOption.Disabled)]
public class SynchronizationAttribute_Ctor_SynchronizationOption : ServicedComponent
{
}

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
