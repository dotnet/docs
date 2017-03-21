        // Create a SoapNormalizedString object.
        string testString = "one two"; 
        SoapNormalizedString normalized = 
            new SoapNormalizedString(testString);
        Console.WriteLine(
            "The value of the SoapNormalizedString object is {0}.", 
            normalized.ToString());