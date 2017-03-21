        // Parse an XSD gTime to create a SoapTime object.
        // The time zone of this object is the current time zone.
        string xsdTime = "12:13:14.123Z";
        SoapTime time = SoapTime.Parse(xsdTime);