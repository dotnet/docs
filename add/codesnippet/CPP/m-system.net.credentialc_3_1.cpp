      // Create a webrequest with the specified url.
      WebRequest^ myWebRequest = WebRequest::Create( url );
      myWebRequest->Credentials = myCredentialCache;
      Console::WriteLine( "\nLinked CredentialCache to your request." );
      // Send the request and wait for response.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();

      // Process response here.

      Console::Write( "Response received successfully." );
      
      // Call 'Remove' method to dispose credentials for current Uri as not required further.
      myCredentialCache->Remove( myWebRequest->RequestUri, "Basic" );
      Console::WriteLine( "\nYour credentials have now been removed from the program's CredentialCache" );
      myWebResponse->Close();