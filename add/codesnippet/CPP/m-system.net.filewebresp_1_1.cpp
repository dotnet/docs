      Uri^ fileUrl = gcnew Uri( String::Concat( "file://", url ) );
      // Create a 'FileWebrequest' Object* with the specified Uri.
      FileWebRequest^ myFileWebRequest = (FileWebRequest^)( WebRequest::Create( fileUrl ) );
      // Send the 'FileWebRequest' Object* and wait for response.
      FileWebResponse^ myFileWebResponse = (FileWebResponse^)( myFileWebRequest->GetResponse() );
      
      // Get the stream Object* associated with the response Object*.
      Stream^ receiveStream = myFileWebResponse->GetResponseStream();

      Encoding^ encode = System::Text::Encoding::GetEncoding( "utf-8" );
      // Pipe the stream to a higher level stream reader with the required encoding format.
      StreamReader^ readStream = gcnew StreamReader( receiveStream,encode );
      Console::WriteLine( "\r\nResponse stream received" );

      array<Char>^ read = gcnew array<Char>(256);
      // Read 256 characters at a time.
      int count = readStream->Read( read, 0, 256 );
      Console::WriteLine( "File Data...\r\n" );
      while ( count > 0 )
      {
         // Dump the 256 characters on a String* and display the String* onto the console.
         String^ str = gcnew String( read,0,count );
         Console::Write( str );
         count = readStream->Read( read, 0, 256 );
      }
      Console::WriteLine( "" );
      // Release resources of stream Object*.
      readStream->Close();
      // Release resources of response Object*.
      myFileWebResponse->Close();