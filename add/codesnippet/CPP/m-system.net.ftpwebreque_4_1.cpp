   static bool AppendFileOnServer( String^ fileName, Uri^ serverUri )
   {
      // The URI described by serverUri should use the ftp:// scheme.
      // It contains the name of the file on the server.
      // Example: ftp://contoso.com/someFile.txt. 
      // The fileName parameter identifies the file containing 
      // the data to be appended to the file on the server.
      if ( serverUri->Scheme != Uri::UriSchemeFtp )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::AppendFile;
      StreamReader^ sourceStream = gcnew StreamReader( fileName );
      array<Byte>^fileContents = Encoding::UTF8->GetBytes( sourceStream->ReadToEnd() );
      sourceStream->Close();
      request->ContentLength = fileContents->Length;

      // This example assumes the FTP site uses anonymous logon.
      request->Credentials = gcnew NetworkCredential( "anonymous","janeDoe@contoso.com" );
      Stream^ requestStream = request->GetRequestStream();
      requestStream->Write( fileContents, 0, fileContents->Length );
      requestStream->Close();
      FtpWebResponse^ response = dynamic_cast<FtpWebResponse^>(request->GetResponse());
      Console::WriteLine( "Append status: {0}", response->StatusDescription );
      response->Close();
      return true;
   }