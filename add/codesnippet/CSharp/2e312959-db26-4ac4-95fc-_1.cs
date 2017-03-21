        // Create a SoapNonPositiveInteger object.
        decimal decimalValue = -14; 
        SoapNonPositiveInteger xsdInteger = 
            new SoapNonPositiveInteger(decimalValue);
        Console.WriteLine(
            "The value of the SoapNonPositiveInteger object is {0}.", 
            xsdInteger.ToString());