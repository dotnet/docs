

/**
* File name: Begingetresponse::cs
* This program shows how to use BeginGetResponse and EndGetResponse methods of the
* HttpWebRequest class. It also shows how to create a customized timeout.
* This is important in case od asynchronous request, because the NCL classes do
* not provide any off-the-shelf asynchronous timeout.
* It uses an asynchronous approach to get the response for the HTTP Web Request.
* The RequestState class is defined to chekc the state of the request.
* After a HttpWebRequest Object* is created, its BeginGetResponse method is used to start
* the asynchronous response phase.
* Finally, the EndGetResponse method is used to end the asynchronous response phase .
*/
// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Text;
using namespace System::Threading;
public ref class RequestState
{
private:

   // This class stores the State of the request.
   const int BUFFER_SIZE;

public:
   StringBuilder^ requestData;
   array<Byte>^BufferRead;
   HttpWebRequest^ request;
   HttpWebResponse^ response;
   Stream^ streamResponse;
   RequestState()
      : BUFFER_SIZE( 1024 )
   {
      BufferRead = gcnew array<Byte>(BUFFER_SIZE);
      requestData = gcnew StringBuilder( "" );
      request = nullptr;
      streamResponse = nullptr;
   }

};

ref class HttpWebRequest_BeginGetResponse
{
public:
   static ManualResetEvent^ allDone = gcnew ManualResetEvent( false );
   literal int BUFFER_SIZE = 1024;
   literal int DefaultTimeOut = 120000; // 2 minute timeout 

   // Abort the request if the timer fires.
   static void TimeoutCallback( Object^ state, bool timedOut )
   {
      if ( timedOut )
      {
         HttpWebRequest^ request = dynamic_cast<HttpWebRequest^>(state);
         if ( request != nullptr )
         {
            request->Abort();
         }
      }
   }

   static void RespCallback( IAsyncResult^ asynchronousResult )
   {
      try
      {
         
         // State of request is asynchronous.
         RequestState^ myRequestState = dynamic_cast<RequestState^>(asynchronousResult->AsyncState);
         HttpWebRequest^ myHttpWebRequest = myRequestState->request;
         myRequestState->response = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->EndGetResponse( asynchronousResult ));
         
         // Read the response into a Stream object.
         Stream^ responseStream = myRequestState->response->GetResponseStream();
         myRequestState->streamResponse = responseStream;
         
         // Begin the Reading of the contents of the HTML page and print it to the console.
         IAsyncResult^ asynchronousInputRead = responseStream->BeginRead( myRequestState->BufferRead, 0, BUFFER_SIZE, gcnew AsyncCallback( ReadCallBack ), myRequestState );
         return;
      }
      catch ( WebException^ e ) 
      {
         Console::WriteLine( "\nRespCallback Exception raised!" );
         Console::WriteLine( "\nMessage: {0}", e->Message );
         Console::WriteLine( "\nStatus: {0}", e->Status );
      }

      allDone->Set();
   }

   static void ReadCallBack( IAsyncResult^ asyncResult )
   {
      try
      {
         RequestState^ myRequestState = dynamic_cast<RequestState^>(asyncResult->AsyncState);
         Stream^ responseStream = myRequestState->streamResponse;
         int read = responseStream->EndRead( asyncResult );
         
         // Read the HTML page and then print it to the console.
         if ( read > 0 )
         {
            myRequestState->requestData->Append( Encoding::ASCII->GetString( myRequestState->BufferRead, 0, read ) );
            IAsyncResult^ asynchronousResult = responseStream->BeginRead( myRequestState->BufferRead, 0, BUFFER_SIZE, gcnew AsyncCallback( ReadCallBack ), myRequestState );
            return;
         }
         else
         {
            Console::WriteLine( "\nThe contents of the Html page are : " );
            if ( myRequestState->requestData->Length > 1 )
            {
               String^ stringContent;
               stringContent = myRequestState->requestData->ToString();
               Console::WriteLine( stringContent );
            }
            Console::WriteLine( "Press any key to continue.........." );
            Console::ReadLine();
            responseStream->Close();
         }
      }
      catch ( WebException^ e ) 
      {
         Console::WriteLine( "\nReadCallBack Exception raised!" );
         Console::WriteLine( "\nMessage: {0}", e->Message );
         Console::WriteLine( "\nStatus: {0}", e->Status );
      }

      allDone->Set();
   }

};

int main()
{
   try
   {
      
      // Create a HttpWebrequest object to the desired URL.
      HttpWebRequest^ myHttpWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.contoso.com" ));
      
      /**
            * If you are behind a firewall and you do not have your browser proxy setup
            * you need to use the following proxy creation code.
      
            // Create a proxy object.
            WebProxy* myProxy = new WebProxy();
      
            // Associate a new Uri object to the _wProxy object, using the proxy address
            // selected by the user.
            myProxy.Address = new Uri(S"http://myproxy");
      
            // Finally, initialize the Web request object proxy property with the _wProxy
            // object.
            myHttpWebRequest.Proxy=myProxy;
            ***/
      // Create an instance of the RequestState and assign the previous myHttpWebRequest
      // object to its request field.
      RequestState^ myRequestState = gcnew RequestState;
      myRequestState->request = myHttpWebRequest;
      
      // Start the asynchronous request.
      IAsyncResult^ result = dynamic_cast<IAsyncResult^>(myHttpWebRequest->BeginGetResponse( gcnew AsyncCallback( HttpWebRequest_BeginGetResponse::RespCallback ), myRequestState ));
      
      // this line impliments the timeout, if there is a timeout, the callback fires and the request becomes aborted
      ThreadPool::RegisterWaitForSingleObject( result->AsyncWaitHandle, gcnew WaitOrTimerCallback( HttpWebRequest_BeginGetResponse::TimeoutCallback ), myHttpWebRequest, HttpWebRequest_BeginGetResponse::DefaultTimeOut, true );
      
      // The response came in the allowed time. The work processing will happen in the
      // callback function.
      HttpWebRequest_BeginGetResponse::allDone->WaitOne();
      
      // Release the HttpWebResponse resource.
      myRequestState->response->Close();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nMain Exception raised!" );
      Console::WriteLine( "\nMessage: {0}", e->Message );
      Console::WriteLine( "\nStatus: {0}", e->Status );
      Console::WriteLine( "Press any key to continue.........." );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nMain Exception raised!" );
      Console::WriteLine( "Source : {0} ", e->Source );
      Console::WriteLine( "Message : {0} ", e->Message );
      Console::WriteLine( "Press any key to continue.........." );
      Console::Read();
   }

}

// </Snippet1>
