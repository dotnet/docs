        // Get the currently registered type for the given XML element 
        // and namespace.
        string registeredXmlTypeName = 
            "ExampleXmlTypeName";
        string registeredXmlTypeNamespace = 
            "http://example.org/ExampleXmlTypeNamespace";
        registeredType = 
            SoapServices.GetInteropTypeFromXmlType(
            registeredXmlTypeName, 
            registeredXmlTypeNamespace);
        Console.WriteLine(
            "The registered interop type is {0}.",
            registeredType);

        // Register a new type for the XML element and namespace.
        SoapServices.RegisterInteropXmlType(
            registeredXmlTypeName,
            registeredXmlTypeNamespace, 
            typeof(String));

        // Get the currently registered type for the given XML element 
        // and namespace.
        registeredType = 
            SoapServices.GetInteropTypeFromXmlType(
            registeredXmlTypeName, 
            registeredXmlTypeNamespace);
        Console.WriteLine(
            "The registered interop type is {0}.",
            registeredType);