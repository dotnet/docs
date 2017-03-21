   // Get the SOAP action for the method.
   System::Reflection::MethodBase^ getHelloMethodBase =
      ExampleNamespace::ExampleClass::typeid->GetMethod( L"GetHello" );
   String^ getHelloSoapAction =
      SoapServices::GetSoapActionFromMethodBase( getHelloMethodBase );
   Console::WriteLine( L"The SOAP action for the method "
   L"ExampleClass.GetHello is {0}.", getHelloSoapAction );
   bool isSoapActionValid =
      SoapServices::IsSoapActionValidForMethodBase(
         getHelloSoapAction, getHelloMethodBase );
   if ( isSoapActionValid )
   {
      Console::WriteLine( L"The SOAP action, {0}, "
      L"is valid for ExampleClass.GetHello", getHelloSoapAction );
   }
   else
   {
      Console::WriteLine( L"The SOAP action, {0}, "
      L"is not valid for ExampleClass.GetHello", getHelloSoapAction );
   }
   
   // Register the SOAP action for the GetHello method.
   SoapServices::RegisterSoapActionForMethodBase( getHelloMethodBase );
   
   // Get the type and the method names encoded into the SOAP action.
   String^ encodedTypeName;
   String^ encodedMethodName;
   SoapServices::GetTypeAndMethodNameFromSoapAction(
      getHelloSoapAction,encodedTypeName,encodedMethodName );
   Console::WriteLine( L"The type name encoded in this SOAP action is {0}.",
      encodedTypeName );
   Console::WriteLine( L"The method name encoded in this SOAP action is {0}.",
      encodedMethodName );