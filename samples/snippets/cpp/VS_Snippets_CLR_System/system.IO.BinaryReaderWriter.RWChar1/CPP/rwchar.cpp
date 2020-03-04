
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   int i;
   array<Char>^invalidPathChars = Path::InvalidPathChars;
   MemoryStream^ memStream = gcnew MemoryStream;
   BinaryWriter^ binWriter = gcnew BinaryWriter( memStream );
   
   // Write to memory.
   binWriter->Write( "Invalid file path characters are: " );
   for ( i = 0; i < invalidPathChars->Length; i++ )
   {
      binWriter->Write( invalidPathChars[ i ] );

   }
   
   // Create the reader using the same MemoryStream 
   // as used with the writer.
   BinaryReader^ binReader = gcnew BinaryReader( memStream );
   
   // Set Position to the beginning of the stream.
   binReader->BaseStream->Position = 0;
   
   // Read the data from memory and write it to the console.
   Console::Write( binReader->ReadString() );
   array<Char>^memoryData = gcnew array<Char>(memStream->Length - memStream->Position);
   for ( i = 0; i < memoryData->Length; i++ )
   {
      memoryData[ i ] = binReader->ReadChar();

   }
   Console::WriteLine( memoryData );
}

// </Snippet1>
