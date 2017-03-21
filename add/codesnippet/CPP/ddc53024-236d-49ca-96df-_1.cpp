   // Parse an XSD formatted string to create a SoapNonNegativeInteger
   // object.
   String^ xsdIntegerString = L"+13";
   SoapNonNegativeInteger^ xsdInteger = SoapNonNegativeInteger::Parse(
      xsdIntegerString );