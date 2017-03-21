   // Parse an XSD formatted string to create a SoapAnyUri object.
   String^ xsdAnyUri = L"http://localhost:8080/WebService";
   SoapAnyUri^ anyUri = SoapAnyUri::Parse( xsdAnyUri );