      // Create a 'HttpWebRequest' object.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( myUri ) );
      // Set referer property  to http://www.microsoft.com .
      myHttpWebRequest->Referer = "http://www.microsoft.com";
      // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );
      // Display the contents of the page to the console.
      Stream^ streamResponse = myHttpWebResponse->GetResponseStream();
      StreamReader^ streamRead = gcnew StreamReader( streamResponse );
      array<Char>^ readBuffer = gcnew array<Char>(256);
      int count = streamRead->Read( readBuffer, 0, 256 );
      Console::WriteLine( "\nThe contents of HTML page are......." );
      while ( count > 0 )
      {
         String^ outputData = gcnew String( readBuffer,0,count );
         Console::Write( outputData );
         count = streamRead->Read( readBuffer, 0, 256 );
      }
      Console::WriteLine( "\nHTTP Request  Headers :\n\n {0}", myHttpWebRequest->Headers );
      Console::WriteLine( "\nHTTP Response Headers :\n\n {0}", myHttpWebResponse->Headers );
      streamRead->Close();
      streamResponse->Close();
      // Release the response object resources.
      myHttpWebResponse->Close();
      Console::WriteLine( "Referer to the site is: {0}", myHttpWebRequest->Referer );