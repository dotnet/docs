

// System::Net::FileWebRequest::BeginGetResponse;System::Net::FileWebRequest::EndGetResponse;
// Snippet1 and Snippet2 go together
/*
This program demonstrates 'BeginGetResponse' and 'EndGetResponse' methods of 'FileWebRequest' class.
The path of the file from where content is to be read  is obtained as a command line argument and a
'WebRequest' Object* is created. Using the 'BeginGetResponse' method and 'EndGetResponse' of 'FileWebRequest'
class a 'FileWebResponse' Object* is obtained which is used to print the content on the file.
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Threading;

// <Snippet1>
// <Snippet2>
public ref class RequestDeclare
{
public:
   FileWebRequest^ myFileWebRequest;
   RequestDeclare()
   {
      myFileWebRequest = nullptr;
   }

};

ref class FileWebRequest_resbeginend
{
public:
   static ManualResetEvent^ allDone = gcnew ManualResetEvent( false );
   static void RespCallback( IAsyncResult^ ar )
   {
      
      // State of request is asynchronous.
      RequestDeclare^ requestDeclare = dynamic_cast<RequestDeclare^>(ar->AsyncState);
      FileWebRequest^ myFileWebRequest = requestDeclare->myFileWebRequest;
      
      // End the Asynchronus request by calling the 'EndGetResponse()' method.
      FileWebResponse^ myFileWebResponse = dynamic_cast<FileWebResponse^>(myFileWebRequest->EndGetResponse( ar ));
      
      // Reade the response into Stream.
      StreamReader^ streamReader = gcnew StreamReader( myFileWebResponse->GetResponseStream() );
      array<Char>^readBuffer = gcnew array<Char>(256);
      int count = streamReader->Read( readBuffer, 0, 256 );
      Console::WriteLine( "The contents of the file are :\n" );
      while ( count > 0 )
      {
         String^ str = gcnew String( readBuffer,0,count );
         Console::WriteLine( str );
         count = streamReader->Read( readBuffer, 0, 256 );
      }

      streamReader->Close();
      
      // Release the response Object* resources.
      myFileWebResponse->Close();
      allDone->Set();
      Console::WriteLine( "File reading is over." );
   }

};

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease enter the file name as command line parameter:" );
      Console::WriteLine( "Usage:FileWebRequest_resbeginend <systemname>/<sharedfoldername>/<filename>\n" );
      Console::WriteLine( "Example:FileWebRequest_resbeginend shafeeque/shaf/hello.txt" );
   }
   else
   {
      try
      {
         
         // Place a 'Webrequest'.
         WebRequest^ myWebRequest = WebRequest::Create( String::Concat( "file://", args[ 1 ] ) );
         
         // Create an instance of the 'RequestDeclare' and associating the 'myWebRequest' to it.
         RequestDeclare^ myRequestDeclare = gcnew RequestDeclare;
         myRequestDeclare->myFileWebRequest = dynamic_cast<FileWebRequest^>(myWebRequest);
         
         // Begin the Asynchronous request for getting file content using 'BeginGetResponse()' method.
         IAsyncResult^ asyncResult = dynamic_cast<IAsyncResult^>(myRequestDeclare->myFileWebRequest->BeginGetResponse( gcnew AsyncCallback( &FileWebRequest_resbeginend::RespCallback ), myRequestDeclare ));
         FileWebRequest_resbeginend::allDone->WaitOne();
      }
      catch ( ArgumentNullException^ e ) 
      {
         Console::WriteLine( "ArgumentNullException is : {0}", e->Message );
      }
      catch ( UriFormatException^ e ) 
      {
         Console::WriteLine( "UriFormatException is : {0}", e->Message );
      }

   }
}

// </Snippet2>
// </Snippet1>
