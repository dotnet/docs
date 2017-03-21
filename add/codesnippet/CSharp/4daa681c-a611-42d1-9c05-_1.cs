        // Create a SoapPositiveInteger object.
        decimal decimalValue = 14; 
        SoapPositiveInteger xsdInteger = 
            new SoapPositiveInteger(decimalValue);
        Console.WriteLine(
            "The value of the SoapPositiveInteger object is {0}.", 
            xsdInteger.ToString());