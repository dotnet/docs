   // Get the method base object for the GetHello method.
   System::Reflection::MethodBase^ methodBase = 
     ExampleNamespace::ExampleClass::typeid->GetMethod( L"GetHello" );
   
   // Print its current SOAP action.
   Console::WriteLine( L"The SOAP action for the method "
      L"ExampleClass.GetHello is {0}.",
      SoapServices::GetSoapActionFromMethodBase( methodBase ) );
   
   // Set the SOAP action of the GetHello method to a new value.
   String^ newSoapAction = L"http://example.org/ExampleSoapAction#NewSoapAction";
   SoapServices::RegisterSoapActionForMethodBase( methodBase, newSoapAction );
   Console::WriteLine( L"The SOAP action for the method "
      L"ExampleClass.GetHello is {0}.",
      SoapServices::GetSoapActionFromMethodBase( methodBase ) );
   
   // Reset the SOAP action of the GetHello method to its default
   // value, which is determined using its SoapMethod attribute.
   SoapServices::RegisterSoapActionForMethodBase( methodBase );
   Console::WriteLine( L"The SOAP action for the method "
      L"ExampleClass.GetHello is {0}.",
      SoapServices::GetSoapActionFromMethodBase( methodBase ) );