        // Create a SoapQName object.
        string name = "SomeName";
        SoapQName qName = new SoapQName(name);
        Console.WriteLine(
            "The value of the SoapQName object is \"{0}\".", 
            qName.ToString());