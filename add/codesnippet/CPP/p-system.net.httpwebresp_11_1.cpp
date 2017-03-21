      // Creates an HttpWebRequest for the specified URL.
      HttpWebRequest^ myHttpWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( url ));
      
      // Sends the HttpWebRequest and waits for response.
      HttpWebResponse^ myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());
      
      // Displays all the headers present in the response received from the URI.
      Console::WriteLine( "\r\nThe following headers were received in the response:" );
      
      // Displays each header and its key associated with the response.
      for ( int i = 0; i < myHttpWebResponse->Headers->Count; ++i )
         Console::WriteLine( "\nHeader Name: {0}, Value : {1}",
            myHttpWebResponse->Headers->Keys[ i ],
            myHttpWebResponse->Headers[ (System::Net::HttpRequestHeader)i ] );
      
      // Releases the resources of the response.
      myHttpWebResponse->Close();