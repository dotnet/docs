   // Parse an XSD formatted string to create a SoapNonPositiveInteger
   // object.
   String^ xsdIntegerString = L"-13";
   SoapNonPositiveInteger^ xsdInteger =
      SoapNonPositiveInteger::Parse( xsdIntegerString );