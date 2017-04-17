// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// <snippet1>
[EventTrackingEnabled]
public class EventTrackingEnabledAttribute_Ctor : ServicedComponent
{
}
// </snippet1>

// <snippet2>
[EventTrackingEnabled(false)]
public class EventTrackingEnabledAttribute_Ctor_Bool : ServicedComponent
{
}
// </snippet2>

// <snippet3>
[EventTrackingEnabled(false)]
public class EventTrackingEnabledAttribute_Value : ServicedComponent
{
    public void ValueExample()
    {
        // Get the EventTrackingEnabledAttribute applied to the class.
        EventTrackingEnabledAttribute attribute =
            (EventTrackingEnabledAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(EventTrackingEnabledAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("EventTrackingEnabledAttribute.Value: {0}",
            attribute.Value);
    }
}
// </snippet3>

// </snippet0>

/*
// Test client.
public class EventTrackingEnabledAttribute_Example
{
    public static void Main()
    {
        // Create a new instance of each example class.
        EventTrackingEnabledAttribute_Value valueExample =
            new EventTrackingEnabledAttribute_Value();

        // Demonstrate the EventTrackingEnabledAttribute properties.
        valueExample.ValueExample();
    }
}
*/