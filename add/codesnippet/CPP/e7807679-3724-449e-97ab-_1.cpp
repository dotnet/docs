   // Extract a CLR namespace and assembly name from an XML namespace.
   String^ typeNamespace;
   String^ assemblyName;
   SoapServices::DecodeXmlNamespaceForClrTypeNamespace(
      xmlNamespace,typeNamespace,assemblyName );
   Console::WriteLine( L"The name of the CLR namespace is {0}.", typeNamespace );
   Console::WriteLine( L"The name of the CLR assembly is {0}.", assemblyName );