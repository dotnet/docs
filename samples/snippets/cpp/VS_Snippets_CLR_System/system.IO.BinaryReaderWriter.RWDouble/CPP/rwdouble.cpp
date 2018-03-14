
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   int i;
   const int arrayLength = 1000;
   
   // Create random data to write to the stream.
   array<double>^dataArray = gcnew array<double>(arrayLength);
   Random^ randomGenerator = gcnew Random;
   for ( i = 0; i < arrayLength; i++ )
   {
      dataArray[ i ] = 100.1 * randomGenerator->NextDouble();

   }
   BinaryWriter^ binWriter = gcnew BinaryWriter( gcnew MemoryStream );
   try
   {
      
      // Write data to the stream.
      Console::WriteLine( "Writing data to the stream." );
      i = 0;
      for ( i = 0; i < arrayLength; i++ )
      {
         binWriter->Write( dataArray[ i ] );

      }
      
      // Create a reader using the stream from the writer.
      BinaryReader^ binReader = gcnew BinaryReader( binWriter->BaseStream );
      
      // Return to the beginning of the stream.
      binReader->BaseStream->Position = 0;
      try
      {
         
         // Read and verify the data.
         i = 0;
         Console::WriteLine( "Verifying the written data." );
         for ( i = 0; i < arrayLength; i++ )
         {
            if ( binReader->ReadDouble() != dataArray[ i ] )
            {
               Console::WriteLine( "Error writing data." );
               break;
            }

         }
         Console::WriteLine( "The data was written and verified." );
      }
      catch ( EndOfStreamException^ e ) 
      {
         Console::WriteLine( "Error writing data: {0}.", e->GetType()->Name );
      }

   }
   finally
   {
      binWriter->Close();
   }

}

// </Snippet1>
