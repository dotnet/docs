// <Snippet1>
using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Text;
array<Byte>^ RSAEncrypt( array<Byte>^DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding )
{
   try
   {
      
      //Create a new instance of RSACryptoServiceProvider.
      RSACryptoServiceProvider^ RSA = gcnew RSACryptoServiceProvider;
      
      //Import the RSA Key information. This only needs
      //toinclude the public key information.
      RSA->ImportParameters( RSAKeyInfo );
      
      //Encrypt the passed byte array and specify OAEP padding.  
      //OAEP padding is only available on Microsoft Windows XP or
      //later.  

      array<Byte>^encryptedData = RSA->Encrypt( DataToEncrypt, DoOAEPPadding );
	  delete RSA;
	  return encryptedData;
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
      RSACryptoServiceProvider^ RSA = gcnew RSACryptoServiceProvider;
      
      //Import the RSA Key information. This needs
      //to include the private key information.
      RSA->ImportParameters( RSAKeyInfo );
      
      //Decrypt the passed byte array and specify OAEP padding.  
      //OAEP padding is only available on Microsoft Windows XP or
      //later.  
	  
      array<Byte>^decryptedData = RSA->Decrypt( DataToDecrypt, DoOAEPPadding );
      delete RSA;
	  return decryptedData;
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
      //public and private key data.
      RSACryptoServiceProvider^ RSA = gcnew RSACryptoServiceProvider;
      
      //Pass the data to ENCRYPT, the public key information 
      //(using RSACryptoServiceProvider.ExportParameters(false),
      //and a boolean flag specifying no OAEP padding.
      encryptedData = RSAEncrypt( dataToEncrypt, RSA->ExportParameters( false ), false );
      
      //Pass the data to DECRYPT, the private key information 
      //(using RSACryptoServiceProvider.ExportParameters(true),
      //and a boolean flag specifying no OAEP padding.
      decryptedData = RSADecrypt( encryptedData, RSA->ExportParameters( true ), false );
      
      //Display the decrypted plaintext to the console. 
      Console::WriteLine( "Decrypted plaintext: {0}", ByteConverter->GetString( decryptedData ) );
	  delete RSA;
   }
   catch ( ArgumentNullException^ ) 
   {
      
      //Catch this exception in case the encryption did
      //not succeed.
      Console::WriteLine( "Encryption failed." );
   }

}

// </Snippet1>
