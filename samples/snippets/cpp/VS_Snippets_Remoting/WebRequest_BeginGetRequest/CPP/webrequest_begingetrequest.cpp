

// <Snippet3>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Text;
using namespace System::Threading;
public ref class RequestState
{
public:

   // This class stores the request state of the request.
   WebRequest^ request;
   RequestState()
   {
      request = nullptr;
   }

};

ref class WebRequest_BeginGetRequeststream
{
public:
   static ManualResetEvent^ allDone = gcnew ManualResetEvent( false );
   static void ReadCallback( IAsyncResult^ asynchronousResult )
   {
      RequestState^ myRequestState = dynamic_cast<RequestState^>(asynchronousResult->AsyncState);
      WebRequest^ myWebRequest = myRequestState->request;
      
      // End of the Asynchronus request.
      Stream^ streamResponse = myWebRequest->EndGetRequestStream( asynchronousResult );
      
      // Create a string that is to be posted to the uri.
      Console::WriteLine( "Please enter a string to be posted:" );
      String^ postData = Console::ReadLine();
      
      // Convert  the string into a Byte array.
      array<Byte>^byteArray = Encoding::UTF8->GetBytes( postData );
      
      // Write data to the stream.
      streamResponse->Write( byteArray, 0, postData->Length );
      streamResponse->Close();
      allDone->Set();
   }

};

int main()
{
   
   // <Snippet1>
   // Create a new request to the mentioned URL.
   WebRequest^ myWebRequest = WebRequest::Create( "http://www.contoso.com" );
   
   // Create an instance of the RequestState and assign 'myWebRequest' to its request field.
   RequestState^ myRequestState = gcnew RequestState;
   myRequestState->request = myWebRequest;
   myWebRequest->ContentType = "application/x-www-form-urlencoded";
   
   // Set the 'Method' prperty  to 'POST' to post data to a Uri.
   myRequestState->request->Method = "POST";
   
   // </Snippet1>
   // Start the Asynchronous 'BeginGetRequestStream' method call.
   IAsyncResult^ r = dynamic_cast<IAsyncResult^>(myWebRequest->BeginGetRequestStream( gcnew AsyncCallback( WebRequest_BeginGetRequeststream::ReadCallback ), myRequestState ));
   WebRequest_BeginGetRequeststream::allDone->WaitOne();
   WebResponse^ myWebResponse = myWebRequest->GetResponse();
   Console::WriteLine( "The String* entered has been posted." );
   Console::WriteLine( "Please wait for the response..." );
   Stream^ streamResponse = myWebResponse->GetResponseStream();
   StreamReader^ streamRead = gcnew StreamReader( streamResponse );
   array<Char>^readBuff = gcnew array<Char>(256);
   int count = streamRead->Read( readBuff, 0, 256 );
   Console::WriteLine( "The contents of the HTML page are " );
   while ( count > 0 )
   {
      String^ outputData = gcnew String( readBuff,0,count );
      Console::Write( outputData );
      count = streamRead->Read( readBuff, 0, 256 );
   }

   streamResponse->Close();
   streamRead->Close();
   
   // Release the HttpWebResponse Resource.
   myWebResponse->Close();
}

// </Snippet3>
