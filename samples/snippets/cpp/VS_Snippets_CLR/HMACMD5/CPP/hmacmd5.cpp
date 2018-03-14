
//<SNIPPET1>
using namespace System;
using namespace System::IO;
using namespace System::Security::Cryptography;

// Computes a keyed hash for a source file, creates a target file with the keyed hash
// prepended to the contents of the source file, then decrypts the file and compares
// the source and the decrypted files.
void EncodeFile( array<Byte>^key, String^ sourceFile, String^ destFile )
{
   
   // Initialize the keyed hash object.
   HMACMD5^ myhmacMD5 = gcnew HMACMD5( key );
   FileStream^ inStream = gcnew FileStream( sourceFile,FileMode::Open );
   FileStream^ outStream = gcnew FileStream( destFile,FileMode::Create );
   
   // Compute the hash of the input file.
   array<Byte>^hashValue = myhmacMD5->ComputeHash( inStream );
   
   // Reset inStream to the beginning of the file.
   inStream->Position = 0;
   
   // Write the computed hash value to the output file.
   outStream->Write( hashValue, 0, hashValue->Length );
   
   // Copy the contents of the sourceFile to the destFile.
   int bytesRead;
   
   // read 1K at a time
   array<Byte>^buffer = gcnew array<Byte>(1024);
   do
   {
      
      // Read from the wrapping CryptoStream.
      bytesRead = inStream->Read( buffer, 0, 1024 );
      outStream->Write( buffer, 0, bytesRead );
   }
   while ( bytesRead > 0 );

   myhmacMD5->Clear();
   
   // Close the streams
   inStream->Close();
   outStream->Close();
   return;
} // end EncodeFile



// Decrypt the encoded file and compare to original file.
bool DecodeFile( array<Byte>^key, String^ sourceFile )
{
   
   // Initialize the keyed hash object. 
   HMACMD5^ hmacMD5 = gcnew HMACMD5( key );
   
   // Create an array to hold the keyed hash value read from the file.
   array<Byte>^storedHash = gcnew array<Byte>(hmacMD5->HashSize / 8);
   
   // Create a FileStream for the source file.
   FileStream^ inStream = gcnew FileStream( sourceFile,FileMode::Open );
   
   // Read in the storedHash.
   inStream->Read( storedHash, 0, storedHash->Length );
   
   // Compute the hash of the remaining contents of the file.
   // The stream is properly positioned at the beginning of the content, 
   // immediately after the stored hash value.
   array<Byte>^computedHash = hmacMD5->ComputeHash( inStream );
   
   // compare the computed hash with the stored value
   bool err = false;
   for ( int i = 0; i < storedHash->Length; i++ )
   {
      if ( computedHash[ i ] != storedHash[ i ] )
      {
         err = true;
      }
   }
   if (err)
        {
            Console::WriteLine("Hash values differ! Encoded file has been tampered with!");
            return false;
        }
        else
        {
            Console::WriteLine("Hash values agree -- no tampering occurred.");
            return true;
        }

} //end DecodeFile


int main()
{
   String^ usageText = "Usage: HMACMD5 inputfile.txt encryptedfile.hsh\nYou must specify the two file names. Only the first file must exist.\n";
   array<String^>^Fileargs = Environment::GetCommandLineArgs();
   
   //If no file names are specified, write usage text.
   if ( Fileargs->Length < 3 )
   {
      Console::WriteLine( usageText );
   }
   else
   {
      try
      {
         
         // Create a random key using a random number generator. This would be the
         //  secret key shared by sender and receiver.
         array<Byte>^secretkey = gcnew array<Byte>(64);
         
         //RNGCryptoServiceProvider is an implementation of a random number generator.
         RNGCryptoServiceProvider^ rng = gcnew RNGCryptoServiceProvider;
         
         // The array is now filled with cryptographically strong random bytes.
         rng->GetBytes( secretkey );
         
         // Use the secret key to encode the message file.
         EncodeFile( secretkey, Fileargs[ 1 ], Fileargs[ 2 ] );
         
         // Take the encoded file and decode
         DecodeFile( secretkey, Fileargs[ 2 ] );
      }
      catch ( IOException^ e ) 
      {
         Console::WriteLine( "Error: File not found", e );
      }

   }
} //end main


//</Snippet1>
