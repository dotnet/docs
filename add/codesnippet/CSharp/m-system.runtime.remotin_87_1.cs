        // Parse an XSD dateTime to create a DateTime object.
        string xsdDateTime = "2003-02-04T13:58:59.9999999+03:00";
        DateTime dateTime = SoapDateTime.Parse(xsdDateTime);