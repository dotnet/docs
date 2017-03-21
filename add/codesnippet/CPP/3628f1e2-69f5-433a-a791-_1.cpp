   // Parse an XSD formatted string to create a SoapNegativeInteger
   // object.
   String^ xsdIntegerString = L"-13";
   SoapNegativeInteger^ xsdInteger = SoapNegativeInteger::Parse(
      xsdIntegerString );