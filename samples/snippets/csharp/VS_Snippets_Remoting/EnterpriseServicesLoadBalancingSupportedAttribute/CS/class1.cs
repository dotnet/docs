// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// <snippet1>
[LoadBalancingSupported]
public class LoadBalancingSupportedAttribute_Ctor : ServicedComponent
{
}
// </snippet1>

// <snippet2>
[LoadBalancingSupported(false)]
public class LoadBalancingSupportedAttribute_Ctor_Bool : ServicedComponent
{
}
// </snippet2>

// <snippet3>
[LoadBalancingSupported(false)]
public class LoadBalancingSupportedAttribute_Value : ServicedComponent
{
    public void ValueExample()
    {
        // Get the LoadBalancingSupportedAttribute applied to the class.
        LoadBalancingSupportedAttribute attribute =
            (LoadBalancingSupportedAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(LoadBalancingSupportedAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("LoadBalancingSupportedAttribute.Value: {0}",
            attribute.Value);
    }
}
// </snippet3>

// </snippet0>

/*
// Test client.
public class LoadBalancingSupportedAttribute_Example
{
    public static void Main()
    {
        // Create a new instance of each example class.
        LoadBalancingSupportedAttribute_Value valueExample =
            new LoadBalancingSupportedAttribute_Value();

        // Demonstrate the LoadBalancingSupportedAttribute properties.
        valueExample.ValueExample();
    }
}
*/