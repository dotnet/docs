
// <SNIPPET1>
using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Text;
using namespace System::IO;
array<Byte>^ EncryptTextToMemory( String^ Data, array<Byte>^Key, array<Byte>^IV )
{
   try
   {
      
      // Create a MemoryStream.
      MemoryStream^ mStream = gcnew MemoryStream;
      
      // Create a new RC2 object.
      RC2^ RC2alg = RC2::Create();
      
      // Create a CryptoStream using the MemoryStream 
      // and the passed key and initialization vector (IV).
      CryptoStream^ cStream = gcnew CryptoStream( mStream,RC2alg->CreateEncryptor( Key, IV ),CryptoStreamMode::Write );
      
      // Convert the passed string to a byte array.
      array<Byte>^toEncrypt = (gcnew ASCIIEncoding)->GetBytes( Data );
      
      // Write the byte array to the crypto stream and flush it.
      cStream->Write( toEncrypt, 0, toEncrypt->Length );
      cStream->FlushFinalBlock();
      
      // Get an array of bytes from the 
      // MemoryStream that holds the 
      // encrypted data.
      array<Byte>^ret = mStream->ToArray();
      
      // Close the streams.
      cStream->Close();
      mStream->Close();
      
      // Return the encrypted buffer.
      return ret;
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( "A Cryptographic error occurred: {0}", e->Message );
      return nullptr;
   }

}

String^ DecryptTextFromMemory( array<Byte>^Data, array<Byte>^Key, array<Byte>^IV )
{
   try
   {
      
      // Create a new MemoryStream using the passed 
      // array of encrypted data.
      MemoryStream^ msDecrypt = gcnew MemoryStream( Data );
      
      // Create a new RC2 object.
      RC2^ RC2alg = RC2::Create();
      
      // Create a CryptoStream using the MemoryStream 
      // and the passed key and initialization vector (IV).
      CryptoStream^ csDecrypt = gcnew CryptoStream( msDecrypt,RC2alg->CreateDecryptor( Key, IV ),CryptoStreamMode::Read );
      
      // Create buffer to hold the decrypted data.
      array<Byte>^fromEncrypt = gcnew array<Byte>(Data->Length);
      
      // Read the decrypted data out of the crypto stream
      // and place it into the temporary buffer.
      csDecrypt->Read( fromEncrypt, 0, fromEncrypt->Length );
      
      //Convert the buffer into a string and return it.
      return (gcnew ASCIIEncoding)->GetString( fromEncrypt );
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( "A Cryptographic error occurred: {0}", e->Message );
      return nullptr;
   }

}

int main()
{
   try
   {
      
      // Create a new RC2 object to generate a key 
      // and initialization vector (IV).  Specify one 
      // of the recognized simple names for this 
      // algorithm.
      RC2^ RC2alg = RC2::Create( "RC2" );
      
      // Create a string to encrypt.
      String^ sData = "Here is some data to encrypt.";
      
      // Encrypt the string to an in-memory buffer.
      array<Byte>^Data = EncryptTextToMemory( sData, RC2alg->Key, RC2alg->IV );
      
      // Decrypt the buffer back to a string.
      String^ Final = DecryptTextFromMemory( Data, RC2alg->Key, RC2alg->IV );
      
      // Display the decrypted string to the console.
      Console::WriteLine( Final );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }

}

// </SNIPPET1>
