public:
   // NOT Working - throws a protocolError - 350 Restarting at 8. for args shown in Main.
   static bool RestartDownloadFromServer( String^ fileName, Uri^ serverUri, long offset )
   {
      // The serverUri parameter should use the ftp:// scheme.
      // It identifies the server file that is to be appended.
      // Example: ftp://contoso.com/someFile.txt.
      // 
      // The fileName parameter identifies the local file
      //
      // The offset parameter specifies where in the server file to start reading data.
      if ( serverUri->Scheme != Uri::UriSchemeFtp )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::DownloadFile;
      request->ContentOffset = offset;
      FtpWebResponse^ response = nullptr;
      try
      {
         response = dynamic_cast<FtpWebResponse^>(request->GetResponse());
      }
      catch ( WebException^ e ) 
      {
         Console::WriteLine( e->Status );
         Console::WriteLine( e->Message );
         return false;
      }

      Stream^ newFile = response->GetResponseStream();
      StreamReader^ reader = gcnew StreamReader( newFile );

      // Display downloaded data.
      String^ newFileData = reader->ReadToEnd();

      // Append the response data to the local file
      // using a StreamWriter.
      StreamWriter^ writer = File::AppendText(fileName);
      writer->Write(newFileData);

     // Display the status description.

     // Cleanup.
     writer->Close();
     reader->Close();
     response->Close();
     // string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
     // Console::WriteLine( sr );
     Console::WriteLine("Download restart - status: {0}",response->StatusDescription);
     return true;
   }