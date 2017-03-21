      // Obtain the WebHeaderCollection instance containing the header name/value pair from the response.
      WebHeaderCollection^ myWebHeaderCollection = myWebClient->ResponseHeaders;
      Console::WriteLine( "\nDisplaying the response headers\n" );
      
      // Loop through the ResponseHeaders and display the header name/value pairs.
      for ( int i = 0; i < myWebHeaderCollection->Count; i++ )
      {
         Console::WriteLine( "\t{0} = {1}", myWebHeaderCollection->GetKey( i ),
            myWebHeaderCollection->Get( i ) );
      }