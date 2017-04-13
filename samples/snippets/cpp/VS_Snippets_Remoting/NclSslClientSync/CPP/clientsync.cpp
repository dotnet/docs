// NclSslClientSync
//<snippet0>
#using <System.dll>
#using <System.Security.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Globalization;
using namespace System::Net;
using namespace System::Net::Security;
using namespace System::Net::Sockets;
using namespace System::Security::Authentication;
using namespace System::Text;
using namespace System::Security::Cryptography::X509Certificates;
using namespace System::IO;

namespace NlsClientSync
{
    public ref class SslTcpClient
    {
    private:
        static Hashtable^ certificateErrors = gcnew Hashtable;
        //<snippet1>
        // Load a table of errors that might cause 
        // the certificate authentication to fail.
        static void InitializeCertificateErrors()
        {
            certificateErrors->Add(0x800B0101,
                "The certification has expired.");
            certificateErrors->Add(0x800B0104,
                "A path length constraint "
                "in the certification chain has been violated.");
            certificateErrors->Add(0x800B0105,
                "A certificate contains an unknown extension "
                "that is marked critical.");
            certificateErrors->Add(0x800B0107,
                "A parent of a given certificate in fact "
                "did not issue that child certificate.");
            certificateErrors->Add(0x800B0108,
                "A certificate is missing or has an empty value "
                "for a necessary field.");
            certificateErrors->Add(0x800B0109,
                "The certificate root is not trusted.");
            certificateErrors->Add(0x800B010C,
                "The certificate has been revoked.");
            certificateErrors->Add(0x800B010F,
                "The name in the certificate does not not match "
                "the host name requested by the client.");
            certificateErrors->Add(0x800B0111,
                "The certificate was explicitly marked "
                "as untrusted by the user.");
            certificateErrors->Add(0x800B0112,
                "A certification chain processed correctly, "
                "but one of the CA certificates is not trusted.");
            certificateErrors->Add(0x800B0113,
                "The certificate has an invalid policy.");
            certificateErrors->Add(0x800B0114,
                "The certificate name is either not "
                "in the permitted list or is explicitly excluded.");
            certificateErrors->Add(0x80092012,
                "The revocation function was unable to check "
                "revocation for the certificate.");
            certificateErrors->Add(0x80090327,
                "An unknown error occurred while "
                "processing the certificate.");
            certificateErrors->Add(0x80096001,
                "A system-level error occurred "
                "while verifying trust.");
            certificateErrors->Add(0x80096002,
                "The certificate for the signer of the message "
                "is invalid or not found.");
            certificateErrors->Add(0x80096003,
                "One of the counter signatures was invalid.");
            certificateErrors->Add(0x80096004,
                "The signature of the certificate "
                "cannot be verified.");
            certificateErrors->Add(0x80096005,
                "The time stamp signature or certificate "
                "could not be verified or is malformed.");
            certificateErrors->Add(0x80096010,
                "The digital signature of the object "
                "was not verified.");
            certificateErrors->Add(0x80096019,
                "The basic constraint extension of a certificate "
                "has not been observed.");
        }

        static String^ CertificateErrorDescription(UInt32 problem)
        {
            // Initialize the error message dictionary 
            // if it is not yet available.
            if (certificateErrors->Count == 0)
            {
                InitializeCertificateErrors();
            }

            String^ description = safe_cast<String^>(
                certificateErrors[problem]);
            if (description == nullptr)
            {
                description = String::Format(
                    CultureInfo::CurrentCulture,
                    "Unknown certificate error - 0x{0:x8}",
                    problem);
            }

            return description;
        }

    public:
        // The following method is invoked 
        // by the CertificateValidationDelegate.
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

        //<snippet3>
        static void RunClient(String^ machineName, String^ serverName)
        {
              
            //<snippet5>
            //<snippet4>
            // Create a TCP/IP client socket.
            // machineName is the host running the server application.
            TcpClient^ client = gcnew TcpClient(machineName, 8080);
            Console::WriteLine("Client connected.");
              
            // Create an SSL stream that will close 
            // the client's stream.
            SslStream^ sslStream = gcnew SslStream(
                client->GetStream(), false,
                gcnew RemoteCertificateValidationCallback(ValidateServerCertificate),
                nullptr);
              
            // The server name must match the name
            // on the server certificate.
            try
            {
                sslStream->AuthenticateAsClient(serverName);
            }
            catch (AuthenticationException^ ex) 
            {
                Console::WriteLine("Exception: {0}", ex->Message);
                if (ex->InnerException != nullptr)
                {
                    Console::WriteLine("Inner exception: {0}", 
                        ex->InnerException->Message);
                }

                Console::WriteLine("Authentication failed - "
                    "closing the connection.");
                sslStream->Close();
                client->Close();
                return;
            }
            //</snippet4>
            // Encode a test message into a byte array.
            // Signal the end of the message using the "<EOF>".
            array<Byte>^ messsage = Encoding::UTF8->GetBytes(
                "Hello from the client.<EOF>");
              
            // Send hello message to the server.
            sslStream->Write(messsage);
            sslStream->Flush();
            //</snippet5>
            // Read message from the server.
            String^ serverMessage = ReadMessage(sslStream);
            Console::WriteLine("Server says: {0}", serverMessage);
           
            // Close the client connection.
            sslStream->Close();
            client->Close();
            Console::WriteLine("Client closed.");
        }
        //</snippet3>
        //<snippet6>
    private:
        static String^ ReadMessage(SslStream^ sslStream)
        {
              
            // Read the  message sent by the server.
            // The end of the message is signaled using the
            // "<EOF>" marker.
            array<Byte>^ buffer = gcnew array<Byte>(2048);
            StringBuilder^ messageData = gcnew StringBuilder;
            // Use Decoder class to convert from bytes to UTF8
            // in case a character spans two buffers.
            Encoding^ u8 = Encoding::UTF8;
            Decoder^ decoder = u8->GetDecoder();

            int bytes = -1;
            do
            {
                bytes = sslStream->Read(buffer, 0, buffer->Length);
                 
                array<__wchar_t>^ chars = gcnew array<__wchar_t>(
                    decoder->GetCharCount(buffer, 0, bytes));
                decoder->GetChars(buffer, 0, bytes, chars, 0);
                messageData->Append(chars);
                 
                // Check for EOF.
                if (messageData->ToString()->IndexOf("<EOF>") != -1)
                {
                    break;
                }
            }
            while (bytes != 0);

            return messageData->ToString();
        }
        //</snippet6>
    };
}

int main()
{
    array<String^>^ args = Environment::GetCommandLineArgs();
    String^ serverCertificateName = nullptr;
    String^ machineName = nullptr;
    if (args == nullptr || args->Length < 2)
    {
        Console::WriteLine("To start the client specify:");
        Console::WriteLine("clientSync machineName [serverName]");
        return 1;
    }
        
    // User can specify the machine name and server name.
    // Server name must match the name on 
    // the server's certificate.
    machineName = args[1];
    if (args->Length < 3)
    {
        serverCertificateName = machineName;
    }
    else
    {
        serverCertificateName = args[2];
    };

    NlsClientSync::SslTcpClient::RunClient(machineName,
        serverCertificateName);

    return 0;
}

//</snippet0>
