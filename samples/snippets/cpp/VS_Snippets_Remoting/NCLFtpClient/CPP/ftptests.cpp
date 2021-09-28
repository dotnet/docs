

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Text;
using namespace System::IO;
using namespace System::Threading;
using namespace System::Security::Cryptography::X509Certificates;

public ref class FtpRequestTest
{
private:

   // FxCop rule requires a private constructor.
   FtpRequestTest(){}


public:

   //<snippet1>
   static bool ListFilesOnServer( Uri^ serverUri )
   {
      // The serverUri should start with the ftp:// scheme.
      if ( serverUri->Scheme != Uri::UriSchemeFtp )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::ListDirectory;

      // Get the ServicePoint object used for this request, and limit it to one connection.
      // In a real-world application you might use the default number of connections (2),
      // or select a value that works best for your application.
      ServicePoint^ sp = request->ServicePoint;
      Console::WriteLine( "ServicePoint connections = {0}.", sp->ConnectionLimit );
      sp->ConnectionLimit = 1;
      FtpWebResponse^ response = dynamic_cast<FtpWebResponse^>(request->GetResponse());

      // The following streams are used to read the data returned from the server.
      Stream^ responseStream = nullptr;
      StreamReader^ readStream = nullptr;
      try
      {
         responseStream = response->GetResponseStream();
         readStream = gcnew StreamReader( responseStream,System::Text::Encoding::UTF8 );
         if ( readStream != nullptr )
         {
            // Display the data received from the server.
            Console::WriteLine( readStream->ReadToEnd() );
         }

         Console::WriteLine( "List status: {0}", response->StatusDescription );
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
      }

      return true;
   }
   //</snippet1>

   // new content
   //<snippet20>
   static bool NameListFilesOnServer( Uri^ serverUri )
   {
      // The serverUri should start with the ftp:// scheme.
      if ( serverUri->Scheme != Uri::UriSchemeFtp )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::ListDirectoryDetails;
      FtpWebResponse^ response = dynamic_cast<FtpWebResponse^>(request->GetResponse());

      // The following streams are used to read the data returned from the server.
      Stream^ responseStream = nullptr;
      StreamReader^ readStream = nullptr;
      try
      {
         responseStream = response->GetResponseStream();
         readStream = gcnew StreamReader( responseStream,System::Text::Encoding::UTF8 );
         if ( readStream != nullptr )
         {
            // Display the data received from the server.
            Console::WriteLine( readStream->ReadToEnd() );
         }

         Console::WriteLine( "Status: {0}", response->StatusDescription );
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
      }

      return true;
   }
   //</snippet20>

   //<snippet21>
   static bool GetDateTimestampOnServer( Uri^ serverUri )
   {
      // The serverUri should start with the ftp:// scheme.
      if ( serverUri->Scheme != Uri::UriSchemeFtp )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::GetDateTimestamp;
      FtpWebResponse^ response = dynamic_cast<FtpWebResponse^>(request->GetResponse());
      Console::WriteLine( "{0} {1}", serverUri, response->LastModified );

      // The output from this method will vary depening on the 
      // file specified and your regional settings. It is similar to:
      // ftp://contoso.com/Data.txt 4/15/2003 10:46:02 AM
      return true;
   }
   //</snippet21>

   //<snippet22>
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
   //</snippet22>

   //<snippet23>
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
   //</snippet23>

   //<snippet24>
   static bool RemoveDirectoryOnServer( Uri^ serverUri )
   {
      // The serverUri should start with the ftp:// scheme.
      if ( serverUri->Scheme != Uri::UriSchemeFtp )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::RemoveDirectory;
      FtpWebResponse^ response = dynamic_cast<FtpWebResponse^>(request->GetResponse());
      Console::WriteLine( "Status: {0}", response->StatusDescription );
      return true;
   }
   //</snippet24>

   //<snippet2>
   static bool UploadFileToServer( String^ fileName, Uri^ serverUri )
   {
      // The URI described by serverUri should use the ftp:// scheme.
      // It contains the name of the file on the server.
      // Example: ftp://contoso.com/someFile.txt.
      // 
      // The fileName parameter identifies the file containing the data to be uploaded.
      if ( serverUri->Scheme != Uri::UriSchemeFtp )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::UploadFile;

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
      response->Close();
      return true;
   }
   //</snippet2>

   //<snippet3>
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
   //</snippet3>

   //<snippet4>
   static bool DeleteFileOnServer( Uri^ serverUri )
   {
      // The serverUri parameter should use the ftp:// scheme.
      // It contains the name of the server file that is to be deleted.
      // Example: ftp://contoso.com/someFile.txt.
      // 
      if ( serverUri->Scheme != Uri::UriSchemeFtp )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::DeleteFile;
      FtpWebResponse^ response = dynamic_cast<FtpWebResponse^>(request->GetResponse());
      Console::WriteLine( "Delete status: {0}", response->StatusDescription );
      response->Close();
      return true;
   }
   //</snippet4>

   //<snippet5>
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
   //</snippet5>


   //<snippet6>
private:
   // DisplayRequestProperties prints a request's properties.
   // This method should be called after the request is sent to the server.
   static void DisplayRequestProperties( FtpWebRequest^ request )
   {
      //<snippet14>
      Console::WriteLine( "User {0} {1}", request->Credentials->GetCredential( request->RequestUri, "basic" )->UserName, request->RequestUri );

      //</snippet14>    
      Console::WriteLine( "Request: {0} {1}", request->Method, request->RequestUri );

      //<snippet15>
      Console::WriteLine( "Passive: {0}  Keep alive: {1}  Binary: {2} Timeout: {3}.", request->UsePassive, request->KeepAlive, request->UseBinary, request->Timeout == -1 ? "none" : request->Timeout.ToString() );

      //</snippet15>  
      //<snippet16>   
      IWebProxy^ proxy = request->Proxy;
      if ( proxy )
      {
         Console::WriteLine( "Proxy: {0}", proxy->GetProxy( request->RequestUri ) );
      }
      else
      {
         Console::WriteLine( "Proxy: (none)" );
      }

      Console::WriteLine( "ConnectionGroup: {0}", request->ConnectionGroupName == nullptr ? "none" : request->ConnectionGroupName );
      //</snippet16>

      Console::WriteLine( "Encrypted connection: {0}", request->EnableSsl );

      Console::WriteLine("Method: {0}", request->Method);
   }
   //</snippet6>

   //<snippet7>
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
   //</snippet7>

   // not enabled in M2
   // Sample call: SendCommandToServer("ftp://contoso.com/", "pwd");
   // The output can only return  status information. 
   static bool SendCommandToServer( String^ serverUri, String^ command )
   {
      // The serverUri parameter should start with the ftp:// scheme.
      // It contains the name of the file on the server that will be appended.
      // Example: ftp://contoso.com/someFile.txt.
      // 
      // The command parameter identifies the command to send to the server.
      if ( serverUri->ToLower()->StartsWith( Uri::UriSchemeFtp ) == false )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = command;

      // This example assumes the FTP site uses anonymous logon.
      request->Credentials = gcnew NetworkCredential( "anonymous","janeDoe@contoso.com" );
      FtpWebResponse^ response = dynamic_cast<FtpWebResponse^>(request->GetResponse());
      Console::WriteLine( "{0} status: {1}", command, response->StatusDescription );
      response->Close();
      return true;
   }

   //<snippet9>
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
   //</snippet9>

   // Make a request to show the request properties
   static void GetRequestProperties( Uri^ serverUri )
   {
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      
      // This example assumes the FTP site uses anonymous logon.
      request->Credentials = gcnew NetworkCredential( "anonymous","janeDoe@contoso.com" );
      request->Proxy = gcnew WebProxy;
      request->Method = WebRequestMethods::Ftp::DownloadFile;
      request->Abort();
      DisplayRequestProperties( request );
   }

   // async snippets
   //<snippet11>
   static bool GetFileSizeFromServer( Uri^ serverUri )
   {
      // The serverUri parameter should start with the ftp:// scheme.
      if ( serverUri->Scheme != Uri::UriSchemeFtp )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::GetFileSize;
      FtpWebResponse^ response = dynamic_cast<FtpWebResponse^>(request->GetResponse());

      // Display information about the server response.
      Console::WriteLine( "size of file: {0}", response->ContentLength );
      response->Close();
      return true;
   }
   //</snippet11>

   //<snippet8>
   static bool ListFilesOnServerSsl( Uri^ serverUri )
   {
      // The serverUri should start with the ftp:// scheme.
      if ( serverUri->Scheme != Uri::UriSchemeFtp )
      {
         return false;
      }

      // Get the object used to communicate with the server.
      FtpWebRequest^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::ListDirectory;
      request->EnableSsl = true;

      // Get the ServicePoint object used for this request, and limit it to one connection.
      // In a real-world application you might use the default number of connections (2),
      // or select a value that works best for your application.
      ServicePoint^ sp = request->ServicePoint;
      Console::WriteLine( "ServicePoint connections = {0}.", sp->ConnectionLimit );
      sp->ConnectionLimit = 1;
      FtpWebResponse^ response = dynamic_cast<FtpWebResponse^>(request->GetResponse());
      Console::WriteLine( "The content length is {0}", response->ContentLength );

      // The following streams are used to read the data returned from the server.
      Stream^ responseStream = nullptr;
      StreamReader^ readStream = nullptr;
      responseStream = response->GetResponseStream();
      readStream = gcnew StreamReader( responseStream,System::Text::Encoding::UTF8 );

      // Display the data received from the server.
      Console::WriteLine( readStream->ReadToEnd() );
      Console::WriteLine( "List status: {0}", response->StatusDescription );
      readStream->Close();
      response->Close();

      //<snippet12>
      Console::WriteLine( "Banner message: {0}", response->BannerMessage );
      //</snippet12>

      //<snippet13>
      Console::WriteLine( "Welcome message: {0}", response->WelcomeMessage );
      //</snippet13>

      //<snippet17>
      Console::WriteLine( "Exit message: {0}", response->ExitMessage );
      //</snippet17>

      return true;
   }

   // </snippet8>
internal:
   static FtpStatusCode WaitForFinalStatus( FtpWebResponse^ response )
   {
      int status = (int)response->StatusCode;

      // < 200 is undefined or informational messages.
      // 300 and 400 are intermediate and temporary errors respectively.
      // 200- 299 and 500- 599 are final statuses indicating
      // sucess or failure respectively.
      while ( status < 200 || (status >= 300 && status < 500) )
      {
         Console::Write( "{0}. ", status );
         System::Threading::Thread::Sleep( 100 );
         status = (int)response->StatusCode;
      }

      return response->StatusCode;
   }


public:
   static void Main()
   {
      // tests for snippets:
      // ListFilesOnServer(new Uri(S"ftp://sharriso1")); 
      // works m3.1
      //    NameListFilesOnServer (new Uri (S"ftp://sharriso1")); 
      // throws
      // GetDateTimestampOnServer (new Uri ("ftp://sharriso1")); 
      //    GetDateTimestampOnServer (new Uri (S"ftp://sharriso1/localfile.txt"));
      //   RemoveDirectoryOnServer (new Uri (S"ftp://sharriso1/DirtyDir"));
      //    MakeDirectoryOnServer (new Uri (S"ftp://sharriso1/DirtyDir"));
      //     UploadUniqueFileOnServer (new Uri (S"ftp://sharriso1/SherdieDir/"), "sharriso2.log"); 
      //      ListFilesOnServer (new Uri (S"ftp://sharriso1")); 
      ListFilesOnServerSsl( gcnew Uri( "ftp://sharriso1" ) );

      // snippet 8 - not working 
      // snippet 1
      //  ListFilesOnServer(new Uri("ftp://sharriso1/")); 
      // snippet 8 - not working 
      //SendCommandToServer("ftp://sharriso1/", "rename localfile.txt loc2.txt");
      // new snippet 7
      // upload is just helper
      //UploadFileToServer("NCLFtpClient.xml", new Uri("ftp://sharriso1/NCLFtpClient.xml"));
      //       RestartDownloadFromServer("piecexml.txt", new Uri("ftp://sharriso1/NCLFtpClient.xml"), 8);
      //        DownloadFileFromServer(new Uri("ftp://sharriso1/onesandtwos.txt"), "downloadedFile0320_1.txt");
      // snippet 11
      GetFileSizeFromServer( gcnew Uri( "ftp://sharriso1/localfile.txt" ) );

      // snippet 5
      // DisplayFileFromServer Not working!
      //  DisplayFileFromServer(new Uri("ftp://sharriso1/ss1.txt"));
      // snippet 2
      // UploadFileToServer("local.txt", new Uri("ftp://sharriso1/localfile.txt"));
      //DeleteFileOnServer(new Uri("ftp://sharriso1/localfile.txt"));
      // DownloadFileFromServer(new Uri("ftp://sharriso1/localFileagain.txt"), "dlagain.txt");
      // AppendFileOnServer("dlagain.txt", new Uri("ftp://sharriso1/localfile.txt"));
      // Snippet 14, 15, and 16
      //     GetRequestProperties(new Uri("ftp://sharriso1/localfile.txt"));
      // Snippet 9
      //   DownloadFileFromServer(new Uri("ftp://sharriso1/localFileagain.txt"), "dlagain.txt");
      //AsynchronousUploadFileToServer( "system.pdb","ftp://sharriso1/localFile.pdb");
      // ListFilesOnServer(new Uri("ftp://sharriso1"));
      //DownloadFileFromServer(new Uri("ftp://sharriso1/localFileagain.txt"), "dlagain.txt");
      //UploadPartialFileOnServer("allOnes.txt", "ftp://sharriso1/babyones.txt", 20 );
      // TestCloning();
      //  test the async methods 
      //    ManualResetEvent wait = new ManualResetEvent(false);
      //   AsynchronousFtpUpLoader uploader = new AsynchronousFtpUpLoader(wait);
      //   uploader.AsynchronousUploadFileToServer("ftptests.cs", "ftp://sharriso1/ftptests.txt");
      //   wait.WaitOne();
      //   Snippet 10
      //  ManualResetEvent wait = new ManualResetEvent(false);
      //  AsynchronousFtpUpLoader uploader = new AsynchronousFtpUpLoader(wait);
      //  uploader.AbortUpload("mscorlib.xml", "ftp://sharriso1/ftptests.txt");
      //  wait.WaitOne();
   }
};


