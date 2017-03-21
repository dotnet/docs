        // Create EllementInformation object.
        ElementInformation elementInfo =
          configSection.ElementInformation;
        // Create a PropertyInformationCollection object.
        PropertyInformationCollection propertyInfoCollection =
          elementInfo.Properties;
        // Create a PropertyInformation object.
        PropertyInformation myPropertyInfo =
          propertyInfoCollection["enabled"];
        // Display the property value.
        Console.WriteLine
          ("anonymousIdentification Section - Enabled: {0}",
          myPropertyInfo.Value);