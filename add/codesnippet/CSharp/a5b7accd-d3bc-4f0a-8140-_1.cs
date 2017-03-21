        // Create a SoapHexBinary object.
        byte[] bytes = new byte[]{ 2, 3, 5, 7, 11 };
        SoapHexBinary hexBinary = new SoapHexBinary(bytes);
        Console.WriteLine("The SoapHexBinary object is {0}.", 
            hexBinary.ToString());