using namespace System;
using namespace System::Security::Cryptography;

int main()
{
   // Create a CryptoConfig object to store configuration information.
   CryptoConfig^ cryptoConfig = gcnew CryptoConfig;

   // Retrieve the class path for CryptoConfig.
   String^ classDescription = cryptoConfig->ToString();

   // Create a new SHA1 provider.
   SHA1CryptoServiceProvider^ SHA1alg =
      dynamic_cast<SHA1CryptoServiceProvider^>(
         CryptoConfig::CreateFromName( L"SHA1" ));

   // Create an RSAParameters with the TestContainer key container.
   CspParameters^ parameters = gcnew CspParameters;
   parameters->KeyContainerName = L"TestContainer";
   array<Object^>^argsArray = gcnew array<Object^>(1){
      parameters
   };
   
   // Instantiate the RSA provider instance accessing the TestContainer
   // key container.
   RSACryptoServiceProvider^ rsaProvider =
      static_cast<RSACryptoServiceProvider^>(
         CryptoConfig::CreateFromName( L"RSA", argsArray ));

   // Use the MapNameToOID method to get an object identifier
   // (OID) from the string name of the SHA1 algorithm.
   String^ sha1Oid = CryptoConfig::MapNameToOID( L"SHA1" );

   // Encode the specified object identifier.
   array<Byte>^encodedMessage = CryptoConfig::EncodeOID( sha1Oid );
   
   // Display the results to the console.
   Console::WriteLine( L"** {0} **", classDescription );
   Console::WriteLine( L"Created an RSA provider with a KeyContainerName called {0}.",
      parameters->KeyContainerName );
   Console::WriteLine( L"Object identifier from the SHA1 name:{0}",
      sha1Oid );
   Console::WriteLine( L"The object identifier encoded: {0}",
      System::Text::Encoding::ASCII->GetString( encodedMessage ) );
   Console::WriteLine( L"This sample completed successfully; press Enter to exit." );
   Console::ReadLine();
}

//
// This sample produces the following output:
//
// ** System.Security.Cryptography.CryptoConfig **
// Created an RSA provider with a KeyContainerName called TestContainer.
// Object identifier from the SHA1 name:1.3.14.3.2.26
// The object identifier encoded: HH*((*H9
// This sample completed successfully; press Enter to exit.