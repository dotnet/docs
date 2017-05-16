
//<SNIPPET1>
using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Text;
using namespace System::IO;
array<Byte>^ HashAndSignBytes( Stream^ DataStream, RSAParameters Key )
{
   try
   {
      
      // Reset the current position in the stream to 
      // the beginning of the stream (0). RSACryptoServiceProvider
      // can't verify the data unless the the stream position
      // is set to the starting position of the data.
      DataStream->Position = 0;
      
      // Create a new instance of RSACryptoServiceProvider using the 
      // key from RSAParameters.  
      RSACryptoServiceProvider^ RSAalg = gcnew RSACryptoServiceProvider;
      RSAalg->ImportParameters( Key );
      
      // Hash and sign the data. Pass a new instance of SHA1CryptoServiceProvider
      // to specify the use of SHA1 for hashing.
      return RSAalg->SignData( DataStream, gcnew SHA1CryptoServiceProvider );
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
      ASCIIEncoding^ ByteConverter = gcnew ASCIIEncoding;
      
      // Create some bytes to be signed.
      array<Byte>^dataBytes = ByteConverter->GetBytes( "Here is some data to sign!" );
      
      // Create a buffer for the memory stream.
      array<Byte>^buffer = gcnew array<Byte>(dataBytes->Length);
      
      // Create a MemoryStream.
      MemoryStream^ mStream = gcnew MemoryStream( buffer );
      
      // Write the bytes to the stream and flush it.
      mStream->Write( dataBytes, 0, dataBytes->Length );
      mStream->Flush();
      
      // Create a new instance of the RSACryptoServiceProvider class 
      // and automatically create a new key-pair.
      RSACryptoServiceProvider^ RSAalg = gcnew RSACryptoServiceProvider;
      
      // Export the key information to an RSAParameters object.
      // You must pass true to export the private key for signing.
      // However, you do not need to export the private key
      // for verification.
      RSAParameters Key = RSAalg->ExportParameters( true );
      
      // Hash and sign the data.
      array<Byte>^signedData = HashAndSignBytes( mStream, Key );
      
      // Verify the data and display the result to the 
      // console.
      if ( VerifySignedHash( dataBytes, signedData, Key ) )
      {
         Console::WriteLine( "The data was verified." );
      }
      else
      {
         Console::WriteLine( "The data does not match the signature." );
      }
      
      // Close the MemoryStream.
      mStream->Close();
   }
   catch ( ArgumentNullException^ ) 
   {
      Console::WriteLine( "The data was not signed or verified" );
   }

}

//</SNIPPET1>
