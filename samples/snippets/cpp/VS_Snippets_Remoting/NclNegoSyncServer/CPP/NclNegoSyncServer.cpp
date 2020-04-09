
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Security;
using namespace System::Net::Sockets;
using namespace System::Security::Principal;
using namespace System::Text;
using namespace System::IO;
using namespace System::Threading;

//<snippet1>
static void AuthenticateClient( TcpClient^ clientRequest )
{
   NetworkStream^ stream = clientRequest->GetStream();
   
   // Create the NegotiateStream.
   NegotiateStream^ authStream = gcnew NegotiateStream( stream,false );
   
   // Perform the server side of the authentication.
   authStream->AuthenticateAsServer();
   
   // Display properties of the authenticated client.
   IIdentity^ id = authStream->RemoteIdentity;
   Console::WriteLine( L"{0} was authenticated using {1}.", id->Name, id->AuthenticationType );
   
   // Read a message from the client.
   array<Byte>^buffer = gcnew array<Byte>(2048);
   int charLength = authStream->Read( buffer, 0, buffer->Length );
   String^ messageData = gcnew String( Encoding::UTF8->GetChars( buffer, 0, buffer->Length ) );
   Console::WriteLine( L"READ {0}", messageData );
   
   // Finished with the current client.
   authStream->Close();
   
   // Close the client connection.
   clientRequest->Close();
}


//</snippet1>
int main()
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

      Console::WriteLine( L"Client connected." );
   }
}

