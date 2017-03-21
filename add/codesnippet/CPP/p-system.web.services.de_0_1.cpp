   ServiceDescription^ myServiceDescription = gcnew ServiceDescription;
   myServiceDescription = ServiceDescription::Read( "ServiceDescription_Imports_Input_CS.wsdl" );
   ImportCollection^ myImportCollection = myServiceDescription->Imports;

   // Create an Import.
   Import^ myImport = gcnew Import;
   myImport->Namespace = myServiceDescription->TargetNamespace;

   // Set the location for the Import.
   myImport->Location = "http://www.contoso.com/";
   myImportCollection->Add( myImport );
   myServiceDescription->Write( "ServiceDescription_Imports_Output_CS.wsdl" );
   myImportCollection->Clear();
   myServiceDescription = ServiceDescription::Read( "ServiceDescription_Imports_Output_CS.wsdl" );
   myImportCollection = myServiceDescription->Imports;
   Console::WriteLine( "The Import elements added to the ImportCollection are: " );
   for ( int i = 0; i < myImportCollection->Count; i++ )
   {
      Console::WriteLine( "{0}. {1}", (i + 1), myImportCollection[ i ]->Location );
   }