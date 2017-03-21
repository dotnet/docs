      String^ remoteUri = "http://www.contoso.com/library/homepage/images/";
      String^ fileName = "ms-banner.gif", ^myStringWebResource = nullptr;
      // Create a new WebClient instance.
      WebClient^ myWebClient = gcnew WebClient;
      // Concatenate the domain with the Web resource filename.
      myStringWebResource = String::Concat( remoteUri, fileName );
      Console::WriteLine( "Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource );
      // Download the Web resource and save it into the current filesystem folder.
      myWebClient->DownloadFile( myStringWebResource, fileName );
      Console::WriteLine( "Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource );
      Console::WriteLine( "\nDownloaded file saved in the following file system folder:\n\t {0}", Application::StartupPath );