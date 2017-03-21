        // Parse an XSD gMonth to create a SoapMonth object.
        // The time zone of this object is +08:00.
        string xsdMonth = "--02--+08:00";
        SoapMonth month = SoapMonth.Parse(xsdMonth);