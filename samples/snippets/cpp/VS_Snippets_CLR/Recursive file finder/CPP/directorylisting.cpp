
//<Snippet1> 
// For Directory::GetFiles and Directory::GetDirectories
//<Snippet2> 
// For File::Exists, Directory::Exists
using namespace System;
using namespace System::IO;
using namespace System::Collections;

// Insert logic for processing found files here.
void ProcessFile( String^ path )
{
   Console::WriteLine( "Processed file '{0}'.", path );
}


// Process all files in the directory passed in, recurse on any directories 
// that are found, and process the files they contain.
void ProcessDirectory( String^ targetDirectory )
{
   
   // Process the list of files found in the directory.
   array<String^>^fileEntries = Directory::GetFiles( targetDirectory );
   IEnumerator^ files = fileEntries->GetEnumerator();
   while ( files->MoveNext() )
   {
      String^ fileName = safe_cast<String^>(files->Current);
      ProcessFile( fileName );
   }

   
   // Recurse into subdirectories of this directory.
   array<String^>^subdirectoryEntries = Directory::GetDirectories( targetDirectory );
   IEnumerator^ dirs = subdirectoryEntries->GetEnumerator();
   while ( dirs->MoveNext() )
   {
      String^ subdirectory = safe_cast<String^>(dirs->Current);
      ProcessDirectory( subdirectory );
   }
}

int main( int argc, char *argv[] )
{
   for ( int i = 1; i < argc; i++ )
   {
      String^ path = gcnew String(argv[ i ]);
      if ( File::Exists( path ) )
      {
         
         // This path is a file
         ProcessFile( path );
      }
      else
      if ( Directory::Exists( path ) )
      {
         
         // This path is a directory
         ProcessDirectory( path );
      }
      else
      {
         Console::WriteLine( "{0} is not a valid file or directory.", path );
      }

   }
}

//</Snippet2>
//</Snippet1>
