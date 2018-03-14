
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   const int arrayLength = 1000;
   
   // Create random data to write to the stream.
   array<Byte>^dataArray = gcnew array<Byte>(arrayLength);
   (gcnew Random)->NextBytes( dataArray );
   BinaryWriter^ binWriter = gcnew BinaryWriter( gcnew MemoryStream );
   
   // Write the data to the stream.
   Console::WriteLine(  "Writing the data." );
   binWriter->Write( dataArray );
   
   // Create the reader using the stream from the writer.
   BinaryReader^ binReader = gcnew BinaryReader( binWriter->BaseStream );
   
   // Set the stream position to the beginning of the stream.
   binReader->BaseStream->Position = 0;
   
   // Read and verify the data.
   array<Byte>^verifyArray = binReader->ReadBytes( arrayLength );
   if ( verifyArray->Length != arrayLength )
   {
      Console::WriteLine( "Error writing the data." );
      return  -1;
   }

   for ( int i = 0; i < arrayLength; i++ )
   {
      if ( verifyArray[ i ] != dataArray[ i ] )
      {
         Console::WriteLine( "Error writing the data." );
         return  -1;
      }

   }
   Console::WriteLine( "The data was written and verified." );
}

// </Snippet1>
