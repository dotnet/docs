   // Parse an XSD formatted string to create a SoapQName object.
   String^ xsdQName = L"tns:SomeName";
   SoapQName^ qName = SoapQName::Parse( xsdQName );