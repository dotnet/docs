   // Convert a CLR namespace and assembly name into an XML namespace.
   String^ xmlNamespace = SoapServices::CodeXmlNamespaceForClrTypeNamespace(
      L"ExampleNamespace", L"AssemblyName" );
   Console::WriteLine( L"The name of the XML namespace is {0}.", xmlNamespace );