      // Create a new webrequest to the mentioned URL.
      WebRequest^ myWebRequest = WebRequest::Create( url );
      
      // Set 'Preauthenticate' property to true. Credentials will be sent with the request.
      myWebRequest->PreAuthenticate = true;

      Console::WriteLine( "\nPlease enter your credentials for the requested Url" );
      Console::WriteLine( "UserName" );
      String^ UserName = Console::ReadLine();
      Console::WriteLine( "Password" );
      String^ Password = Console::ReadLine();
      
      // Create a New 'NetworkCredential' object.
      NetworkCredential^ networkCredential = gcnew NetworkCredential( UserName,Password );
      
      // Associate the 'NetworkCredential' object with the 'WebRequest' object.
      myWebRequest->Credentials = networkCredential;
      
      // Assign the response object of 'WebRequest' to a 'WebResponse' variable.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();