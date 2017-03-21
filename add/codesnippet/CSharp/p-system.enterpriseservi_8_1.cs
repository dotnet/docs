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
