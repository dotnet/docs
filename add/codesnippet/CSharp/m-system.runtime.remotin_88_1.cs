        // Create a SoapNonNegativeInteger object.
        SoapNonNegativeInteger xsdInteger = 
            new SoapNonNegativeInteger();
        xsdInteger.Value = +14; 
        Console.WriteLine(
            "The value of the SoapNonNegativeInteger object is {0}.", 
            xsdInteger.ToString());