   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_input.wsdl" );
   Console::WriteLine( "Total Number of bindings defined are: {0}", myServiceDescription->Bindings->Count );
   myBinding = myServiceDescription->Bindings[ 0 ];

   // Remove the first binding in the collection.
   myServiceDescription->Bindings->Remove( myBinding );
   Console::WriteLine( "Successfully removed binding {0}", myBinding->Name );
   Console::WriteLine( "Total Number of bindings defined now are: {0}", myServiceDescription->Bindings->Count );
   myServiceDescription->Write( "MathService_temp.wsdl" );

   // Add binding to the ServiceDescription instance.
   myServiceDescription->Bindings->Add( myBinding );

   if ( myServiceDescription->Bindings->Contains( myBinding ) )
      Console::WriteLine( "Successfully added binding {0}", myBinding->Name );

   Console::WriteLine( "Binding was added at index {0}", myServiceDescription->Bindings->IndexOf( myBinding ) );
   Console::WriteLine( "Total Number of bindings defined now are: {0}", myServiceDescription->Bindings->Count );
   myServiceDescription->Write( "MathService_temp1.wsdl" );