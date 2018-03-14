

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Security::Cryptography;
int main()
{
   try
   {
      
      //Create a new instance of DSACryptoServiceProvider.
      DSACryptoServiceProvider^ DSA = gcnew DSACryptoServiceProvider;
      
      //The hash to sign.
      array<Byte>^Hash = {59,4,248,102,77,97,142,201,210,12,224,93,25,41,100,197,213,134,130,135};
      
      //Create an DSASignatureFormatter Object* and pass it the 
      //DSACryptoServiceProvider to transfer the key information.
      DSASignatureFormatter^ DSAFormatter = gcnew DSASignatureFormatter( DSA );
      
      //Set the hash algorithm to SHA1.
      DSAFormatter->SetHashAlgorithm( "SHA1" );
      
      //Create a signature for HashValue and return it.
      array<Byte>^SignedHash = DSAFormatter->CreateSignature( Hash );
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( e->Message );
   }

}

// </Snippet1>
