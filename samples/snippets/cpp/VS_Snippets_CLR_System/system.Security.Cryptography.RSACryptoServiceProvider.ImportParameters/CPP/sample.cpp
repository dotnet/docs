#using <System.dll>

using namespace System;
using namespace System::Security::Cryptography;

int main()
{
   // <Snippet1>
   try
   {
      //Create a new RSACryptoServiceProvider object. 
      RSACryptoServiceProvider^ RSA = gcnew RSACryptoServiceProvider;
      
      //Export the key information to an RSAParameters object.
      //Pass false to export the public key information or pass
      //true to export public and private key information.
      RSAParameters RSAParams = RSA->ExportParameters( false );
      
      //Create another RSACryptoServiceProvider object.
      RSACryptoServiceProvider^ RSA2 = gcnew RSACryptoServiceProvider;
      
      //Import the the key information from the other 
      //RSACryptoServiceProvider object.  
      RSA2->ImportParameters( RSAParams );
   }
   catch ( CryptographicException^ e ) 
   {
      //Catch this exception in case the encryption did
      //not succeed.
      Console::WriteLine( e->Message );
   }
   // </Snippet1>
}
