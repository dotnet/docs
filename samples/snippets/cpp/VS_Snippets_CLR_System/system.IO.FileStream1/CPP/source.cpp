
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   String^ fileName =  "Test@##@.dat";
   
   // Create random data to write to the file.
   array<Byte>^dataArray = gcnew array<Byte>(100000);
   (gcnew Random)->NextBytes( dataArray );
   FileStream^ fileStream = gcnew FileStream( fileName,FileMode::Create );
   try
   {
      
      // Write the data to the file, byte by byte.
      for ( int i = 0; i < dataArray->Length; i++ )
      {
         fileStream->WriteByte( dataArray[ i ] );

      }
      
      // Set the stream position to the beginning of the file.
      fileStream->Seek( 0, SeekOrigin::Begin );
      
      // Read and verify the data.
      for ( int i = 0; i < fileStream->Length; i++ )
      {
         if ( dataArray[ i ] != fileStream->ReadByte() )
         {
            Console::WriteLine( "Error writing data." );
            return  -1;
         }

      }
      Console::WriteLine( "The data was written to {0} "
      "and verified.", fileStream->Name );
   }
   finally
   {
      fileStream->Close();
   }

}

// </Snippet1>
