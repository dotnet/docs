        // Parse an XSD gDay to create a SoapDay object.
        // The time zone of this object is +08:00.
        string xsdDay = "---30+08:00";
        SoapDay day = SoapDay.Parse(xsdDay);