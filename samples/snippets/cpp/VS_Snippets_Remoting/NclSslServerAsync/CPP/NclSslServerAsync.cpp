
// NclSslServerAsync
//<snippet0>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Net::Security;
using namespace System::Security::Authentication;
using namespace System::Text;
using namespace System::Security::Cryptography::X509Certificates;
using namespace System::IO;

// The following example demonstrates the server side of a 
// client-server application that communicates using the
// SslStream, TcpListener, and TcpClient classes.
// After connecting to the server and authenticating, 
// the server reads a message from the client,
// sends a message to the client,
// and then terminates. Messages sent to and from the client are terminated
// with '<EOF>'.
// The ClientState class holds information shared
// by asynchronous calls.
// <snippet1>
public ref class ClientState
{
internal:
   SslStream^ stream;
   TcpClient^ client;
   StringBuilder^ readData;
   array<Byte>^buffer;
   ClientState( SslStream^ stream, TcpClient^ client )
   {
      this->stream = stream;
      this->client = client;
      readData = gcnew StringBuilder;
      buffer = gcnew array<Byte>(2048);
   }

   void Close()
   {
      
      // Close the SslStream. This will also close the 
      // NetworkStream allocated to the TcpClient.
      stream->Close();
      
      // Close the TcpClient.
      client->Close();
      readData = nullptr;
      buffer = nullptr;
      Console::WriteLine( L"Client closed." );
   }

};


