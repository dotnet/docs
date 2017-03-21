      Uri^ ourUri = gcnew Uri( url );
      
      // Create a 'WebRequest' object with the specified url.
      WebRequest^ myWebRequest = WebRequest::Create( url );
      
      // Send the 'WebRequest' and wait for response.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();
      
      // Use "ResponseUri" property to get the actual Uri from where the response was attained.
      if ( ourUri->Equals( myWebResponse->ResponseUri ) )
      {
         Console::WriteLine( "\nRequest Url : {0} was not redirected", url );
      }
      else
      {
         Console::WriteLine( "\nRequest Url : {0} was redirected to {1}", url, myWebResponse->ResponseUri );
      }
      
      // Release resources of response object.
      myWebResponse->Close();