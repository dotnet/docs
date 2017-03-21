        // Create a SoapInteger object.
        decimal decimalValue = -14; 
        SoapInteger xsdInteger = new SoapInteger(decimalValue);
        Console.WriteLine(
            "The value of the SoapInteger object is {0}.", 
            xsdInteger.ToString());