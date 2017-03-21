   static bool DisplayFileFromServer( Uri^ serverUri )
   {
      // The serverUri parameter should start with the ftp:// scheme.
      if ( serverUri->Scheme != Uri::UriSchemeFtp )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      WebClient^ request = gcnew WebClient;

      // This example assumes the FTP site uses anonymous logon.
      request->Credentials = gcnew NetworkCredential( "anonymous","janeDoe@contoso.com" );
      try
      {
         array<Byte>^newFileData = request->DownloadData( serverUri->ToString() );
         String^ fileString = System::Text::Encoding::UTF8->GetString( newFileData );
         Console::WriteLine( fileString );
      }
      catch ( WebException^ e ) 
      {
         Console::WriteLine( e );
      }

      return true;
   }