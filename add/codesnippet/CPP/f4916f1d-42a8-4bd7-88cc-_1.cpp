   // Get the XML type name and the XML type namespace for
   // an Interop type.
   String^ xmlTypeName;
   String^ xmlTypeNamespace;
   isSoapTypeAttribute = SoapServices::GetXmlTypeForInteropType( ExampleNamespace::ExampleClass::typeid,xmlTypeName,xmlTypeNamespace );
   
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
   
   // Print the XML type name and the XML type namespace.
   Console::WriteLine( L"The XML type for the type "
   L"ExampleNamespace.ExampleClass is {0}.", xmlTypeName );
   Console::WriteLine( L"The XML type namespace for the type "
   L"ExampleNamespace.ExampleClass is {0}.", xmlTypeNamespace );