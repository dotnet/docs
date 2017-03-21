        // Parse an XSD gYear to create a SoapYear object.
        // The time zone of this object is -08:00.
        string xsdYear = "2003-08:00";
        SoapYear year = SoapYear.Parse(xsdYear);