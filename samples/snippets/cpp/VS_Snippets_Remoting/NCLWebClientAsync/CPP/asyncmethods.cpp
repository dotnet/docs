

// NCLWebClientAsync
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Text;
using namespace System::ComponentModel;

//<Snippet42>
  static void UploadProgressCallback(Object^ sender, 
            UploadProgressChangedEventArgs^ e)
        {
            // Displays the operation identifier, and the transfer progress.
            Console::WriteLine("{0}    uploaded {1} of {2} bytes. {3} % complete...", 
                (String ^)e->UserState, 
                e->BytesSent, 
                e->TotalBytesToSend,
                e->ProgressPercentage);
        }
  static void DownloadProgressCallback(Object^ sender, 
            DownloadProgressChangedEventArgs^ e)
        {
            // Displays the operation identifier, and the transfer progress.
            Console::WriteLine("{0}    downloaded {1} of {2} bytes. {3} % complete...", 
                (String ^)e->UserState, 
                e->BytesReceived, 
                e->TotalBytesToReceive,
                e->ProgressPercentage);
        }
//</Snippet42>

//<Snippet1>
void UploadString( String^ address )
{
   String^ data = "Time = 12:00am temperature = 50";
   WebClient^ client = gcnew WebClient;
   
   // Optionally specify an encoding for uploading and downloading strings.
   client->Encoding = System::Text::Encoding::UTF8;
   
   // Upload the data.
   String^ reply = client->UploadString( address, data );
   
   // Disply the server's response.
   Console::WriteLine( reply );
}


//</Snippet1>
//<Snippet2>
void PostString( String^ address )
{
   String^ data = "Time = 12:00am temperature = 50";
   String^ method = "POST";
   WebClient^ client = gcnew WebClient;
   String^ reply = client->UploadString( address, method, data );
   Console::WriteLine( reply );
}


//</Snippet2>
void UploadFileCallback2( Object^ sender, UploadFileCompletedEventArgs^ e );

//<Snippet3>
// Sample call: UploadFileInBackground3("http://www.contoso.com/fileUpload.aspx", "data.txt")
void UploadFileInBackground3( String^ address, String^ fileName )
{
   
   //<Snippet43>
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);

   client->UseDefaultCredentials = true;
   
   //</Snippet43>
   client->UploadFileCompleted += gcnew UploadFileCompletedEventHandler( UploadFileCallback2 );
   client->UploadFileAsync( uri, fileName );
   Console::WriteLine( "File upload started." );
}

//</Snippet3>

//<Snippet4>
// Sample call: UploadFileInBackground2("http://www.contoso.com/fileUpload.aspx", "data.txt")
void UploadFileInBackground2( String^ address, String^ fileName )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);

   client->UploadFileCompleted += 
     gcnew UploadFileCompletedEventHandler (UploadFileCallback2);
   
   // Specify a progress notification handler.
   client->UploadProgressChanged += 
       gcnew UploadProgressChangedEventHandler( UploadProgressCallback );
   client->UploadFileAsync( uri, "POST", fileName );
   Console::WriteLine( "File upload started." );
}


//</Snippet4>
//<Snippet5>
void UploadFileCallback2( Object^ /*sender*/, UploadFileCompletedEventArgs^ e )
{
   String^ reply = System::Text::Encoding::UTF8->GetString( e->Result );
   Console::WriteLine( reply );
}


//</Snippet5>
void UploadFileCallback( Object^ sender, UploadFileCompletedEventArgs^ e );

//<Snippet6>
// Sample call: UploadFileInBackground("http://www.contoso.com/fileUpload.aspx", "data.txt")
void UploadFileInBackground( String^ address, String^ fileName )
{
   System::Threading::AutoResetEvent^ waiter = gcnew System::Threading::AutoResetEvent( false );
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   String^ method = "POST";
   
   // Specify that UploadFileCallback method gets called
   // when the file upload completes.
   client->UploadFileCompleted += gcnew UploadFileCompletedEventHandler( UploadFileCallback );
   client->UploadFileAsync( uri, method, fileName, waiter );
   
   // Block the main application thread. Real applications
   // can perform other tasks while waiting for the upload to complete.
   waiter->WaitOne();
   Console::WriteLine( "File upload is complete." );
}


