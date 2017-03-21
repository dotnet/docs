   // Parse an XSD formatted string to create a SoapBase64Binary object.
   // The string "AgMFBws=" is byte[]{ 2, 3, 5, 7, 11 } expressed in
   // Base 64 format.
   String^ xsdBase64Binary = L"AgMFBws=";
   SoapBase64Binary^ base64Binary = SoapBase64Binary::Parse( xsdBase64Binary );