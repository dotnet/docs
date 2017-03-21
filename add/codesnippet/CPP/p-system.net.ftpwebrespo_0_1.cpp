   static bool DownloadFileFromServer( Uri^ serverUri, String^ localFileName )
   {
      // The serverUri parameter should start with the ftp:// scheme.
      if ( serverUri->Scheme != Uri::UriSchemeFtp )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      // Note that the cast to FtpWebRequest is done only
      // for the purposes of illustration. If your application
      // does not set any properties other than those defined in the
      // System.Net.WebRequest class, you can use the following line instead:
      // WebRequest request = WebRequest.Create(serverUri);
      //
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::DownloadFile;
      FtpWebResponse^ response = dynamic_cast<FtpWebResponse^>(request->GetResponse());
      Stream^ responseStream = nullptr;
      StreamReader^ readStream = nullptr;
      StreamWriter^ writeStream = nullptr;
      try
      {
         responseStream = response->GetResponseStream();
         readStream = gcnew StreamReader( responseStream,System::Text::Encoding::UTF8 );
         
         // Display information about the data received from the server.
         Console::WriteLine( "Bytes received: {0}", response->ContentLength );
         Console::WriteLine( "Message from server: {0}", response->StatusDescription );
         Console::WriteLine( "Resource: {0}", response->ResponseUri );

         // Write the bytes received from the server to the local file.
         if ( readStream != nullptr )
         {
            writeStream = gcnew StreamWriter( localFileName,false );
            writeStream->Write( readStream->ReadToEnd() );
         }
      }
      finally
      {
         if ( readStream != nullptr )
         {
            readStream->Close();
         }

         if ( response != nullptr )
         {
            response->Close();
         }

         if ( writeStream != nullptr )
         {
            writeStream->Close();
         }
      }

      return true;
   }