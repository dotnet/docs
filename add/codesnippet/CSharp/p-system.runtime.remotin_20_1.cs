        // Print the XML namespace for the CLR types 
        // that have an assembly but no common language runtime namespace.
        Console.WriteLine(
            "The XML namespace for the CLR types " +
            "that have an assembly but no namespace, is {0}.",
            SoapServices.XmlNsForClrTypeWithAssembly);