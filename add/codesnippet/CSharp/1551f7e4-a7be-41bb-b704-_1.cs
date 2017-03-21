        // Get the XML element name and the XML namespace for 
        // an Interop type.
        string xmlElement;
        bool isSoapTypeAttribute =
            SoapServices.GetXmlElementForInteropType(
            typeof(ExampleNamespace.ExampleClass), 
            out xmlElement, out xmlNamespace);

        // Print whether the requested value was flagged 
        // with a SoapTypeAttribute.
        if (isSoapTypeAttribute)
        {
            Console.WriteLine(
                "The requested value was flagged " +
                "with the SoapTypeAttribute.");
        }
        else 
        {
            Console.WriteLine(
                "The requested value was not flagged " +
                "with the SoapTypeAttribute.");
        }

        // Print the XML element and the XML namespace.
        Console.WriteLine(
            "The XML element for the type " +
            "ExampleNamespace.ExampleClass is {0}.",
            xmlElement);
        Console.WriteLine(
            "The XML namespace for the type " +
            "ExampleNamespace.ExampleClass is {0}.",
            xmlNamespace);