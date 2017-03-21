      // Create a new WebRequest Object to the mentioned URL.
      WebRequest^ myWebRequest = WebRequest::Create( "http://www.contoso.com" );
      Console::WriteLine( "\nThe Timeout time of the request before setting is : {0} milliseconds", myWebRequest->Timeout );
      
      // Set the 'Timeout' property in Milliseconds.
      myWebRequest->Timeout = 10000;
      
      // This request will throw a WebException if it reaches the timeout limit
      // before it is able to fetch the resource.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();