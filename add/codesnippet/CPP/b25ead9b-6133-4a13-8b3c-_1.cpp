   // Get the currently registered type for the given XML element
   // and namespace.
   String^ registeredXmlTypeName = L"ExampleXmlTypeName";
   String^ registeredXmlTypeNamespace =
      L"http://example.org/ExampleXmlTypeNamespace";
   registeredType = SoapServices::GetInteropTypeFromXmlType(
      registeredXmlTypeName, registeredXmlTypeNamespace );
   Console::WriteLine( L"The registered interop type is {0}.",
      registeredType );
   
   // Register a new type for the XML element and namespace.
   SoapServices::RegisterInteropXmlType( registeredXmlTypeName,
      registeredXmlTypeNamespace,String::typeid );
   
   // Get the currently registered type for the given XML element
   // and namespace.
   registeredType = SoapServices::GetInteropTypeFromXmlType(
      registeredXmlTypeName,registeredXmlTypeNamespace );
   Console::WriteLine( L"The registered interop type is {0}.",
      registeredType );