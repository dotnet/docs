// <snippet0>
using System;
using System.EnterpriseServices;
using System.Reflection;

// References:
// System.EnterpriseServices

// <snippet1>
[assembly: ApplicationQueuing]
// </snippet1>

public class ApplicationQueuingExample : ServicedComponent
{
    public void ApplicationQueuingAttribute_Enabled()
    {
        // <snippet2>
        // This example code requires that an ApplicationQueuing attribute be
        // applied to the assembly, as shown below:
        // [assembly: ApplicationQueuing]

        // Get the ApplicationQueuingAttribute applied to the assembly.
        ApplicationQueuingAttribute attribute =
            (ApplicationQueuingAttribute)Attribute.GetCustomAttribute(
            System.Reflection.Assembly.GetExecutingAssembly(),
            typeof(ApplicationQueuingAttribute),
            false);

        // Display the current value of the attribute's Enabled property.
        Console.WriteLine("ApplicationQueuingAttribute.Enabled: {0}",
            attribute.Enabled);

        // Set the Enabled property value of the attribute.
        attribute.Enabled = false;

        // Display the new value of the attribute's Enabled property.
        Console.WriteLine("ApplicationQueuingAttribute.Enabled: {0}",
            attribute.Enabled);

        // </snippet2>
    }

    public void ApplicationQueuingAttribute_QueueListenerEnabled()
    {
        // <snippet3>
        // This example code requires that an ApplicationQueuing attribute be
        // applied to the assembly, as shown below:
        // [assembly: ApplicationQueuing]

        // Get the ApplicationQueuingAttribute applied to the assembly.
        ApplicationQueuingAttribute attribute =
            (ApplicationQueuingAttribute)Attribute.GetCustomAttribute(
            System.Reflection.Assembly.GetExecutingAssembly(),
            typeof(ApplicationQueuingAttribute),
            false);

        // Display the current value of the attribute's QueueListenerEnabled
        // property.
        Console.WriteLine(
            "ApplicationQueuingAttribute.QueueListenerEnabled: {0}",
            attribute.Enabled);

        // Set the QueueListenerEnabled property value of the attribute.
        attribute.QueueListenerEnabled = false;

        // Display the new value of the attribute's QueueListenerEnabled
        // property.
        Console.WriteLine(
            "ApplicationQueuingAttribute.QueueListenerEnabled: {0}",
            attribute.QueueListenerEnabled);

        // </snippet3>
    }

    public void ApplicationQueuingAttribute_MaxListenerThreads()
    {
        // <snippet4>
        // This example code requires that an ApplicationQueuing attribute be
        // applied to the assembly, as shown below:
        // [assembly: ApplicationQueuing]

        // Get the ApplicationQueuingAttribute applied to the assembly.
        ApplicationQueuingAttribute attribute =
            (ApplicationQueuingAttribute)Attribute.GetCustomAttribute(
            System.Reflection.Assembly.GetExecutingAssembly(),
            typeof(ApplicationQueuingAttribute),
            false);

        // Display the current value of the attribute's MaxListenerThreads
        // property.
        Console.WriteLine(
            "ApplicationQueuingAttribute.MaxListenerThreads: {0}",
            attribute.MaxListenerThreads);

        // Set the MaxListenerThreads property value of the attribute.
        attribute.MaxListenerThreads = 1;

        // Display the new value of the attribute's MaxListenerThreads
        // property.
        Console.WriteLine(
            "ApplicationQueuingAttribute.MaxListenerThreads: {0}",
            attribute.MaxListenerThreads);

        // </snippet4>
    }
}

// </snippet0>

/*
// Test client
public class TestClient
{
    public static void Main()
    {
        // Create a new instance of the example class.
        ApplicationQueuingExample example =
            new ApplicationQueuingExample();

        // Demonstrate the ApplicationQueuingAttribute properties.
        example.ApplicationQueuingAttribute_Enabled();
        example.ApplicationQueuingAttribute_QueueListenerEnabled();
        example.ApplicationQueuingAttribute_MaxListenerThreads();
    }
}
*/