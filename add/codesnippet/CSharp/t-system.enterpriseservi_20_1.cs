using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

[ExceptionClass("ExceptionHandler")]
public class ExceptionClassAttribute_Ctor_String : ServicedComponent
{
}

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
