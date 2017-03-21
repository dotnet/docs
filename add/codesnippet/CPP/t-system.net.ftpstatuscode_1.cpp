   static bool MakeDirectoryOnServer( Uri^ serverUri )
   {
      // The serverUri should start with the ftp:// scheme.
      if ( serverUri->Scheme != Uri::UriSchemeFtp )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::MakeDirectory;
      FtpWebResponse^ response = dynamic_cast<FtpWebResponse^>(request->GetResponse());
      Console::WriteLine( "Status: {0}", response->StatusDescription );
      return true;
   }