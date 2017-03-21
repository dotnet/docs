public:
   void AbortUpload( String^ fileName, String^ serverUri )
   {
      request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::UploadFile;

      // Get the file to be uploaded and convert it to bytes.
      StreamReader^ sourceStream = gcnew StreamReader( fileName );
      fileContents = Encoding::UTF8->GetBytes( sourceStream->ReadToEnd() );
      sourceStream->Close();

      // Set the content length to the number of bytes in the file.
      request->ContentLength = fileContents->Length;

      // Asynchronously get the stream for the file contents.
      IAsyncResult^ ar = request->BeginGetRequestStream( gcnew AsyncCallback( this, &AsynchronousFtpUpLoader::EndGetStreamCallback ), nullptr );
      Console::WriteLine( "Getting the request stream asynchronously..." );
      Console::WriteLine( "Press 'a' to abort the upload or any other key to continue" );
      String^ input = Console::ReadLine();
      if ( input->Equals( "a" ) )
      {
         request->Abort();
         Console::WriteLine( "Request aborted" );
         return;
      }
   }