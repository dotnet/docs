        // Create a SoapPositiveInteger object.
        SoapPositiveInteger xsdInteger = 
            new SoapPositiveInteger();
        xsdInteger.Value = 14; 
        Console.WriteLine(
            "The value of the SoapPositiveInteger object is {0}.", 
            xsdInteger.ToString());