//</Snippet6>
//<Snippet7>
void UploadFileCallback( Object^ /*sender*/, UploadFileCompletedEventArgs^ e )
{
   System::Threading::AutoResetEvent^ waiter = dynamic_cast<System::Threading::AutoResetEvent^>(e->UserState);
   ;
   try
   {
      String^ reply = System::Text::Encoding::UTF8->GetString( e->Result );
      Console::WriteLine( reply );
   }
   finally
   {
      
      // If this thread throws an exception, make sure that
      // you let the main application thread resume.
      waiter->Set();
   }

}


//</Snippet7>
void UploadStringCallback( Object^ sender, UploadStringCompletedEventArgs^ e );

//<Snippet8>
void UploadStringInBackground( String^ address )
{
   System::Threading::AutoResetEvent^ waiter = gcnew System::Threading::AutoResetEvent( false );
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   String^ data = "Time = 12:00am temperature = 50";
   String^ method = "POST";

   client->UploadStringCompleted += gcnew UploadStringCompletedEventHandler( UploadStringCallback );
   client->UploadStringAsync( uri, method, data, waiter );
   
   // Block the main application thread. Real applications
   // can perform other tasks while waiting for the upload to complete.
   waiter->WaitOne();
   Console::WriteLine( "String upload is complete." );
}


//</Snippet8>
//<Snippet9>
void UploadStringCallback( Object^ /*sender*/, UploadStringCompletedEventArgs^ e )
{
   System::Threading::AutoResetEvent^ waiter = dynamic_cast<System::Threading::AutoResetEvent^>(e->UserState);
   try
   {
      String^ reply = dynamic_cast<String^>(e->Result);
      Console::WriteLine( reply );
   }
   finally
   {
      
      // If this thread throws an exception, make sure that
      // you let the main application thread resume.
      waiter->Set();
   }

}


//</Snippet9>
void OpenReadCallback( Object^ sender, OpenReadCompletedEventArgs^ e );

//<Snippet10>
void OpenResourceForReading( String^ address )
{
   System::Threading::AutoResetEvent^ waiter = gcnew System::Threading::AutoResetEvent( false );
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);

   client->OpenReadCompleted += gcnew OpenReadCompletedEventHandler( OpenReadCallback );
   client->OpenReadAsync( uri, waiter );
   
   // Block the main application thread. Real applications
   // can perform other tasks while waiting for the upload to complete.
   waiter->WaitOne();
}


//</Snippet10>
//<Snippet11>
void OpenReadCallback( Object^ /*sender*/, OpenReadCompletedEventArgs^ e )
{
   System::Threading::AutoResetEvent^ waiter = dynamic_cast<System::Threading::AutoResetEvent^>(e->UserState);
   Stream^ reply = nullptr;
   StreamReader^ s = nullptr;
   try
   {
      reply = dynamic_cast<Stream^>(e->Result);
      s = gcnew StreamReader( reply );
      Console::WriteLine( s->ReadToEnd() );
   }
   finally
   {
      if ( s != nullptr )
      {
         s->Close();
      }
      if ( reply != nullptr )
      {
         reply->Close();
      }
      
      // If this thread throws an exception, make sure that
      // you let the main application thread resume.
      waiter->Set();
   }

}


//</Snippet11>
void OpenWriteCallback( Object^ sender, OpenWriteCompletedEventArgs^ e );

//<Snippet12>
void OpenResourceForWriting( String^ address )
{
   System::Threading::AutoResetEvent^ waiter = gcnew System::Threading::AutoResetEvent( false );
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   
   // Specify that the OpenWriteCallback method gets called
   // when the writeable stream is available.
   client->OpenWriteCompleted += gcnew OpenWriteCompletedEventHandler( OpenWriteCallback );
   client->OpenWriteAsync( uri, "POST", waiter );
   
   // Block the main application thread. Real applications
   // can perform other tasks while waiting for the upload to complete.
   waiter->WaitOne();
}


//</Snippet12>
//<Snippet13>
void OpenWriteCallback( Object^ /*sender*/, OpenWriteCompletedEventArgs^ e )
{
   System::Threading::AutoResetEvent^ waiter = dynamic_cast<System::Threading::AutoResetEvent^>(e->UserState);
   Stream^ body = nullptr;
   StreamWriter^ s = nullptr;
   try
   {
      body = dynamic_cast<Stream^>(e->Result);
      s = gcnew StreamWriter( body );
      s->AutoFlush = true;
      s->Write( "This is content data to be sent to the server." );
   }
   finally
   {
      if ( s != nullptr )
      {
         s->Close();
      }
      if ( body != nullptr )
      {
         body->Close();
      }
      
      // If this thread throws an exception, make sure that
      // you let the main application thread resume.
      waiter->Set();
   }

}


