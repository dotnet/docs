

// System::Net::WebRequest::BeginGetResponse  System::Net::WebRequest::EndGetResponse
/*
* This program demonstrates BeginGetResponse and EndGetResponse methods of
* WebRequest Class::A new WebRequest object is created to the mentioned Uri.
* An Asynchronous call is started for response from the Uri using BeginGetResponse
* method of WebRequest class.
* The asynchronous response is ended by the EndGetResponse method of the
* WebRequest class. The page at the requested Uri is finally displayed.
*/
// <Snippet1>
// <Snippet2>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Text;
using namespace System::Threading;
public ref class RequestState
{
private:

   // This class stores the state of the request.
   literal int BUFFER_SIZE = 1024;

public:
   StringBuilder^ requestData;
   array<Byte>^bufferRead;
   WebRequest^ request;
   WebResponse^ response;
   Stream^ responseStream;
   RequestState()
   {
      bufferRead = gcnew array<Byte>(BUFFER_SIZE);
      requestData = gcnew StringBuilder( "" );
      request = nullptr;
      responseStream = nullptr;
   }

};

ref class WebRequest_BeginGetResponse
{
public:
   static ManualResetEvent^ allDone = gcnew ManualResetEvent( false );
   literal int BUFFER_SIZE = 1024;
   static void RespCallback( IAsyncResult^ asynchronousResult )
   {
      try
      {
         
         // Set the State of request to asynchronous.
         RequestState^ myRequestState = dynamic_cast<RequestState^>(asynchronousResult->AsyncState);
         WebRequest^ myWebRequest1 = myRequestState->request;
         
         // End the Asynchronous response.
         myRequestState->response = myWebRequest1->EndGetResponse( asynchronousResult );
         
         // Read the response into a 'Stream' object.
         Stream^ responseStream = myRequestState->response->GetResponseStream();
         myRequestState->responseStream = responseStream;
         
         // Begin the reading of the contents of the HTML page and print it to the console.
         IAsyncResult^ asynchronousResultRead = responseStream->BeginRead( myRequestState->bufferRead, 0, BUFFER_SIZE, gcnew AsyncCallback( ReadCallBack ), myRequestState );
      }
      catch ( WebException^ e ) 
      {
         Console::WriteLine( "WebException raised!" );
         Console::WriteLine( "\n {0}", e->Message );
         Console::WriteLine( "\n {0}", e->Status );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Exception raised!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }

   }

   static void ReadCallBack( IAsyncResult^ asyncResult )
   {
      try
      {
         
         // Result state is set to AsyncState.
         RequestState^ myRequestState = dynamic_cast<RequestState^>(asyncResult->AsyncState);
         Stream^ responseStream = myRequestState->responseStream;
         int read = responseStream->EndRead( asyncResult );
         
         // Read the contents of the HTML page and then print to the console.
         if ( read > 0 )
         {
            myRequestState->requestData->Append( Encoding::ASCII->GetString( myRequestState->bufferRead, 0, read ) );
            IAsyncResult^ asynchronousResult = responseStream->BeginRead( myRequestState->bufferRead, 0, BUFFER_SIZE, gcnew AsyncCallback( ReadCallBack ), myRequestState );
         }
         else
         {
            Console::WriteLine( "\nThe HTML page Contents are:  " );
            if ( myRequestState->requestData->Length > 1 )
            {
               String^ sringContent;
               sringContent = myRequestState->requestData->ToString();
               Console::WriteLine( sringContent );
            }
            Console::WriteLine( "\nPress 'Enter' key to continue........" );
            responseStream->Close();
            allDone->Set();
         }
      }
      catch ( WebException^ e ) 
      {
         Console::WriteLine( "WebException raised!" );
         Console::WriteLine( "\n {0}", e->Message );
         Console::WriteLine( "\n {0}", e->Status );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Exception raised!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }

   }

};

int main()
{
   try
   {
      
      // Create a new webrequest to the mentioned URL.
      WebRequest^ myWebRequest = WebRequest::Create( "http://www.contoso.com" );
      
      // Please, set the proxy to a correct value.
      WebProxy^ proxy = gcnew WebProxy( "myproxy:80" );
      proxy->Credentials = gcnew NetworkCredential( "srikun","simrin123" );
      myWebRequest->Proxy = proxy;
      
      // Create a new instance of the RequestState.
      RequestState^ myRequestState = gcnew RequestState;
      
      // The 'WebRequest' object is associated to the 'RequestState' object.
      myRequestState->request = myWebRequest;
      
      // Start the Asynchronous call for response.
      IAsyncResult^ asyncResult = dynamic_cast<IAsyncResult^>(myWebRequest->BeginGetResponse( gcnew AsyncCallback( WebRequest_BeginGetResponse::RespCallback ), myRequestState ));
      WebRequest_BeginGetResponse::allDone->WaitOne();
      
      // Release the WebResponse resource.
      myRequestState->response->Close();
      Console::Read();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "WebException raised!" );
      Console::WriteLine( "\n {0}", e->Message );
      Console::WriteLine( "\n {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }

}

// </Snippet2>
// </Snippet1>
