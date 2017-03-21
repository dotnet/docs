        // Parse an XSD gYearMonth to create a SoapYearMonth object.
        // The time zone of this object is -08:00.
        string xsdYearMonth = "2003-11-08:00";
        SoapYearMonth yearMonth = SoapYearMonth.Parse(xsdYearMonth);