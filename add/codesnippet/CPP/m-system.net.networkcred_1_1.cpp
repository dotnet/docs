      // Call the onstructor  to create an instance of NetworkCredential with the
      // specified user name and password.
      NetworkCredential^ myCredentials = gcnew NetworkCredential( username,passwd );
      
      // Create a WebRequest with the specified URL.
      WebRequest^ myWebRequest = WebRequest::Create( url );
      myCredentials->Domain = domain;
      myWebRequest->Credentials = myCredentials;
      Console::WriteLine( "\n\nCredentials Domain : {0} , UserName : {1} , Password : {2}",
         myCredentials->Domain, myCredentials->UserName, myCredentials->Password );
      Console::WriteLine( "\n\nRequest to Url is sent.Waiting for response..." );
      
      // Send the request and wait for a response.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();
      
      // Process the response.
      Console::WriteLine( "\nResponse received successfully." );
      
      // Release the resources of the response object.
      myWebResponse->Close();