
// <Snippet1>
using namespace System;
using namespace System::Security::Cryptography::X509Certificates;
int main()
{
   
   // The path to the certificate.
   String^ Certificate = "Certificate.cer";
   String^ OtherCertificate = "OtherCertificate.cer";
   
   // Load the certificate into an X509Certificate object.
   X509Certificate^ cert = X509Certificate::CreateFromCertFile( Certificate );
   
   // Load the certificate into an X509Certificate object.
   X509Certificate^ certTwo = X509Certificate::CreateFromCertFile( OtherCertificate );
   
   // Get the value.
   bool result = cert->Equals( certTwo );
   
   // Display the value to the console.
   Console::WriteLine( result );
}

// </Snippet1>
