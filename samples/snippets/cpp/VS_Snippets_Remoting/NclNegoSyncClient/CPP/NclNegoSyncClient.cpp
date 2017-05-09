
//<snippet0>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Security;
using namespace System::Net::Sockets;
using namespace System::Security::Principal;

//<snippet2>
static void DisplayStreamProperties( NegotiateStream^ stream )
{
   Console::WriteLine( L"Can read: {0}", stream->CanRead );
   Console::WriteLine( L"Can write: {0}", stream->CanWrite );
   Console::WriteLine( L"Can seek: {0}", stream->CanSeek );
   try
   {
      
      // If the underlying stream supports it, display the length.
      Console::WriteLine( L"Length: {0}", stream->Length );
   }
   catch ( NotSupportedException^ ) 
   {
      Console::WriteLine( L"Cannot get the length of the underlying stream." );
   }

   if ( stream->CanTimeout )
   {
      Console::WriteLine( L"Read time-out: {0}", stream->ReadTimeout );
      Console::WriteLine( L"Write time-out: {0}", stream->WriteTimeout );
   }
}


//</snippet2>
//<snippet1>
static void DisplayAuthenticationProperties( NegotiateStream^ stream )
{
   Console::WriteLine( L"IsAuthenticated: {0}", stream->IsAuthenticated );
   Console::WriteLine( L"IsMutuallyAuthenticated: {0}", stream->IsMutuallyAuthenticated );
   Console::WriteLine( L"IsEncrypted: {0}", stream->IsEncrypted );
   Console::WriteLine( L"IsSigned: {0}", stream->IsSigned );
   Console::WriteLine( L"ImpersonationLevel: {0}", stream->ImpersonationLevel );
   Console::WriteLine( L"IsServer: {0}", stream->IsServer );
}


//</snippet1>
//<snippet4>
int main()
{
   
   //<snippet3>
   // Establish the remote endpoint for the socket.
   // For this example, use the local machine.
   IPHostEntry^ ipHostInfo = Dns::GetHostEntry( Dns::GetHostName() );
   IPAddress^ ipAddress = ipHostInfo->AddressList[ 0 ];
   
   // Client and server use port 11000. 
   IPEndPoint^ remoteEP = gcnew IPEndPoint( ipAddress,11000 );
   
   // Create a TCP/IP socket.
   TcpClient^ client = gcnew TcpClient;
   
   // Connect the socket to the remote endpoint.
   client->Connect( remoteEP );
   Console::WriteLine( L"Client connected to {0}.", remoteEP );
   
   // Ensure the client does not close when there is 
   // still data to be sent to the server.
   client->LingerState = (gcnew LingerOption( true,0 ));
   
   // Request authentication.
   NetworkStream^ clientStream = client->GetStream();
   NegotiateStream^ authStream = gcnew NegotiateStream( clientStream );
   
   // Request authentication for the client only (no mutual authentication).
   // Authenicate using the client's default credetials.
   // Permit the server to impersonate the client to access resources on the server only.
   // Request that data be transmitted using encryption and data signing.
   authStream->AuthenticateAsClient( dynamic_cast<NetworkCredential^>(CredentialCache::DefaultCredentials), 
          L"", 
          ProtectionLevel::EncryptAndSign, 
          TokenImpersonationLevel::Impersonation );
   
   //</snippet3>
   DisplayAuthenticationProperties( authStream );
   DisplayStreamProperties( authStream );
   if ( authStream->CanWrite )
   {
      
      // Encode the test data into a byte array.
      array<Byte>^message = System::Text::Encoding::UTF8->GetBytes( L"Hello from the client." );
      authStream->Write( message, 0, message->Length );
      authStream->Flush();
      Console::WriteLine( L"Sent {0} bytes.", message->Length );
   }

   
   // Close the client connection.
   authStream->Close();
   Console::WriteLine( L"Client closed." );
}

//</snippet4>
//</snippet0>
