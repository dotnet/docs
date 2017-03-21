        // Create a SoapNegativeInteger object.
        SoapNegativeInteger xsdInteger = 
            new SoapNegativeInteger();
        xsdInteger.Value = -14; 
        Console.WriteLine(
            "The value of the SoapNegativeInteger object is {0}.", 
            xsdInteger.ToString());