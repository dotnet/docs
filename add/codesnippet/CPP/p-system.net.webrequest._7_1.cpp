      // Create a new request to the mentioned URL.
      WebRequest^ myWebRequest = WebRequest::Create( "http://www.contoso.com" );
      
      // Assign the response object of 'WebRequest' to a 'WebResponse' variable.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();
      
      // Release the resources of response object.
      myWebResponse->Close();
      Console::WriteLine( "\nThe HttpHeaders are \n {0}", myWebRequest->Headers );