      // Create a 'WebRequest' object with the specified url.
      WebRequest^ myWebRequest = WebRequest::Create( "http://www.contoso.com" );
      // Send the 'WebRequest' and wait for response.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();
      
      // Process the response here.
      Console::WriteLine( "\nResponse Received::Trying to Close the response stream.." );
      // Release resources of response Object*.
      myWebResponse->Close();
      Console::WriteLine( "\nResponse Stream successfully closed" );