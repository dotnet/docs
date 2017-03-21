   // Parse an XSD gMonth to create a SoapMonth object.
   // The timezone of this object is +08:00.
   String^ xsdMonth = "--02--+08:00";
   SoapMonth^ month = SoapMonth::Parse( xsdMonth );