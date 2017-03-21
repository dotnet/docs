using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Collections;
using namespace System::Text;

ref class Members
{
private:

   // Use a public service provider for encryption and decryption.
   static DESCryptoServiceProvider^ des = gcnew DESCryptoServiceProvider;

public:
   [STAThread]
   static void Main()
   {
      String^ message = L"012345678901234567890";
      array<Byte>^sourceBytes = Encoding::ASCII->GetBytes( message );
      Console::WriteLine( L"** Phrase to be encoded: {0}", message );
      array<Byte>^encodedBytes = EncodeBytes( sourceBytes );
      Console::WriteLine( L"** Phrase after encoding: {0}",
         Encoding::ASCII->GetString( encodedBytes ) );
      array<Byte>^decodedBytes = DecodeBytes( encodedBytes );
      Console::WriteLine( L"** Phrase after decoding: {0}",
         Encoding::ASCII->GetString( decodedBytes ) );
      Console::WriteLine( L"Sample ended successfully; "
      L"press Enter to continue." );
      Console::ReadLine();
   }

private:
   // Encode the specified byte array by using CryptoAPITranform.
   static array<Byte>^ EncodeBytes( array<Byte>^sourceBytes )
   {
      int currentPosition = 0;
      array<Byte>^targetBytes = gcnew array<Byte>(1024);
      int sourceByteLength = sourceBytes->Length;
      
      // Create a DES encryptor from this instance to perform encryption.
      CryptoAPITransform^ cryptoTransform =
         static_cast<CryptoAPITransform^>(des->CreateEncryptor());
      
      // Retrieve the block size to read the bytes.
      int inputBlockSize = cryptoTransform->InputBlockSize;

      // Retrieve the key handle.
      IntPtr keyHandle = cryptoTransform->KeyHandle;

      // Retrieve the block size to write the bytes.
      int outputBlockSize = cryptoTransform->OutputBlockSize;

      try
      {
         // Determine if multiple blocks can be transformed.
         if ( cryptoTransform->CanTransformMultipleBlocks )
         {
            int numBytesRead = 0;
            while ( sourceByteLength - currentPosition >= inputBlockSize )
            {
               // Transform the bytes from currentPosition in the
               // sourceBytes array, writing the bytes to the targetBytes
               // array.
               numBytesRead = cryptoTransform->TransformBlock(
                  sourceBytes, currentPosition, inputBlockSize,
                  targetBytes, currentPosition );
               // Advance the current position in the sourceBytes array.
               currentPosition += numBytesRead;
            }
            
            // Transform the final block of bytes.
            array<Byte>^finalBytes = cryptoTransform->TransformFinalBlock(
               sourceBytes, currentPosition, sourceByteLength - currentPosition );

            // Copy the contents of the finalBytes array to the
            // targetBytes array.
            finalBytes->CopyTo( targetBytes, currentPosition );
         }
      }
      catch ( Exception^ ex ) 
      {
         Console::WriteLine( L"Caught unexpected exception:{0}", ex );
      }
      
      // Determine if the current transform can be reused.
      if (  !cryptoTransform->CanReuseTransform )
      {
         // Free up any used resources.
         cryptoTransform->Clear();
      }

      // Trim the extra bytes in the array that were not used.
      return TrimArray( targetBytes );
   }

   // Decode the specified byte array using CryptoAPITranform.
   static array<Byte>^ DecodeBytes( array<Byte>^sourceBytes )
   {
      array<Byte>^targetBytes = gcnew array<Byte>(1024);
      int currentPosition = 0;
      
      // Create a DES decryptor from this instance to perform decryption.
      CryptoAPITransform^ cryptoTransform =
         static_cast<CryptoAPITransform^>(des->CreateDecryptor());
      int inputBlockSize = cryptoTransform->InputBlockSize;
      int sourceByteLength = sourceBytes->Length;
      try
      {
         int numBytesRead = 0;
         while ( sourceByteLength - currentPosition >= inputBlockSize )
         {
            // Transform the bytes from currentposition in the 
            // sourceBytes array, writing the bytes to the targetBytes
            // array.
            numBytesRead = cryptoTransform->TransformBlock(
               sourceBytes, currentPosition, inputBlockSize,
               targetBytes, currentPosition );
            
            // Advance the current position in the source array.
            currentPosition += numBytesRead;
         }
         
         // Transform the final block of bytes.
         array<Byte>^finalBytes = cryptoTransform->TransformFinalBlock(
            sourceBytes, currentPosition, sourceByteLength - currentPosition );
         
         // Copy the contents of the finalBytes array to the targetBytes
         // array.
         finalBytes->CopyTo( targetBytes, currentPosition );
      }
      catch ( Exception^ ex ) 
      {
         Console::WriteLine( L"Caught unexpected exception:{0}", ex );
      }

      // Strip out the second block of bytes.
      Array::Copy(targetBytes, (inputBlockSize * 2), targetBytes, inputBlockSize, targetBytes->Length - (inputBlockSize * 2));

      
      // Trim the extra bytes in the array that were not used.
      return TrimArray( targetBytes );
   }

   // Resize the dimensions of the array to a size that contains only valid
   // bytes.
   static array<Byte>^ TrimArray( array<Byte>^targetArray )
   {
      IEnumerator^ enum1 = targetArray->GetEnumerator();
      int i = 0;
      while ( enum1->MoveNext() )
      {
         if ( enum1->Current->ToString()->Equals( L"0" ) )
         {
            break;
         }
         i++;
      }

      // Create a new array with the number of valid bytes.
      array<Byte>^returnedArray = gcnew array<Byte>(i);
      for ( int j = 0; j < i; j++ )
      {
         returnedArray[ j ] = targetArray[ j ];
      }
      return returnedArray;
   }
};

int main()
{
   Members::Main();
}

//
// This sample produces the following output:
//
// ** Phrase to be encoded: 012345678901234567890
// ** Phrase after encoding: AIGC(+b7X?^djAU?15ve?o
// ** Phrase after decoding: 012345678901234567890
// Sample ended successfully; press Enter to continue.