   // Parse an XSD gYearMonth to create a SoapYearMonth object.
   // The timezone of this object is -08:00.
   String^ xsdYearMonth = "2003-11-08:00";
   SoapYearMonth^ yearMonth = SoapYearMonth::Parse( xsdYearMonth );