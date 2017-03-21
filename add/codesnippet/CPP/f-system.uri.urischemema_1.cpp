         Uri^ address3 = gcnew Uri( "mailto:user@contoso.com?subject=uri" );
         if ( address3->Scheme == Uri::UriSchemeMailto )
         {
            Console::WriteLine( "Uri is an email address" );
         }