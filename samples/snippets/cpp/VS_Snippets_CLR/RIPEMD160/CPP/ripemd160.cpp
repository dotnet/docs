
//<SNIPPET1>
using namespace System;
using namespace System::IO;
using namespace System::Security::Cryptography;

// Print the byte array in a readable format.
void PrintByteArray( array<Byte>^array )
{
   int i;
   for ( i = 0; i < array->Length; i++ )
   {
      Console::Write( String::Format( "{0:X2}", array[ i ] ) );
      if ( (i % 4) == 3 )
            Console::Write( " " );

   }
   Console::WriteLine();
}

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "Usage: hashdir <directory>" );
      return 0;
   }

   try
   {
      
      // Create a DirectoryInfo object representing the specified directory.
      DirectoryInfo^ dir = gcnew DirectoryInfo( args[ 1 ] );
      
      // Get the FileInfo objects for every file in the directory.
      array<FileInfo^>^files = dir->GetFiles();
      
      // Initialize a RIPE160 hash object.
      RIPEMD160 ^ myRIPEMD160 = RIPEMD160Managed::Create();
      array<Byte>^hashValue;
      
      // Compute and print the hash values for each file in directory.
      System::Collections::IEnumerator^ myEnum = files->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         FileInfo^ fInfo = safe_cast<FileInfo^>(myEnum->Current);
         
         // Create a fileStream for the file.
         FileStream^ fileStream = fInfo->Open( FileMode::Open );
         
         // Compute the hash of the fileStream.
         hashValue = myRIPEMD160->ComputeHash( fileStream );
         
         // Write the name of the file to the Console.
         Console::Write( "{0}: ", fInfo->Name );
         
         // Write the hash value to the Console.
         PrintByteArray( hashValue );
         
         // Close the file.
         fileStream->Close();
      }
      return 0;
   }
   catch ( DirectoryNotFoundException^ ) 
   {
      Console::WriteLine( "Error: The directory specified could not be found." );
   }
   catch ( IOException^ ) 
   {
      Console::WriteLine( "Error: A file in the directory could not be accessed." );
   }

}

//</SNIPPET1>
