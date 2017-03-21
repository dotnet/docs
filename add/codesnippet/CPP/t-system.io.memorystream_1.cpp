using namespace System;
using namespace System::IO;
using namespace System::Text;

int main()
{
   int count;
   array<Byte>^byteArray;
   array<Char>^charArray;
   UnicodeEncoding^ uniEncoding = gcnew UnicodeEncoding;

   // Create the data to write to the stream.
   array<Byte>^firstString = uniEncoding->GetBytes( "Invalid file path characters are: " );
   array<Byte>^secondString = uniEncoding->GetBytes( Path::InvalidPathChars );

   MemoryStream^ memStream = gcnew MemoryStream( 100 );
   try
   {
      // Write the first string to the stream.
      memStream->Write( firstString, 0, firstString->Length );

      // Write the second string to the stream, byte by byte.
      count = 0;
      while ( count < secondString->Length )
      {
         memStream->WriteByte( secondString[ count++ ] );
      }

      
      // Write the stream properties to the console.
      Console::WriteLine( "Capacity = {0}, Length = {1}, "
      "Position = {2}\n", memStream->Capacity.ToString(), memStream->Length.ToString(), memStream->Position.ToString() );

      // Set the stream position to the beginning of the stream.
      memStream->Seek( 0, SeekOrigin::Begin );

      // Read the first 20 bytes from the stream.
      byteArray = gcnew array<Byte>(memStream->Length);
      count = memStream->Read( byteArray, 0, 20 );

      // Read the remaining bytes, byte by byte.
      while ( count < memStream->Length )
      {
         byteArray[ count++ ] = Convert::ToByte( memStream->ReadByte() );
      }
      
      // Decode the Byte array into a Char array 
      // and write it to the console.
      charArray = gcnew array<Char>(uniEncoding->GetCharCount( byteArray, 0, count ));
      uniEncoding->GetDecoder()->GetChars( byteArray, 0, count, charArray, 0 );
      Console::WriteLine( charArray );
   }
   finally
   {
      memStream->Close();
   }
}