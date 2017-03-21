         array<String^>^myURLArray = ChannelServices::GetUrlsForObject( myHelloServer );
         Console::WriteLine( "Number of URLs for the specified Object: {0}", myURLArray->Length );
         for ( int iIndex = 0; iIndex < myURLArray->Length; iIndex++ )
            Console::WriteLine( "URL: {0}", myURLArray[ iIndex ] );