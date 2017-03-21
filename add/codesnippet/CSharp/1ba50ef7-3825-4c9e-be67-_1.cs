        // Parse an XSD formatted string to create a SoapBase64Binary object.
        // The string "AgMFBws=" is byte[]{ 2, 3, 5, 7, 11 } expressed in 
        // Base 64 format.
        string xsdBase64Binary = "AgMFBws=";
        SoapBase64Binary base64Binary = 
            SoapBase64Binary.Parse(xsdBase64Binary);