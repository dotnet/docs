        // Create a SoapNonPositiveInteger object.
        SoapNonPositiveInteger xsdInteger = 
            new SoapNonPositiveInteger();
        xsdInteger.Value = -14; 
        Console.WriteLine(
            "The value of the SoapNonPositiveInteger object is {0}.", 
            xsdInteger.ToString());