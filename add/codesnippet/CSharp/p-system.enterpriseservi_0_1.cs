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
