using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// The GUID (Globally Unique Identifier) shown below is for example purposes
// only and should be replaced by a GUID that you have generated.
[assembly: ApplicationID("727FC170-1D80-4e89-84CC-22AAB10A6F24")]

public class ApplicationIDAttribute_Value : ServicedComponent
{
    public void ValueExample()
    {
        // Get the ApplicationIDAttribute applied to the assembly.
        ApplicationIDAttribute attribute =
            (ApplicationIDAttribute)Attribute.GetCustomAttribute(
            System.Reflection.Assembly.GetExecutingAssembly(),
            typeof(ApplicationIDAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("ApplicationIDAttribute.Value: {0}",
            attribute.Value);
    }
}
