        // Create a SoapAnyUri object.
        SoapAnyUri anyUri = new SoapAnyUri();
        anyUri.Value = "http://localhost:8080/WebService"; 
        Console.WriteLine(
            "The value of the SoapAnyUri object is {0}.", 
            anyUri.ToString());