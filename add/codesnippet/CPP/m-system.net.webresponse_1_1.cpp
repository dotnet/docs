      // Create a 'WebRequest' object with the specified url.
      WebRequest^ myWebRequest = WebRequest::Create( "http://www.contoso.com" );
      
      // Send the 'WebRequest' and wait for response.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();
      
      // Obtain a 'Stream' object associated with the response object.
      Stream^ ReceiveStream = myWebResponse->GetResponseStream();

      Encoding^ encode = System::Text::Encoding::GetEncoding( "utf-8" );
      
      // Pipe the stream to a higher level stream reader with the required encoding format.
      StreamReader^ readStream = gcnew StreamReader( ReceiveStream,encode );
      Console::WriteLine( "\nResponse stream received" );
      array<Char>^ read = gcnew array<Char>(256);
      
      // Read 256 charcters at a time.
      int count = readStream->Read( read, 0, 256 );
      Console::WriteLine( "HTML...\r\n" );

      while ( count > 0 )
      {
         // Dump the 256 characters on a string and display the string onto the console.
         String^ str = gcnew String( read,0,count );
         Console::Write( str );
         count = readStream->Read( read, 0, 256 );
      }

      Console::WriteLine( "" );
      // Release the resources of stream object.
      readStream->Close();
      
      // Release the resources of response object.
      myWebResponse->Close();