//</Snippet13>
void OpenWriteCallback2( Object^ sender, OpenWriteCompletedEventArgs^ e );

//<Snippet14>
void OpenResourceForWriting2( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   
   // Specify that the OpenWriteCallback method gets called
   // when the writeable stream is available.
   client->OpenWriteCompleted += gcnew OpenWriteCompletedEventHandler( OpenWriteCallback2 );
   client->OpenWriteAsync( uri, "POST" );
   
   // Applications can perform other tasks
   // while waiting for the upload to complete.
}


//</Snippet14>
//<Snippet15>
void OpenWriteCallback2( Object^ /*sender*/, OpenWriteCompletedEventArgs^ e )
{
   Stream^ body = nullptr;
   StreamWriter^ s = nullptr;
   try
   {
      body = dynamic_cast<Stream^>(e->Result);
      s = gcnew StreamWriter( body );
      s->AutoFlush = true;
      s->Write( "This is content data to be sent to the server." );
   }
   finally
   {
      if ( s != nullptr )
      {
         s->Close();
      }
      if ( body != nullptr )
      {
         body->Close();
      }
   }

}


//</Snippet15>
//<Snippet16>
void OpenResourceForPosting( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   
   // Specify that the OpenWriteCallback method gets called
   // when the writeable stream is available.
   client->OpenWriteCompleted += gcnew OpenWriteCompletedEventHandler( OpenWriteCallback2 );
   client->OpenWriteAsync( uri );
   
   // Applications can perform other tasks
   // while waiting for the upload to complete.
}


//</Snippet16>
void DownloadFileCallback( Object^ sender, System::ComponentModel::AsyncCompletedEventArgs^ e );

//<Snippet17>
// Sample call : DownLoadFileInBackground ("http://www.contoso.com/logs/January.txt");
void DownLoadFileInBackground( String^ address )
{
   System::Threading::AutoResetEvent^ waiter = gcnew System::Threading::AutoResetEvent( false );
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   
   // Specify that the DownloadFileCallback method gets called
   // when the download completes.
   client->DownloadFileCompleted += gcnew AsyncCompletedEventHandler( DownloadFileCallback );
   client->DownloadFileAsync( uri, "serverdata.txt", waiter );
   
   // Block the main application thread. Real applications
   // can perform other tasks while waiting for the download to complete.
   waiter->WaitOne();
}


//</Snippet17>
//<Snippet18>
void DownloadFileCallback( Object^ /*sender*/, System::ComponentModel::AsyncCompletedEventArgs^ e )
{
   if ( e->Cancelled )
   {
      Console::WriteLine( "File download cancelled." );
   }

   if ( e->Error != nullptr )
   {
      Console::WriteLine( e->Error->ToString() );
   }

   System::Threading::AutoResetEvent^ waiter = dynamic_cast<System::Threading::AutoResetEvent^>(e->UserState);
   
   // Let the main application thread resume.
   waiter->Set();
}


//</Snippet18>
void DownloadFileCallback2( Object^ sender, System::ComponentModel::AsyncCompletedEventArgs^ e );

//<Snippet19>
// Sample call : DownLoadFileInBackground2 ("http://www.contoso.com/logs/January.txt");
void DownLoadFileInBackground2( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   
   // Specify that the DownloadFileCallback method gets called
   // when the download completes.
   client->DownloadFileCompleted += gcnew AsyncCompletedEventHandler( DownloadFileCallback2 );
   
   // Specify a progress notification handler.
   client->DownloadProgressChanged += gcnew DownloadProgressChangedEventHandler( DownloadProgressCallback );
   client->DownloadFileAsync( uri, "serverdata.txt" );
}


//</Snippet19>
//<Snippet20>
void DownloadFileCallback2( Object^ /*sender*/, System::ComponentModel::AsyncCompletedEventArgs^ e )
{
   if ( e->Cancelled )
   {
      Console::WriteLine( "File download cancelled." );
   }

   if ( e->Error != nullptr )
   {
      Console::WriteLine( e->Error->ToString() );
   }
}


//</Snippet20>
void DownloadDataCallback( Object^ sender, DownloadDataCompletedEventArgs^ e );

