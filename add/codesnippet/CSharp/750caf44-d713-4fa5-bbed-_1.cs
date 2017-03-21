        // Parse an XSD formatted string to create a SoapNonPositiveInteger 
        // object.
        string xsdIntegerString = "-13";
        SoapNonPositiveInteger xsdInteger = 
            SoapNonPositiveInteger.Parse(xsdIntegerString);