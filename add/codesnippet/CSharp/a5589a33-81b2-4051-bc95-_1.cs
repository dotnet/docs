        // Parse an XSD formatted string to create a SoapPositiveInteger 
        // object.
        string xsdIntegerString = "+13";
        SoapPositiveInteger xsdInteger = 
            SoapPositiveInteger.Parse(xsdIntegerString);