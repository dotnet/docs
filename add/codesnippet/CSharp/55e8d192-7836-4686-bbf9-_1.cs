        // Create a SoapNegativeInteger object.
        decimal decimalValue = -14; 
        SoapNegativeInteger xsdInteger = 
            new SoapNegativeInteger(decimalValue);
        Console.WriteLine(
            "The value of the SoapNegativeInteger object is {0}.", 
            xsdInteger.ToString());