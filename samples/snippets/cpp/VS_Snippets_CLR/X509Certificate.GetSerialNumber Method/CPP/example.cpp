
// <Snippet1>
using namespace System;
using namespace System::Security::Cryptography::X509Certificates;
int main()
{
   
   // The path to the certificate.
   String^ Certificate = "Certificate.cer";
   
   // Load the certificate into an X509Certificate object.
   X509Certificate^ cert = X509Certificate::CreateFromCertFile( Certificate );
   
   // Get the value.
   array<Byte>^results = cert->GetSerialNumber();
   
   // Display the value to the console.
   System::Collections::IEnumerator^ enum0 = results->GetEnumerator();
   while ( enum0->MoveNext() )
   {
      Byte b = safe_cast<Byte>(enum0->Current);
      Console::Write( b );
   }
}

// </Snippet1>
