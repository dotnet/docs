         Uri^ address1 = gcnew Uri( "http://www.contoso.com/index.htm#search" );
         Console::WriteLine( "address 1 {0} a valid scheme name",
            Uri::CheckSchemeName( address1->Scheme ) ? (String^)" has" : " does not have" );
         if ( address1->Scheme == Uri::UriSchemeHttp )
         {
            Console::WriteLine( "Uri is HTTP type" );
         }

         Console::WriteLine( address1->HostNameType );