   String^ interopTypeXmlElementName = L"ExampleClassElementName";
   String^ interopTypeXmlNamespace = L"http://example.org/ExampleXmlNamespace";
   Type^ interopType = SoapServices::GetInteropTypeFromXmlElement(
      interopTypeXmlElementName, interopTypeXmlNamespace );
   Console::WriteLine( L"The interop type is {0}.", interopType );
   String^ interopTypeXmlTypeName = L"ExampleXmlTypeName";
   String^ interopTypeXmlTypeNamespace =
      L"http://example.org/ExampleXmlTypeNamespace";
   interopType = SoapServices::GetInteropTypeFromXmlType(
      interopTypeXmlTypeName,interopTypeXmlTypeNamespace );
   Console::WriteLine( L"The interop type is {0}.", interopType );