
//<SNIPPET1>
using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Text;
array<Byte>^ RSAEncrypt( array<Byte>^DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding )
{
   try
   {
      
      //Create a new instance of RSACryptoServiceProvider.
      RSACryptoServiceProvider^ RSAalg = gcnew RSACryptoServiceProvider;
      
      //Import the RSA Key information. This only needs
      //toinclude the public key information.
      RSAalg->ImportParameters( RSAKeyInfo );
      
      //Encrypt the passed byte array and specify OAEP padding.  
      //OAEP padding is only available on Microsoft Windows XP or
      //later.  
      return RSAalg->Encrypt( DataToEncrypt, DoOAEPPadding );
   }
   //Catch and display a CryptographicException  
   //to the console.
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( e->Message );
      return nullptr;
   }

}

array<Byte>^ RSADecrypt( array<Byte>^DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding )
{
   try
   {
      
      //Create a new instance of RSACryptoServiceProvider.
      RSACryptoServiceProvider^ RSAalg = gcnew RSACryptoServiceProvider;
      
      //Import the RSA Key information. This needs
      //to include the private key information.
      RSAalg->ImportParameters( RSAKeyInfo );
      
      //Decrypt the passed byte array and specify OAEP padding.  
      //OAEP padding is only available on Microsoft Windows XP or
      //later.  
      return RSAalg->Decrypt( DataToDecrypt, DoOAEPPadding );
   }
   //Catch and display a CryptographicException  
   //to the console.
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( e );
      return nullptr;
   }

}

int main()
{
   try
   {
      
      //Create a UnicodeEncoder to convert between byte array and string.
      UnicodeEncoding^ ByteConverter = gcnew UnicodeEncoding;
      
      //Create byte arrays to hold original, encrypted, and decrypted data.
      array<Byte>^dataToEncrypt = ByteConverter->GetBytes( "Data to Encrypt" );
      array<Byte>^encryptedData;
      array<Byte>^decryptedData;
      
      //Create a new instance of RSACryptoServiceProvider to generate
      //public and private key data.  Pass an integer specifying a key-
      //length of 2048.
      RSACryptoServiceProvider^ RSAalg = gcnew RSACryptoServiceProvider( 2048 );
      
      //Display the key-legth to the console.
      Console::WriteLine( "A new key pair of legth {0} was created", RSAalg->KeySize );
      
      //Pass the data to ENCRYPT, the public key information 
      //(using RSACryptoServiceProvider.ExportParameters(false),
      //and a boolean flag specifying no OAEP padding.
      encryptedData = RSAEncrypt( dataToEncrypt, RSAalg->ExportParameters( false ), false );
      
      //Pass the data to DECRYPT, the private key information 
      //(using RSACryptoServiceProvider.ExportParameters(true),
      //and a boolean flag specifying no OAEP padding.
      decryptedData = RSADecrypt( encryptedData, RSAalg->ExportParameters( true ), false );
      
      //Display the decrypted plaintext to the console. 
      Console::WriteLine( "Decrypted plaintext: {0}", ByteConverter->GetString( decryptedData ) );
   }
   catch ( ArgumentNullException^ ) 
   {
      
      //Catch this exception in case the encryption did
      //not succeed.
      Console::WriteLine( "Encryption failed." );
   }

}

//</SNIPPET1>