// The RequestState class is the state object used to store the request information
// during asynchronous operations.
private ref class RequestState
{
internal:
   FtpWebRequest^ request;
   Object^ requestData;
   RequestState( FtpWebRequest ^theRequest, Object^ data )
   {
      request = theRequest;
      requestData = data;
   }
};

public ref class AsynchronousFtpUpLoader
{
private:
   ManualResetEvent^ wait;
   FtpWebRequest^ request;
   array<Byte>^fileContents;
   Exception^ asyncException;

public:
   AsynchronousFtpUpLoader( ManualResetEvent^ wait )
   {
      this->wait = wait;
   }

   // In the AsynchronousUploadFileToServer method,
   // serverUri contains the name of the file on the FTP server, and
   // fileName contains the name of the file on the local computer.
   void AsynchronousUploadFileToServer( String^ fileName, String^ serverUri )
   {
      request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( serverUri ));
      request->Method = WebRequestMethods::Ftp::UploadFile;

      // This example assumes the FTP site uses anonymous logon.
      request->Credentials = gcnew NetworkCredential( "anonymous","janeDoe@contoso.com" );

      // Get the file to be uploaded and convert it to bytes.
      StreamReader^ sourceStream = gcnew StreamReader( fileName );
      fileContents = Encoding::UTF8->GetBytes( sourceStream->ReadToEnd() );
      sourceStream->Close();

      // Set the content length to the number of bytes in the file.
      request->ContentLength = fileContents->Length;

      // Asynchronously get the stream for the file contents.
      IAsyncResult^ ar = request->BeginGetRequestStream( gcnew AsyncCallback( this, &AsynchronousFtpUpLoader::EndGetStreamCallback ), nullptr );
      Console::WriteLine( "Getting the request stream asynchronously..." );
   }

