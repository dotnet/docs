
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   int i = 0;
   
   // Create random data to write to the stream.
   array<Byte>^writeArray = gcnew array<Byte>(1000);
   (gcnew Random)->NextBytes( writeArray );
   BinaryWriter^ binWriter = gcnew BinaryWriter( gcnew MemoryStream );
   BinaryReader^ binReader = gcnew BinaryReader( binWriter->BaseStream );
   try
   {
      
      // Write the data to the stream.
      Console::WriteLine( "Writing the data." );
      for ( i = 0; i < writeArray->Length; i++ )
      {
         binWriter->Write( writeArray[ i ] );

      }
      
      // Set the stream position to the beginning of the stream.
      binReader->BaseStream->Position = 0;
      
      // Read and verify the data from the stream.
      for ( i = 0; i < writeArray->Length; i++ )
      {
         if ( binReader->ReadByte() != writeArray[ i ] )
         {
            Console::WriteLine( "Error writing the data." );
            return  -1;
         }

      }
      Console::WriteLine( "The data was written and verified." );
   }
   // Catch the EndOfStreamException and write an error message.
   catch ( EndOfStreamException^ e ) 
   {
      Console::WriteLine( "Error writing the data.\n{0}", e->GetType()->Name );
   }

}

// </Snippet1>
