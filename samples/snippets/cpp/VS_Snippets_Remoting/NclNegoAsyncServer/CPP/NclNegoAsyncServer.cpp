
//<snippet0>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Security;
using namespace System::Net::Sockets;
using namespace System::Security::Authentication;
using namespace System::Security::Principal;
using namespace System::Text;
using namespace System::IO;
using namespace System::Threading;

// ClientState is the AsyncState object.
private ref class ClientState
{
private:
   AuthenticatedStream^ authStream;
   TcpClient^ client;
   array<Byte>^buffer;
   StringBuilder^ message;
   ManualResetEvent^ waiter;

internal:
   ClientState( AuthenticatedStream^ a, TcpClient^ theClient )
   {
      authStream = a;
      client = theClient;
      message = nullptr;
      buffer = gcnew array<Byte>(2048);
      waiter = gcnew ManualResetEvent( false );
   }

internal:
   property TcpClient^ Client 
   {
      TcpClient^ get()
      {
         return client;
      }
   }

   property AuthenticatedStream^ AuthStream 
   {
      AuthenticatedStream^ get()
      {
         return authStream;
      }
  }

   property array<Byte>^ Buffer 
   {
      array<Byte>^ get()
      {
         return buffer;
      }

   }

   property StringBuilder^ Message 
   {
      StringBuilder^ get()
      {
         if ( message == nullptr )
                  message = gcnew StringBuilder;

         return message;
      }

   }

   property ManualResetEvent^ Waiter 
   {
      ManualResetEvent^ get()
      {
         return waiter;
      }

   }

};

public ref class AsynchronousAuthenticatingTcpListener
{
public:
   int Main()
   {
      
      // Create an IPv4 TCP/IP socket. 
      TcpListener^ listener = gcnew TcpListener( IPAddress::Any,11000 );
      
      // Listen for incoming connections.
      listener->Start();
      while ( true )
      {
         TcpClient^ clientRequest = nullptr;
         
         // Application blocks while waiting for an incoming connection.
         // Type CNTL-C to terminate the server.
         clientRequest = listener->AcceptTcpClient();
         Console::WriteLine( L"Client connected." );
         
         // A client has connected. 
         try
         {
            AuthenticateClient( clientRequest );
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( e );
            continue;
         }

      }
   }


   //<snippet1>
   static void AuthenticateClient( TcpClient^ clientRequest )
   {
      NetworkStream^ stream = clientRequest->GetStream();
      
      // Create the NegotiateStream.
      NegotiateStream^ authStream = gcnew NegotiateStream( stream,false );
      
      // Save the current client and NegotiateStream instance 
      // in a ClientState object.
      ClientState^ cState = gcnew ClientState( authStream,clientRequest );
      
      // Listen for the client authentication request.
      authStream->BeginAuthenticateAsServer( gcnew AsyncCallback( EndAuthenticateCallback ), cState );
      
      // Wait until the authentication completes.
      cState->Waiter->WaitOne();
      cState->Waiter->Reset();
      authStream->BeginRead( cState->Buffer, 0, cState->Buffer->Length, gcnew AsyncCallback( EndReadCallback ), cState );
      cState->Waiter->WaitOne();
      
      // Finished with the current client.
      authStream->Close();
      clientRequest->Close();
   }


   //</snippet1>    
   // The following method is invoked by the
   // BeginServerAuthenticate callback delegate.
   //<snippet2>
   static void EndAuthenticateCallback( IAsyncResult^ ar )
   {
      
      // Get the saved data.
      ClientState^ cState = dynamic_cast<ClientState^>(ar->AsyncState);
      TcpClient^ clientRequest = cState->Client;
      NegotiateStream^ authStream = dynamic_cast<NegotiateStream^>(cState->AuthStream);
      Console::WriteLine( L"Ending authentication." );
      
      // Any exceptions that occurred during authentication are
      // thrown by the EndServerAuthenticate method.
      try
      {
         
         // This call blocks until the authentication is complete.
         authStream->EndAuthenticateAsServer( ar );
      }
      catch ( AuthenticationException^ e ) 
      {
         Console::WriteLine( e );
         Console::WriteLine( L"Authentication failed - closing connection." );
         cState->Waiter->Set();
         return;
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e );
         Console::WriteLine( L"Closing connection." );
         cState->Waiter->Set();
         return;
      }

      
      // Display properties of the authenticated client.
      IIdentity^ id = authStream->RemoteIdentity;
      Console::WriteLine( L"{0} was authenticated using {1}.", id->Name, id->AuthenticationType );
      cState->Waiter->Set();
   }


   //</snippet2>
   //<snippet3>
   static void EndReadCallback( IAsyncResult^ ar )
   {
      
      // Get the saved data.
      ClientState^ cState = dynamic_cast<ClientState^>(ar->AsyncState);
      TcpClient^ clientRequest = cState->Client;
      NegotiateStream^ authStream = dynamic_cast<NegotiateStream^>(cState->AuthStream);
      
      // Get the buffer that stores the message sent by the client.
      int bytes = -1;
      
      // Read the client message.
      try
      {
         bytes = authStream->EndRead( ar );
         cState->Message->Append( Encoding::UTF8->GetChars( cState->Buffer, 0, bytes ) );
         if ( bytes != 0 )
         {
            authStream->BeginRead( cState->Buffer, 0, cState->Buffer->Length, gcnew AsyncCallback( EndReadCallback ), cState );
            return;
         }
      }
      catch ( Exception^ e ) 
      {
         
         // A real application should do something
         // useful here, such as logging the failure.
         Console::WriteLine( L"Client message exception:" );
         Console::WriteLine( e );
         cState->Waiter->Set();
         return;
      }

      IIdentity^ id = authStream->RemoteIdentity;
      Console::WriteLine( L"{0} says {1}", id->Name, cState->Message );
      cState->Waiter->Set();
   }

   //</snippet3>
};

void main()
{
   AsynchronousAuthenticatingTcpListener^ aatl = gcnew AsynchronousAuthenticatingTcpListener;
   aatl->Main();
}

//</snippet0>