// </snippet1>
public ref class SslTcpListener
{
public:

   // <snippet2>
   // The following method is invoked by the CertificateValidationDelegate.
   static bool ValidateCertificate( 
       Object^ sender,
       X509Certificate^ certificate, 
       X509Chain^ chain,
       SslPolicyErrors sslPolicyErrors)
   {
      if ( certificate == nullptr )
      {
         
         // Null certificate and no errors means that the client was not
         // required to provide a certificate.
         if ( sslPolicyErrors == SslPolicyErrors::None)
         {
            return true;
         }
         else
         {
             Console::WriteLine(L"Certificate error: {0}", sslPolicyErrors);
         }    
            return false;
      }

      Console::WriteLine( L"Server is validating certificate." );
      Console::WriteLine( L"Certificate was issued to {0} and is valid from {1} until {2}.", 
          certificate->Subject, 
          certificate->GetEffectiveDateString(), 
          certificate->GetExpirationDateString() );
      return true;
   }


   // </snippet2>
   // <snippet3>
   void AuthenticateCallback( IAsyncResult^ ar )
   {
      ClientState^ state = dynamic_cast<ClientState^>(ar->AsyncState);
      SslStream^ stream = state->stream;
      try
      {
         stream->EndAuthenticateAsServer( ar );
         Console::WriteLine( L"Authentication succeeded." );
         Console::WriteLine( L"Cipher: {0} strength {1}", stream->CipherAlgorithm, stream->CipherStrength );
         Console::WriteLine( L"Hash: {0} strength {1}", stream->HashAlgorithm, stream->HashStrength );
         Console::WriteLine( L"Key exchange: {0} strength {1}", stream->KeyExchangeAlgorithm, stream->KeyExchangeStrength );
         Console::WriteLine( L"Protocol: {0}", stream->SslProtocol );
         
         // Asynchronously read a message from the client.
         stream->BeginRead( state->buffer, 0, state->buffer->Length, gcnew AsyncCallback( this, &SslTcpListener::ReadCallback ), state );
      }
      catch ( Exception^ authenticationException ) 
      {
         Console::WriteLine( L"Authentication error: {0}", authenticationException->Message );
         if ( authenticationException->InnerException != nullptr )
         {
            Console::WriteLine( L" Inner exception: {0}", authenticationException->InnerException->Message );
         }
         state->Close();
         return;
      }

   }


   // </snippet3>
   // <snippet4>
   void WriteCallback( IAsyncResult^ ar )
   {
      ClientState^ state = dynamic_cast<ClientState^>(ar->AsyncState);
      SslStream^ stream = state->stream;
      try
      {
         Console::WriteLine( L"Writing data to the client." );
         stream->EndWrite( ar );
      }
      catch ( Exception^ writeException ) 
      {
         Console::WriteLine( L"Write error: {0}", writeException->Message );
         state->Close();
         return;
      }

      Console::WriteLine( L"Finished with client." );
      state->Close();
   }


   // </snippet4>
   // <snippet5>
   void ReadCallback( IAsyncResult^ ar )
   {
      ClientState^ state = dynamic_cast<ClientState^>(ar->AsyncState);
      SslStream^ stream = state->stream;
      
      // Read the  message sent by the client.
      // The end of the message is signaled using the
      // "<EOF>" marker.
      int byteCount = -1;
      try
      {
         Console::WriteLine( L"Reading data from the client." );
         byteCount = stream->EndRead( ar );
         
         // Use Decoder class to convert from bytes to UTF8
         // in case a character spans two buffers.
         Decoder^ decoder = Encoding::UTF8->GetDecoder();
         array<Char>^chars = gcnew array<Char>(decoder->GetCharCount( state->buffer, 0, byteCount ));
         decoder->GetChars( state->buffer, 0, byteCount, chars, 0 );
         state->readData->Append( chars );
         
         // Check for EOF or an empty message.
         if ( state->readData->ToString()->IndexOf( L"<EOF>" ) == -1 && byteCount != 0 )
         {
            
            // We are not finished reading.
            // Asynchronously read more message data from  the client.
            stream->BeginRead( state->buffer, 0, state->buffer->Length, gcnew AsyncCallback( this, &SslTcpListener::ReadCallback ), state );
         }
         else
         {
            Console::WriteLine( L"Message from the client: {0}", state->readData );
         }
         
         // Encode a test message into a byte array.
         // Signal the end of the message using "<EOF>".
         array<Byte>^message = Encoding::UTF8->GetBytes( L"Hello from the server.<EOF>" );
         
         // Asynchronously send the message to the client.
         stream->BeginWrite( message, 0, message->Length, gcnew AsyncCallback( this, &SslTcpListener::WriteCallback ), state );
      }
      catch ( Exception^ readException ) 
      {
         Console::WriteLine( L"Read error: {0}", readException->Message );
         state->Close();
         return;
      }

   }


   // </snippet5>
   // <snippet6>
   void ProcessClient( ClientState^ state, X509Certificate^ serverCertificate )
   {
      try
      {
         state->stream->BeginAuthenticateAsServer( 
             serverCertificate, true, SslProtocols::Tls, true, 
             gcnew AsyncCallback( this, &SslTcpListener::AuthenticateCallback ), state );
      }
      catch ( Exception^ authenticationException ) 
      {
         Console::WriteLine( L"Authentication error: {0}", authenticationException->Message );
         state->Close();
         return;
      }

   }


   // </snippet6>
   // <snippet7>
   int ServerSideTest()
   {
      array<String^>^args = Environment::GetCommandLineArgs();
      if ( args == nullptr || args->Length == 0 )
      {
         Console::WriteLine( L"You must specify the server certificate file." );
         return 0;
      }

      X509Certificate^ serverCertificate = X509Certificate::CreateFromCertFile( args[ 1 ] );
      
      // Create a TCP/IP (IPv4) socket and listen for incoming connections.
      TcpListener^ listener = gcnew TcpListener( IPAddress::Any,8080 );
      listener->Start();
      while ( true )
      {
         
         // Application blocks while waiting for an incoming connection.
         // Type CNTL-C to terminate the server.
         TcpClient^ client = listener->AcceptTcpClient();
         Console::WriteLine( L"Client connected." );
         SslStream^ stream = gcnew SslStream( client->GetStream(),false,
             gcnew RemoteCertificateValidationCallback( ValidateCertificate ) );
         ClientState^ state = gcnew ClientState( stream,client );
         SslTcpListener^ listenerWorker = gcnew SslTcpListener;
         listenerWorker->ProcessClient( state, serverCertificate );
      }
   }

   // </snippet7>
};

int main()
{
   SslTcpListener^ stl = gcnew SslTcpListener;
   stl->ServerSideTest();
}

//</snippet0>
