   // Parse an XSD formatted string to create a SoapPositiveInteger
   // object.
   String^ xsdIntegerString = L"+13";
   SoapPositiveInteger^ xsdInteger =
      SoapPositiveInteger::Parse( xsdIntegerString );