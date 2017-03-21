        string interopTypeXmlElementName = 
            "ExampleClassElementName";
        string interopTypeXmlNamespace = 
            "http://example.org/ExampleXmlNamespace";
        Type interopType = SoapServices.GetInteropTypeFromXmlElement(
            interopTypeXmlElementName, 
            interopTypeXmlNamespace);
        Console.WriteLine("The interop type is {0}.", interopType);

        string interopTypeXmlTypeName = 
            "ExampleXmlTypeName";
        string interopTypeXmlTypeNamespace = 
            "http://example.org/ExampleXmlTypeNamespace";
        interopType = SoapServices.GetInteropTypeFromXmlType(
            interopTypeXmlTypeName, interopTypeXmlTypeNamespace);
        Console.WriteLine("The interop type is {0}.", interopType);