         String^ address = "www.contoso.com";
         String^ uriString = String::Format( "{0}{1}{2}",
            Uri::UriSchemeHttp, Uri::SchemeDelimiter, address );

#if OLDMETHOD           
         Uri^ result;
         if ( Uri::TryParse( uriString, false, false, result ) == true )
         {
            Console::WriteLine( "{0} is a valid Uri", result );
         }
         else
         {
            Console::WriteLine( "Uri not created" );
         }
#endif
         Uri ^result = gcnew Uri(uriString);
         if (result->IsWellFormedOriginalString())
             Console::WriteLine("{0} is a well formed Uri", uriString);
         else
             Console::WriteLine("{0} is not a well formed Uri", uriString);