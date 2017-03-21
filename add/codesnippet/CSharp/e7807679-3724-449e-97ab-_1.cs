        // Extract a CLR namespace and assembly name from an XML namespace.
        string typeNamespace;
        string assemblyName;
        SoapServices.DecodeXmlNamespaceForClrTypeNamespace(xmlNamespace,
            out typeNamespace, out assemblyName);
        Console.WriteLine("The name of the CLR namespace is {0}.", 
            typeNamespace);
        Console.WriteLine("The name of the CLR assembly is {0}.", 
            assemblyName);