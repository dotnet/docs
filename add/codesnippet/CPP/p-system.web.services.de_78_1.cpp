   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MimeContentSample_cpp.wsdl" );

   // Get the Binding.
   Binding^ myBinding = myServiceDescription->Bindings[ "b1" ];

   // Get the first OperationBinding.
   OperationBinding^ myOperationBinding = myBinding->Operations[ 0 ];
   OutputBinding^ myOutputBinding = myOperationBinding->Output;
   ServiceDescriptionFormatExtensionCollection ^ myServiceDescriptionFormatExtensionCollection = myOutputBinding->Extensions;

   // Find all MimeContentBinding objects in extensions.
   array<MimeContentBinding^>^myMimeContentBindings = (array<MimeContentBinding^>^)myServiceDescriptionFormatExtensionCollection->FindAll( MimeContentBinding::typeid );

   // Enumerate the array and display MimeContentBinding properties.
   IEnumerator^ myEnum = myMimeContentBindings->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      MimeContentBinding^ myMimeContentBinding = safe_cast<MimeContentBinding^>(myEnum->Current);
      Console::WriteLine( "Type: {0}", myMimeContentBinding->Type );
      Console::WriteLine( "Part: {0}", myMimeContentBinding->Part );
   }