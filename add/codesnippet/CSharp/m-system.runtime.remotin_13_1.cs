        // Create a SoapHexBinary object.
        SoapHexBinary hexBinary = new SoapHexBinary();
        hexBinary.Value = new byte[]{ 2, 3, 5, 7, 11 };
        Console.WriteLine("The SoapHexBinary object is {0}.", 
            hexBinary.ToString());