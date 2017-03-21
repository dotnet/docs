        // Create a SoapBase64Binary object.
        byte[] bytes = new byte[]{ 2, 3, 5, 7, 11 };
        SoapBase64Binary base64Binary = new SoapBase64Binary(bytes);
        Console.WriteLine("The SoapBase64Binary object is {0}.", 
            base64Binary.ToString());