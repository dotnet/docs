        // Create a SoapNonNegativeInteger object.
        decimal decimalValue = +14; 
        SoapNonNegativeInteger xsdInteger = 
            new SoapNonNegativeInteger(decimalValue);
        Console.WriteLine(
            "The value of the SoapNonNegativeInteger object is {0}.", 
            xsdInteger.ToString());