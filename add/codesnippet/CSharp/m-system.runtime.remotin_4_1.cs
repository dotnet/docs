        // Determine whether an XML namespace represents a CLR namespace.
        string clrNamespace = SoapServices.XmlNsForClrType;
        if (SoapServices.IsClrTypeNamespace(clrNamespace))
        {
            Console.WriteLine(
                "The namespace {0} is a CLR namespace.",
                clrNamespace);
        }
        else 
        {
            Console.WriteLine(
                "The namespace {0} is not a CLR namespace.",
                clrNamespace);
        }