private:
   void EndGetStreamCallback( IAsyncResult^ ar )
   {
      //   Thread.Sleep(5000);
      //  Console.WriteLine("I'm awake now");
      Stream^ requestStream = nullptr;

      // End the asynchronous call to get the request stream.
      try
      {
         requestStream = request->EndGetRequestStream( ar );
      }
      // Return exceptions to the main application thread.
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Could not get the request stream." );
         asyncException = e;
         wait->Set();
         return;
      }

      // Write the file contents to the request stream.
      requestStream->Write( fileContents, 0, fileContents->Length );
      Console::WriteLine( "Writing {0} bytes to the stream.", fileContents->Length );

      // IMPORTANT: Close the request stream before sending the request.
      requestStream->Close();
      IAsyncResult^ responseAR = request->BeginGetResponse( gcnew AsyncCallback( this, &AsynchronousFtpUpLoader::EndGetResponseCallback ), nullptr );
   }

   // The EndGetResponseCallback method  
   // completes a call to BeginGetResponse.
   void EndGetResponseCallback( IAsyncResult^ ar )
   {
      FtpWebResponse^ response = nullptr;
      try
      {
         response = dynamic_cast<FtpWebResponse^>(request->EndGetResponse( ar ));
      }
      // Return exceptions to the main application thread.
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Error getting response." );
         asyncException = e;
      }

      Console::WriteLine( "Upload status: {0}", response->StatusDescription );
      
      // Signal the application thread that this is complete.
      wait->Set();
   }

   //<snippet10>
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
   //</snippet10>
};

int main()
{
   FtpRequestTest::Main();
}
