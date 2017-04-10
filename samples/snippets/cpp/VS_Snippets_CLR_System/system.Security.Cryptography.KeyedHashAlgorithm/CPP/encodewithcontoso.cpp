// This sample class demonstrates how to use the ContosoKeyedHash class to
// compute Hash
//<Snippet21>
#using <System.dll>
#using "contosokeyedhash.dll"
using namespace Contoso;
using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Collections;
using namespace System::Security::Cryptography;

namespace Contoso
{
   ref class EncodeWithContoso
   {
   public:
      [STAThread]
      static void Main()
      {
         EncodeMessage();
         EncodeStream();
         Console::WriteLine( L"This sample completed successfully; "
         L"press Enter to exit" );
         Console::ReadLine();
      }

   private:
      // Compute the hash for a ContosoKeyedHash that has transformed a
      // file stream.
      static void EncodeStream()
      {
         //<Snippet4>
         array<Byte>^keyData = gcnew array<Byte>(24);
         RandomNumberGenerator::Create()->GetBytes( keyData );
         ContosoKeyedHash^ localCrypto = gcnew ContosoKeyedHash( keyData );
         //</Snippet4>

         String^ filePath = (String::Concat(
            System::IO::Directory::GetCurrentDirectory(), L"\\members.txt" ));
         try
         {
            //<Snippet14>
            FileStream^ fileStream = gcnew FileStream(
               filePath,FileMode::Open,FileAccess::Read );
            localCrypto->ComputeHash( fileStream );
            //</Snippet14>

            SummarizeMAC( localCrypto,
               L"ContosoKeyedHash after encoding a file stream." );
         }
         catch ( FileNotFoundException^ ) 
         {
            Console::WriteLine( L"The specified path was not found: {0}", filePath );
         }
      }

      // Compute the hash for a ContosoKeyedHash that has transformed
      // a byte array.
      static void EncodeMessage()
      {
         array<Byte>^ keyData = gcnew array<Byte>(24);
         RandomNumberGenerator::Create()->GetBytes( keyData );
         ContosoKeyedHash^ localCrypto = gcnew ContosoKeyedHash( keyData );
         
         //<Snippet13>
         String^ message = L"Hello World.";
         array<Byte>^ encodedMessage = EncodeBytes(
            Encoding::ASCII->GetBytes( message ) );
         localCrypto->ComputeHash( encodedMessage );
         
         //</Snippet13>
         SummarizeMAC( localCrypto, L"ContosoKeyedHash after encoding a message." );
      }


      // Transform the byte array using ContosoKeyedHash,
      // then summarize its properties.
      static array<Byte>^ EncodeBytes( array<Byte>^ sourceBytes )
      {
         int currentPosition = 0;
         array<Byte>^targetBytes = gcnew array<Byte>(1024);
         int sourceByteLength = sourceBytes->Length;
         
         // Create an encryptor with a random key and the
         // KeyedHashAlgorithm class name.
         array<Byte>^ key = gcnew array<Byte>(24);
         RandomNumberGenerator::Create()->GetBytes( key );
         String^ keyedHashName = L"System.Security.Cryptography.KeyedHashAlgorithm";
         ContosoKeyedHash^ localCrypto = gcnew ContosoKeyedHash( keyedHashName,key );
         
         // Retrieve the block size to read the bytes.
         //<Snippet9>
         int inputBlockSize = localCrypto->InputBlockSize;
         //</Snippet9>

         try
         {
            // Determine if multiple blocks can be transformed.
            //<Snippet6>
            if ( localCrypto->CanTransformMultipleBlocks )
            //</Snippet6>
            {
               int numBytesRead = 0;
               while ( sourceByteLength - currentPosition >= inputBlockSize )
               {
                  // Transform the bytes from the currentposition in the
                  // sourceBytes array, writing the bytes to the
                  // targetBytes array.
                  //<Snippet18>
                  numBytesRead = localCrypto->TransformBlock(
                     sourceBytes,
                     currentPosition,
                     inputBlockSize,
                     targetBytes,
                     currentPosition );
                  //</Snippet18>

                  // Advance the current position in the source array.
                  currentPosition += numBytesRead;
               }
               
               // Transform the final block of bytes.
               //<Snippet19>
               array<Byte>^ finalBytes = localCrypto->TransformFinalBlock(
                  sourceBytes,
                  currentPosition,
                  sourceByteLength - currentPosition );
               //</Snippet19>

               // Copy the contents of the finalBytes array to the
               // targetBytes array.
               finalBytes->CopyTo( targetBytes, currentPosition );
            }
         }
         catch ( Exception^ ex ) 
         {
            Console::WriteLine( L"Caught unexpected exception:{0}",
               ex->ToString() );
         }
         
         // Find the length of valid bytes (those without zeros).
         //<Snippet15>
         IEnumerator^ enum1 = targetBytes->GetEnumerator();
         int i = 0;
         while ( enum1->MoveNext() )
         {
            if ( enum1->Current->ToString()->Equals( L"0" ) )
            {
               break;
            }

            i++;
         }
         
         // Compute the hash based on the valid bytes in the array.
         localCrypto->ComputeHash( targetBytes, 0, i );
         //</Snippet15>

         SummarizeMAC( localCrypto, L"ContosoKeyedHash after computing "
         L"hash for specified region of byte array" );
         
         //<Snippet5>
         // Determine if the current transform can be reused.
         if (  !localCrypto->CanReuseTransform )
         //</Snippet5>
         {
            // Free up any used resources.
            //<Snippet12>
            localCrypto->Clear();
            //</Snippet12>

            //<Snippet16>
            localCrypto->Initialize();
            //</Snippet16>
         }
         
         // Create a new array with the number of valid bytes.
         array<Byte>^returnedArray = gcnew array<Byte>(i);
         for ( int j = 0; j < i; j++ )
         {
            returnedArray[ j ] = targetBytes[ j ];

         }
         return returnedArray;
      }

      // Write a summary of the specified ContosoKeyedHash to the
      // console window.
      static void SummarizeMAC( ContosoKeyedHash^ localCrypto,
         String^ description )
      {
         //<Snippet20>
         String^ classDescription = localCrypto->ToString();
         //</Snippet20>

         //<Snippet7>
         array<Byte>^computedHash = localCrypto->Hash;
         //</Snippet7>

         //<Snippet8>
         int hashSize = localCrypto->HashSize;
         //</Snippet8>

         //<Snippet11>
         int outputBlockSize = localCrypto->OutputBlockSize;
         //</Snippet11>

         // Retrieve the key used in the hash algorithm.
         //<Snippet10>
         array<Byte>^key = localCrypto->Key;
         //</Snippet10>

         Console::WriteLine( L"\n**********************************" );
         Console::WriteLine( classDescription );
         Console::WriteLine( description );
         Console::WriteLine( L"----------------------------------" );
         Console::WriteLine( L"The size of the computed hash : {0}",
            hashSize );
         Console::WriteLine( L"The key used in the hash algorithm : {0}",
            Encoding::ASCII->GetString( key ) );
         Console::WriteLine( L"The value of the computed hash : {0}",
            Encoding::ASCII->GetString( computedHash ) );
      }
   };
}

int main()
{
   EncodeWithContoso::Main();
}
//</Snippet21>

