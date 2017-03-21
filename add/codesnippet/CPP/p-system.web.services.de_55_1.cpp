   ServiceDescription^ myServiceDescription = gcnew ServiceDescription;
   myServiceDescription = ServiceDescription::Read( "ServiceDescription_Extensions_Input_cs.wsdl" );
   Console::WriteLine( myServiceDescription->Bindings[ 1 ]->Extensions[ 0 ] );
   SoapBinding^ mySoapBinding = gcnew SoapBinding;
   mySoapBinding->Required = true;
   SoapBinding^ mySoapBinding1 = gcnew SoapBinding;
   mySoapBinding1->Required = false;
   myServiceDescription->Extensions->Add( mySoapBinding );
   myServiceDescription->Extensions->Add( mySoapBinding1 );
   System::Collections::IEnumerator^ myEnum = myServiceDescription->Extensions->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      ServiceDescriptionFormatExtension^ myServiceDescriptionFormatExtension = (ServiceDescriptionFormatExtension^)(myEnum->Current);
      Console::WriteLine( "Required: {0}", myServiceDescriptionFormatExtension->Required );
   }

   myServiceDescription->Write( "ServiceDescription_Extensions_Output_cs.wsdl" );
   myServiceDescription->RetrievalUrl = "http://www.contoso.com/";
   Console::WriteLine( "Retrieval URL is: {0}", myServiceDescription->RetrievalUrl );