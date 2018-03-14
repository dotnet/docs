// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// <snippet1>
[ExceptionClass("ExceptionHandler")]
public class ExceptionClassAttribute_Ctor_String : ServicedComponent
{
}
// </snippet1>

// <snippet2>
[ExceptionClass("ExceptionHandler")]
public class ExceptionClassAttribute_Value : ServicedComponent
{
    public void ValueExample()
    {
        // Get the ExceptionClassAttribute applied to the class.
        ExceptionClassAttribute attribute =
            (ExceptionClassAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(ExceptionClassAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("ExceptionClassAttribute.Value: {0}",
            attribute.Value);
    }
}
// </snippet2>

// </snippet0>

/*
// Test client.
public class ExceptionClassAttribute_Example
{
    public static void Main()
    {
        // Create a new instance of each example class.
        ExceptionClassAttribute_Value valueExample =
            new ExceptionClassAttribute_Value();

        // Demonstrate the ExceptionClassAttribute properties.
        valueExample.ValueExample();
    }
}
*/