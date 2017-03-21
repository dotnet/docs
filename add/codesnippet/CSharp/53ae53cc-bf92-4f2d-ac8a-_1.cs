        // Convert a CLR namespace and assembly name into an XML namespace.
        string xmlNamespace = 
            SoapServices.CodeXmlNamespaceForClrTypeNamespace(
            "ExampleNamespace", "AssemblyName");
        Console.WriteLine("The name of the XML namespace is {0}.", 
            xmlNamespace);