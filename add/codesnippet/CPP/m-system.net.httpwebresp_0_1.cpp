      // Creates an HttpWebRequest with the specified URL.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( url ) );
      // Sends the HttpWebRequest and waits for the response.
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );
      // Gets the stream associated with the response.
      Stream^ receiveStream = myHttpWebResponse->GetResponseStream();
      Encoding^ encode = System::Text::Encoding::GetEncoding( "utf-8" );
      // Pipes the stream to a higher level stream reader with the required encoding format.
      StreamReader^ readStream = gcnew StreamReader( receiveStream,encode );
      Console::WriteLine( "\r\nResponse stream received." );
      array<Char>^ read = gcnew array<Char>(256);
      // Reads 256 characters at a time.
      int count = readStream->Read( read, 0, 256 );
      Console::WriteLine( "HTML...\r\n" );
      while ( count > 0 )
      {
         // Dumps the 256 characters on a String* and displays the String* to the console.
         String^ str = gcnew String( read,0,count );
         Console::Write( str );
         count = readStream->Read( read, 0, 256 );
      }
      Console::WriteLine( "" );
      // Releases the resources of the response.
      myHttpWebResponse->Close();
      // Releases the resources of the Stream.
      readStream->Close();