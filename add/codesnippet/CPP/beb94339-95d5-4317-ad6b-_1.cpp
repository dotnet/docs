   // Print the XML namespace for a method invocation and its
   // response.
   System::Reflection::MethodBase^ getHelloMethod =
      ExampleNamespace::ExampleClass::typeid->GetMethod( L"GetHello" );
   String^ methodCallXmlNamespace =
      SoapServices::GetXmlNamespaceForMethodCall( getHelloMethod );
   String^ methodResponseXmlNamespace =
      SoapServices::GetXmlNamespaceForMethodResponse( getHelloMethod );
   Console::WriteLine( L"The XML namespace for the invocation of the method "
   L"GetHello in ExampleClass is {0}.", methodResponseXmlNamespace );
   Console::WriteLine( L"The XML namespace for the response of the method "
   L"GetHello in ExampleClass is {0}.", methodCallXmlNamespace );