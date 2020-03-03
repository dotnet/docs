
//<SNIPPET1>
using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Text;
array<Byte>^ HashAndSignBytes( array<Byte>^DataToSign, RSAParameters Key, int Index, int Length )
{
   try
   {
      
      // Create a new instance of RSACryptoServiceProvider using the 
      // key from RSAParameters.  
      RSACryptoServiceProvider^ RSAalg = gcnew RSACryptoServiceProvider;
      RSAalg->ImportParameters( Key );
      
      // Hash and sign the data. Pass a new instance of SHA1CryptoServiceProvider
      // to specify the use of SHA1 for hashing.
      return RSAalg->SignData( DataToSign, Index, Length, gcnew SHA1CryptoServiceProvider );
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( e->Message );
      return nullptr;
   }

}

bool VerifySignedHash( array<Byte>^DataToVerify, array<Byte>^SignedData, RSAParameters Key )
{
   try
   {
      
      // Create a new instance of RSACryptoServiceProvider using the 
      // key from RSAParameters.
      RSACryptoServiceProvider^ RSAalg = gcnew RSACryptoServiceProvider;
      RSAalg->ImportParameters( Key );
      
      // Verify the data using the signature.  Pass a new instance of SHA1CryptoServiceProvider
      // to specify the use of SHA1 for hashing.
      return RSAalg->VerifyData( DataToVerify, gcnew SHA1CryptoServiceProvider, SignedData );
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( e->Message );
      return false;
   }

}

int main()
{
   try
   {
      
      // Create a UnicodeEncoder to convert between byte array and string.
      ASCIIEncoding^ ByteConverter = gcnew ASCIIEncoding;
      String^ dataString = "Data to Sign";
      
      // Create byte arrays to hold original, encrypted, and decrypted data.
      array<Byte>^originalData = ByteConverter->GetBytes( dataString );
      array<Byte>^signedData;
      array<Byte>^smallArray;
      
      // Create a new instance of the RSACryptoServiceProvider class 
      // and automatically create a new key-pair.
      RSACryptoServiceProvider^ RSAalg = gcnew RSACryptoServiceProvider;
      
      // Export the key information to an RSAParameters object.
      // You must pass true to export the private key for signing.
      // However, you do not need to export the private key
      // for verification.
      RSAParameters Key = RSAalg->ExportParameters( true );
      
      // Hash and sign the data.  Start at the fifth offset
      // only use data from the next 7 bytes.
      signedData = HashAndSignBytes( originalData, Key, 5, 7 );
      
      // The previous method only signed one segment
      // of the array.  Create a new array for verification
      // that only holds the data that was actually signed.
      //
      // Initialize the array.
      smallArray = gcnew array<Byte>(7);
      
      // Copy 7 bytes starting at the 5th index to 
      // the new array.
      Array::Copy( originalData, 5, smallArray, 0, 7 );
      
      // Verify the data and display the result to the 
      // console.  
      if ( VerifySignedHash( smallArray, signedData, Key ) )
      {
         Console::WriteLine( "The data was verified." );
      }
      else
      {
         Console::WriteLine( "The data does not match the signature." );
      }
   }
   catch ( ArgumentNullException^ ) 
   {
      Console::WriteLine( "The data was not signed or verified" );
   }

}

//</SNIPPET1>