//<Snippet21>
// Sample call : DownLoadDataInBackground ("http://www.contoso.com/GameScores.html");
void DownloadDataInBackground( String^ address )
{
   System::Threading::AutoResetEvent^ waiter = gcnew System::Threading::AutoResetEvent( false );
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   
   // Specify that the DownloadDataCallback method gets called
   // when the download completes.
   client->DownloadDataCompleted += gcnew DownloadDataCompletedEventHandler( DownloadDataCallback );
   client->DownloadDataAsync( uri, waiter );
   
   // Block the main application thread. Real applications
   // can perform other tasks while waiting for the download to complete.
   waiter->WaitOne();
}


//</Snippet21>
//<Snippet22>
void DownloadDataCallback( Object^ /*sender*/, DownloadDataCompletedEventArgs^ e )
{
   System::Threading::AutoResetEvent^ waiter = dynamic_cast<System::Threading::AutoResetEvent^>(e->UserState);
   try
   {
      
      // If the request was not canceled and did not throw
      // an exception, display the resource.
      if (  !e->Cancelled && e->Error == nullptr )
      {
         array<Byte>^data = dynamic_cast<array<Byte>^>(e->Result);
         String^ textData = System::Text::Encoding::UTF8->GetString( data );
         Console::WriteLine( textData );
      }
   }
   finally
   {
      
      // Let the main application thread resume.
      waiter->Set();
   }

}


//</Snippet22>
void DownloadDataCallback2( Object^ sender, DownloadDataCompletedEventArgs^ e );

//<Snippet23>
// Sample call : DownloadDataInBackground2 ("http://www.contoso.com/GameScores.html");
void DownloadDataInBackground2( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   
   // Specify that the DownloadDataCallback2 method gets called
   // when the download completes.
   client->DownloadDataCompleted += gcnew DownloadDataCompletedEventHandler( DownloadDataCallback2 );
   client->DownloadDataAsync( uri );
}


//</Snippet23>
//<Snippet24>
void DownloadDataCallback2( Object^ /*sender*/, DownloadDataCompletedEventArgs^ e )
{
   
   // If the request was not canceled and did not throw
   // an exception, display the resource.
   if (  !e->Cancelled && e->Error == nullptr )
   {
      array<Byte>^data = dynamic_cast<array<Byte>^>(e->Result);
      String^ textData = System::Text::Encoding::UTF8->GetString( data );
      Console::WriteLine( textData );
   }
}


//</Snippet24>
//<Snippet25>
void DownloadString( String^ address )
{
   WebClient^ client = gcnew WebClient;
   String^ reply = client->DownloadString( address );
   Console::WriteLine( reply );
}


// </Snippet25>
void DownloadStringCallback( Object^ sender, DownloadStringCompletedEventArgs^ e );

//<Snippet26>
// Sample call : DownLoadStringInBackground ("http://www.contoso.com/GameScores.html");
void DownloadStringInBackground( String^ address )
{
   System::Threading::AutoResetEvent^ waiter = gcnew System::Threading::AutoResetEvent( false );
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   
   // Specify that the DownloadStringCallback method gets called
   // when the download completes.
   client->DownloadStringCompleted += gcnew DownloadStringCompletedEventHandler( DownloadStringCallback );
   client->DownloadStringAsync( uri, waiter );
   
   // Block the main application thread. Real applications
   // can perform other tasks while waiting for the download to complete.
   waiter->WaitOne();
}


//</Snippet26>
//<Snippet27>
void DownloadStringCallback( Object^ /*sender*/, DownloadStringCompletedEventArgs^ e )
{
   System::Threading::AutoResetEvent^ waiter = dynamic_cast<System::Threading::AutoResetEvent^>(e->UserState);
   try
   {
      
      // If the request was not canceled and did not throw
      // an exception, display the resource.
      if (  !e->Cancelled && e->Error == nullptr )
      {
         String^ textString = dynamic_cast<String^>(e->Result);
         Console::WriteLine( textString );
      }
   }
   finally
   {
      
      // Let the main application thread resume.
      waiter->Set();
   }

}


//</Snippet27>
void DownloadStringCallback2( Object^ sender, DownloadStringCompletedEventArgs^ e );

