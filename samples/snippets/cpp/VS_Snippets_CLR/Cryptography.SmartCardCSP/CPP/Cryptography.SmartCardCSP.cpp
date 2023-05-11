
//<SNIPPET1>
using namespace System;
using namespace System::Security::Cryptography;
int main()
{

   // To identify the Smart Card CryptoGraphic Providers on your
   // computer, use the Microsoft Registry Editor (Regedit.exe).
   // The available Smart Card CryptoGraphic Providers are listed
   // in HKEY_LOCAL_MACHINE\Software\Microsoft\Cryptography\Defaults\Provider.
   // Create a new CspParameters object that identifies a
   // Smart Card CryptoGraphic Provider.
   // The 1st parameter comes from HKEY_LOCAL_MACHINE\Software\Microsoft\Cryptography\Defaults\Provider Types.
   // The 2nd parameter comes from HKEY_LOCAL_MACHINE\Software\Microsoft\Cryptography\Defaults\Provider.
   CspParameters^ csp = gcnew CspParameters( 1,L"Schlumberger Cryptographic Service Provider" );
   csp->Flags = CspProviderFlags::UseDefaultKeyContainer;

   // Initialize an RSACryptoServiceProvider object using
   // the CspParameters object.
   RSACryptoServiceProvider^ rsa = gcnew RSACryptoServiceProvider( csp );

   // Create some data to sign.
   array<Byte>^data = gcnew array<Byte>{
      0,1,2,3,4,5,6,7
   };
   Console::WriteLine( L"Data			: {0}", BitConverter::ToString( data ) );

   // Sign the data using the Smart Card CryptoGraphic Provider.
   array<Byte>^sig = rsa->SignData( data, L"SHA1" );
   Console::WriteLine( L"Signature	: {0}", BitConverter::ToString( sig ) );

   // Verify the data using the Smart Card CryptoGraphic Provider.
   bool verified = rsa->VerifyData( data, L"SHA1", sig );
   Console::WriteLine( L"Verified		: {0}", verified );
}

//</SNIPPET1>
