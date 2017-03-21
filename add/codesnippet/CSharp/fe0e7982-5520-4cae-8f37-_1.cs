        // Create a SoapQName object.
        string key = "tns";
        string name = "SomeName";
        SoapQName qName = new SoapQName(key, name);
        Console.WriteLine(
            "The value of the SoapQName object is \"{0}\".", 
            qName.ToString());