//<Snippet28>
// Sample call : DownloadStringInBackground2 ("http://www.contoso.com/GameScores.html");
void DownloadStringInBackground2( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   
   // Specify that the DownloadStringCallback2 method gets called
   // when the download completes.
   client->DownloadStringCompleted += gcnew DownloadStringCompletedEventHandler( DownloadStringCallback2 );
   client->DownloadStringAsync( uri );
}


//</Snippet28>
//<Snippet29>
void DownloadStringCallback2( Object^ /*sender*/, DownloadStringCompletedEventArgs^ e )
{
   
   // If the request was not canceled and did not throw
   // an exception, display the resource.
   if (  !e->Cancelled && e->Error == nullptr )
   {
      String^ textString = dynamic_cast<String^>(e->Result);
      Console::WriteLine( textString );
   }
}


//</Snippet29>
void OpenReadCallback2( Object^ sender, OpenReadCompletedEventArgs^ e );

//<Snippet30>
void OpenResourceForReading2( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);

   client->OpenReadCompleted += gcnew OpenReadCompletedEventHandler( OpenReadCallback2 );
   client->OpenReadAsync( uri );
}


//</Snippet30>
//<Snippet31>
void OpenReadCallback2( Object^ /*sender*/, OpenReadCompletedEventArgs^ e )
{
   Stream^ reply = nullptr;
   StreamReader^ s = nullptr;
   try
   {
      reply = dynamic_cast<Stream^>(e->Result);
      s = gcnew StreamReader( reply );
      Console::WriteLine( s->ReadToEnd() );
   }
   finally
   {
      if ( s != nullptr )
      {
         s->Close();
      }
      if ( reply != nullptr )
      {
         reply->Close();
      }
   }

}


//</Snippet31>
void UploadDataCallback( Object^ sender, UploadDataCompletedEventArgs^ e );

//<Snippet32>
void UploadDataInBackground( String^ address )
{
   System::Threading::AutoResetEvent^ waiter = gcnew System::Threading::AutoResetEvent( false );
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   String^ text = "Time = 12:00am temperature = 50";
   array<Byte>^data = System::Text::Encoding::UTF8->GetBytes( text );
   String^ method = "POST";

   client->UploadDataCompleted += gcnew UploadDataCompletedEventHandler( UploadDataCallback );
   client->UploadDataAsync( uri, method, data, waiter );
   
   // Block the main application thread. Real applications
   // can perform other tasks while waiting for the upload to complete.
   waiter->WaitOne();
   Console::WriteLine( "Data upload is complete." );
}


//</Snippet32>
//<Snippet33>
void UploadDataCallback( Object^ /*sender*/, UploadDataCompletedEventArgs^ e )
{
   System::Threading::AutoResetEvent^ waiter = dynamic_cast<System::Threading::AutoResetEvent^>(e->UserState);
   try
   {
      array<Byte>^data = dynamic_cast<array<Byte>^>(e->Result);
      String^ reply = System::Text::Encoding::UTF8->GetString( data );
      Console::WriteLine( reply );
   }
   finally
   {
      
      // If this thread throws an exception, make sure that
      // you let the main application thread resume.
      waiter->Set();
   }

}


//</Snippet33>
void UploadDataCallback2( Object^ sender, UploadDataCompletedEventArgs^ e );

//<Snippet34>
void UploadDataInBackground2( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   String^ text = "Time = 12:00am temperature = 50";
   array<Byte>^data = System::Text::Encoding::UTF8->GetBytes( text );
   String^ method = "POST";

   client->UploadDataCompleted += gcnew UploadDataCompletedEventHandler( UploadDataCallback2 );
   client->UploadDataAsync( uri, method, data );
}


//</Snippet34>
//<Snippet35>
void UploadDataCallback2( Object^ /*sender*/, UploadDataCompletedEventArgs^ e )
{
   array<Byte>^data = dynamic_cast<array<Byte>^>(e->Result);
   String^ reply = System::Text::Encoding::UTF8->GetString( data );
   Console::WriteLine( reply );
}


//</Snippet35>
void UploadDataCallback3( Object^ sender, UploadDataCompletedEventArgs^ e );

//<Snippet36>
void UploadDataInBackground3( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   String^ text = "Time = 12:00am temperature = 50";
   array<Byte>^data = System::Text::Encoding::UTF8->GetBytes( text );

   client->UploadDataCompleted += gcnew UploadDataCompletedEventHandler( UploadDataCallback3 );
   client->UploadDataAsync( uri, data );
}


