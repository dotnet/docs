
// NclSslClientAsync
//<snippet0>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Net;
using namespace System::Net::Security;
using namespace System::Net::Sockets;
using namespace System::Security::Authentication;
using namespace System::Text;
using namespace System::Security::Cryptography::X509Certificates;
using namespace System::IO;

// The following example demonstrates the client side of a 
// client-server application that communicates using the
// SslStream and TcpClient classes.
// After connecting to the server and authenticating, 
// the client sends the server a message, recieves a message from the server,
// and then terminates. Messages sent to and from the server are terminated
// with '<EOF>'.
public ref class SslTcpClient
{
private:

   // certificateErrors holds the mapping of Win32 results to descriptive strings.
   // It is used by the CertificateErrorDescription method.
   static Hashtable^ certificateErrors = gcnew Hashtable;

   // complete is used to terminate the application when all 
   // asynchronous calls have completed or any call has thrown an exception.
   // complete might be used by any of the callback methods.
   static bool complete = false;

   // e stores any exception thrown by an asynchronous method so that
   // the mail application thread can display the exception and terminate gracefully.
   // e might be used by any of the callback methods.
   static Exception^ e = nullptr;

   // <snippet8>
   // readData and buffer holds the data read from the server.
   // They is used by the ReadCallback method.
   static StringBuilder^ readData = gcnew StringBuilder;
   static array<Byte>^buffer = gcnew array<Byte>(2048);

   // </snippet8>
   //<snippet1>
   // Load a table of errors that might cause the certificate authentication to fail. 
   static void InitializeCertificateErrors()
   {
      certificateErrors->Add( 0x800B0101, L"The certification has expired." );
      certificateErrors->Add( 0x800B0104, L"A path length constraint in the certification chain has been violated." );
      certificateErrors->Add( 0x800B0105, L"A certificate contains an unknown extension that is marked critical." );
      certificateErrors->Add( 0x800B0107, L"A parent of a given certificate in fact did not issue that child certificate." );
      certificateErrors->Add( 0x800B0108, L"A certificate is missing or has an empty value for a necessary field." );
      certificateErrors->Add( 0x800B0109, L"The certificate root is not trusted." );
      certificateErrors->Add( 0x800B010C, L"The certificate has been revoked." );
      certificateErrors->Add( 0x800B010F, L"The name in the certificate does not not match the host name requested by the client." );
      certificateErrors->Add( 0x800B0111, L"The certificate was explicitly marked as untrusted by the user." );
      certificateErrors->Add( 0x800B0112, L"A certification chain processed correctly, but one of the CA certificates is not trusted." );
      certificateErrors->Add( 0x800B0113, L"The certificate has an invalid policy." );
      certificateErrors->Add( 0x800B0114, L"The certificate name is either not in the permitted list or is explicitly excluded." );
      certificateErrors->Add( 0x80092012, L"The revocation function was unable to check revocation for the certificate." );
      certificateErrors->Add( 0x80090327, L"An unknown error occurred while processing the certificate." );
      certificateErrors->Add( 0x80096001, L"A system-level error occurred while verifying trust." );
      certificateErrors->Add( 0x80096002, L"The certificate for the signer of the message is invalid or not found." );
      certificateErrors->Add( 0x80096003, L"One of the counter signatures was invalid." );
      certificateErrors->Add( 0x80096004, L"The signature of the certificate cannot be verified." );
      certificateErrors->Add( 0x80096005, L"The time stamp signature or certificate could not be verified or is malformed." );
      certificateErrors->Add( 0x80096010, L"The digital signature of the object was not verified." );
      certificateErrors->Add( 0x80096019, L"The basic constraint extension of a certificate has not been observed." );
   }

   static String^ CertificateErrorDescription( int problem )
   {
      
      // Initialize the error message dictionary if it is not yet available.
      if ( certificateErrors->Count == 0 )
      {
         InitializeCertificateErrors();
      }

      String^ description = dynamic_cast<String^>(certificateErrors[ problem ]);
      if ( description == nullptr )
      {
         description = String::Format( L"Unknown certificate error - 0x{0:x8}", problem );
      }

      return description;
   }


public:

   // The following method is invoked by the CertificateValidationDelegate.
    static bool ValidateServerCertificate(
            Object^ sender,
            X509Certificate^ certificate,
            X509Chain^ chain,
            SslPolicyErrors sslPolicyErrors)
        {
        
            Console::WriteLine("Validating the server certificate.");
            if (sslPolicyErrors == SslPolicyErrors::None)
                return true;

            Console::WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }

   //</snippet1>
   //<snippet2>
    static X509Certificate^ SelectLocalCertificate(
            Object^ sender, 
			String^ targetHost, 
			X509CertificateCollection^ localCertificates, 
			X509Certificate^ remoteCertificate, 
			array<String^>^ acceptableIssuers
    )
    {	
        Console::WriteLine("Client is selecting a local certificate.");
        if (acceptableIssuers != nullptr && 
                acceptableIssuers->Length > 0 &&
                localCertificates != nullptr &&
                localCertificates->Count > 0)
        {
            // Use the first certificate that is from an acceptable issuer.
            IEnumerator^ myEnum1 = localCertificates->GetEnumerator();
            while ( myEnum1->MoveNext() )
            {
				X509Certificate^ certificate = safe_cast<X509Certificate^>(myEnum1->Current);
				String^ issuer = certificate->Issuer;
				if ( Array::IndexOf( acceptableIssuers, issuer ) != -1 )
					return certificate;
            }
        }
        if (localCertificates != nullptr &&
                localCertificates->Count > 0)
			return localCertificates[0];
                
        return nullptr;
     }

   //</snippet2>
   //<snippet3>
   static void AuthenticateCallback( IAsyncResult^ ar )
   {
      SslStream^ stream = dynamic_cast<SslStream^>(ar->AsyncState);
      try
      {
         stream->EndAuthenticateAsClient( ar );
         Console::WriteLine( L"Authentication succeeded." );
         Console::WriteLine( L"Cipher: {0} strength {1}", stream->CipherAlgorithm, stream->CipherStrength );
         Console::WriteLine( L"Hash: {0} strength {1}", stream->HashAlgorithm, stream->HashStrength );
         Console::WriteLine( L"Key exchange: {0} strength {1}", stream->KeyExchangeAlgorithm, stream->KeyExchangeStrength );
         Console::WriteLine( L"Protocol: {0}", stream->SslProtocol );
         
         // Encode a test message into a byte array.
         // Signal the end of the message using the "<EOF>".
         array<Byte>^message = Encoding::UTF8->GetBytes( L"Hello from the client.<EOF>" );
         
         // Asynchronously send a message to the server.
         stream->BeginWrite( message, 0, message->Length, gcnew AsyncCallback( WriteCallback ), stream );
      }
      catch ( Exception^ authenticationException ) 
      {
         e = authenticationException;
         complete = true;
         return;
      }

   }


   //</snippet3>
   //<snippet4>
   static void WriteCallback( IAsyncResult^ ar )
   {
      SslStream^ stream = dynamic_cast<SslStream^>(ar->AsyncState);
      try
      {
         Console::WriteLine( L"Writing data to the server." );
         stream->EndWrite( ar );
         
         // Asynchronously read a message from the server.
         stream->BeginRead( buffer, 0, buffer->Length, gcnew AsyncCallback( ReadCallback ), stream );
      }
      catch ( Exception^ writeException ) 
      {
         e = writeException;
         complete = true;
         return;
      }

   }


   //</snippet4>
   //<snippet5>
   static void ReadCallback( IAsyncResult^ ar )
   {
      
      // Read the  message sent by the server.
      // The end of the message is signaled using the
      // "<EOF>" marker.
      SslStream^ stream = dynamic_cast<SslStream^>(ar->AsyncState);
      int byteCount = -1;
      try
      {
         Console::WriteLine( L"Reading data from the server." );
         byteCount = stream->EndRead( ar );
         
         // Use Decoder class to convert from bytes to UTF8
         // in case a character spans two buffers.
         Decoder^ decoder = Encoding::UTF8->GetDecoder();
         array<Char>^chars = gcnew array<Char>(decoder->GetCharCount( buffer, 0, byteCount ));
         decoder->GetChars( buffer, 0, byteCount, chars, 0 );
         readData->Append( chars );
         
         // Check for EOF or an empty message.
         if ( readData->ToString()->IndexOf( L"<EOF>" ) == -1 && byteCount != 0 )
         {
            
            // We are not finished reading.
            // Asynchronously read more message data from  the server.
            stream->BeginRead( buffer, 0, buffer->Length, gcnew AsyncCallback( ReadCallback ), stream );
         }
         else
         {
            Console::WriteLine( L"Message from the server: {0}", readData );
         }
      }
      catch ( Exception^ readException ) 
      {
         e = readException;
         complete = true;
         return;
      }

      complete = true;
   }


   //</snippet5>
   //<snippet7>
   int TestNclSslClient()
   {
      array<String^>^args = Environment::GetCommandLineArgs();
      String^ serverName = nullptr;
      if ( args == nullptr || args->Length < 3 )
      {
         Console::WriteLine( L"To start the client specify the host name and"
         L" one or more client certificate file names." );
         return 1;
      }

      
      //<snippet6>
      // Server name must match the host name and the name on the host's certificate. 
      serverName = args[ 1 ];
      
      // Create a TCP/IP client socket.
      TcpClient^ client = gcnew TcpClient( serverName,80 );
      Console::WriteLine( L"Client connected." );
      
      // Create an SSL stream that will close the client's stream.
      SslStream^ sslStream = gcnew SslStream( 
          client->GetStream(),
          false,
          gcnew RemoteCertificateValidationCallback( ValidateServerCertificate ),
          gcnew LocalCertificateSelectionCallback( SelectLocalCertificate ) );
      
      //</snippet6>
      // Create the certificate collection to hold the client's certificate.
      X509CertificateCollection^ clientCertificates = gcnew X509CertificateCollection;
      for ( int i = 2; i < args->Length; i++ )
      {
         X509Certificate^ certificate = X509Certificate::CreateFromCertFile( args[ i ] );
         clientCertificates->Add( certificate );

      }
      
      // The server name must match the name on the server certificate.
      sslStream->BeginAuthenticateAsClient( 
          serverName, 
          clientCertificates, 
          SslProtocols::Ssl3, 
          true, 
          gcnew AsyncCallback( AuthenticateCallback ), 
          sslStream );
      
      // User can press a key to exit application, or let the 
      // asynchronous calls continue until they complete.
      Console::WriteLine( L"To quit, press the enter key." );
      do
      {
         
         // Real world applications would do work here
         // while waiting for the asynchronous calls to complete.
         System::Threading::Thread::Sleep( 100 );
      }
      while ( complete != true && Console::KeyAvailable == false );

      if ( Console::KeyAvailable )
      {
         Console::ReadLine();
         Console::WriteLine( L"Quitting." );
         client->Close();
         sslStream->Close();
         return 1;
      }

      if ( e != nullptr )
      {
         Console::WriteLine( L"An exception was thrown: {0}", e );
      }

      sslStream->Close();
      client->Close();
      Console::WriteLine( L"Good bye." );
      return 0;
   }

   //</snippet7>
};


//</snippet0>
int main()
{
   SslTcpClient^ stc = gcnew SslTcpClient;
   stc->TestNclSslClient();
}

