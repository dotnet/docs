

// System::Net::FileWebRequest::BeginGetRequestStream;System::Net::FileWebRequest::EndGetRequestStream;
// Snippet1 and Snippet2 go together
/*
This program demonstrates 'BeginGetRequestStream' and 'EndGetRequestStream' method of 'FileWebRequest' class
The path of the file from where content is to be read  is obtained as a command line argument and a 'webRequest'
Object* is created.Using the 'BeginGetRequestStream' method and 'EndGetRequestStream' of 'FileWebRequest' class
a stream Object* is obtained which is used to write into the file.
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Text;
using namespace System::Threading;

// <Snippet1>
// <Snippet2>
public ref class RequestDeclare
{
public:
   FileWebRequest^ myFileWebRequest;
   String^ userinput;
   RequestDeclare()
   {
      myFileWebRequest = nullptr;
   }

};

ref class FileWebRequest_reqbeginend
{
public:
   static ManualResetEvent^ allDone = gcnew ManualResetEvent( false );
   static void ReadCallback( IAsyncResult^ ar )
   {
      try
      {
         
         // State of the request is asynchronous.
         RequestDeclare^ requestDeclare = dynamic_cast<RequestDeclare^>(ar->AsyncState);
         FileWebRequest^ myFileWebRequest = requestDeclare->myFileWebRequest;
         String^ sendToFile = requestDeclare->userinput;
         
         // End the Asynchronus request by calling the 'EndGetRequestStream()' method.
         Stream^ readStream = myFileWebRequest->EndGetRequestStream( ar );
         
         // Convert the String* into Byte array.
         ASCIIEncoding^ encoder = gcnew ASCIIEncoding;
         array<Byte>^byteArray = encoder->GetBytes( sendToFile );
         
         // Write to the stream.
         readStream->Write( byteArray, 0, sendToFile->Length );
         readStream->Close();
         allDone->Set();
         Console::WriteLine( "\nThe String you entered was successfully written into the file." );
         Console::WriteLine( "\nPress Enter to continue." );
      }
      catch ( ApplicationException^ e ) 
      {
         Console::WriteLine( "ApplicationException is : {0}", e->Message );
      }

   }

};

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease enter the file name as command line parameter:" );
      Console::WriteLine( "Usage:FileWebRequest_reqbeginend <systemname>/<sharedfoldername>/<filename>\n" );
      Console::WriteLine( "Example:FileWebRequest_reqbeginend shafeeque/shaf/hello.txt" );
   }
   else
   {
      try
      {
         
         // Place a webrequest.
         WebRequest^ myWebRequest = WebRequest::Create( String::Concat( "file://", args[ 1 ] ) );
         
         // Create an instance of the 'RequestDeclare' and associate the 'myWebRequest' to it.
         RequestDeclare^ requestDeclare = gcnew RequestDeclare;
         requestDeclare->myFileWebRequest = dynamic_cast<FileWebRequest^>(myWebRequest);
         
         // Set the 'Method' property of 'FileWebRequest' Object* to 'POST' method.
         requestDeclare->myFileWebRequest->Method = "POST";
         Console::WriteLine( "Enter the String* you want to write into the file:" );
         requestDeclare->userinput = Console::ReadLine();
         
         // Begin the Asynchronous request for getting file content using 'BeginGetRequestStream()' method .
         IAsyncResult^ r = dynamic_cast<IAsyncResult^>(requestDeclare->myFileWebRequest->BeginGetRequestStream( gcnew AsyncCallback( &FileWebRequest_reqbeginend::ReadCallback ), requestDeclare ));
         FileWebRequest_reqbeginend::allDone->WaitOne();
         Console::Read();
      }
      catch ( ProtocolViolationException^ e ) 
      {
         Console::WriteLine( "ProtocolViolationException is : {0}", e->Message );
      }
      catch ( InvalidOperationException^ e ) 
      {
         Console::WriteLine( "InvalidOperationException is : {0}", e->Message );
      }
      catch ( UriFormatException^ e ) 
      {
         Console::WriteLine( "UriFormatExceptionException is : {0}", e->Message );
      }

   }
}

// </Snippet2>
// </Snippet1>