//</Snippet36>
//<Snippet37>
void UploadDataCallback3( Object^ /*sender*/, UploadDataCompletedEventArgs^ e )
{
   array<Byte>^data = dynamic_cast<array<Byte>^>(e->Result);
   String^ reply = System::Text::Encoding::UTF8->GetString( data );
   Console::WriteLine( reply );
}


//</Snippet37>
void UploadStringCallback2( Object^ sender, UploadStringCompletedEventArgs^ e );

//<Snippet38>
void UploadStringInBackground2( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   String^ data = "Time = 12:00am temperature = 50";

   client->UploadStringCompleted += gcnew UploadStringCompletedEventHandler( UploadStringCallback2 );
   client->UploadStringAsync( uri, data );
}


//</Snippet38>
//<Snippet39>
void UploadStringCallback2( Object^ /*sender*/, UploadStringCompletedEventArgs^ e )
{
   String^ reply = dynamic_cast<String^>(e->Result);
   Console::WriteLine( reply );
}


//</Snippet39>
//<Snippet40>
void UploadStringInBackground3( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   String^ data = "Time = 12:00am temperature = 50";
   String^ method = "POST";

   client->UploadStringCompleted += gcnew UploadStringCompletedEventHandler( UploadStringCallback2 );
   client->UploadStringAsync( uri, method, data );
}


//</Snippet40>
//<Snippet41>
// Sample call : DownLoadFileWithProgressNotify ("http://www.contoso.com/logs/January.txt");
void DownLoadFileWithProgressNotify( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   
   // Specify that the DownloadFileCallback method gets called
   // when the download completes.
   client->DownloadFileCompleted += gcnew AsyncCompletedEventHandler( DownloadFileCallback2 );
   
   // Specify a progress notification handler.
   client->DownloadProgressChanged += gcnew DownloadProgressChangedEventHandler( DownloadProgressCallback );
   
   // The user token, shown here as ID 1234, is used to uniquely
   // identify notification events raised for this data transfer operation.
   client->DownloadFileAsync( uri, "serverdata.txt", "ID 1234" );
}


//</Snippet41>
// nothing below this line appears in the docs.
//[System.Security.Permissions.FileIOPermissionAttribute(System.Security.Permissions.SecurityAction.Deny, Write=@"c:\whidbeycode\ncl.xml")]
int main()
{
   
   // OpenResourceForReading ("http://google.com");
   //OpenResourceForReading2("http://google.com");
   //  System.Threading.Thread.Sleep (10000);
   UploadDataInBackground2( "http://sharriso1/test/postaccepter.aspx" );
   
   // DownloadString ("http://google.com");
   /*
       UploadDataInBackground ("http://sharriso1/test/postaccepter.aspx");
   
       System.Threading.Thread.Sleep (1000);
       UploadDataInBackground3 ("http://sharriso1/test/postaccepter.aspx");
       System.Threading.Thread.Sleep (1000);
   
       UploadStringInBackground ("http://sharriso1/test/postaccepter.aspx");
       UploadStringInBackground2 ("http://sharriso1/test/postaccepter.aspx");
       System.Threading.Thread.Sleep (1000);
       UploadStringInBackground3 ("http://sharriso1/test/postaccepter.aspx");
       System.Threading.Thread.Sleep (1000);
       */
   // OpenResourceForWriting2("http://sharriso1/test/postaccepter.aspx");
   // DownloadDataInBackground ("http://google.com");
   //System.Threading.Thread.Sleep (10000);
   // DownloadString ("http://google.com");
   //  DownloadStringInBackground ("http://google.com");
   //  DownloadStringInBackground2 ("http://google.com");
   //  System.Threading.Thread.Sleep (1000); 
   //  DownLoadFileInBackground2 ("http://sharriso1/test/uploadedFiles/onesandtwos.txt");
   DownLoadFileWithProgressNotify( "http://sharriso1/test/uploadedFiles/onesandtwos.txt" );
   
   //System.Threading.Thread.Sleep (10000);
   // UploadString ();
   //   UploadStringInBackground ("http://sharriso1/test/fileUploadercs.aspx");
   //   UploadFileInBackground2 ("http://sharriso1/test/fileUploadercs.aspx", "onesandtwos.txt");
   //  UploadFileInBackground3 ("http://sharriso1/test/fileUploadercs.aspx", "onesandtwos.txt");
   System::Threading::Thread::Sleep( 1000 );
}
