         Uri^ address4 = gcnew Uri( "news:123456@contoso.com" );
         if ( address4->Scheme == Uri::UriSchemeNews )
         {
            Console::WriteLine( "Uri is an Internet news group" );
         }