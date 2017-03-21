        // Create a SoapAnyUri object.
        string anyUriValue = "http://localhost:8080/WebService"; 
        SoapAnyUri anyUri = new SoapAnyUri(anyUriValue);
        Console.WriteLine(
            "The value of the SoapAnyUri object is {0}.", 
            anyUri.ToString());