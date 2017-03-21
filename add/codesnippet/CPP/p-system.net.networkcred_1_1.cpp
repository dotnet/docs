      // Create an empty instance of the NetworkCredential class.
      NetworkCredential^ myCredentials = gcnew NetworkCredential( "","","" );
      myCredentials->Domain = domain;
      myCredentials->UserName = username;
      myCredentials->Password = passwd;
      
      // Create a WebRequest with the specified URL.
      WebRequest^ myWebRequest = WebRequest::Create( url );
      myWebRequest->Credentials = myCredentials;
      Console::WriteLine( "\n\nUser Credentials:- Domain : {0} , UserName : {1} , Password : {2}",
         myCredentials->Domain, myCredentials->UserName, myCredentials->Password );
      
      // Send the request and wait for a response.
      Console::WriteLine( "\n\nRequest to Url is sent.Waiting for response...Please wait ..." );
      WebResponse^ myWebResponse = myWebRequest->GetResponse();
      
      // Process the response.
      Console::WriteLine( "\nResponse received sucessfully" );
      
      // Release the resources of the response object.
      myWebResponse->Close();