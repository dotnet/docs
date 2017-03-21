        // Parse an XSD formatted string to create a SoapNonNegativeInteger 
        // object.
        string xsdIntegerString = "+13";
        SoapNonNegativeInteger xsdInteger = 
            SoapNonNegativeInteger.Parse(xsdIntegerString);