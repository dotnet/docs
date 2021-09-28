/*
This program demonstrates 'BeginResolve' and 'EndResolve' methods of Dns class.
It obtains the 'IPHostEntry' Object* by calling 'BeginResolve' and 'EndResolve' method
of 'Dns' class by passing a URL, a callback function and an instance of 'RequestState'
class.Then prints host name, IP address list and aliases.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Threading;

// <Snippet1>
// <Snippet2>
public ref class DnsBeginGetHostByName
{
public:
   static System::Threading::ManualResetEvent^ allDone = nullptr;
   ref class RequestState
   {
   public:
      IPHostEntry^ host;
      RequestState()
      {
         host = nullptr;
      }
   };

   static void RespCallback( IAsyncResult^ ar )
   {
      try
      {
         // Convert the IAsyncResult* Object* to a RequestState Object*.
         RequestState^ tempRequestState = dynamic_cast<RequestState^>(ar->AsyncState);
         
         // End the asynchronous request.
         tempRequestState->host = Dns::EndResolve( ar );
         allDone->Set();
      }
      catch ( ArgumentNullException^ e ) 
      {
         Console::WriteLine( "ArgumentNullException caught!!!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Exception caught!!!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }
   }
};

int main()
{
   DnsBeginGetHostByName::allDone = gcnew ManualResetEvent( false );
   
   // Create an instance of the RequestState class.
   DnsBeginGetHostByName::RequestState^ myRequestState =
      gcnew DnsBeginGetHostByName::RequestState;
   
   // Begin an asynchronous request for information like host name, IP addresses, or
   // aliases for specified the specified URI.
   IAsyncResult^ asyncResult = Dns::BeginResolve( "www.contoso.com",
      gcnew AsyncCallback( DnsBeginGetHostByName::RespCallback ), myRequestState );
   
   // Wait until asynchronous call completes.
   DnsBeginGetHostByName::allDone->WaitOne();
   Console::WriteLine( "Host name : {0}", myRequestState->host->HostName );
   Console::WriteLine( "\nIP address list : " );
   for ( int index = 0; index < myRequestState->host->AddressList->Length; index++ )
      Console::WriteLine( myRequestState->host->AddressList[ index ] );
   Console::WriteLine( "\nAliases : " );
   for ( int index = 0; index < myRequestState->host->Aliases->Length; index++ )
      Console::WriteLine( myRequestState->host->Aliases[ index ] );
}
// </Snippet2>
// </Snippet1>
