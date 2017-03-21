        // Get the currently registered type for the given XML element 
        // and namespace.
        string registeredXmlElementName = 
            "ExampleClassElementName";
        string registeredXmlNamespace = 
            "http://example.org/ExampleXmlNamespace";
        Type registeredType = 
            SoapServices.GetInteropTypeFromXmlElement(
            registeredXmlElementName, 
            registeredXmlNamespace);
        Console.WriteLine(
            "The registered interop type is {0}.",
            registeredType);

        // Register a new type for the XML element and namespace.
        SoapServices.RegisterInteropXmlElement(
            registeredXmlElementName,
            registeredXmlNamespace, 
            typeof(String));

        // Get the currently registered type for the given XML element 
        // and namespace.
        registeredType = 
            SoapServices.GetInteropTypeFromXmlElement(
            registeredXmlElementName, 
            registeredXmlNamespace);
        Console.WriteLine(
            "The registered interop type is {0}.",
            registeredType);