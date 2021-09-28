
//<snippet0>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Security;
using namespace System::Net::Sockets;
using namespace System::Text;

//<snippet6>
// The following class displays the properties of an authenticatedStream.
public ref class AuthenticatedStreamReporter
{
public:
   static void DisplayProperties( AuthenticatedStream^ stream )
   {
      Console::WriteLine( L"IsAuthenticated: {0}", stream->IsAuthenticated );
      Console::WriteLine( L"IsMutuallyAuthenticated: {0}", stream->IsMutuallyAuthenticated );
      Console::WriteLine( L"IsEncrypted: {0}", stream->IsEncrypted );
      Console::WriteLine( L"IsSigned: {0}", stream->IsSigned );
      Console::WriteLine( L"IsServer: {0}", stream->IsServer );
   }

};


//</snippet6>
public ref class ASynchronousAuthenticatingTcpClient
{
private:
   static TcpClient^ client = nullptr;

public:
   void Main()
   {
      
   //<snippet2>
   //<snippet1>
      // Establish the remote endpoint for the socket.
      // For this example, use the local machine.
      IPHostEntry^ ipHostInfo = Dns::GetHostEntry( Dns::GetHostName() );
      IPAddress^ ipAddress = ipHostInfo->AddressList[ 0 ];
      
      // Client and server use port 11000. 
      IPEndPoint^ remoteEP = gcnew IPEndPoint( ipAddress,11000 );
      
      // Create a TCP/IP socket.
      client = gcnew TcpClient;
      
      // Connect the socket to the remote endpoint.
      client->Connect( remoteEP );
      Console::WriteLine( L"Client connected to {0}.", remoteEP );
      
      // Ensure the client does not close when there is 
      // still data to be sent to the server.
      client->LingerState = (gcnew LingerOption( true,0 ));
      
   //<snippet3>
      // Request authentication.
      NetworkStream^ clientStream = client->GetStream();
      NegotiateStream^ authStream = gcnew NegotiateStream( clientStream,false );
      
   //</snippet1>        
      // Pass the NegotiateStream as the AsyncState object 
      // so that it is available to the callback delegate.
      IAsyncResult^ ar = authStream->BeginAuthenticateAsClient( gcnew AsyncCallback( EndAuthenticateCallback ), authStream );
      
   //</snippet2>
      Console::WriteLine( L"Client waiting for authentication..." );
      
      // Wait until the result is available.
      ar->AsyncWaitHandle->WaitOne();
      
      // Display the properties of the authenticated stream.
      AuthenticatedStreamReporter::DisplayProperties( authStream );
      
      // Send a message to the server.
      // Encode the test data into a byte array.
      array<Byte>^message = Encoding::UTF8->GetBytes( L"Hello from the client." );
      ar = authStream->BeginWrite( message, 0, message->Length, gcnew AsyncCallback( EndWriteCallback ), authStream );
      
   //</snippet3>
      ar->AsyncWaitHandle->WaitOne();
      Console::WriteLine( L"Sent {0} bytes.", message->Length );
      
      // Close the client connection.
      authStream->Close();
      Console::WriteLine( L"Client closed." );
   }


   //<snippet5>
   // The following method is called when the authentication completes.
   static void EndAuthenticateCallback( IAsyncResult^ ar )
   {
      Console::WriteLine( L"Client ending authentication..." );
      NegotiateStream^ authStream = dynamic_cast<NegotiateStream^>(ar->AsyncState);
      
      // End the asynchronous operation.
      authStream->EndAuthenticateAsClient( ar );
      
      //         Console.WriteLine("AllowedImpersonation: {0}", authStream.AllowedImpersonation);
   }


   //</snippet5>
   //<snippet4>
   // The following method is called when the write operation completes.
   static void EndWriteCallback( IAsyncResult^ ar )
   {
      Console::WriteLine( L"Client ending write operation..." );
      NegotiateStream^ authStream = dynamic_cast<NegotiateStream^>(ar->AsyncState);
      
      // End the asynchronous operation.
      authStream->EndWrite( ar );
   }

   //</snippet4>
};

void main()
{
   ASynchronousAuthenticatingTcpClient^ aatc = gcnew ASynchronousAuthenticatingTcpClient;
   aatc->Main();
}
//</snippet0>

