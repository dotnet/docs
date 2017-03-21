      // Create a new 'HttpWebRequest' Object to the mentioned URL.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( "http://www.contoso.com" ) );
      // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );
      Console::WriteLine( "\nThe HttpHeaders are \n\n\tName\t\tValue\n {0}", myHttpWebRequest->Headers );
      // Print the HTML contents of the page to the console.
      Stream^ streamResponse = myHttpWebResponse->GetResponseStream();
      StreamReader^ streamRead = gcnew StreamReader( streamResponse );
      array<Char>^ readBuff = gcnew array<Char>(256);
      int count = streamRead->Read( readBuff, 0, 256 );
      Console::WriteLine( "\nThe HTML contents of page the are  : \n\n " );
      while ( count > 0 )
      {
         String^ outputData = gcnew String( readBuff,0,count );
         Console::Write( outputData );
         count = streamRead->Read( readBuff, 0, 256 );
      }
      streamResponse->Close();
      streamRead->Close();
      // Release the HttpWebResponse Resource.
      myHttpWebResponse->Close();