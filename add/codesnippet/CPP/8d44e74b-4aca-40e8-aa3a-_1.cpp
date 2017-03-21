   //Output chain element information.
   Console::WriteLine( "Chain Element Information" );
   Console::WriteLine( "Number of chain elements: {0}", ch->ChainElements->Count );
   Console::WriteLine( "Chain elements synchronized? {0} {1}", ch->ChainElements->IsSynchronized, Environment::NewLine );
   System::Collections::IEnumerator^ myEnum = ch->ChainElements->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      X509ChainElement ^ element = safe_cast<X509ChainElement ^>(myEnum->Current);
      Console::WriteLine( "Element issuer name: {0}", element->Certificate->Issuer );
      Console::WriteLine( "Element certificate valid until: {0}", element->Certificate->NotAfter );
      Console::WriteLine( "Element certificate is valid: {0}", element->Certificate->Verify() );
      Console::WriteLine( "Element error status length: {0}", element->ChainElementStatus->Length );
      Console::WriteLine( "Element information: {0}", element->Information );
      Console::WriteLine( "Number of element extensions: {0}{1}", element->Certificate->Extensions->Count, Environment::NewLine );
      if ( ch->ChainStatus->Length > 1 )
      {
         for ( int index = 0; index < element->ChainElementStatus->Length; index++ )
         {
            Console::WriteLine( element->ChainElementStatus[ index ].Status );
            Console::WriteLine( element->ChainElementStatus[ index ].StatusInformation );
         }
      }
   }

   store->Close();