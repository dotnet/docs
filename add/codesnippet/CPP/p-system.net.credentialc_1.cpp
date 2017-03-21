      // Ensure Directory Security settings for default web site in IIS is "Windows Authentication".
      String^ url = "http://localhost";

      // Create a 'HttpWebRequest' object with the specified url.
      HttpWebRequest^ myHttpWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( url ));

      // Assign the credentials of the logged in user or the user being impersonated.
      myHttpWebRequest->Credentials = CredentialCache::DefaultCredentials;

      // Send the 'HttpWebRequest' and wait for response.
      HttpWebResponse^ myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());
      Console::WriteLine( "Authentication successful" );
      Console::WriteLine( "Response received successfully" );
