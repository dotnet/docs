
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   array<Char>^invalidPathChars = Path::InvalidPathChars;
   MemoryStream^ memStream = gcnew MemoryStream;
   BinaryWriter^ binWriter = gcnew BinaryWriter( memStream );
   
   // Write to memory.
   binWriter->Write( "Invalid file path characters are: " );
   binWriter->Write( Path::InvalidPathChars, 0, Path::InvalidPathChars->Length );
   
   // Create the reader using the same MemoryStream 
   // as used with the writer.
   BinaryReader^ binReader = gcnew BinaryReader( memStream );
   
   // Set Position to the beginning of the stream.
   binReader->BaseStream->Position = 0;
   
   // Read the data from memory and write it to the console.
   Console::Write( binReader->ReadString() );
   int arraySize = (int)(memStream->Length - memStream->Position);
   array<Char>^memoryData = gcnew array<Char>(arraySize);
   binReader->Read( memoryData, 0, arraySize );
   Console::WriteLine( memoryData );
}

// </Snippet1>
