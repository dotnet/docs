   // Parse an XSD formatted string to create a SoapHexBinary object.
   String^ xsdHexBinary = L"3f789ABC";
   SoapHexBinary^ hexBinary = SoapHexBinary::Parse( xsdHexBinary );