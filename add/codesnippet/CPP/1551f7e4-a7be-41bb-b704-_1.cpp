   // Get the XML element name and the XML namespace for
   // an Interop type.
   String^ xmlElement;
   bool isSoapTypeAttribute = SoapServices::GetXmlElementForInteropType(
      ExampleNamespace::ExampleClass::typeid,xmlElement,xmlNamespace );
   
   // Print whether the requested value was flagged
   // with a SoapTypeAttribute.
   if ( isSoapTypeAttribute )
   {
      Console::WriteLine( L"The requested value was flagged "
      L"with the SoapTypeAttribute." );
   }
   else
   {
      Console::WriteLine( L"The requested value was not flagged "
      L"with the SoapTypeAttribute." );
   }
   
   // Print the XML element and the XML namespace.
   Console::WriteLine( L"The XML element for the type "
   L"ExampleNamespace.ExampleClass is {0}.", xmlElement );
   Console::WriteLine( L"The XML namespace for the type "
   L"ExampleNamespace.ExampleClass is {0}.", xmlNamespace );