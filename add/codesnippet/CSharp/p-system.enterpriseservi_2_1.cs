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
