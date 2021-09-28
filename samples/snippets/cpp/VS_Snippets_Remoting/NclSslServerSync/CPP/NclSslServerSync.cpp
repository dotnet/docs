
// NclSslServerSync
// <snippet0>
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
public ref class SslTcpServer sealed
{
private:
   static X509Certificate^ serverCertificate = nullptr;

public:

   // The certificate parameter specifies the name of the file 
   // containing the machine certificate.
   static void RunServer( String^ certificate )
   {
      serverCertificate = X509Certificate::CreateFromCertFile( certificate );
      
      // Create a TCP/IP (IPv4) socket and listen for incoming connections.
      TcpListener^ listener = gcnew TcpListener( IPAddress::Any,8080 );
      listener->Start();
      
      while (true) 
      {
         Console::WriteLine( L"Waiting for a client to connect..." );
         
         // Application blocks while waiting for an incoming connection.
         // Type CNTL-C to terminate the server.
         TcpClient^ client = listener->AcceptTcpClient();
         ProcessClient( client );

      }
   }


   //<snippet1>
   static void ProcessClient( TcpClient^ client )
   {
      
      // A client has connected. Create the 
      // SslStream using the client's network stream.
      SslStream^ sslStream = gcnew SslStream( client->GetStream(),false );
      
      // Authenticate the server but don't require the client to authenticate.
      try
      {
         sslStream->AuthenticateAsServer( serverCertificate, false, true );
         // false == no client cert required; true == check cert revocation.
         
         // Display the properties and settings for the authenticated stream.
         DisplaySecurityLevel( sslStream );
         DisplaySecurityServices( sslStream );
         DisplayCertificateInformation( sslStream );
         DisplayStreamProperties( sslStream );
         
         // Set timeouts for the read and write to 5 seconds.
         sslStream->ReadTimeout = 5000;
         sslStream->WriteTimeout = 5000;
         
         // Read a message from the client.   
         Console::WriteLine( L"Waiting for client message..." );
         String^ messageData = ReadMessage( sslStream );
         Console::WriteLine( L"Received: {0}", messageData );
         
         // Write a message to the client.
         array<Byte>^message = Encoding::UTF8->GetBytes( L"Hello from the server.<EOF>" );
         Console::WriteLine( L"Sending hello message." );
         sslStream->Write( message );
      }
      catch ( AuthenticationException^ e ) 
      {
         Console::WriteLine( L"Exception: {0}", e->Message );
         if ( e->InnerException != nullptr )
         {
            Console::WriteLine( L"Inner exception: {0}", e->InnerException->Message );
         }
         Console::WriteLine( L"Authentication failed - closing the connection." );
         sslStream->Close();
         client->Close();
         return;
      }
      finally
      {
         
         // The client stream will be closed with the sslStream
         // because we specified this behavior when creating
         // the sslStream.
         sslStream->Close();
         client->Close();
      }

   }


   //</snippet1>
   //<snippet2>
   static String^ ReadMessage( SslStream^ sslStream )
   {
      
      // Read the  message sent by the client.
      // The client signals the end of the message using the
      // "<EOF>" marker.
      array<Byte>^buffer = gcnew array<Byte>(2048);
      StringBuilder^ messageData = gcnew StringBuilder;
      int bytes = -1;
      do
      {
         
         // Read the client's test message.
         bytes = sslStream->Read( buffer, 0, buffer->Length );
         
         // Use Decoder class to convert from bytes to UTF8
         // in case a character spans two buffers.
         Decoder^ decoder = Encoding::UTF8->GetDecoder();
         array<Char>^chars = gcnew array<Char>(decoder->GetCharCount( buffer, 0, bytes ));
         decoder->GetChars( buffer, 0, bytes, chars, 0 );
         messageData->Append( chars );
         
         // Check for EOF or an empty message.
         if ( messageData->ToString()->IndexOf( L"<EOF>" ) != -1 )
         {
            break;
         }
      }
      while ( bytes != 0 );

      return messageData->ToString();
   }


   //</snippet2>
   //<snippet3>
   static void DisplaySecurityLevel( SslStream^ stream )
   {
      Console::WriteLine( L"Cipher: {0} strength {1}", stream->CipherAlgorithm, stream->CipherStrength );
      Console::WriteLine( L"Hash: {0} strength {1}", stream->HashAlgorithm, stream->HashStrength );
      Console::WriteLine( L"Key exchange: {0} strength {1}", stream->KeyExchangeAlgorithm, stream->KeyExchangeStrength );
      Console::WriteLine( L"Protocol: {0}", stream->SslProtocol );
   }


   //</snippet3>
   //<snippet4>
   static void DisplaySecurityServices( SslStream^ stream )
   {
      Console::WriteLine( L"Is authenticated: {0} as server? {1}", stream->IsAuthenticated, stream->IsServer );
      Console::WriteLine( L"IsSigned: {0}", stream->IsSigned );
      Console::WriteLine( L"Is Encrypted: {0}", stream->IsEncrypted );
   }


   //</snippet4>
   //<snippet5>
   static void DisplayStreamProperties( SslStream^ stream )
   {
      Console::WriteLine( L"Can read: {0}, write {1}", stream->CanRead, stream->CanWrite );
      Console::WriteLine( L"Can timeout: {0}", stream->CanTimeout );
   }


   //</snippet5>
   //<snippet6>
   static void DisplayCertificateInformation( SslStream^ stream )
   {
      Console::WriteLine( L"Certificate revocation list checked: {0}", stream->CheckCertRevocationStatus );
      X509Certificate^ localCertificate = stream->LocalCertificate;
      if ( stream->LocalCertificate != nullptr )
      {
         Console::WriteLine( L"Local cert was issued to {0} and is valid from {1} until {2}.", 
             localCertificate->Subject, 
             localCertificate->GetEffectiveDateString(), 
             localCertificate->GetExpirationDateString() );
      }
      else
      {
         Console::WriteLine( L"Local certificate is null." );
      }

      X509Certificate^ remoteCertificate = stream->RemoteCertificate;
      if ( stream->RemoteCertificate != nullptr )
      {
         Console::WriteLine( L"Remote cert was issued to {0} and is valid from {1} until {2}.", 
            remoteCertificate->Subject, 
            remoteCertificate->GetEffectiveDateString(), 
            remoteCertificate->GetExpirationDateString() );
      }
      else
      {
         Console::WriteLine( L"Remote certificate is null." );
      }
   }


private:

   //</snippet6>
   static void DisplayUsage()
   {
      Console::WriteLine( L"To start the server specify:" );
      Console::WriteLine( L"serverSync certificateFile.cer" );
      Environment::Exit( 1 );
   }

public:
   int RunServerASync()
   {
      array<String^>^args = Environment::GetCommandLineArgs();
      String^ certificate = nullptr;
      if ( args == nullptr || args->Length < 2 )
      {
         DisplayUsage();
      }

      certificate = args[ 1 ];
      SslTcpServer::RunServer( certificate );
      return 0;
   }

};

int main(){
    SslTcpServer^ sts = gcnew SslTcpServer();
    sts->RunServerASync();
}
// </snippet0>
