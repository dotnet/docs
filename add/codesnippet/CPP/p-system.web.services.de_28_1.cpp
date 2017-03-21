   // Read from an existing wsdl file.
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MapToProperty_cpp.wsdl" );

   // Get the existing binding
   Binding^ myBinding = myServiceDescription->Bindings[ "MyWebServiceSoap" ];
   OperationBinding^ myOperationBinding = (OperationBinding^)(myBinding->Operations[ 0 ]);
   InputBinding^ myInputBinding = myOperationBinding->Input;

   // Get the 'SoapHeaderBinding' instance from 'myInputBinding'.
   SoapHeaderBinding^ mySoapHeaderBinding = (SoapHeaderBinding^)(myInputBinding->Extensions[ 1 ]);
   if ( mySoapHeaderBinding->MapToProperty )
      Console::WriteLine( "'SoapHeaderBinding' instance is mapped to a specific property in proxy generated class" );
   else
      Console::WriteLine( "'SoapHeaderBinding' instance is not mapped to a specific property in proxy generated class" );