// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// <snippet1>

// Note: Access checks must be performed at the component level to allow access
// to private components.
[assembly: ApplicationAccessControl(false,
AccessChecksLevel=AccessChecksLevelOption.ApplicationComponent)]

[PrivateComponent]
public class PrivateComponentAttribute_Example : ServicedComponent
{
    public void Example()
    {
        // Display some output.
        Console.WriteLine("Private component called successfully.");
    }
}
// </snippet1>

public class PrivateComponentAttribute_Test : ServicedComponent
{
    public void Test()
    {
        // Create a new instance of the example class.
        PrivateComponentAttribute_Example example =
            new PrivateComponentAttribute_Example();

        // Call a method on the class.
        example.Example();
    }
}
// </snippet0>
