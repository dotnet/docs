        // Create a SoapBase64Binary object.
        SoapBase64Binary base64Binary = new SoapBase64Binary();
        base64Binary.Value = new byte[]{ 2, 3, 5, 7, 11, 0, 5 };
        Console.WriteLine("The SoapBase64Binary object is {0}.", 
            base64Binary.ToString());