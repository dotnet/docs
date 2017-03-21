   // Get the currently registered type for the given XML element
   // and namespace.
   String^ registeredXmlElementName = L"ExampleClassElementName";
   String^ registeredXmlNamespace =
      L"http://example.org/ExampleXmlNamespace";
   Type^ registeredType =
      SoapServices::GetInteropTypeFromXmlElement(
         registeredXmlElementName, registeredXmlNamespace );
   Console::WriteLine( L"The registered interop type is {0}.",
      registeredType );
   
   // Register a new type for the XML element and namespace.
   SoapServices::RegisterInteropXmlElement(
      registeredXmlElementName,registeredXmlNamespace,String::typeid );
   
   // Get the currently registered type for the given XML element
   // and namespace.
   registeredType = SoapServices::GetInteropTypeFromXmlElement(
      registeredXmlElementName,registeredXmlNamespace );
   Console::WriteLine( L"The registered interop type is {0}.",
      registeredType );