        // Get the XML type name and the XML type namespace for 
        // an Interop type.
        string xmlTypeName;
        string xmlTypeNamespace;
        isSoapTypeAttribute =
            SoapServices.GetXmlTypeForInteropType(
            typeof(ExampleNamespace.ExampleClass), 
            out xmlTypeName, out xmlTypeNamespace);

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

        // Print the XML type name and the XML type namespace.
        Console.WriteLine(
            "The XML type for the type " +
            "ExampleNamespace.ExampleClass is {0}.",
            xmlTypeName);
        Console.WriteLine(
            "The XML type namespace for the type " +
            "ExampleNamespace.ExampleClass is {0}.",
            xmlTypeNamespace);