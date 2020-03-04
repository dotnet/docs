
//<SNIPPET1> 
using namespace System;
using namespace System::Security::Cryptography::X509Certificates;
int main()
{
   
   // The path to the certificate.
   String^ Certificate = L"test.pfx";
   
   // Load the certificate into an X509Certificate object.
   X509Certificate^ cert = gcnew X509Certificate( Certificate );
   array<Byte>^certData = cert->Export( X509ContentType::Cert );
   X509Certificate^ newCert = gcnew X509Certificate( certData );
   
   // Get the value.
   String^ resultsTrue = newCert->ToString( true );
   
   // Display the value to the console.
   Console::WriteLine( resultsTrue );
   
   // Get the value.
   String^ resultsFalse = newCert->ToString( false );
   
   // Display the value to the console.
   Console::WriteLine( resultsFalse );
}

//</SNIPPET1> 
