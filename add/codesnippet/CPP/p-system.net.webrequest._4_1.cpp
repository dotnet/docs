      // Create a new WebRequest object to the mentioned URL.
      WebRequest^ myWebRequest = WebRequest::Create( "http://www.contoso.com" );
      Console::WriteLine( "\nThe Uri requested is {0}", myWebRequest->RequestUri);
      // Assign the response object of 'WebRequest' to a 'WebResponse' variable.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();
			// Get the stream containing content returned by the server.
      Stream^ streamResponse = myWebResponse->GetResponseStream();
			Console::WriteLine("\nThe Uri that responded to the request is '{0}'",myWebResponse->ResponseUri);
      StreamReader^ reader = gcnew StreamReader(streamResponse);
			// Read the content.
      String^ responseFromServer = reader->ReadToEnd();
      // Display the content.
      Console::WriteLine("\nThe HTML Contents received:");
      Console::WriteLine (responseFromServer);
      // Cleanup the streams and the response.
      reader->Close();
      streamResponse->Close();
      myWebResponse->Close();