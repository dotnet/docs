   static bool UploadUniqueFileOnServer( Uri^ serverUri, String^ fileName )
   {
      // The URI described by serverUri should use the ftp:// scheme.
      // It contains the name of the directory on the server.
      // Example: ftp://contoso.com.
      // 
      // The fileName parameter identifies the file containing the data to be uploaded.
      if ( serverUri->Scheme != Uri::UriSchemeFtp )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::UploadFileWithUniqueName;

      // Don't set a time limit for the operation to complete.
      request->Timeout = System::Threading::Timeout::Infinite;

      // Copy the file contents to the request stream.
      const int bufferLength = 2048;
      array<Byte>^buffer = gcnew array<Byte>(bufferLength);
      int count = 0;
      int readBytes = 0;
      FileStream^ stream = File::OpenRead( fileName );
      Stream^ requestStream = request->GetRequestStream();
      do
      {
         readBytes = stream->Read( buffer, 0, bufferLength );
         requestStream->Write( buffer, 0, bufferLength );
         count += readBytes;
      }
      while ( readBytes != 0 );

      Console::WriteLine( "Writing {0} bytes to the stream.", count );
      
      // IMPORTANT: Close the request stream before sending the request.
      requestStream->Close();
      FtpWebResponse^ response = dynamic_cast<FtpWebResponse^>(request->GetResponse());
      Console::WriteLine( "Upload status: {0}, {1}", response->StatusCode, response->StatusDescription );
      Console::WriteLine( "File name: {0}", response->ResponseUri );
      response->Close();
      return true;
   }