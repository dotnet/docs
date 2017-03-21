         Uri^ address8 = gcnew Uri( "https://example.contoso.com" );
         if ( address8->Scheme == Uri::UriSchemeHttps )
         {
            Console::WriteLine( "Uri is Https protocol." );
         }