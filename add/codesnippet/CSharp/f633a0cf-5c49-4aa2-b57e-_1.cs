        // Create a SoapQName object.
        string key = "tns";
        string name = "SomeName";
        string namespaceValue = "http://example.org";
        SoapQName qName = new SoapQName(key, name, namespaceValue);
        Console.WriteLine(
            "The value of the SoapQName object is \"{0}\".", 
            qName.ToString());